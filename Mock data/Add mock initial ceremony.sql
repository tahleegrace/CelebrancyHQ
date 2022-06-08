USE CelebrancyHQ;

/* Mock persons. */
/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Joseph', 'Biden', 'joebidentest@celebrancyhq.co', 'M', 'Joe', 'Mr', '1942-11-20', GETUTCDATE(), GETUTCDATE())

DECLARE @JoeBidenId INT
SET @JoeBidenId = SCOPE_IDENTITY()

INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Jill', 'Biden', 'jillbidentest@celebrancyhq.co', 'F', 'Jill', 'Mrs', '1951-06-03', GETUTCDATE(), GETUTCDATE())

DECLARE @JillBidenId INT
SET @JillBidenId = SCOPE_IDENTITY()*/

/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Barack', 'Obama', 'barackobamatest@celebrancyhq.co', 'M', 'Barack', 'Mr', '1961-08-04', GETUTCDATE(), GETUTCDATE())*/

DECLARE @BarackObamaId INT
/*SET @BarackObamaId = SCOPE_IDENTITY()*/
SET @BarackObamaId = 4

/*INSERT INTO Persons (FirstName, LastName, EmailAddress, Gender, PreferredName, Title, DateOfBirth, Created, Updated)
VALUES ('Nancy', 'Pelosi', 'nancypelositest@celebrancyhq.co', 'F', 'Nancy', 'Mrs', '1940-03-26', GETUTCDATE(), GETUTCDATE())*/

DECLARE @NancyPelosiId INT
/*SET @NancyPelosiId = SCOPE_IDENTITY()*/
SET @NancyPelosiId = 5

/* Mock ceremony. */
/*INSERT INTO Ceremonies (Name, CeremonyDate, CeremonyTypeId, Created, Updated)
VALUES ('Marriage of Joseph and Jill Biden', '2022-06-06', 1, GETUTCDATE(), GETUTCDATE())*/

DECLARE @CeremonyId INT
/*SET @CeremonyId = SCOPE_IDENTITY()*/
SET @CeremonyId = 1

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

INSERT INTO OrganisationPhoneNumbers (OrganisationId, Type, IsPrimary, PhoneNumber, Created, Updated, Deleted)
VALUES (@OrganisationId, 'Mobile', 1, '0472581931', GETUTCDATE(), GETUTCDATE(), 0)

/*INSERT INTO CeremonyVenues (CeremonyId, OrganisationId, Name, IsPrimary, Created, Updated, Deleted)
VALUES (@CeremonyId, @OrganisationId, 'Ceremony venue', 1, GETUTCDATE(), GETUTCDATE(), 0)*/