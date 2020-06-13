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
            IServiceAction<IHumanOutput> addHumanOutput)
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
        public static IServiceAction<IFileEqualityComparer> AddBathBinaryFileEqualityComparerAction(this IServiceCollection services,
            IServiceAction<IHumanOutput> addHumanOutput)
        {
            var serviceAction = ServiceAction<IFileEqualityComparer>.New(() => services.AddBathBinaryFileEqualityComparer(addHumanOutput));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="TextFileEqualityComparer"/> implementation of <see cref="IFileEqualityComparer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddBathTextFileEqualityComparer(this IServiceCollection services,
            IServiceAction<IHumanOutput> addHumanOutput)
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
            IServiceAction<IHumanOutput> addHumanOutput)
        {
            var serviceAction = ServiceAction<IFileEqualityComparer>.New(() => services.AddBathTextFileEqualityComparer(addHumanOutput));
            return serviceAction;
        }
    }
}
