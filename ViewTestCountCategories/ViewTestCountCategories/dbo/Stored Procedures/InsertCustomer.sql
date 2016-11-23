create PROCEDURE InsertCustomer(@CustomerID NChar(5) ,@CompanyName nvarchar(40), @ContactName nvarchar(30))
as
insert into dbo.Customers ([CustomerID], [ContactName], [CompanyName])
values (@CustomerID, @CompanyName, @ContactName)
