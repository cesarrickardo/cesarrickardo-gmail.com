using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_test
{
    class Program
    {
        static string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            CustomersWithNameLongerThan25Characters();
        }

        static void CustomersWithNameLongerThan25Characters()
        {
            using (var dbconn = new CustomersDB())
            {
                var query = "SELECT CompanyName FROM Customers where LEN(CompanyName) > 25";
                SqlConnection cn = new SqlConnection(conn);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Console.WriteLine("\t{0}", rd.GetValue(0));
                }




                Console.ReadLine();
            }
            
        }
        
    }
}
