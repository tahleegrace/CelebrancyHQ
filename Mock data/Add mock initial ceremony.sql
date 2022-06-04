USE CelebrancyHQ;

/* Mock persons. */
INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Joseph', 'Biden', 'joebidentest@celebrancyhq.co', 'M', 'Joe', 'Mr', '1942-11-20', GETUTCDATE(), GETUTCDATE())

DECLARE @JoeBidenId INT
SET @JoeBidenId = SCOPE_IDENTITY()

INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Jill', 'Biden', 'jillbidentest@celebrancyhq.co', 'F', 'Jill', 'Mrs', '1951-06-03', GETUTCDATE(), GETUTCDATE())

DECLARE @JillBidenId INT
SET @JillBidenId = SCOPE_IDENTITY()

/* Mock ceremony. */
INSERT INTO Ceremonies (Name, CeremonyDate, CeremonyTypeId, Created, Updated)
VALUES ('Marriage of Joseph and Jill Biden', '2022-06-06', 1, GETUTCDATE(), GETUTCDATE())

DECLARE @CeremonyId INT
SET @CeremonyId = SCOPE_IDENTITY()

/* Mock participants. */

/* Celebrant. */
INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, 1, 1, GETUTCDATE(), GETUTCDATE())

/* Joe Biden. */
INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @JoeBidenId, 3, GETUTCDATE(), GETUTCDATE())

/* Jill Biden. */
INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @JillBidenId, 3, GETUTCDATE(), GETUTCDATE())