
     
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