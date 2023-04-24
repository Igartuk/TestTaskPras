using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasBLL.Interfaces;
using TestTaskPrasBLL.Services;
using TestTaskPrasDAL;

namespace TestTaskPrasBLL
{
    public static class BLLDIExtention
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.RegisterDALDependencies();
            services.AddScoped<IPostService, PostService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
                
        }
    }
}
