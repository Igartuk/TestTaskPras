using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasDAL.Interfaces;
using TestTaskPrasDAL.Models;
using TestTaskPrasDAL.Models.Entities;
using TestTaskPrasDAL.Repositories;

namespace TestTaskPrasDAL
{
    public static class DalDIExtention
    {
        public static void RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IPostRepository, PostRepository>();
            
            
        }

        
    }
}
