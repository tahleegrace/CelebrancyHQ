using AutoMapper;

using CelebrancyHQ.Auditing.Persons;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Persons;
using CelebrancyHQ.Models.Exceptions.Persons;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.Addresses;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Persons
{
    /// <summary>
    /// Provides functionality for managing persons.
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonPhoneNumberRepository _personPhoneNumberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonAuditingService _personAuditingService;
        private readonly IPersonAddressAuditingService _personAddressAuditingService;
        private readonly IPersonPhoneNumberAuditingService _personPhoneNumberAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of PersonService.
        /// </summary>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="personPhoneNumberRepository">The person phone number repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="addressRepository">The address repository.</param>
        /// <param name="personAuditingService">The person auditing service.</param>
        /// <param name="personAddressAuditingService">The person address auditing service.</param>
        /// <param name="personPhoneNumberAuditingService">The person phone number auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public PersonService(IPersonRepository personRepository, IPersonPhoneNumberRepository personPhoneNumberRepository, 
            IUserRepository userRepository, IAddressRepository addressRepository, IPersonAuditingService personAuditingService, 
            IPersonAddressAuditingService personAddressAuditingService, IPersonPhoneNumberAuditingService personPhoneNumberAuditingService, IMapper mapper)
        {
            this._personRepository = personRepository;
            this._personPhoneNumberRepository = personPhoneNumberRepository;
            this._userRepository = userRepository;
            this._addressRepository = addressRepository;
            this._personAuditingService = personAuditingService;
            this._personAddressAuditingService = personAddressAuditingService;
            this._personPhoneNumberAuditingService = personPhoneNumberAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Updates the details of the specified person.
        /// </summary>
        /// <param name="request">The person.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Update(UpdatePersonRequest request, int currentUserId)
        {
            // Make sure the person has been provided and has an ID.
            if ((request == null) || (request.PersonId <= 0))
            {
                throw new PersonNotProvidedException();
            }

            // Get the current user.
            var currentUser = await this._userRepository.FindById(currentUserId);

            if (currentUser == null)
            {
                throw new UserNotFoundException(currentUserId);
            }

            // Make sure a person exists with the specified ID.
            var existingPerson = await this._personRepository.FindById(request.PersonId);

            if (existingPerson == null)
            {
                throw new PersonNotFoundException(request.PersonId);
            }

            // Make sure the email address is not used by another person.
            if (existingPerson.EmailAddress != request.EmailAddress)
            {
                var personExistsWithEmailAddress = await this._personRepository.PersonExistsWithEmailAddress(request.EmailAddress);

                if (personExistsWithEmailAddress)
                {
                    throw new PersonAlreadyExistsWithEmailAddressException(request.EmailAddress);
                }
            }

            // Generate audit events for the person.
            var auditEvents = this._personAuditingService.GenerateAuditEvents(existingPerson, this._mapper.Map<Person>(request));

            // Save the address of the person.
            if (request.Address != null)
            {
                // Generate audit logs for the address.
                var addressAuditEvents = this._personAddressAuditingService.GenerateAuditEvents(existingPerson.Address, this._mapper.Map<Address>(request.Address));

                Address addressToUpdate = existingPerson.Address ?? new Address();
                this._mapper.Map(request.Address, addressToUpdate);

                if (existingPerson.Address == null)
                {
                    await this._addressRepository.Create(addressToUpdate);
                    existingPerson.AddressId = addressToUpdate.Id;

                    addressAuditEvents = this._personAddressAuditingService.GenerateAuditEvents(null, addressToUpdate);
                }
                else
                {
                    await this._addressRepository.Update(addressToUpdate);
                }

                // Save the audit logs for the address.
                await this._personAddressAuditingService.SaveAuditEvents(addressToUpdate, existingPerson, currentUser.PersonId, addressAuditEvents);
            }

            // Save the person.
            this._mapper.Map(request, existingPerson);
            await this._personRepository.Update(existingPerson);

            // Save the phone numbers for the person.
            if (request.PhoneNumbers != null)
            {
                var existingPhoneNumbers = await this._personPhoneNumberRepository.GetPhoneNumbersForPerson(existingPerson.Id);

                var existingPhoneNumberIds = existingPhoneNumbers.Select(p => p.Id).ToList();
                var newPhoneNumbers = request.PhoneNumbers.Where(p => p.Id == null).ToList();
                var updatedPhoneNumbers = request.PhoneNumbers.Where(p => p.Id != null).ToList();
                var updatedPhoneNumberIds = updatedPhoneNumbers.Select(p => p.Id).ToList();
                var deletedPhoneNumbers = existingPhoneNumbers.Where(p => !updatedPhoneNumberIds.Contains(p.Id)).ToList();

                // Save any new phone numbers.
                var phoneNumbersToCreate = this._mapper.Map<List<PersonPhoneNumber>>(newPhoneNumbers);

                foreach (var phoneNumber in phoneNumbersToCreate)
                {
                    phoneNumber.PersonId = existingPerson.Id;
                }

                await this._personPhoneNumberRepository.Create(phoneNumbersToCreate);

                // Save any updated phone numbers.
                var phoneNumbersToUpdate = existingPhoneNumbers.Where(p => updatedPhoneNumberIds.Contains(p.Id)).ToList();

                foreach(var existingPhoneNumber in phoneNumbersToUpdate)
                {
                    var newPhoneNumber = updatedPhoneNumbers.Where(p => p.Id == existingPhoneNumber.Id).FirstOrDefault();
                    var phoneNumberAuditEvents = this._personPhoneNumberAuditingService.GenerateAuditEvents(existingPhoneNumber, this._mapper.Map<PersonPhoneNumber>(newPhoneNumber));

                    this._mapper.Map(newPhoneNumber, existingPhoneNumber);

                    await this._personPhoneNumberAuditingService.SaveAuditEvents(existingPhoneNumber, existingPerson, currentUser.Person.Id, phoneNumberAuditEvents);
                }

                await this._personPhoneNumberRepository.Update(phoneNumbersToUpdate);

                // Delete any deleted phone numbers.
                await this._personPhoneNumberRepository.Delete(deletedPhoneNumbers);

                // Generate and save audit logs for the new phone numbers.
                foreach (var phoneNumber in phoneNumbersToCreate)
                {
                    var phoneNumberAuditEvents = this._personPhoneNumberAuditingService.GenerateAuditEvents(null, phoneNumber);
                    await this._personPhoneNumberAuditingService.SaveAuditEvents(phoneNumber, existingPerson, currentUser.Person.Id, phoneNumberAuditEvents);
                }

                // Generate and save audit logs for the deleted phone numbers.
                foreach (var phoneNumber in deletedPhoneNumbers)
                {
                    var phoneNumberAuditEvents = this._personPhoneNumberAuditingService.GenerateAuditEvents(phoneNumber, null);
                    await this._personPhoneNumberAuditingService.SaveAuditEvents(phoneNumber, existingPerson, currentUser.Person.Id, phoneNumberAuditEvents);
                }
            }

            // Save the audit logs for the person.
            await this._personAuditingService.SaveAuditEvents(existingPerson, currentUser.PersonId, auditEvents);
        }
    }
}