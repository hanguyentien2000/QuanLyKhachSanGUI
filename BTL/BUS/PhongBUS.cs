using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using System.Data;

namespace BTL.BUS
{
    class PhongBUS
    {
        DataProvider data = new DataProvider();

        public DataTable layTTPhong()
        {
            string sql = "SELECT MaPhong, TenLoaiPhong, " +
                "CASE WHEN TrangThaiPhong = 0 THEN N'Đang sử dụng' " +
                "ELSE N'Trống' END AS TrangThaiPhong " +
                "FROM Phong INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong";
            return data.GetTable(sql);
        }

        public bool themTTPhong(int maLoaiPhong, int trangThai)
        {
            string sql = "INSERT INTO Phong VALUES(" + maLoaiPhong + "," + trangThai + ")";
            if(data.ExecuteNonQuery(sql))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool thayDoiTTPhong(int maPhong, int maLoaiPhong, int trangThai)
        {
            string sql = "UPDATE Phong SET MaLoaiPhong=" + maLoaiPhong + ",TrangThaiPhong=" + trangThai + " WHERE MaPhong=" + maPhong;
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool xoaTTPhong(int maPhong)
        {
            string sql = "DELETE Phong WHERE MaPhong=" + maPhong;
            if (data.ExecuteNonQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable timKiemTTPhong(string tuKhoa)
        {
            string sql = "";
            if(tuKhoa == "Trống")
            {
                tuKhoa = "0";
                sql = "SELECT MaPhong, TenLoaiPhong, " +
                "CASE WHEN TrangThaiPhong = 0 THEN N'Đang sử dụng' " +
                "ELSE N'Trống' END AS TrangThaiPhong " +
                "FROM Phong INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                "WHERE ( TrangThaiPhong LIKE N'%" + tuKhoa + "%')";
            } else if(tuKhoa == "Đang sử dụng")
            {
                tuKhoa = "1";
                sql = "SELECT MaPhong, TenLoaiPhong, " +
                "CASE WHEN TrangThaiPhong = 0 THEN N'Đang sử dụng' " +
                "ELSE N'Trống' END AS TrangThaiPhong " +
                "FROM Phong INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                "WHERE ( TrangThaiPhong LIKE '%" + tuKhoa + "%') ";
            } else
            {
                sql = "SELECT MaPhong, TenLoaiPhong, " +
                "CASE WHEN TrangThaiPhong = 0 THEN N'Đang sử dụng' " +
                "ELSE N'Trống' END AS TrangThaiPhong " +
                "FROM Phong INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                "WHERE ( MaPhong LIKE '%" + tuKhoa + "%') OR ( TenLoaiPhong LIKE N'%" + tuKhoa + "%')";
            }
            return data.GetTable(sql);
        }
        public int kiemTraPhongDat(int maPhong)
        {
            string sql = "SELECT dbo.kiemTraPhongDat(" + maPhong + ") AS 'checkPhong'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["checkPhong"].ToString());
        }
    }
}
