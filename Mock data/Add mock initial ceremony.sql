USE CelebrancyHQ;

/*INSERT INTO PersonPhoneNumbers (PersonId, Type, IsPrimary, PhoneNumber, Created, Updated, Deleted)
VALUES (1, 'Mobile', 1, '0472581931', GETUTCDATE(), GETUTCDATE(), 0)*/

/* Mock persons. */
/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Joseph', 'Biden', 'joebidentest@celebrancyhq.co', 'M', 'Joe', 'Mr', '1942-11-20', GETUTCDATE(), GETUTCDATE())*/

DECLARE @JoeBidenId INT
/*SET @JoeBidenId = SCOPE_IDENTITY()*/
SET @JoeBidenId = 2

/*INSERT INTO Users (EmailAddress, PasswordHash, PasswordSalt, PersonId, Created, Updated)
VALUES ('joebidentest@celebrancyhq.co', 'joebiden', 'testsalt', @JoeBidenId, GETUTCDATE(), GETUTCDATE())*/

/*INSERT INTO PersonPhoneNumbers (PersonId, Type, IsPrimary, PhoneNumber, Created, Updated, Deleted)
VALUES (@JoeBidenId, 'Mobile', 1, '0412345678', GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Jill', 'Biden', 'jillbidentest@celebrancyhq.co', 'F', 'Jill', 'Mrs', '1951-06-03', GETUTCDATE(), GETUTCDATE())*/

DECLARE @JillBidenId INT
/*SET @JillBidenId = SCOPE_IDENTITY()*/
SET @JillBidenId = 3

/*INSERT INTO Users (EmailAddress, PasswordHash, PasswordSalt, PersonId, Created, Updated)
VALUES ('jillbidentest@celebrancyhq.co', 'jillbiden', 'testsalt', @JillBidenId, GETUTCDATE(), GETUTCDATE())*/

/*INSERT INTO PersonPhoneNumbers (PersonId, Type, IsPrimary, PhoneNumber, Created, Updated, Deleted)
VALUES (@JillBidenId, 'Mobile', 1, '0412987654', GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Barack', 'Obama', 'barackobamatest@celebrancyhq.co', 'M', 'Barack', 'Mr', '1961-08-04', GETUTCDATE(), GETUTCDATE())*/

DECLARE @BarackObamaId INT
/*SET @BarackObamaId = SCOPE_IDENTITY()*/
SET @BarackObamaId = 4

/*INSERT INTO Users (EmailAddress, PasswordHash, PasswordSalt, PersonId, Created, Updated)
VALUES ('barackobamatest@celebrancyhq.co', 'barackobama', 'testsalt', @BarackObamaId, GETUTCDATE(), GETUTCDATE())*/

/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Nancy', 'Pelosi', 'nancypelositest@celebrancyhq.co', 'F', 'Nancy', 'Mrs', '1940-03-26', GETUTCDATE(), GETUTCDATE())*/

DECLARE @NancyPelosiId INT
/*SET @NancyPelosiId = SCOPE_IDENTITY()*/
SET @NancyPelosiId = 5

/*INSERT INTO Users (EmailAddress, PasswordHash, PasswordSalt, PersonId, Created, Updated)
VALUES ('nancypelositest@celebrancyhq.co', 'nancypelosi', 'testsalt', @NancyPelosiId, GETUTCDATE(), GETUTCDATE())*/

/* Mock ceremony. */
/*INSERT INTO Ceremonies (Name, CeremonyDate, CeremonyTypeId, Created, Updated)
VALUES ('Marriage of Joseph and Jill Biden', '2022-06-06', 1, GETUTCDATE(), GETUTCDATE())*/

DECLARE @CeremonyId INT
/*SET @CeremonyId = SCOPE_IDENTITY()*/
SET @CeremonyId = 1

/* Ceremony permissions. */

/* Celebrant. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 1, 'KeyDetails', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 1, 'Dates', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 1, 'Participants', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 1, 'ServiceProviders', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)

/* Couple. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 3, 'KeyDetails', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 3, 'Dates', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 3, 'Participants', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 3, 'ServiceProviders', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)

/* Organiser. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 4, 'KeyDetails', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 4, 'Dates', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 4, 'Participants', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 4, 'ServiceProviders', 1, 1, 1, 1, 1, GETUTCDATE(), GETUTCDATE(), 0)

/* Witness. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 6, 'KeyDetails', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 6, 'Dates', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 6, 'Participants', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 6, 'ServiceProviders', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)

/* Bridal Party. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 7, 'KeyDetails', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 7, 'Dates', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 7, 'Participants', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 7, 'ServiceProviders', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)

/* Invited guest */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 8, 'KeyDetails', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 8, 'Dates', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 8, 'Participants', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 8, 'ServiceProviders', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)

/* Other. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 11, 'KeyDetails', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 11, 'Dates', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 11, 'Participants', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 11, 'ServiceProviders', 0, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)

/* Interpreter. */
/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 13, 'KeyDetails', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 13, 'Dates', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 13, 'Participants', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)*/

INSERT INTO CeremonyPermissions (CeremonyId, CeremonyTypeParticipantId, Field, CanView, CanEdit, CanEditWithApproval, IsApprover, CanViewHistory, Created, Updated, Deleted)
VALUES (@CeremonyId, 13, 'ServiceProviders', 1, 0, 0, 0, 0, GETUTCDATE(), GETUTCDATE(), 0)

/* Mock participants. */

/* Celebrant. */
/*INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, 1, 1, GETUTCDATE(), GETUTCDATE())

/* Joe Biden. */
INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @JoeBidenId, 3, GETUTCDATE(), GETUTCDATE())

/* Jill Biden. */
INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @JillBidenId, 3, GETUTCDATE(), GETUTCDATE())*/

/* Barack Obama. */
/*INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @BarackObamaId, 7, GETUTCDATE(), GETUTCDATE())*/

/*INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @BarackObamaId, 6, GETUTCDATE(), GETUTCDATE())*/

/* Nancy Pelosi. */
/*INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @NancyPelosiId, 7, GETUTCDATE(), GETUTCDATE())*/

/*INSERT INTO CeremonyParticipants (CeremonyId, PersonId, CeremonyTypeParticipantId, Created, Updated)
VALUES (@CeremonyId, @NancyPelosiId, 6, GETUTCDATE(), GETUTCDATE())*/

/* Mock dates. */

/* Initial phone call. */
/*INSERT INTO CeremonyDates (CeremonyId, CeremonyTypeDateId, Date, Created, Updated, Deleted)
VALUES (@CeremonyId, 1, '2022-06-12 01:00', GETUTCDATE(), GETUTCDATE(), 0)*/

/* Initial interview. */
/*INSERT INTO CeremonyDates (CeremonyId, CeremonyTypeDateId, Date, Created, Updated, Deleted)
VALUES (@CeremonyId, 2, '2022-06-13 01:00', GETUTCDATE(), GETUTCDATE(), 0)*/

/* Rehearsal. */
/*INSERT INTO CeremonyDates (CeremonyId, CeremonyTypeDateId, Date, Created, Updated, Deleted)
VALUES (@CeremonyId, 3, '2022-06-14 01:00', GETUTCDATE(), GETUTCDATE(), 0)*/

/* Ceremony. */
/*INSERT INTO CeremonyDates (CeremonyId, CeremonyTypeDateId, Date, Created, Updated, Deleted)
VALUES (@CeremonyId, 4, '2022-06-15 01:00', GETUTCDATE(), GETUTCDATE(), 0)*/

/* Reception. */
/*INSERT INTO CeremonyDates (CeremonyId, CeremonyTypeDateId, Date, Created, Updated, Deleted)
VALUES (@CeremonyId, 5, '2022-06-15 04:00', GETUTCDATE(), GETUTCDATE(), 0)*/

/* Mock venue. */
/*INSERT INTO Addresses (StreetAddress, Suburb, State, Postcode, Country, Created, Updated, Deleted)
VALUES ('George St', 'Brisbane City', 'QLD', '4000', 'Australia', GETUTCDATE(), GETUTCDATE(), 0)

DECLARE @AddressId INT
SET @AddressId = SCOPE_IDENTITY()

INSERT INTO Organisations (Name, Type, AddressId, Created, Updated, Deleted)
VALUES ('Queensland Parliament House', 'Venue', @AddressId, GETUTCDATE(), GETUTCDATE(), 0)*/

DECLARE @OrganisationId INT
/*SET @OrganisationId = SCOPE_IDENTITY()*/
SET @OrganisationId = 3

/*INSERT INTO OrganisationPhoneNumbers (OrganisationId, Type, IsPrimary, PhoneNumber, Created, Updated, Deleted)
VALUES (@OrganisationId, 'Mobile', 1, '0472581931', GETUTCDATE(), GETUTCDATE(), 0)*/

/*INSERT INTO CeremonyVenues (CeremonyId, OrganisationId, Name, IsPrimary, Created, Updated, Deleted)
VALUES (@CeremonyId, @OrganisationId, 'Ceremony venue', 1, GETUTCDATE(), GETUTCDATE(), 0)*/