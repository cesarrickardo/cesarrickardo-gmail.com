using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasteknik_fråga_3
{
    class Program
    {

        static string conn =  @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        static void Main(string[] args)
        {
            EmployeesPerRegion();
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
