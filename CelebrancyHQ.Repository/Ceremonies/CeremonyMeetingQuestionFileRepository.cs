using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony meeting question files repository.
    /// </summary>
    public class CeremonyMeetingQuestionFileRepository : ICeremonyMeetingQuestionFileRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionFileRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyMeetingQuestionFileRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the ceremony meeting question file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The ceremony meeting question file with the specified ID.</returns>
        public async Task<CeremonyMeetingQuestionFile?> FindById(int id)
        {
            return await this._context.CeremonyMeetingQuestionFiles.Include(cmqf => cmqf.File)
                                                                   .Include(cmqf => cmqf.File.File)
                                                                   .Where(cmqf => cmqf.Id == id && !cmqf.Deleted)
                                                                   .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the ceremony meeting question files for the specified question.
        /// </summary>
        /// <param name="questionId">The ID of the question.</param>
        /// <returns>The ceremony meeting question files for the specified question.</returns>
        public async Task<List<CeremonyMeetingQuestionFile>> GetQuestionFiles(int questionId)
        {
            return await this._context.CeremonyMeetingQuestionFiles.Include(cmqf => cmqf.File)
                                                                   .Include(cmqf => cmqf.File.File)
                                                                   .Where(cmqf => cmqf.QuestionId == questionId && !cmqf.Deleted)
                                                                   .ToListAsync();
        }

        /// <summary>
        /// Creates a new ceremony meeting question file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created ceremony meeting question file.</returns>
        public async Task<CeremonyMeetingQuestionFile> Create(CeremonyMeetingQuestionFile file)
        {
            file.Created = DateTime.UtcNow;
            file.Updated = DateTime.UtcNow;

            this._context.CeremonyMeetingQuestionFiles.Add(file);

            await this._context.SaveChangesAsync();

            var newFile = await FindById(file.Id);
            return newFile;
        }
    }
}