USE [MSPetShop4Profile]

CREATE TABLE [Profiles] (
    [UniqueID] [int] IDENTITY (1, 1) NOT NULL ,
    [Username] [varchar] (256)  NOT NULL ,
    [ApplicationName] [varchar] (256)  NOT NULL ,
    [IsAnonymous] [bit] NULL ,
    [LastActivityDate] [datetime] NULL ,
    [LastUpdatedDate] [datetime] NULL ,
    CONSTRAINT [PK_Profiles_1] PRIMARY KEY  NONCLUSTERED 
    (
        [UniqueID]
    )  ON [PRIMARY] ,
    CONSTRAINT [PK_Profiles] UNIQUE  CLUSTERED 
    (
        [Username],
        [ApplicationName]
    )  ON [PRIMARY] 
) ON [PRIMARY]

CREATE TABLE [Cart] (
    [UniqueID] [int] NOT NULL ,
    [ItemId] [varchar] (10)  NOT NULL ,
    [Name] [varchar] (80)  NOT NULL ,
    [Type] [varchar] (80)  NOT NULL ,
    [Price] [decimal](10, 2) NOT NULL ,
    [CategoryId] [varchar] (10)  NOT NULL ,
    [ProductId] [varchar] (10)  NOT NULL ,
    [IsShoppingCart] [bit]  NOT NULL ,
    [Quantity] [int] NOT NULL ,
    CONSTRAINT [FK_Cart_Profiles] FOREIGN KEY 
    (
        [UniqueID]
    ) REFERENCES [Profiles] (
        [UniqueID]
    ) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]

CREATE TABLE [Account] (
    [UniqueID] [int] NOT NULL ,
    [Email] [varchar] (80)  NOT NULL ,
    [FirstName] [varchar] (80)  NOT NULL ,
    [LastName] [varchar] (80)  NOT NULL ,
    [Address1] [varchar] (80)  NOT NULL ,
    [Address2] [varchar] (80)  NULL ,
    [City] [varchar] (80)  NOT NULL ,
    [State] [varchar] (80)  NOT NULL ,
    [Zip] [varchar] (20)  NOT NULL ,
    [Country] [varchar] (20)  NOT NULL ,
    [Phone] [varchar] (20)  NULL ,
    CONSTRAINT [FK_Account_Profiles] FOREIGN KEY (
        [UniqueID]
    ) REFERENCES [Profiles] (
        [UniqueID]
    ) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]

CREATE  CLUSTERED  INDEX [FK_Cart_UniqueID] ON [dbo].[Cart]([UniqueID]) ON [PRIMARY]

CREATE  CLUSTERED  INDEX [FK_Account_UniqueID] ON [dbo].[Account]([UniqueID]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_SHOPPINGCART] ON [dbo].[Cart] (
	[IsShoppingCart] ASC
)