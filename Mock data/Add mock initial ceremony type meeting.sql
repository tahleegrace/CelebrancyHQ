/* Mock ceremony type meeting. */
DECLARE @CeremonyTypeID INT
SET @CeremonyTypeID = 1

DECLARE @CeremonyTypeMeetingID INT

/*INSERT INTO CeremonyTypeMeetings (CeremonyTypeId, TemplateId, Name, Code, Description, OrganisationId, Created, Updated, Deleted)
VALUES (@CeremonyTypeID, NULL, 'Test Ceremony Type Meeting', 'TestMeeting', 'A test ceremony type meeting', NULL, GETUTCDATE(), GETUTCDATE(), 0)*/

/*SET @CeremonyTypeMeetingID = SCOPE_IDENTITY()*/
SET @CeremonyTypeMeetingID = 1

/* Text question. */
INSERT INTO CeremonyTypeMeetingQuestions (CeremonyTypeMeetingId, QuestionTypeId, Question, Description, Options, Required, Created, Updated, Deleted)
VALUES (@CeremonyTypeMeetingID, 1, 'What is your ideal party or ceremony?', NULL, NULL, 1, GETUTCDATE(), GETUTCDATE(), 0)

/* Dropdown question. */
INSERT INTO CeremonyTypeMeetingQuestions (CeremonyTypeMeetingId, QuestionTypeId, Question, Description, Options, Required, Created, Updated, Deleted)
VALUES (@CeremonyTypeMeetingID, 2, 'What type of ceremony would you prefer?', NULL, '"Elaborate";"Simple"', 1, GETUTCDATE(), GETUTCDATE(), 0)

/* Checkboxes question. */
INSERT INTO CeremonyTypeMeetingQuestions (CeremonyTypeMeetingId, QuestionTypeId, Question, Description, Options, Required, Created, Updated, Deleted)
VALUES (@CeremonyTypeMeetingID, 3, 'What drinks will be provided?', NULL, '"Crows Nest Musk";"Saxbys Snazberry","Cooks Orange"', 1, GETUTCDATE(), GETUTCDATE(), 0)

/* Image question. */
INSERT INTO CeremonyTypeMeetingQuestions (CeremonyTypeMeetingId, QuestionTypeId, Question, Description, Options, Required, Created, Updated, Deleted)
VALUES (@CeremonyTypeMeetingID, 4, 'Provide one or more photos of the venue.', NULL, NULL, 1, GETUTCDATE(), GETUTCDATE(), 0)

/* File question. */
INSERT INTO CeremonyTypeMeetingQuestions (CeremonyTypeMeetingId, QuestionTypeId, Question, Description, Options, Required, Created, Updated, Deleted)
VALUES (@CeremonyTypeMeetingID, 5, 'Provide a signed contract of service.', NULL, NULL, 1, GETUTCDATE(), GETUTCDATE(), 0)