using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using System.Data.SqlClient;
using System.Data;

namespace BTL.BUS
{
    class NhanVienBUS
    {
        DataProvider data = new DataProvider();
        public DataTable layTTNhanVien()
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinhNV, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhNV, ChucVu " +
                "FROM NhanVien";
            return data.GetTable(sql);
        }
        public bool themTTNhanVien(string hoTen, string soDT, string ngaySinh, string diaChi, int gioiTinh, string chucVu)
        {
            string sql = "INSERT INTO NhanVien VALUES (N'" + hoTen + "','" + soDT + "','" + ngaySinh + "',N'" + diaChi + "'," + gioiTinh + ",N'" + chucVu + "')";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public bool thayDoiTTNhanVien(int maNV, string hoTen, string soDT, string ngaySinh, string diaChi, int gioiTinh, string chucVu)
        {
            string sql = "UPDATE NhanVien SET TenNhanVien=N'" + hoTen + "',SoDienThoai='" + soDT + "',NgaySinh='" + ngaySinh + "',N'" + diaChi + "',GioiTinh=" + gioiTinh + ",ChucVu=N'" + chucVu + "' WHERE MaNhanVien=" + maNV + "";
            if (data.ExecuteNonQuery(sql))
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
        public bool timKiemTTNhanVien(string tuKhoa)
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinhNV, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhNV, ChucVu" +
                "FROM NhanVien WHERE ( MaNhanVien LIKE '%" + tuKhoa + "%') OR ( TenNhanVien LIKE N'%" + tuKhoa + "%') OR " +
                "( SoDienThoai LIKE '%" + tuKhoa + "%') OR ( NgaySinhNV LIKE '%" + tuKhoa + "%') OR " +
                "( DiaChiNhanVien LIKE N'%" + tuKhoa + "%') OR ( GioiTinh LIKE %" + tuKhoa + "%) OR ( ChucVu LIKE N'%" + tuKhoa + "%')";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }

        public int kiemTraNhanVienDatPhong(int maNV)
        {
            string sql = "SELECT dbo.kiemTraNhanVienDP(" + maNV + ") AS 'check'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["check"].ToString());
        }
    }
}
