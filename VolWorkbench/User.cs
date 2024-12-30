using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolWorkbench
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Đảm bảo mã hóa mật khẩu trước khi lưu
        public DateTime DateCreated { get; set; }
    }
}
