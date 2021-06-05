using BTL.DAL;
using BTL.DTO;
using BTL.Models;
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
            String sql = "select * from Phong where MaLoaiPhong = "+ Convert.ToInt32(maLoaiPhong) 
                + " AND MaPhong not in (Select MaPhong from DatPhong where (NgayDat<='" + checkIn.ToString("yyyy/MM/dd") 
                +"' AND NgayDi>'" + checkIn.ToString("yyyy/MM/dd") + "') OR "
                + "(NgayDat < '" + checkOut.ToString("yyyy/MM/dd") +"' AND NgayDi>= '" + checkOut.ToString("yyyy/MM/dd") 
                + "'))";
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
        
        // get tất cả checkin
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
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            string sql = "UPDATE DatPhong SET TrangThaiDatPhong = 2 AND NgayDi ='" + today + "' where MaDatPhong = " + maDatPhong;
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
            String sql = "Select MaDatPhong,MaNhanVien,MaKhachHang,MaPhong,NgayDat,NgayDen,NgayDi,TienDatCoc from DatPhong inner join KhachHang" 
                + " on DatPhong.MaKhachHang = KhachHang.MaKhachHang where TrangThaiDatPhong = 1 AND " +
               "(MaDatPhong =" + keywords + " OR MaKhachHang =" + keywords + " OR MaPhong =" + keywords + " OR TenKhachHang like N'%"+ keywords + "%' OR SDT='"+ keywords +"')";
            return data.ExecuteQuery(sql);
        }
        public bool passToThongKe(int maDatPhong)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            string sql = "UPDATE DatPhong SET TrangThaiDatPhong = 2, NgayDi = '"+ today +"' where MaDatPhong = " + maDatPhong;
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
        public DataTable getAllDichVu()
        {
            string sql = "Select * from DichVu";
            return data.ExecuteQuery(sql);
        }
        public DataTable getDichVuOneRoom(int maDatPhong)
        {
            string sql = "select ChiTietDichVu.MaDichVu,TenDichVu,SoLuongDung,DonGia,GhiChu from ChiTietDichVu inner join HoaDon on" +
                " ChiTietDichVu.MaHoaDon = HoaDon.MaHoaDon inner join DichVu on DichVu.MaDichVu = ChiTietDichVu.MaDichVu inner join DatPhong on "
                + "HoaDon.MaDatPhong = DatPhong.MaDatPhong where HoaDon.MaDatPhong = " + maDatPhong;
            return data.ExecuteQuery(sql);
        }
        public Boolean ktraDichVu(int maHD,int maDichVu)
        {
            string sql = "select * from ChiTietDichVu where MaHoaDon =" + maHD + " AND MaDichVu =" + maDichVu;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public int getSoLuongDung(int maHD, int maDichVu)
        {
            string sql = "select SoLuongDung from ChiTietDichVu where MaHoaDon =" + maHD + " AND MaDichVu =" + maDichVu;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            int sldv = 0;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sldv = reader.GetInt32(0);
            }
            return sldv;
        }
        public int getMaHD(int maDatPhong)
        {
            string sql = "select MaHoaDon from HoaDon inner join DatPhong on HoaDon.MaDatPhong = DatPhong.MaDatPhong where DatPhong.MaDatPhong =" + maDatPhong;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int maHD = 0;
            if(reader.Read())
            {
                maHD = reader.GetInt32(0);
            }
            return maHD;

        }
        public Boolean themDV(int maHoaDon,int maDichVu,int soLuong,string ghiChu)
        {
            string sql = "insert into ChiTietDichVu values(" + maDichVu + "," + maHoaDon + "," + soLuong + ",'" + ghiChu + "')";
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else return false;
        }
        public Boolean suaDV(int maHoaDon, int maDichVu, int soLuong, string ghiChu)
        {
            string sql = "update ChiTietDichVu set SoLuongDung=" + soLuong + ", GhiChu ='" + ghiChu +"' where MaHoaDon=" + maHoaDon + " AND MaDichVu=" + maDichVu;
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else return false;
        }
        public Boolean xoaDichVu(int maHoaDon, int maDichVu)
        {
            string sql = "Delete ChiTietDichVu where MaHoaDon =" + maHoaDon + " AND MaDichVu =" + maDichVu;
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else return false;
        }
        // get HoaDon
        public int getTienCoc(int maDatPhong)
        {
            int tienCoc = 0;
            string sql = "";
            sql = "SELECT TienDatCoc from DatPhong where MaDatPhong =" + maDatPhong;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        tienCoc += Convert.ToInt32(reader.GetValue(0));
                    }
                }
            }
            return tienCoc;
        }
        public int getTongTienDV(int maHoaDon)
        {
            int tongTienDV = 0;
            string sql = "";
            sql = "SELECT DonGia,SoLuongDung from DichVu inner join ChiTietDichVu on DichVu.MaDichVu = ChiTietDichVu.MaDichVu inner join" + 
                " HoaDon on HoaDon.MaHoaDon = ChiTietDichVu.MaHoaDon";
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tongTienDV += Convert.ToInt32(reader.GetValue(0)) * Convert.ToInt32(reader.GetValue(1));
                    }
                }
            }
            return tongTienDV;
        }
        public int getTongTienPhong(int maDatPhong)
        {
            int tongTienPhong = 0;
            string sql = "";
            sql = "SELECT TienDatCoc from DatPhong where MaDatPhong = " + maDatPhong;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        tongTienPhong += Convert.ToInt32(reader.GetValue(0)) * 2;
                    }
                }
            }
            return tongTienPhong;
        }
        public HoaDonDTO ttHoaDon(int maHoaDon)
        {
            HoaDonDTO hd = new HoaDonDTO();
            string sql = "";
            sql = "Select * from HoaDon where MaHoaDon =" + maHoaDon;
            SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        hd.MaHD = Convert.ToInt32(reader.GetValue(0));
                        hd.MaDatPhong = Convert.ToInt32(reader.GetValue(1));
                        hd.NgayLap = reader.GetDateTime(2);
                        hd.TongTien = Convert.ToInt32(reader.GetValue(3));
                    }
                }
            }
            return hd;
        }
        public Boolean updateHDSauKhiCheckOut(int maHD,int tongTien)
        {
            string sql = "update HoaDon set TongTien =" + tongTien + ", NgayLap ='" + DateTime.Now.ToString("yyyy/MM/dd") + "' where MaHoaDon =" + maHD;
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else return false;
        }
    }
}
