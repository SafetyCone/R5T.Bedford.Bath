using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.Bedford.Bath
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="BinaryFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBathBinaryFileEqualityComparer(this IServiceCollection services)
        {
            services.AddSingleton<IFileEqualityComparer, BinaryFileEqualityComparer>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="BinaryFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IFileEqualityComparer> AddBathBinaryFileEqualityComparerAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IFileEqualityComparer>(() => services.AddBathBinaryFileEqualityComparer());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="TextFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBathTextFileEqualityComparer(this IServiceCollection services)
        {
            services.AddSingleton<IFileEqualityComparer, TextFileEqualityComparer>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="TextFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IFileEqualityComparer> AddBathTextFileEqualityComparerAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IFileEqualityComparer>(() => services.AddBathTextFileEqualityComparer());
            return serviceAction;
        }
    }
}
