using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasteknik_fråga_2
{
    class Program
    {

        static string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        static void Main(string[] args)
        {
            SaleByTerritory();
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
    }
}
