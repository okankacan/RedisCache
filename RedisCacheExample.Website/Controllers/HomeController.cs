using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisCacheExample.Business.Interface;
using RedisCacheExample.Business.Models;
using RedisCacheExample.Website.Models;

namespace RedisCacheExample.Website.Controllers
{
    public class HomeController : Controller
    {

   
        private readonly IRedisCache _redisCache;

        public HomeController( IRedisCache redisCache)
        {
       
            _redisCache = redisCache;
        }

        public IActionResult Index()
        {
            var result = (List<Product>)_redisCache.RedisGet("ProductCache"); 
            return View(result);
        }
        
        public IActionResult About()
        {
            var result = _redisCache.RedisRemove("ProductCache");
            return View();
        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
