using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasteknik
{
    class Program
    {
        static string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            ProductsByCategoryName("Confections");
            //SaleByTerritory();
            // EmployeesPerRegion();

        }
        static void ProductsByCategoryName(string CategoryName)
        {
            SqlConnection cn = new SqlConnection(conn);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT  ProductName, UnitPrice, UnitsInStock FROM  Products";
            cmd.Parameters.AddWithValue("@CategoryName",CategoryName);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine("\t{0},\t{1},\t{2}", rd.GetValue(0), rd.GetValue(1), rd.GetValue(2));
            }
            rd.Close();
            cn.Close();
            Console.ReadLine();
            
            // funkar men resultatet ser inte så snyggt ut 

        }
        static void SaleByTerritory()
        {
            var query = "SELECT TOP (5) [Order Details].UnitPrice * [Order Details].Quantity AS TotalSale, Territories.TerritoryDescription FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID GROUP BY[Order Details].UnitPrice * [Order Details].Quantity, Territories.TerritoryDescription order by TotalSale desc";
            SqlConnection cn = new SqlConnection(conn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine("\t{0},\t{1}", rd.GetValue(0), rd.GetValue(1));
            }
            rd.Close();
            cn.Close();
            Console.ReadLine();
            // Funkar !
        }
        static void EmployeesPerRegion()
        {
            var query = " SELECT        Employees.EmployeeID, MAX(Employees.Region) AS Region, Employees.City FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID CROSS JOIN Products GROUP BY Employees.EmployeeID, Employees.Region, Employees.City ORDER BY COUNT(*) DESC";
            SqlConnection cn = new SqlConnection(conn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine("\t{0},\t{1},\t{2}", rd.GetValue(0).ToString(), rd.GetValue(1).ToString(), rd.GetValue(2).ToString());
            }
            rd.Close();
            cn.Close();
            Console.ReadLine();
            // funkar men tror det e inte helt klart, kolla igen !
            // kollat lite ser lite bättre ut !

        }
    }
}
