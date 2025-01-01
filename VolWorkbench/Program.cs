using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DotNetEnv;


namespace VolWorkbench
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Env.Load("envdb.env");


            // Lấy thông tin kết nối từ .env
            string server = Env.GetString("DB_SERVER");
            string port = Env.GetString("DB_PORT");
            string database = Env.GetString("DB_NAME");
            string username = Env.GetString("DB_USER");
            string password = Env.GetString("DB_PASSWORD");
            string sslMode = Env.GetString("DB_SSLMODE");

            // Tạo chuỗi kết nối từ thông tin trong .env
            string connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};SslMode={sslMode};";

            // Cấu hình DbContextOptions sử dụng chuỗi kết nối
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 11, 8)), options =>
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null));

            // Tạo instance của ApplicationDbContext
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Khởi tạo cấu hình ứng dụng
            ApplicationConfiguration.Initialize();
            Application.Run(new Form_Login());
        }
    }
}