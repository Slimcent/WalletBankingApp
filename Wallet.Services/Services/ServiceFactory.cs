﻿using System;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetServices<T>() where T : class
        {
            var newservice = _serviceProvider.GetService(typeof(T));
            return (T)newservice;
        }
    }
}
