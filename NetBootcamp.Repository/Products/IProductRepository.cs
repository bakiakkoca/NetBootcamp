using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Repository.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task UpdateProductName(string name, int id);


    }
}
