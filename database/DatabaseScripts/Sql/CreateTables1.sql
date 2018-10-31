USE [MSPetShop4]


CREATE TABLE [Category] (
	[CategoryId] varchar(10) PRIMARY KEY,
	[Name] varchar(80) NULL,
	[Descn] varchar(255) NULL
)


CREATE TABLE [Inventory] (
	[ItemId] varchar(10) PRIMARY KEY,
	[Qty] int NOT NULL
)

CREATE TABLE [Supplier] (
	[SuppId] int PRIMARY KEY,
	[Name] varchar(80) NULL,
	[Status] varchar(2) NOT NULL,
	[Addr1] varchar(80) NULL,
	[Addr2] varchar(80) NULL,
	[City] varchar(80) NULL,
	[State] varchar(80) NULL,
	[Zip] varchar(5) NULL,
	[Phone] varchar(40) NULL 
)


CREATE TABLE [Product] (
	[ProductId] varchar(10) PRIMARY KEY,
	[CategoryId] varchar(10) NOT NULL REFERENCES [Category]([CategoryId]),
	[Name] varchar(80) NULL,
	[Descn] varchar(255) NULL,
	[Image] varchar(80) NULL
)

CREATE TABLE [Item] (
	[ItemId] varchar(10) PRIMARY KEY,
	[ProductId] varchar(10) NOT NULL REFERENCES [Product]([ProductId]),
	[ListPrice] decimal(10, 2) NULL,
	[UnitCost] decimal(10, 2) NULL,
	[Supplier] int NULL REFERENCES [Supplier]([SuppId]),
	[Status] varchar(2) NULL,
	[Name] varchar(80) NULL,
	[Image] varchar(80) NULL
)

CREATE INDEX [IxItem] ON [Item]([ProductId], [ItemId], [ListPrice], [Name])

CREATE INDEX [IxProduct1] ON [Product]([Name])
CREATE INDEX [IxProduct2] ON [Product]([CategoryId])
CREATE INDEX [IxProduct3] ON [Product]([CategoryId], [Name])
CREATE INDEX [IxProduct4] ON [Product]([CategoryId], [ProductId], [Name])