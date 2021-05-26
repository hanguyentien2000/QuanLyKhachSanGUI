using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using System.Data.SqlClient;
using System.Data;
namespace BTL.BLL
{
    class NhanVienBLL
    {
        Dal data = new Dal();
        public DataTable layDSNhanVien()
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam'" +
                "ELSE N'Nữ' END AS GioiTinhNV, ChucVu FROM NhanVien";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public bool themMoiTTNhanVien(string tenNV, string sdt, string ngaySinh, string diaChi,  int gioiTinh, string chucVu)
        {
            string sql = "INSERT INTO NhanVien VALUES (N'" + tenNV + "','" + sdt + "','" + ngaySinh + "',N'" + diaChi + "'," + gioiTinh + ",N'" + chucVu + "')";
            if(data.ExecuteNonQuery(sql))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool thayDoiTTNhanVien(int MaNV, string tenNV, string sdt, string ngaySinh, string diaChi, int gioiTinh, string chucVu)
        {
            string sql = "UPDATE NhanVien SET TenNhanVien=N'" + tenNV + "',SoDienThoai='" + sdt + "',NgaySinh='" + ngaySinh + "',DiaChiNhanVien=N'" + diaChi + "',GioiTinhNV=" + gioiTinh + ",ChucVu=N'" + chucVu + "' WHERE MaNhanVien=" + MaNV + "";
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool xoaTTNhanVien(int MaNV)
        {
            string sql = "DELETE NhanVien WHERE MaNhanVien=" + MaNV + "";
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable timKiemTTNhanVien(string tuKhoa)
        {
            string sql = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, NgaySinh, DiaChiNhanVien, " +
                "CASE WHEN GioiTinhNV = 0 THEN N'Nam'" +
                "ELSE N'Nữ' END AS GioiTinhNV, ChucVu FROM NhanVien AND ( MaNhanVien LIKE '%" + tuKhoa + "%' ) OR " +
                "( TenNhanVien LIKE N'%" + tuKhoa + "%' ) OR ( SoDienThoai LIKE '%" + tuKhoa + "%' ) OR " +
                "( NgaySinh LIKE '%" + tuKhoa + "%' ) OR ( DiaChiNhanVien LIKE N'%" + tuKhoa + "%' ) OR ( GioiTinh LIKE N'%" + tuKhoa + "%' ) OR " +
                "( ChucVu LIKE N'%" + tuKhoa + "%' )";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public int kiemTraMaNhanVien(int MaNV)
        {
            string sql = "SELECT dbo.checkMaNhanVien(" + MaNV + ") AS 'Value'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["Value"].ToString());
        }
    }
}
