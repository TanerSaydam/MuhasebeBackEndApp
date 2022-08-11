﻿using Core.CorssCuttingConcerns.Caching;
using Core.CorssCuttingConcerns.Caching.Microsoft;
using Core.DataAccess.AutoMapper;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
