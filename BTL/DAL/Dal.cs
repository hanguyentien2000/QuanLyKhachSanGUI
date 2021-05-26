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
        public SqlConnection GetDBConnection()
        {
            string connString = @"Data Source=DESKTOP-93RPIAO\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True"; //Hưng
            //string connString = @"Data Source=DESKTOP-A5S98G0\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        public void setParameters(SqlCommand cmd, params dynamic[] parameters)
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

        public DataTable ExecuteQuery(String query, object[] parameters = null)
        {
            DataTable table = new DataTable();
            using (GetDBConnection())
            {
                GetDBConnection().Open();
                SqlCommand command = new SqlCommand(query, GetDBConnection());
                if (query != null)
                {
                    Int32 i = 0;
                    String[] queries = query.Split(' ');
                    foreach (String str in queries)
                    {
                        if (str.Contains('@'))
                        {
                            command.Parameters.AddWithValue(str, parameters[i]);
                            i++;
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            return table;
        }

        public DataTable GetTable(string sql, params dynamic[] parameters)
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

        public bool ExecuteNonQuery(string sql, params dynamic[] parameters)
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

        //public bool ExecuteNonQuery(string sql)
        //{
        //    SqlConnection conn = GetDBConnection();
        //    conn.Open();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        cmd.Clone();
        //        return true;
        //    }
        //    catch (SqlException)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();
        //    }
        //}
    }
}
