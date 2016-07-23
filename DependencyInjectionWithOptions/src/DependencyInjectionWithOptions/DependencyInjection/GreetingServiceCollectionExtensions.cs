﻿using DependencyInjectionWithOptions;
using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GreetingServiceCollectionExtensions
    {
        public static IServiceCollection AddGreetingService(this IServiceCollection collection, Action<GreetingServiceOptions> setupAction)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            collection.Configure(setupAction);
            return collection.AddTransient<IGreetingService, GreetingService>();
        }

        public static IServiceCollection AddGreetingService(this IServiceCollection collection, IConfiguration config)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (config == null) throw new ArgumentNullException(nameof(config));


            collection.Configure<GreetingServiceOptions>(config);
            return collection.AddTransient<IGreetingService, GreetingService>();
        }
    }
}
