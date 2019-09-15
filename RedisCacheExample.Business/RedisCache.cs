using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisCacheExample.Business.Interface;
using RedisCacheExample.Business.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCacheExample.Business
{
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IProductService _productService;

        public RedisCache(IDistributedCache distributedCache, IProductService productService)
        {
            _distributedCache = distributedCache;
            _productService = productService;
        }

        public object RedisGet(string cacheKey)
        {
            byte[] result = null;
            result = _distributedCache.Get(cacheKey);
            if (result == null)
            {
                RedisSet(_productService.CreateProductListAsync(), cacheKey);
                result = _distributedCache.Get(cacheKey);
            }

            var pruduct = JsonConvert.DeserializeObject<List<Product>>(Encoding.UTF8.GetString(result));
            return pruduct;
        }

        public bool RedisRemove(string cacheKey)
        {
            _distributedCache.Remove(cacheKey);
            return true;
        }

        public bool RedisSet(List<Product> Model, string cacheKey)
        {
            var cacheKeyResult = _distributedCache.Get(cacheKey);
            if (cacheKeyResult == null)
            {
                if (Model != null || !Model.Any())
                {
                    var data = JsonConvert.SerializeObject(Model);
                    var dataByte = Encoding.UTF8.GetBytes(data);
                    _distributedCache.Set(cacheKey, dataByte);
                    return true;
                }
            }
            return false;
        }
    }
}
