using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DTO
{
    class NhanVienDTO
    {
        int maNV, gioiTinh;
        string hoTen, soDT, diaChi, chucVu, ngaySinh;

        public int MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}
