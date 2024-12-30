using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            // Cấu hình trực tiếp DbContextOptions tại runtime
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql("Server=171.247.175.33;Port=62807;Database=tool_for;Uid=zs0b;Pwd=123456789;SslMode=None;",
                                    new MySqlServerVersion(new Version(10, 11, 8)));

            // Tạo instance của ApplicationDbContext
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form_Login());
        }
    }
}