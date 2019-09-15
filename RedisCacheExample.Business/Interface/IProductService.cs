using RedisCacheExample.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisCacheExample.Business.Interface
{
    public interface IProductService
    {
        List<Product> CreateProductListAsync();
    }
}
