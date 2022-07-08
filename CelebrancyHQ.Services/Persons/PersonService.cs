using AutoMapper;

using CelebrancyHQ.Auditing.Persons;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Persons;
using CelebrancyHQ.Models.Exceptions.Persons;
using CelebrancyHQ.Models.Exceptions.Users;
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
        private readonly IUserRepository _userRepository;
        private readonly IPersonAuditingService _personAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of PersonService.
        /// </summary>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="personAuditingService">The person auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public PersonService(IPersonRepository personRepository, IUserRepository userRepository, IPersonAuditingService personAuditingService, IMapper mapper)
        {
            this._personRepository = personRepository;
            this._userRepository = userRepository;
            this._personAuditingService = personAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Updates the details of the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Update(UpdatePersonRequest person, int currentUserId)
        {
            // Make sure the person has been provided and has an ID.
            if ((person == null) || (person.PersonId <= 0))
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
            var existingPerson = await this._personRepository.FindById(person.PersonId);

            if (existingPerson == null)
            {
                throw new PersonNotFoundException(person.PersonId);
            }

            // Make sure the email address is not used by another person.
            if (existingPerson.EmailAddress != person.EmailAddress)
            {
                var personExistsWithEmailAddress = await this._personRepository.PersonExistsWithEmailAddress(person.EmailAddress);

                if (personExistsWithEmailAddress)
                {
                    throw new PersonAlreadyExistsWithEmailAddressException(person.EmailAddress);
                }
            }

            // Generate audit events for the person.
            var auditEvents = this._personAuditingService.GenerateAuditEvents(existingPerson, this._mapper.Map<Person>(person));

            // Save the person.
            this._mapper.Map(person, existingPerson);
            await this._personRepository.Update(existingPerson);

            // TODO: Update the address for the person here.
            // TODO: Update the phone numbers for the person here.

            // Save the audit logs for the person.
            await this._personAuditingService.SaveAuditEvents(existingPerson, currentUser.PersonId, auditEvents);
        }
    }
}