using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Implementation.Repositories;
using Utilities.Implementation.UnitOfWorks;
using Utilities.Interfaces.Repositories;
using Utilities.Interfaces.UnitOfWorks;

namespace Utilities.Configuration.Database
{
    public static class RepositoryExtension
    {
        public static void UseRepository(this IServiceCollection services, Type dbContextType)
        {
            services.AddScoped(typeof(DbContext), dbContextType);
            services.AddScoped(typeof(IUnitOfWorkAsync), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
