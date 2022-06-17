using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Persons
{
    /// <summary>
    /// The person phone numbers repository.
    /// </summary>
    public class PersonPhoneNumberRepository : IPersonPhoneNumberRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of OrganisationPhoneNumberRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PersonPhoneNumberRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the primary phone numbers for the participants in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The primary phone numbers for the participants in the specified ceremony.</returns>
        public async Task<Dictionary<int, PersonPhoneNumber>> GetPrimaryPhoneNumbersForCeremonyParticipants(int ceremonyId)
        {
            var personIds = await this._context.CeremonyParticipants.Where(cp => cp.CeremonyId == ceremonyId && !cp.Deleted)
                                                                    .Select(cp => cp.PersonId)
                                                                    .ToListAsync();

            return await this._context.PersonPhoneNumbers.Where(pp => personIds.Contains(pp.PersonId) && !pp.Deleted && pp.IsPrimary)
                                                         .ToDictionaryAsync(pp => pp.PersonId, pp => pp);
        }

        /// <summary>
        /// Creates new phone numbers for a person.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <returns>The newly created phone numbers.</returns>
        public async Task<List<PersonPhoneNumber>> Create(List<PersonPhoneNumber> phoneNumbers)
        {
            if (phoneNumbers == null || phoneNumbers.Count == 0)
            {
                return new List<PersonPhoneNumber>();
            }

            foreach (var phoneNumber in phoneNumbers)
            {
                phoneNumber.Created = DateTime.UtcNow;
                phoneNumber.Updated = DateTime.UtcNow;

                this._context.PersonPhoneNumbers.Add(phoneNumber);
            }

            await this._context.SaveChangesAsync();

            return phoneNumbers;
        }
    }
}