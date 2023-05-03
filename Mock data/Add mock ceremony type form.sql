/* Mock ceremony type form. */
DECLARE @CeremonyTypeId INT
SET @CeremonyTypeId = 1

DECLARE @CeremonyTypeFormId INT

INSERT INTO CeremonyTypeForms (CeremonyTypeId, TemplateId, Name, Code, Description, OrganisationId, Created, Updated, Deleted)
VALUES (@CeremonyTypeId, NULL, 'Test Ceremony Type Form', 'TestForm', 'A test ceremony type form', NULL, GETUTCDATE(), GETUTCDATE(), 0)