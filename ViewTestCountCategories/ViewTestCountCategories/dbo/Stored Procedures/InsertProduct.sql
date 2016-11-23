CREATE procedure InsertProduct(@ProductName nvarchar(40),@Unitprice money)
as
insert into dbo.Products (ProductName, [UnitPrice])
values (@ProductName, @Unitprice)