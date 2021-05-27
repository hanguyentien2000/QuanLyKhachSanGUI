using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Models
{
    class KhachHangDTO
    {
        public int MaKH { get; set; }
        public String Hoten { get; set; }
        public int SDT { get; set; }
        public int NgaySinh { get; set; }
        public String Email { get; set; }
        public String GioiTinh { get; set; }
        public String DiaChi { get; set; }
        public Boolean TrangThai { get; set; }
    }
}
