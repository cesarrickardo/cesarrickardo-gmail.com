using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_test
{
    class CustomersDB: DbContext
    {
        public DbSet<Program> context { get; set; }
       
    }
}
