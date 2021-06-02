using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DTO
{
    class PhongDTO
    {
        int maPhong, maLoaiPhong, trangThai;

        public int MaPhong { get => maPhong; set => maPhong = value; }
        public int MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public byte[] AnhPhong { get; set; }
    }
}
