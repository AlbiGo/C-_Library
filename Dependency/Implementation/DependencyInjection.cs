using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dependency.Implementation
{
    /// <summary>
    /// Infrastructure that is used to register classes for dependency injection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DependencyInjection<T> where T : class
    {
        //private MathDBContext<T>? _mathDBContext;
        //private Repositories<T>? _repositories;
        //private Services<T>? _services;
        private static ServiceCollection _serviceCollection;
        ////Inject Repositories
        //public Repositories<T> DbIBudRepos => _repositories ??= new Repositories<T>(this);

        ////Inject Services
        //public Services<T> DbIServices => _services ??= new Services<T>(this);

        ////Inject Database Context
        //public MathDBContext<T> MathDBContext => _mathDBContext ?? new MathDBContext<T>();

        /// <summary>
        /// Create dependency instance
        /// </summary>
        /// <returns> Create dependency instance</returns>
        public static void InitializeDI()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddScoped<MathDBContext>();
            _serviceCollection.AddScoped<IMathRepo, MathRepo>();
            _serviceCollection.AddScoped<IMathService, MathService>();
        }

        public static dynamic GetService()
        {
            //Initialize DI
            InitializeDI();

            // Build the service provider
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            // Resolve the consumer class
            var _service = serviceProvider.GetRequiredService<T>();

            return _service;
        }

    }

    ///// <summary>
    ///// Repositories
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public class Repositories<T> where T : class
    //{
    //    private DependencyInjection<T> _DependencyInjection { get; }

    //    public Repositories(DependencyInjection<T> DependencyInjection) => _DependencyInjection = DependencyInjection;

    //    #region Repositories

    //    public IMathRepo<T> MathRepository => new MathRepo<T>(_DependencyInjection.MathDBContext);

    //    #endregion
    //}

    ///// <summary>
    ///// Services
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public class Services<T> where T : class
    //{
    //    private DependencyInjection<T> _DependencyInjection { get; }

    //    public Services(DependencyInjection<T> DependencyInjection)
    //    {
    //        _DependencyInjection = DependencyInjection;
    //    }

    //    #region Services

    //    public IMathService<T> MathService => new MathService<T>(_DependencyInjection.DbIBudRepos.MathRepository);

    //    #endregion
    //}
}
