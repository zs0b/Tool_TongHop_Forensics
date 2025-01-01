using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace VolWorkbench
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Load .env file
            Env.Load("envdb.env");


            // Lấy thông tin từ .env
            string dbHost = Env.GetString("DB_HOST");
            string dbPort = Env.GetString("DB_PORT");
            string dbName = Env.GetString("DB_NAME");
            string dbUser = Env.GetString("DB_USER");
            string dbPassword = Env.GetString("DB_PASSWORD");
            string dbSslMode = Env.GetString("DB_SSLMODE");

            // Tạo chuỗi kết nối
            string connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};Uid={dbUser};Pwd={dbPassword};SslMode={dbSslMode};";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33)));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}



