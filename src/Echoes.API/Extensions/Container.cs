using System;
using Microsoft.Extensions.DependencyInjection;
using Auxo.Core;
using Microsoft.AspNetCore.Http;

namespace Echoes.API
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _httpContextAcessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor) => _httpContextAcessor = httpContextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _httpContextAcessor.HttpContext; 
    }
    
    public class Container : IContainer
    {
        public Container()
        {
        }
        
        public object GetService(Type type) => HttpContext.Current.RequestServices.GetService(type);

        public T GetService<T>() where T : class => HttpContext.Current.RequestServices.GetService<T>();
    }
}