using BTL.DAL;
using BTL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.BUS
{
    class DatPhongBUS
    {
        DataProvider data = new DataProvider();
        public DataTable getPhong(DateTime checkIn,DateTime checkOut,String maLoaiPhong)
        {
            MessageBox.Show(maLoaiPhong);
            String sql = "select * from Phong where MaLoaiPhong = "+ Convert.ToInt32(maLoaiPhong) + " AND MaPhong not in (Select MaPhong from ChiTietPhongDat inner join DatPhong on ChiTietPhongDat.MaDatPhong = DatPhong.MaDatPhong where (NgayDat<'" + checkIn.ToString("MM/dd/yyyy") +"' AND NgayDi>'" + checkIn.ToString("MM/dd/yyyy") + "') OR " + "(NgayDat < '" + checkOut.ToString("MM/dd/yyyy") +"' AND NgayDi> '" + checkOut.ToString("MM/dd/yyyy") + "'))";
            return data.ExecuteQuery(sql);
        }
        public bool datPhong(KhachHangDTO khachHang,string checkIn,string checkOut)
        {
            
            return false;
        }
    }
}
