using netcore_swagger.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_swagger.Services
{
    public class DB
    {
        private static string connectStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=MYDB;User Id=sa;Password=1234;Integrated Security=True";

        public static int ExecuteCRUDByQuery(string strSql)
        {
            SqlConnection conn = null;
            int iR = 0;
            try
            {
                conn = new SqlConnection(connectStr);
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                conn.Open();
                //execute command
                iR = cmd.ExecuteNonQuery();
            }
            catch { iR = 0; }
            finally
            {
                if (conn.State != 0)
                    conn.Close();
            }
            return iR;
        }

        public static DataTable ExecuteQuery(string strSql)
        {
            SqlConnection conn = null;
            DataTable dt = null;
            try
            {
                conn = new SqlConnection(connectStr);
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.Text;
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Open();
                //fill data
                da.Fill(dt);
                if (!(dt.Rows.Count > 0))
                    dt = null;

            }
            catch { dt = null; }
            finally
            {
                if (conn.State != 0)
                    conn.Close();
            }
            return dt;
        }

        public static Products GetProductByRow(DataRow dr)
        {
            Products products = new Products();
            products.Id = Convert.ToInt32(dr["Id"]);
            products.Product_code = dr["Product_code"].ToString();
            products.Product_name = dr["Product_name"].ToString();
            products.Product_type = dr["Product_type"].ToString();
            products.Description = dr["Description"].ToString();
            products.Create_date = Convert.ToDateTime(dr["Create_date"]);
            products.Modify_date = Convert.ToDateTime(DateTime.Now);
            products.Enable = Convert.ToBoolean(dr["Enable"]);
            return products;
        }

    }
}
