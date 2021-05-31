using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using BTL.DTO;


namespace BTL.BUS
{
    class TaiKhoanBUS
    {
        DataProvider data = new DataProvider();
        public DataTable GetTableTaiKhoan()
        {
            string sql = "SELECT Username, Password, LoaiTaiKhoan, TrangThai, TenNhanVien FROM Taikhoan INNER JOIN NhanVien ON Taikhoan.MaNhanVien=NhanVien.MaNhanVien";
            return data.GetTable(sql);
        }

        public DataTable SearchTenDangNhap(string searchKey)
        {
            string sql = "Select * from dbo.TAIKHOAN where Username LIKE '%" + searchKey + "%'";
            return data.GetTable(sql);
        }

        public TaiKhoanDTO GetTaiKhoan(string Username)
        {
            string sql = "Select * from dbo.TAIKHOAN where Username = '" + Username + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.Username = dt.Rows[0].ItemArray[1].ToString();
            tk.Password = dt.Rows[0].ItemArray[2].ToString();
            tk.MaNhanVien = Int32.Parse(dt.Rows[0].ItemArray[5].ToString());
            tk.LoaiTaiKhoan = Int32.Parse(dt.Rows[0].ItemArray[3].ToString());
            tk.TrangThai = Int32.Parse(dt.Rows[0].ItemArray[4].ToString());
            return tk;
        }

        public bool AddTaiKhoan(string TenDangNhap, string MatKhau, int LoaiTaiKhoan, int trangThai, int MaNV)
        {
            string sql = "Insert into TAIKHOAN values('" + TenDangNhap + "','" + MatKhau + "'," + LoaiTaiKhoan + "," + trangThai + "," + MaNV + ")";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }

        public bool UpdateTaiKhoan(string TenDangNhap, string MatKhau, int LoaiTaiKhoan, int trangThai)
        {
            string sql = "Update TAIKHOAN SET Password='" + MatKhau + "', LoaiTaiKhoan =" + LoaiTaiKhoan + ", TrangThai=" + trangThai +  " where Username = '" + TenDangNhap + "'";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }

        public void DeleteTaiKhoan(string TenTK)
        {
            string sql = "Delete from TAIKHOAN where Username='" + TenTK + "'";
            data.ExecuteQuery(sql);
        }

        public int kiemTraNhanVienCoTK(int maNV)
        {
            string sql = "SELECT dbo.kiemTraPhongDat(" + maNV + ") AS 'checkTK'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["checkTK"].ToString());
        }

        public string kiemTraMatKhau(string userName)
        {
            string sql = "SELECT Password FROM TaiKhoan WHERE Username='" + userName + "'";
            return data.ExecuteQuery(sql).Rows[0]["Password"].ToString();
        }

        public bool UpdateMatKhau(string TenDangNhap, string MatKhau)
        {
            string sql = "Update TAIKHOAN SET Password='" + MatKhau + "' where Username = '" + TenDangNhap + "'";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
    }
}
