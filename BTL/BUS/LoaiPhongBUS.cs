using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL.DAL;
using System.Data;

namespace BTL.BUS
{
    class LoaiPhongBUS
    {
        DataProvider data = new DataProvider();

        public DataTable layTTLoaiPhong()
        {
            string sql = "SELECT * FROM LoaiPhong";
            return data.GetTable(sql);
        }
    }
}
