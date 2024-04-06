-- dbo.Categories definition

-- Drop table

-- DROP TABLE dbo.Categories;

CREATE TABLE dbo.Categories (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Categories PRIMARY KEY (Id)
);


-- dbo.Customers definition

-- Drop table

-- DROP TABLE dbo.Customers;

CREATE TABLE dbo.Customers (
	Id int IDENTITY(1,1) NOT NULL,
	IdentificationNumber int NOT NULL,
	FirstName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	LastName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Customers PRIMARY KEY (Id)
);


-- dbo.Products definition

-- Drop table

-- DROP TABLE dbo.Products;

CREATE TABLE dbo.Products (
	Id int IDENTITY(1,1) NOT NULL,
	Code nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Description nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UnitPrice float NOT NULL,
	ImageUrl nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Products PRIMARY KEY (Id)
);


-- dbo.Orders definition

-- Drop table

-- DROP TABLE dbo.Orders;

CREATE TABLE dbo.Orders (
	Id int IDENTITY(1,1) NOT NULL,
	[Date] datetime2 NOT NULL,
	CustomerId int NOT NULL,
	CONSTRAINT PK_Orders PRIMARY KEY (Id),
	CONSTRAINT FK_Orders_Customers_CustomerId FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_Orders_CustomerId ON dbo.Orders (  CustomerId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- dbo.ProductCategories definition

-- Drop table

-- DROP TABLE dbo.ProductCategories;

CREATE TABLE dbo.ProductCategories (
	CategoryId int NOT NULL,
	ProductId int NOT NULL,
	CONSTRAINT PK_ProductCategories PRIMARY KEY (ProductId,CategoryId),
	CONSTRAINT FK_ProductCategories_Categories_CategoryId FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(Id) ON DELETE CASCADE,
	CONSTRAINT FK_ProductCategories_Products_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_ProductCategories_CategoryId ON dbo.ProductCategories (  CategoryId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- dbo.ProductStock definition

-- Drop table

-- DROP TABLE dbo.ProductStock;

CREATE TABLE dbo.ProductStock (
	Id int IDENTITY(1,1) NOT NULL,
	SerialNumber nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Status nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	BatchCode nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ProductId int NOT NULL,
	CONSTRAINT PK_ProductStock PRIMARY KEY (Id),
	CONSTRAINT FK_ProductStock_Products_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id) ON DELETE CASCADE
);


-- dbo.OrderDetails definition

-- Drop table

-- DROP TABLE dbo.OrderDetails;

CREATE TABLE dbo.OrderDetails (
	Id int IDENTITY(1,1) NOT NULL,
	Quantity float NOT NULL,
	TotalPrice float NOT NULL,
	ProductId int NOT NULL,
	OrderId int NOT NULL,
	CONSTRAINT PK_OrderDetails PRIMARY KEY (Id),
	CONSTRAINT FK_OrderDetails_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES dbo.Orders(Id) ON DELETE CASCADE,
	CONSTRAINT FK_OrderDetails_Products_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_OrderDetails_OrderId ON dbo.OrderDetails (  OrderId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_OrderDetails_ProductId ON dbo.OrderDetails (  ProductId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;



	 
INSERT INTO dbo.Categories (Name) VALUES
	 (N'Technology'),
	 (N'School Items'),
	 (N'Art and books');

	 	
	INSERT INTO dbo.Products (Code,Name,Description,UnitPrice,ImageUrl) VALUES
	 (N'00001',N'Book',N'100 pages book',5.0,N'/assets/productImages/book.png'),
	 (N'00002',N'Blue Pencil',N'blue pencil',1.0,N'/assets/productImages/BluePencil.png'),
	 (N'00003',N'Asus Laptop',N'laptop for work',700.0,N'/assets/productImages/Rog.png'),
	 (N'00004',N'IPhone 15',N'cellphone',1000.0,N'/assets/productImages/Iphone15.png'),
	 (N'00005',N'Iphone 14',N'cellphone',900.0,N'/assets/productImages/Iphone14.png'),
	 (N'00006',N'Iphone 13',N'cellphone',700.0,N'/assets/productImages/Iphone14.png'),
	 (N'00007',N'Clean Code',N'developer book',30.0,N'/assets/productImages/bookClean.png'),
	 (N'00008',N'Clean architecture',N'developer book',20.0,N'/assets/productImages/bookCleanarch.png'),
	 (N'00009',N'Pragmatic programmer',N'developer book',10.0,N'/assets/productImages/Pragmatic.png'),
	 (N'00010',N'Ipad pro 11',N'tablet',700.0,N'/assets/productImages/Ipad.png');


	 INSERT INTO dbo.Customers (IdentificationNumber,FirstName,LastName,Email) VALUES
	 (801432255,N'JOHN',N'UBAQUE',N'alexander80143@gmail.com'),
	 (410658987,N'lizeth',N'garzon',N'info@solucionesug.com');

	 INSERT INTO dbo.ProductCategories (CategoryId,ProductId) VALUES
	 (1,1),
	 (1,2),
	 (1,3),
	 (1,4),
	 (1,5),
	 (2,4),
	 (2,7),
	 (3,8),
	 (3,9),
	 (3,10);
INSERT INTO dbo.ProductCategories (CategoryId,ProductId) VALUES
	 (3,4);


	 INSERT INTO dbo.ProductStock (SerialNumber,Status,BatchCode,ProductId) VALUES
	 (N'1',N'S',N'XXXX',1),
	 (N'2',N'S',N'XXXX',1),
	 (N'3',N'S',N'XXXX',10),
	 (N'444',N'S',N'IFT142',2),
	 (N'333',N'S',N'IFT142',2),
	 (N'444',N'S',N'IFT142',2),
	 (N'xe2514',N'S',N'XXX35',3),
	 (N'xe2515',N'S',N'XXX35',4),
	 (N'xe2516',N'S',N'XXX35',5),
	 (N'xe2517',N'S',N'XXX35',6);
INSERT INTO dbo.ProductStock (SerialNumber,Status,BatchCode,ProductId) VALUES
	 (N'B123',N'S',N'IFT142',7),
	 (N'B124',N'S',N'IFT142',8),
	 (N'B125',N'S',N'IFT142',9);