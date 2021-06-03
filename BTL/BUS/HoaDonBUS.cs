using BTL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.BUS
{
    class HoaDonBUS
    {
        DataProvider data = new DataProvider();
        public DataTable getAllHoaDonAndDatPhong()
        {
            string sql = "SELECT MaHoaDon, DatPhong.MaDatPhong, TenNhanVien, TenKhachHang, MaPhong, NgayDat, NgayDen, NgayDi, TienDatCoc, TrangThaiDatPhong, NgayLap, TongTien " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "inner join NhanVien on DatPhong.MaNhanVien = NhanVien.MaNhanVien " +
                "inner join KhachHang on DatPhong.MaKhachHang = KhachHang.MaKhachHang";
            return data.GetTable(sql);
        }
        public DataTable getAllHoaDonAndDatPhongByDate(string date1, string date2)
        {
            string sql = "SELECT MaHoaDon, DatPhong.MaDatPhong, TenNhanVien, TenKhachHang, MaPhong, NgayDat, NgayDen, NgayDi, TienDatCoc, TrangThaiDatPhong, NgayLap, TongTien " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "inner join NhanVien on DatPhong.MaNhanVien = NhanVien.MaNhanVien " +
                "inner join KhachHang on DatPhong.MaKhachHang = KhachHang.MaKhachHang " +
                "WHERE NgayLap >= '" + date1 + "' AND NgayLap <= '" + date2 + "'";
            return data.GetTable(sql);
        }
        public DataTable getAllHoaDonAndDatPhongByDateAndTrangThai(int trangthai, string date1, string date2)
        {
            string sql = "SELECT MaHoaDon, DatPhong.MaDatPhong, TenNhanVien, TenKhachHang, MaPhong, NgayDat, NgayDen, NgayDi, TienDatCoc, TrangThaiDatPhong, NgayLap, TongTien " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "inner join NhanVien on DatPhong.MaNhanVien = NhanVien.MaNhanVien " +
                "inner join KhachHang on DatPhong.MaKhachHang = KhachHang.MaKhachHang " +
                "WHERE TrangThaiDatPhong = '" + trangthai + "' AND NgayLap >= '" + date1 + "' AND NgayLap <= '" + date2 + "'";
            return data.GetTable(sql);
        }
        public DataTable getAllHoaDonAndDatPhongByTrangThai(int trangthai)
        {
            string sql = "SELECT MaHoaDon, DatPhong.MaDatPhong, TenNhanVien, TenKhachHang, MaPhong, NgayDat, NgayDen, NgayDi, TienDatCoc, TrangThaiDatPhong, NgayLap, TongTien " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "inner join NhanVien on DatPhong.MaNhanVien = NhanVien.MaNhanVien " +
                "inner join KhachHang on DatPhong.MaKhachHang = KhachHang.MaKhachHang WHERE TrangThaiDatPhong = '" + trangthai + "'";
            return data.GetTable(sql);
        }
        public int getCountHoaDonAndDatPhongByDateAndTrangThai(int trangthai, string date1, string date2)
        {
            string sql = "SELECT COUNT(*) AS SoHoaDon " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "WHERE TrangThaiDatPhong = '" + trangthai + "' AND NgayLap >= '" + date1 + "' AND NgayLap <= '" + date2 + "'";
            return Int32.Parse(new DataProvider().ExecuteQuery(sql).Rows[0]["SoHoaDon"].ToString());
        }
        public int getCountHoaDonAndDatPhongByDate(string date1, string date2)
        {
            string sql = "SELECT COUNT(*) AS SoHoaDon " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "WHERE NgayLap >= '" + date1 + "' AND NgayLap <= '" + date2 + "'";
            return Int32.Parse(new DataProvider().ExecuteQuery(sql).Rows[0]["SoHoaDon"].ToString());
        }
        public Double getSumTongTienByDateAndTrangThai(int trangthai, string date1, string date2)
        {
            string sql = "SELECT SUM(TongTien) AS TONG " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "WHERE TrangThaiDatPhong = '" + trangthai + "' AND NgayLap >= '" + date1 + "' AND NgayLap <= '" + date2 + "'";
            return Double.Parse(new DataProvider().ExecuteQuery(sql).Rows[0]["TONG"].ToString());
        }
        public Double getSumTongTienByDate(string date1, string date2)
        {
            string sql = "SELECT SUM(TongTien) AS TONG " +
                "FROM DatPhong inner join HoaDon " +
                "on DatPhong.MaDatPhong = HoaDon.MaDatPhong " +
                "WHERE NgayLap >= '" + date1 + "' AND NgayLap <= '" + date2 + "'";
            return Double.Parse(new DataProvider().ExecuteQuery(sql).Rows[0]["TONG"].ToString());
        }
        public DataTable getChiTietDichVuByMaHD(int mahd)
        {
            string sql = "SELECT TenDichVu, SoLuongDung, GhiChu, DonGia " +
                "FROM ChiTietDichVu inner join DichVu on ChiTietDichVu.MaDichVu = DichVu.MaDichVu " +
                "WHERE MaHoaDon = '" + mahd + "'";
            return data.GetTable(sql);
        }
        public bool checkChiTietDichVuByMaHD(int mahd)
        {
            string sql = "SELECT TenDichVu, SoLuongDung, GhiChu, DonGia " +
                "FROM ChiTietDichVu inner join DichVu on ChiTietDichVu.MaDichVu = DichVu.MaDichVu " +
                "WHERE MaHoaDon = '" + mahd + "'";
            DataTable bang = data.GetTable(sql);
            if (bang.Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}
