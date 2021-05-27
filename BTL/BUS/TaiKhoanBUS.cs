using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using BTL.DTO;


namespace BTL.BLL
{
    class TaiKhoanBUS
    {
        DataProvider data = new DataProvider();
        public DataTable GetTableTaiKhoan()
        {
            string sql = "Select * from dbo.TAIKHOAN";
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
            tk.Username = dt.Rows[0].ItemArray[0].ToString();
            tk.Password = dt.Rows[0].ItemArray[1].ToString();
            //tk.LoaiTaiKhoan = dt.Rows[0].ItemArray[2].ToString();
            tk.MaNhanVien = int.Parse(dt.Rows[0].ItemArray[3].ToString());
            return tk;
        }

        public void AddTaiKhoan(string TenDangNhap, string MatKhau, int LoaiTaiKhoan, int MaNV)
        {
            string sql = "Insert into dbo.TAIKHOAN values('" + TenDangNhap + "','" + MatKhau + "','" + LoaiTaiKhoan + "','" + MaNV + "')";
            data.ExecuteNonQuery(sql);
        }
    }
}
