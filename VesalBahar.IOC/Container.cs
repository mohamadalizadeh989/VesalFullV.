using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VesalBahar.Core.Interfaces;
using VesalBahar.Core.Services;
using VesalBahar.Core.Utilities.Security;
using VesalBahar.Data.Contexts;

namespace VesalBahar.IOC
{
    public static class Container
    {
        public static IServiceCollection AddServiceToIoC(this IServiceCollection service, IConfiguration confiquration)
        {
            service.AddDbContext<VesaleBaharContext>(options =>
            {
                options.UseSqlServer(confiquration.GetConnectionString("VesaleBaharConnection"));
            });
            service.AddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));
            service.AddTransient<ISecurityService, SecurityService>();
            service.AddTransient<IArticleService, ArticleService>();
            service.AddTransient<IArticleGroupService, ArticleGroupService>();

            return service;
        }
    }
}
