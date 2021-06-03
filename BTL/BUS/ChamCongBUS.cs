using BTL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BTL.DTO;
using System.Data.SqlClient;

namespace BTL.BUS
{
    class ChamCongBUS
    {
        DataProvider data = new DataProvider();
        public DataTable getChamCongByMaNV(int manv)
        {
            string sql = "SELECT * FROM ChamCong WHERE MaNhanVien = '" + manv.ToString().Trim() + "'";
            return data.GetTable(sql);
        }

        public bool checkChamCongByMaNVandNgay(int manv, String ngay)
        {
            string sql = "SELECT * FROM ChamCong WHERE MaNhanVien = '" + manv + "' AND NgayChamCong = '" + ngay + "'";
            DataTable check = data.GetTable(sql);
            if (check.Rows.Count==0)
                return true;
            else
                return false;
        }
        public bool insertChamCongByMaNVandNgay(int manv, String ngay)
        {
            string sql = "INSERT INTO ChamCong VALUES ('" + manv + "', '" + ngay + "')";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
        public DataTable getChamCongByMaNVAndDate(int manv, string date1, string date2)
        {
            string sql = "SELECT * FROM ChamCong WHERE MaNhanVien = '" + manv.ToString().Trim() + "'" +
                " AND NgayChamCong >= '" + date1 + "' AND NgayChamCong <= '" + date2 + "'";
            return data.GetTable(sql);
        }
        public int getCountChamCongByMaNVAndDate(int manv, string date1, string date2)
        {
            string sql = "SELECT COUNT(*) AS SOBUOI FROM ChamCong WHERE MaNhanVien = '" + manv.ToString().Trim() + "'" +
                " AND NgayChamCong >= '" + date1 + "' AND NgayChamCong <= '" + date2 + "'";
            return Int32.Parse(new DataProvider().ExecuteQuery(sql).Rows[0]["SOBUOI"].ToString());
        }
        public int getCountChamCongByMaNV(int manv)
        {
            string sql = "SELECT COUNT(*) AS SOBUOI FROM ChamCong WHERE MaNhanVien = '" + manv.ToString().Trim() + "'";
            return Int32.Parse(new DataProvider().ExecuteQuery(sql).Rows[0]["SOBUOI"].ToString());
        }
        public bool deleteChamCongByMaNV(int manv)
        {
            string sql = "DELETE FROM ChamCong WHERE MaNhanVien = '" + manv.ToString().Trim() + "'";
            if (data.ExecuteNonQuery(sql))
                return true;
            else
                return false;
        }
    }
}
