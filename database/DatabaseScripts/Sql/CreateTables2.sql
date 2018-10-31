USE [MSPetShop4Orders]

CREATE TABLE [Orders] (
	[OrderId] int IDENTITY PRIMARY KEY,
	[UserId] varchar(20) NOT NULL,
	[OrderDate] datetime NOT NULL,
	[ShipAddr1] varchar(80) NOT NULL,
	[ShipAddr2] varchar(80) NULL,
	[ShipCity] varchar(80) NOT NULL,
	[ShipState] varchar(80) NOT NULL,
	[ShipZip] varchar(20) NOT NULL,
	[ShipCountry] varchar(20) NOT NULL,
	[BillAddr1] varchar(80) NOT NULL,
	[BillAddr2] varchar(80) NULL,
	[BillCity] varchar(80) NOT NULL,
	[BillState] varchar(80) NOT NULL,
	[BillZip] varchar(20) NOT NULL,
	[BillCountry] varchar(20) NOT NULL,
	[Courier] varchar(80) NOT NULL,
	[TotalPrice] decimal(10, 2) NOT NULL,
	[BillToFirstName] varchar(80) NOT NULL,
	[BillToLastName] varchar(80) NOT NULL,
	[ShipToFirstName] varchar(80) NOT NULL,
	[ShipToLastName] varchar(80) NOT NULL,
	[AuthorizationNumber] int NOT NULL,
	[Locale] varchar(20) NOT NULL
)

CREATE TABLE [LineItem] (
	[OrderId] int NOT NULL REFERENCES [Orders]([OrderId]),
	[LineNum] int NOT NULL,
	[ItemId] varchar(10) NOT NULL,
	[Quantity] int NOT NULL,
	[UnitPrice] decimal(10, 2) NOT NULL,
	CONSTRAINT [PkLineItem] PRIMARY KEY ([OrderId], [LineNum])
)

CREATE TABLE [OrderStatus] (
	[OrderId] int NOT NULL REFERENCES [Orders]([OrderId]),
	[LineNum] int NOT NULL,
	[Timestamp] datetime NOT NULL,
	[Status] varchar(2) NOT NULL,
	CONSTRAINT [PkOrderStatus] PRIMARY KEY ([OrderId], [LineNum])
)