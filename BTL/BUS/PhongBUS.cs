using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using BTL.DTO;
using System.Data;
using static LinqToDB.DataProvider.SqlServer.SqlServerProviderAdapter;
using System.Data.SqlClient;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace BTL.BUS
{
    class PhongBUS
    {
        DataProvider data = new DataProvider();

        public DataTable layTTPhong()
        {
            string sql = "SELECT MaPhong, TenLoaiPhong, " +
                "CASE WHEN TrangThaiPhong = 0 THEN N'Đang sử dụng'" +
                "ELSE N'Trống' END AS TrangThaiPhong " +
                "FROM Phong INNER JOIN LoaiPhong ON Phong.MaLoaiPhong=LoaiPhong.MaLoaiPhong";
            return data.GetTable(sql);
        }

        public bool themTTPhong(int maLoaiPhong, int trangThai, byte[] anhPhong)
        {
            string sql = "INSERT INTO Phong VALUES(" + maLoaiPhong + "," + trangThai + ",@image)";
            if(data.ExecuteNonQueryWithImage(sql, anhPhong))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool thayDoiTTPhong(int maPhong, int maLoaiPhong, int trangThai, byte[] anhPhong)
        {
            string sql = "UPDATE Phong SET MaLoaiPhong=" + maLoaiPhong + ",TrangThaiPhong=1" + trangThai + ", anhPhong=@image WHERE MaPhong=" + maPhong;
            if (data.ExecuteNonQueryWithImage(sql, anhPhong))
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

        public PhongDTO layAnhPhong(int maPhong)
        {
            string sql = "SELECT anhPhong FROM Phong WHERE MaPhong=" + maPhong;
            PhongDTO phong = new PhongDTO();
            phong.AnhPhong = (byte[])data.GetTable(sql).Rows[0].ItemArray[0];
            return phong;
        }
        public Boolean checkPhong(int Ma)
        {
            string sql = "select * from DatPhong where MaPhong =" + Ma + "";
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
    }
}
