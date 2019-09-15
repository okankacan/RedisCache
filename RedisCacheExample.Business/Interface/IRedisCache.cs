using RedisCacheExample.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCacheExample.Business.Interface
{
   public  interface IRedisCache
    {
        bool RedisSet(List<Product> Model, string cacheKey);
        object RedisGet(string cacheKey);

        bool RedisRemove(string cacheKey);
    }
}
