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
    class TaiKhoanBLL
    {
        DataProvider da = new DataProvider();
        private List<TaiKhoanDTO> ToList(DataTable dt)
        {
          
            List<TaiKhoanDTO> results = new List<TaiKhoanDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoanDTO user = new TaiKhoanDTO();
                user.Username = "";
                user.Password = "";
                user.Quantri = true;
                user.MaNV = 0;
      
                user.Username = dt.Rows[i].ItemArray[0].ToString();
                user.Password = dt.Rows[i].ItemArray[1].ToString();
                //user.Quantri = dt.Rows[i].ItemArray[2].ToString() ? true : false;
                user.MaNV = int.Parse(dt.Rows[i].ItemArray[3].ToString());
                results.Add(user);
            }
            return results;
        }
        public bool UpdatePassword(string password,string username)
        {
            String sql = "Update TaiKhoan set Password = @'"+ password +"'";
            return da.ExecuteNonQuery(sql, password);
        }
    }
}
