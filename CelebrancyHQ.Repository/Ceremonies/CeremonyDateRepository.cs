using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony date repository.
    /// </summary>
    public class CeremonyDateRepository : ICeremonyDateRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyDateRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyDateRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the dates for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The dates for the specified ceremony.</returns>
        public async Task<List<CeremonyDate>> GetCeremonyDates(int ceremonyId)
        {
            return await this._context.CeremonyDates.Include(cd => cd.CeremonyTypeDate)
                                                    .Where(cd => cd.CeremonyId == ceremonyId && !cd.Deleted)
                                                    .ToListAsync();
        }

        /// <summary>
        /// Gets the ceremony date with the specified ID.
        /// </summary>
        /// <param name="ceremonyDateId">The ID of the ceremony date.</param>
        /// <returns>The ceremony date with the specified ID.</returns>
        public async Task<CeremonyDate?> FindById(int ceremonyDateId)
        {
            return await this._context.CeremonyDates.Include(cd => cd.CeremonyTypeDate)
                                                    .Where(cd => cd.Id == ceremonyDateId && !cd.Deleted)
                                                    .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new ceremony date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The newly created ceremony date.</returns>
        public async Task<CeremonyDate> Create(CeremonyDate date)
        {
            date.Created = DateTime.UtcNow;
            date.Updated = DateTime.UtcNow;

            this._context.CeremonyDates.Add(date);

            await this._context.SaveChangesAsync();

            var newDate = await FindById(date.Id);
            return newDate;
        }

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        public async Task Update(CeremonyDate date)
        {
            date.Updated = DateTime.UtcNow;
            this._context.Entry(date).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
    }
}