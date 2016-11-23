Create Procedure CustomersGetOrders(@customerID nchar(5))
as begin 
select * From Customers c, Orders o
end 
