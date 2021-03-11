using netcore_swagger.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_swagger.Services
{
    public interface IProductService
    {
        int Add(Products products);
        IEnumerable<Products> GetAll();

        Products FindProduct(int id);

        int UpdateProduct(Products products);
        int DelProduct(int id);
    }
}
