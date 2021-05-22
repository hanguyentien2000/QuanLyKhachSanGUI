using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DAL
{
    class Dal
    {
        private SqlConnection GetDBConnection()
        {
            string connString = @"Data Source=DESKTOP-A5S98G0\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        private void setParameters(SqlCommand cmd, params dynamic[] parameters)
        {
            try
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    dynamic para = parameters[i];
                    string index = "@" + i;
                    cmd.Parameters.AddWithValue(index, para);
                }
            }
            catch (SqlException)
            {

            }
        }

        public DataTable Query(string sql, params dynamic[] parameters)
        {
            SqlConnection conn = GetDBConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                setParameters(cmd, parameters);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        public bool ExecuteQuery(string sql, params dynamic[] parameters)
        {
            SqlConnection conn = GetDBConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                setParameters(cmd, parameters);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
