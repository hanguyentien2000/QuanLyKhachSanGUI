using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DTO
{
    class KhachHangDTO
    {
        int maKH, gioiTinh;
        string hoTen, soDT, ngaySinh, email, diaChi, cmnd;

        public int MaKH { get => maKH; set => maKH = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public int TrangThai { get;  set; }
    }
}
