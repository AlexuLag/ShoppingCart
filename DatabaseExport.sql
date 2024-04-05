
CREATE TABLE dbo.Categories (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Categories PRIMARY KEY (Id)
);



CREATE TABLE dbo.Customers (
	Id int IDENTITY(1,1) NOT NULL,
	IdentificationNumber int NOT NULL,
	FirstName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	LastName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Customers PRIMARY KEY (Id)
);



CREATE TABLE dbo.Products (
	Id int IDENTITY(1,1) NOT NULL,
	Code nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Description nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UnitPrice float NOT NULL,
	ImageUrl nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Products PRIMARY KEY (Id)
);



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



CREATE TABLE dbo.ProductStock (
	Id int IDENTITY(1,1) NOT NULL,
	SerialNumber nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Status nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	BatchCode nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ProductId int NOT NULL,
	CONSTRAINT PK_ProductStock PRIMARY KEY (Id),
	CONSTRAINT FK_ProductStock_Products_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id) ON DELETE CASCADE
);




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


