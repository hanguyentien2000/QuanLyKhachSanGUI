using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Models
{
    class DatPhongDTO
    {
        public int MaDatPhong { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayDen { get; set; }
        public DateTime NgayDi { get; set; }
        public int TienDatCoc { get; set; }
        public int SoLuong { get; set; }
        public Boolean TrangThai { get; set; }
    }
}
