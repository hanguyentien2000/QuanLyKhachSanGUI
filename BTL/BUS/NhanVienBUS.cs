using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using System.Data.SqlClient;
using System.Data;
using BTL.DTO;

namespace BTL.BUS
{
    class NhanVienBUS
    {
        DataProvider data = new DataProvider();
        public DataTable layTTNhanVien()
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinhNV, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhNV, CMND, ChucVu " +
                "FROM NhanVien";
            return data.GetTable(sql);
        }

        public DataTable layChucVuNhanVien()
        {
            string sql = "SELECT * FROM LoaiChucVu";
            return data.GetTable(sql);
        }
        public bool themTTNhanVien(string hoTen, string soDT, string ngaySinh, string diaChi, int gioiTinh, string cmnd, string chucVu, byte[] anhNV)
        {
            string sql = "INSERT INTO NhanVien VALUES (N'" + hoTen + "','" + soDT + "','" + ngaySinh + "',N'" + diaChi + "'," + gioiTinh + ",'" + cmnd + "',N'" + chucVu + "',@image)";
            if (data.ExecuteNonQueryWithImage(sql, anhNV))
                return true;
            else
                return false;
        }
        public bool thayDoiTTNhanVien(int maNV, string hoTen, string soDT, string ngaySinh, string diaChi, int gioiTinh, string cmnd, string chucVu, byte[] anhNV)
        {
            string sql = "UPDATE NhanVien SET TenNhanVien=N'" + hoTen + "',SoDienThoai='" + soDT + "',NgaySinhNV='" + ngaySinh + "',DiaChiNhanVien=N'" + diaChi + "',GioiTinhNV=" + gioiTinh + ",CMND='" + cmnd + "',ChucVu=N'" + chucVu + "',anhNV=@image WHERE MaNhanVien=" + maNV + "";
            if (data.ExecuteNonQueryWithImage(sql, anhNV))
                return true;
            else
                return false;
        }
        public bool xoaTTNhanVien(int maNV)
        {
            string sql = "DELETE NhanVien WHERE MaNhanVien=" + maNV + "";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public DataTable timKiemTTNhanVien(string tuKhoa)
        {
            string sql = "";
            if(tuKhoa == "Nam")
            {
                tuKhoa = "0";
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinhNV, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhNV, CMND, ChucVu " +
                "FROM NhanVien WHERE " +
                "( GioiTinhNV LIKE N'%" + tuKhoa + "%')";
            } else if (tuKhoa == "Nữ")
            {
                tuKhoa = "1";
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinhNV, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhNV, CMND, ChucVu " +
                "FROM NhanVien WHERE " +
                "( GioiTinhNV LIKE N'%" + tuKhoa + "%')";
            } else
            {
                sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinhNV, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhNV, CMND, ChucVu " +
                "FROM NhanVien WHERE ( MaNhanVien LIKE '%" + tuKhoa + "%') OR ( TenNhanVien LIKE N'%" + tuKhoa + "%') OR " +
                "( SoDienThoai LIKE '%" + tuKhoa + "%') OR ( NgaySinhNV LIKE '%" + tuKhoa + "%') OR " +
                "( DiaChiNhanVien LIKE N'%" + tuKhoa + "%') OR ( ChucVu LIKE N'%" + tuKhoa + "%') OR ( CMND LIKE N'%" + tuKhoa + "%')";
            }
            return data.GetTable(sql);
        }

        public int kiemTraNhanVienDatPhong(int maNV)
        {
            string sql = "SELECT dbo.kiemTraNhanVienDP(" + maNV + ") AS 'checkNV'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["checkNV"].ToString());
        }

        public int kiemTraCMND(string cmnd)
        {
            string sql = "SELECT dbo.kiemTraCMNDNV('" + cmnd + "') AS 'checkCMNDNV'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["checkCMNDNV"].ToString());
        }
        public NhanVienDTO layAnhNV(int maNV)
        {
            string sql = "SELECT anhNV FROM NhanVien WHERE MaNhanVien=" + maNV;
            NhanVienDTO nv = new NhanVienDTO();
            nv.anhNV = (byte[])data.GetTable(sql).Rows[0].ItemArray[0];
            return nv;
        }
    }
}
