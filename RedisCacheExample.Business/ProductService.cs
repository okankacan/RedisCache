using RedisCacheExample.Business.Interface;
using RedisCacheExample.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisCacheExample.Business
{
    public class ProductService : IProductService
    {
        public List<Product> CreateProductListAsync()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Id = 1,
                Name = "Samsung Galaxy Note 8"
              
            });

            products.Add(new Product()
            {
                Id = 2,
                Name = "Samsung Galaxy S8"
               
            });

            products.Add(new Product()
            {
                Id = 3,
                Name = "Apple Iphone 8"
               
            });

            products.Add(new Product()
            {
                Id = 4,
                Name = "Apple Iphone X"
              
            });

            products.Add(new Product()
            {
                Id = 5,
                Name = "Apple iPad Pro"
               

            });

            return  products;
        }
    }
}
