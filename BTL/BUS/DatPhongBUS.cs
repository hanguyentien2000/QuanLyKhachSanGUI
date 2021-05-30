using BTL.DAL;
using BTL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            String sql = "select * from Phong where MaLoaiPhong = "+ Convert.ToInt32(maLoaiPhong) + " AND MaPhong not in (Select MaPhong from ChiTietPhongDat inner join DatPhong on ChiTietPhongDat.MaDatPhong = DatPhong.MaDatPhong where (NgayDat<'" + checkIn.ToString("yyyy/MM/dd") +"' AND NgayDi>'" + checkIn.ToString("yyyy/MM/dd") + "') OR " + "(NgayDat < '" + checkOut.ToString("yyyy/MM/dd") +"' AND NgayDi> '" + checkOut.ToString("yyyy/MM/dd") + "'))";
            return data.ExecuteQuery(sql);
        }
        public KhachHangDTO getKhachHang(string tuKhoa)
        {
            KhachHangDTO kh = new KhachHangDTO();
            string sql = "";
            sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email,GioiTinhKH " +
           ",DiaChiKhachHang, CMND,TrangThai " +
            "FROM KhachHang WHERE ( MaKhachHang = '" + tuKhoa + "') OR ( CMND = N'" + tuKhoa + "') ";
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        kh.MaKH = Convert.ToInt32(reader.GetValue(0));
                        kh.HoTen = reader.GetString(1);
                        kh.SoDT = reader.GetString(2);
                        kh.NgaySinh = Convert.ToString(reader.GetDateTime(3));
                        kh.Email = reader.GetString(4);
                        kh.GioiTinh = Convert.ToInt32(reader.GetValue(5));
                        kh.DiaChi = reader.GetString(6);
                        kh.Cmnd = reader.GetString(7);
                        kh.TrangThai = Convert.ToInt32(reader.GetValue(8));

                    }

                }
            }
            return kh;
        }
        public PhongDTO getPhong(String maPhong)
        {
            PhongDTO phong = new PhongDTO();
            string sql = "select * from Phong where MaPhong =" + maPhong;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        phong.MaPhong = Convert.ToInt32(reader.GetValue(0));
                        phong.MaLoaiPhong = Convert.ToInt32(reader.GetValue(1));
                        phong.TrangThai = Convert.ToInt32(reader.GetValue(1));
                    }

                }
            }
            
            return phong;
        }
        
        public int getGia(String maPhong)
        {
            String sql = "select GiaPhong from LoaiPhong where MaLoaiPhong =" + maPhong;
            int gia = 0;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        gia = Convert.ToInt32(reader.GetValue(0));

                    }

                }
            }
            return gia;
        }
        public bool datPhong(KhachHangDTO khachHang,string checkIn,string checkOut)
        {
            return false;
        }
    }
}
