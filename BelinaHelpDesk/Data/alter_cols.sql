use BelinaHelpDesk;
ALTER TABLE [dbo].AspNetUsers ALTER COLUMN Email NVARCHAR(MAX);
ALTER TABLE AspNetUsers ALTER COLUMN PasswordHash NVARCHAR(MAX);
ALTER TABLE AspNetUsers ALTER COLUMN SecurityStamp NVARCHAR(MAX);
ALTER TABLE AspNetUsers ALTER COLUMN ConcurrencyStamp NVARCHAR(MAX);
ALTER TABLE AspNetUsers ALTER COLUMN PhoneNumber NVARCHAR(MAX);
ALTER TABLE AspNetUsers ALTER COLUMN LockoutEnd NVARCHAR(MAX);
ALTER TABLE AspNetUserTokens ALTER COLUMN Value NVARCHAR(MAX);
ALTER TABLE AspNetUserLogins ALTER COLUMN ProviderDisplayName NVARCHAR(MAX);
ALTER TABLE AspNetUserClaims ALTER COLUMN ClaimType NVARCHAR(MAX);
ALTER TABLE AspNetUserClaims ALTER COLUMN ClaimValue NVARCHAR(MAX);
ALTER TABLE AspNetRoleClaims ALTER COLUMN ClaimValue NVARCHAR(MAX);
ALTER TABLE AspNetRoleClaims ALTER COLUMN ClaimType NVARCHAR(MAX);