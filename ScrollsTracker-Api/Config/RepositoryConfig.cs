﻿using Microsoft.EntityFrameworkCore;
using ScrollsTracker.Api.Repository;
using ScrollsTracker.Domain.Interfaces.Repository;
using ScrollsTracker.Infra.Repository.Context;

namespace ScrollsTracker.Api.Config
{
    public static class RepositoryConfig
    {
        public static void AddConfigRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IObraRepository, ObraRepository>();
        }
    }
}
