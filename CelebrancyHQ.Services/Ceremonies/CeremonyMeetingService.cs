using AutoMapper;

using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony meetings.
    /// </summary>
    public class CeremonyMeetingService : ICeremonyMeetingService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly ICeremonyTypeMeetingRepository _ceremonyTypeMeetingRepository;
        private readonly ICeremonyMeetingRepository _ceremonyMeetingRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="ceremonyTypeMeetingRepository">The ceremony type meeting repository.</param>
        /// <param name="ceremonyMeetingRepository">The ceremony meeting repository.</param>
        /// <param name="mapper">The mappers.</param>
        public CeremonyMeetingService(ICeremonyHelpers ceremonyHelpers, ICeremonyTypeMeetingRepository ceremonyTypeMeetingRepository, 
            ICeremonyMeetingRepository ceremonyMeetingRepository, IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._ceremonyTypeMeetingRepository = ceremonyTypeMeetingRepository;
            this._ceremonyMeetingRepository = ceremonyMeetingRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Creates a new ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created ceremony meeting.</returns>
        public async Task<CeremonyMeetingDTO> Create(CreateCeremonyMeetingRequest meeting, int ceremonyId, int currentUserId)
        {
            if (meeting == null)
            {
                throw new CeremonyMeetingNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to add the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Make sure a ceremony type meeting exists with the specified ID.
            var ceremonyTypeMeeting = await this._ceremonyTypeMeetingRepository.FindById(meeting.CeremonyTypeMeetingId);

            if (ceremonyTypeMeeting == null)
            {
                throw new CeremonyTypeMeetingNotFoundException(meeting.CeremonyTypeMeetingId);
            }

            // Save the meeting.
            var meetingToCreate = this._mapper.Map<CeremonyMeeting>(meeting);
            meetingToCreate.CeremonyId = ceremonyId;
            meetingToCreate.CeremonyTypeMeetingId = meeting.CeremonyTypeMeetingId;

            var newMeeting = await this._ceremonyMeetingRepository.Create(meetingToCreate);

            // TODO: Create questions for the meeting.
            // TODO: Generate audit logs for the meeting.

            return this._mapper.Map<CeremonyMeetingDTO>(newMeeting);
        }
    }
}