using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DTO
{
    class TaiKhoanDTO
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public int LoaiTaiKhoan { get; set; }
        public int MaNhanVien { get; set; }
        public int TrangThai { get; set; }
    }
}
