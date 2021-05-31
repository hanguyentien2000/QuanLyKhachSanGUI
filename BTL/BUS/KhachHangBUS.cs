using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using System.Data;
using BTL.DTO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

namespace BTL.BUS
{
    class KhachHangBUS
    {
        DataProvider data = new DataProvider();
        public DataTable layTTKhachHang()
        {
            string sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email, " +
                "CASE WHEN GioiTinhKH = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhKH, DiaChiKhachHang, CMND, " +
                "CASE WHEN TrangThai = 0 THEN N'BAD' " +
                "ELSE 'GOOD' END AS TrangThai FROM KhachHang"; 
            return data.GetTable(sql);
        }

        public bool themTTKhachHang(string hoTen, string soDT, string ngaySinh, string email, int gioiTinh, string diaChi, string cmnd, int trangThai)
        {
            string sql = "INSERT INTO KhachHang VALUES (N'" + hoTen + "','" + soDT + "','" + ngaySinh + "','" + email + "'," + gioiTinh + ",N'" + diaChi + "','" + cmnd + "'," + trangThai + ")";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public bool thayDoiTTKhachHang(int maKH, string hoTen, string soDT, string ngaySinh, string email, int gioiTinh, string diaChi, string cmnd, int trangThai)
        {
            string sql = "UPDATE KhachHang SET TenKhachHang=N'" + hoTen + "',SDT='" + soDT + "',NgaySinhKH='" + ngaySinh + "',Email=N'" + email + "',GioiTinhKH=" + gioiTinh + ",DiaChiKhachHang=N'" + diaChi + "',CMND='" + cmnd + "', TrangThai=" + trangThai + " WHERE MaKhachHang=" + maKH;
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public bool xoaTTKhachHang(int maKH)
        {
            string sql = "DELETE KhachHang WHERE MaKhachHang=" + maKH + "";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public DataTable timKiemTTKhachHang(string tuKhoa)
        {
            string sql = "";
            if (tuKhoa == "Nam")
            {
                tuKhoa = "0";
                sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email, " +
                "CASE WHEN GioiTinhKH = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhKH, DiaChiKhachHang, CMND, " +
                "CASE WHEN TrangThai = 0 THEN 'BAD' " +
                "ELSE 'GOOD' END AS TrangThai " +
                "FROM KhachHang WHERE ( GioiTinhKH LIKE N'%" + tuKhoa + "%') ";
            }
            else if (tuKhoa == "Nữ")
            {
                tuKhoa = "1";
                sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email, " +
                "CASE WHEN GioiTinhKH = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhKH, DiaChiKhachHang, CMND, " +
                "CASE WHEN TrangThai = 0 THEN 'BAD' " +
                "ELSE 'GOOD' END AS TrangThai " +
                "FROM KhachHang WHERE ( GioiTinhKH LIKE N'%" + tuKhoa + "%') ";
            }
            else if (tuKhoa == "BAD")
            {
                tuKhoa = "0";
                sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email, " +
                "CASE WHEN GioiTinhKH = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhKH, DiaChiKhachHang, CMND, " +
                "CASE WHEN TrangThai = 0 THEN 'BAD' " +
                "ELSE 'GOOD' END AS TrangThai " +
                "FROM KhachHang WHERE ( TrangThai LIKE N'%" + tuKhoa + "%') ";
            }
            else if (tuKhoa == "GOOD")
            {
                tuKhoa = "1";
                sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email, " +
                "CASE WHEN GioiTinhKH = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhKH, DiaChiKhachHang, CMND, " +
                "CASE WHEN TrangThai = 0 THEN 'BAD' " +
                "ELSE 'GOOD' END AS TrangThai " +
                "FROM KhachHang WHERE ( TrangThai LIKE N'%" + tuKhoa + "%') ";
            }
            else
            {
                sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email, " +
                "CASE WHEN GioiTinhKH = 0 THEN N'Nam' " +
                "ELSE N'Nữ' END AS GioiTinhKH, DiaChiKhachHang, CMND, " +
                "CASE WHEN TrangThai = 0 THEN 'BAD' " +
                "ELSE 'GOOD' END AS TrangThai " +
                "FROM KhachHang WHERE ( MaKhachHang LIKE '%" + tuKhoa + "%') OR ( TenKhachHang LIKE N'%" + tuKhoa + "%') OR " +
                "( SDT LIKE '%" + tuKhoa + "%') OR ( NgaySinhKH LIKE '%" + tuKhoa + "%') OR " +
                "( Email LIKE N'%" + tuKhoa + "%') OR ( GioiTinhKH LIKE N'%" + tuKhoa + "%') OR ( DiaChiKhachHang LIKE N'%" + tuKhoa + "%') OR " +
                "( CMND LIKE '%" + tuKhoa + "%')";
            }
            return data.GetTable(sql);
        }
        public KhachHangDTO getKhachHang(string tuKhoa)
        {
            KhachHangDTO kh = new KhachHangDTO();
            string sql = "";
                sql = "SELECT MaKhachHang, TenKhachHang, SDT, NgaySinhKH, Email,GioiTinhKH " +
               ",DiaChiKhachHang, CMND " +
                "FROM KhachHang WHERE ( MaKhachHang = '" + tuKhoa + "') OR ( CMND = N'" + tuKhoa +"') ";
           
           SqlConnection conn = data.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
           
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if(reader.Read())
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
             }
                    return kh;
        }
        public int kiemTraKhachHangDatPhong(int maKH)
        {
            string sql = "SELECT dbo.kiemTraKhachHangDP(" + maKH + ") AS 'checkKH'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["checkKH"].ToString());
        }

        public int kiemTraCMND(string cmnd)
        {
            string sql = "SELECT dbo.kiemTraCMNDKH('" + cmnd + "') AS 'checkCMNDKH'";
            return Int32.Parse(data.ExecuteQuery(sql).Rows[0]["checkCMNDKH"].ToString());
        }
    }
}
