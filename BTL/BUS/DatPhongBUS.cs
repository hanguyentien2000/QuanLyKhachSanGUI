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
        public DataTable getTTDatPhong()
        {
            string sql = "SELECT MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0";
            return data.GetTable(sql);
        }
        public DataTable getPhong(DateTime checkIn,DateTime checkOut,String maLoaiPhong)
        {
            String sql = "select * from Phong where MaLoaiPhong = "+ Convert.ToInt32(maLoaiPhong) + " AND MaPhong not in (Select MaPhong from DatPhong where (NgayDat<='" + checkIn.ToString("yyyy/MM/dd") +"' AND NgayDi>='" + checkIn.ToString("yyyy/MM/dd") + "') OR " + "(NgayDat <= '" + checkOut.ToString("yyyy/MM/dd") +"' AND NgayDi>= '" + checkOut.ToString("yyyy/MM/dd") + "'))";
            return data.ExecuteQuery(sql);
        }
        public KhachHangDTO getKhachHang(string tuKhoa)
        {
            KhachHangDTO kh = new KhachHangDTO();
            string sql = "";
            sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email,GioiTinhKH " +
           ",DiaChiKhachHang, CMND " +
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

                    }
                }
                else
                {
                    MessageBox.Show("Không có khách hàng này");
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
        public bool datPhong(int maNV,int maKH,int maPhong,string checkIn,string checkOut,int tienCoc)
        {
            string sql = "INSERT INTO DatPhong(MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc,TrangThaiDatPhong) values(" + 
                maNV +"," + maKH + "," + maPhong + ",'" + checkIn + "','" + checkOut + "'," + tienCoc + ", 0)";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
    }
}
