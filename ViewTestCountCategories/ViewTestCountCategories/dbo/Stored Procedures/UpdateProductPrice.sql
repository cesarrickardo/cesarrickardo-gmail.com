create procedure UpdateProductPrice(@ProductID int,@Unitprice money)
as
update Products set UnitPrice=@Unitprice
where ProductID = Products.ProductID
