using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace VolWorkbench
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(
                "Server=171.247.175.33;Port=62807;Database=tool_for;Uid=zs0b;Pwd=123456789;SslMode=None;",
                new MySqlServerVersion(new Version(8, 0, 33))
            );


            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}


