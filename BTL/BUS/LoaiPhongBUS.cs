using BTL.DAL;
using BTL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DTO;

namespace BTL.BUS
{
    class LoaiPhongBUS
    {
        DataProvider data = new DataProvider();
        public DataTable GetTableLoaiPhong()
        {
            string sql = "Select * from dbo.LoaiPhong";
            return data.GetTable(sql);
        }

        public DataTable SearchLoaiPhong(string searchKey)
        {
            string sql = "Select * from dbo.LoaiPhong where TenLoaiPhong LIKE N'%" + searchKey + "%'";
            return data.GetTable(sql);
        }

        public LoaiPhongDTO GetLoaiPhong(int maLoai)
        {
            string sql = "Select * from dbo.LoaiPhong where MaLoaiPhong = " + maLoai + "";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            LoaiPhongDTO lp = new LoaiPhongDTO();
            lp.MaLoaiPhong = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            lp.TenLoaiPhong = dt.Rows[0].ItemArray[1].ToString();
            lp.SoLuong = int.Parse(dt.Rows[0].ItemArray[2].ToString());
            lp.GiaPhong = int.Parse(dt.Rows[0].ItemArray[3].ToString());
            return lp;
        }

        public void AddLoaiPhong(string tenLoai, int soLuong, int giaPhong)
        {
            string sql = "Insert into LoaiPhong values(N'" + tenLoai + "'," + soLuong + "," + giaPhong + ")";
            data.ExecuteNonQuery(sql);
        }

        public void UpdateLoaiPhong(int maLoai, string tenLoai, int soLuong, int giaPhong)
        {
            string sql = "Update LoaiPhong SET TenLoaiPhong=N'" + tenLoai + "',  SoLuongNguoi =" + soLuong + ", GiaPhong =" + giaPhong + " where MaLoaiPhong = " + maLoai + "";
            data.ExecuteNonQuery(sql);
        }

        public void DeleteLoaiPhong(int maLoai)
        {
            string sql = "Delete from LoaiPhong where MaLoaiPhong ='" + maLoai + "'";
            data.ExecuteNonQuery(sql);
        }
    }
}
