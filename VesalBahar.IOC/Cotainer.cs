using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VesalBahar.Data.Contexts;

namespace VesalBahar.IOC
{
    public static class Cotainer
    {
        public static IServiceCollection  AddServiceToIoC(this IServiceCollection service, IConfiguration confiquration)
        {
            service.AddDbContext<VesaleBaharContext>(options =>
            {
                options.UseSqlServer(confiquration.GetConnectionString("VesaleBaharConnection"));
            });
            return service;
        }
    }
}
