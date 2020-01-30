using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath;
using R5T.Dacia;


namespace R5T.Bedford.Bath
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="BinaryFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBathBinaryFileEqualityComparer(this IServiceCollection services,
            ServiceAction<IHumanOutput> addHumanOutput)
        {
            services
                .AddSingleton<IFileEqualityComparer, BinaryFileEqualityComparer>()
                .RunServiceAction(addHumanOutput)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="BinaryFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IFileEqualityComparer> AddBathBinaryFileEqualityComparerAction(this IServiceCollection services,
            ServiceAction<IHumanOutput> addHumanOutput)
        {
            var serviceAction = new ServiceAction<IFileEqualityComparer>(() => services.AddBathBinaryFileEqualityComparer(addHumanOutput));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="TextFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBathTextFileEqualityComparer(this IServiceCollection services,
            ServiceAction<IHumanOutput> addHumanOutput)
        {
            services
                .AddSingleton<IFileEqualityComparer, TextFileEqualityComparer>()
                .RunServiceAction(addHumanOutput)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="TextFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IFileEqualityComparer> AddBathTextFileEqualityComparerAction(this IServiceCollection services,
            ServiceAction<IHumanOutput> addHumanOutput)
        {
            var serviceAction = new ServiceAction<IFileEqualityComparer>(() => services.AddBathTextFileEqualityComparer(addHumanOutput));
            return serviceAction;
        }
    }
}
