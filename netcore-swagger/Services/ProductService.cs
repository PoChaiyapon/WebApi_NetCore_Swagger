using netcore_swagger.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_swagger.Services
{
    public class ProductService : IProductService
    {
        public int Add(Products products)
        {
            string sql = "EXEC MYDB..SP_Product @TYPE = 'ADD_PRODUCT' ";
            sql += string.Format(",@Product_code = '{0}'", products.Product_code);
            sql += string.Format(",@Product_name = '{0}'", products.Product_name);
            sql += string.Format(",@Product_type = '{0}'", products.Product_type);
            sql += string.Format(",@Description = '{0}'", products.Description);
            sql += string.Format(",@Create_date = '{0}'", products.Create_date);
            sql += string.Format(",@Enable = '{0}'", products.Enable);
            int retVal = DB.ExecuteCRUDByQuery(sql);
            return retVal;
        }

        public int DelProduct(int id)
        {
            string sql = "EXEC MYDB..SP_Product @TYPE = 'DEL_PRODUCT' ";
            sql += string.Format(",@Id = {0}", id);
            int retVal = DB.ExecuteCRUDByQuery(sql);
            return retVal;
        }

        public Products FindProduct(int id)
        {
            Products products = null;
            string sql = "EXEC MYDB..SP_Product @TYPE = 'GET_PRODUCT' ";
            sql += string.Format(",@Id = {0}", id);
            DataTable dtProduct = DB.ExecuteQuery(sql);
            if(dtProduct != null)
            {
                DataRow dr = dtProduct.Rows[0];
                products = DB.GetProductByRow(dr);
            }

            return products;
        }

        public IEnumerable<Products> GetAll()
        {
            List<Products> products = null;
            DataTable dtProduct = null;
            string sql = "EXEC MYDB..SP_Product @TYPE = 'GET_PRODUCT' ";
            dtProduct = DB.ExecuteQuery(sql);
            if(dtProduct != null)
            {
                products = new List<Products>();
                foreach (DataRow dr in dtProduct.Rows)
                    products.Add(DB.GetProductByRow(dr));
            }
            return products;
        }

        public int UpdateProduct(Products products)
        {
            string sql = "EXEC MYDB..SP_Product @TYPE = 'UPDATE_PRODUCT' ";
            sql += string.Format(",@Id = {0}", products.Id);
            sql += string.Format(",@Product_name = '{0}'", products.Product_name);
            sql += string.Format(",@Product_type = '{0}'", products.Product_type);
            sql += string.Format(",@Description = '{0}'", products.Description);
            sql += string.Format(",@Enable = '{0}'", products.Enable);
            int retVal = DB.ExecuteCRUDByQuery(sql);
            return retVal;
        }
    }
}
