USE [MSPetShop4Profile]

DECLARE @userid int

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'AdamBarr', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone@microsoft.com', 'Adam', 'Barr', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'KimAbercrombie', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone1@microsoft.com', 'Kim', 'Abercrombie', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')
           
INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'RobYoung', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone2@microsoft.com', 'Rob', 'Young', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'TomYoutsey', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone3@microsoft.com', 'Tom', 'Youtsey', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'GaryWYukish', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone4@microsoft.com', 'Gary W.', 'Yukish', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'RobCaron', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone5@microsoft.com', 'Rob', 'Caron', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'KarinZimprich', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone6@microsoft.com', 'Karin', 'Zimprich', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'RandallBoseman', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone7@microsoft.com', 'Randall', 'Boseman', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'KevinKennedy', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone8@microsoft.com', 'Kevin', 'Kennedy', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'DianeTibbott', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone9@microsoft.com', 'Diane', 'Tibbott', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'GarrettYoung', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone10@microsoft.com', 'Garrett', 'Young', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')           

INSERT INTO [Profiles] (
	[Username], [ApplicationName], [IsAnonymous], [LastActivityDate], [LastUpdatedDate]
)
VALUES (
     'demo', '.NET Pet Shop 4.0', 0, GETDATE(), GETDATE()
)
SET @userid = (SELECT @@IDENTITY)
INSERT INTO [Account] ([UniqueID], [Email], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone])
     VALUES
           (@userid, 'someone@microsoft.com', 'Adam', 'Barr', 'Vertigo Software, Inc.', '503A Canal Blvd.', 'Point Richmond', 'CA', '94804', 'USA', '(510) 307-8200')