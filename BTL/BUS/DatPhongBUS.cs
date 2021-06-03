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
        public Boolean datPhongKM(KhachHangDTO khachHangDTO,int maNV,int maPhong, string checkIn, string checkOut, int tienCoc)
        {
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            string sql = "INSERT INTO KhachHang output INSERTED.MaKhachHang VALUES(@tenKH,@sdt,@ns,@email,@gtinh,@diaChi,@cmnd,@tt)";
            int modified = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tenKH", khachHangDTO.HoTen);
                cmd.Parameters.AddWithValue("@sdt", khachHangDTO.SoDT);
                cmd.Parameters.AddWithValue("@ns", khachHangDTO.NgaySinh);
                cmd.Parameters.AddWithValue("@email", khachHangDTO.Email);
                cmd.Parameters.AddWithValue("@gtinh", khachHangDTO.GioiTinh);
                cmd.Parameters.AddWithValue("@diaChi", khachHangDTO.DiaChi);
                cmd.Parameters.AddWithValue("@cmnd", khachHangDTO.Cmnd);
                cmd.Parameters.AddWithValue("@tt", 0);
                modified = (int)cmd.ExecuteScalar();
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            if (datPhong(maNV, modified, maPhong, checkIn, checkOut, tienCoc))
            {
                return true;
            }
            else return false;
        }
        
        
        public DataTable getTTDatPhongCI()
        {
            string sql = "SELECT MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0";
            return data.GetTable(sql);
        }
        public DataTable getCheckInToday()
        {
            // checkin hôm nay
            String sql = "";
            String today = DateTime.Now.ToString("yyyy/MM/dd");
            String yesterday = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            if(DateTime.Now.Hour >= 14)
            {
                sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0 AND NgayDat ='" + today + "'";
            }
            else if(DateTime.Now.Hour <= 12)
            {
                sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0 AND (NgayDat ='" + today + "' OR NgayDat ='" + yesterday + "')";
            }
            return data.ExecuteQuery(sql);
        }
        public DataTable getOutOfDate()
        {
            // check in quá hạn
            String sql = "";
            String today = DateTime.Now.ToString("yyyy/MM/dd");
            String yesterday = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            if (DateTime.Now.Hour >= 12)
            {
                sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0 AND NgayDat <'" + today + "'";
            }
            else
            {
                sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0 AND NgayDat <'" + yesterday + "'";
            }
            return data.ExecuteQuery(sql);
        }
        //public DataTable locCheckIn(DateTime start,DateTime end)
        //{
        //    String sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0 AND NgayDat >='" + start.ToString("yyyy/MM/dd") +
        //        "' AND NgayDat <= '" + end.ToString("yyyy/MM/dd") + "'";
        //    return data.ExecuteQuery(sql);
        //}
        public bool passToCheckout(int maDatPhong)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            string sql = "UPDATE DatPhong SET TrangThaiDatPhong = 1, NgayDen = '"+ today + "' where MaDatPhong = " + maDatPhong;
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public bool quaHanCheckIn(int maDatPhong)
        {
            string sql = "UPDATE DatPhong SET TrangThaiDatPhong = 2 where MaDatPhong = " + maDatPhong;
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public DataTable timKiemCheckIn(string keywords)
        {
            String sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 0 AND "+
               "(MaDatPhong =" + keywords + " OR MaKhachHang =" + keywords + " OR MaPhong =" +keywords+ ")";
            return data.ExecuteQuery(sql);
        }
        // check out
        public DataTable getTTDatPhongCO()
        {
            string sql = "SELECT MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDen,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 1";
            return data.GetTable(sql);
        }
        public DataTable timKiemCheckOut(string keywords)
        {
            String sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDen,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 1 AND " +
               "(MaDatPhong =" + keywords + " OR MaKhachHang =" + keywords + " OR MaPhong =" + keywords + ")";
            return data.ExecuteQuery(sql);
        }
        public bool passToThongKe(int maDatPhong)
        {
            string sql = "UPDATE DatPhong SET TrangThaiDatPhong = 2 where MaDatPhong = " + maDatPhong;
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public DataTable getCheckOutToday()
        {
            String sql = "";
            String today = DateTime.Now.ToString("yyyy/MM/dd");
            
            sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDen,NgayDi,TienDatCoc from DatPhong where TrangThaiDatPhong = 1 AND NgayDi ='" + today + "'";
            return data.ExecuteQuery(sql);
        }
        // dịch vu
        public DataTable getDichVuOneRoom(int maDatPhong)
        {
            string sql = "select MaDichVu,TenDichVu,SoLuongDung,DonGia,GhiChu from ChiTietDichVu inner join HoaDon on" +
                " ChiTietDichVu.MaHoaDon = HoaDon.MaHoaDon inner join on DichVu inner join DichVu.MaDichVu = ChiTietDichVu.MaDichVu inner join DatPhong on"
                + "HoaDon.MaDatPhong = DatPhong.MaDatPhong where MaDatPhong = " + maDatPhong;
            return data.ExecuteQuery(sql);
        }
    }
}
