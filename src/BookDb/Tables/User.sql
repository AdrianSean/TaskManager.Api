CREATE TABLE [dbo].[User]
(
	[UserId] BIGINT NOT NULL IDENTITY(1,1),
	[Firstname] [NVARCHAR] (50) NOT NULL,
	[Lastname] [nvarchar] (50) NOT NULL,
	[Username] nvarchar(50) NOT NULL,
	CONSTRAINT [Pk_User] PRIMARY KEY ([UserId])
);
GO