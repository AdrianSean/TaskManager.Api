using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Web.Common
{
    public sealed class NinjectDependancyResolver : IDependencyResolver
    {
        private readonly IKernel _container;

        public NinjectDependancyResolver(IKernel container)
        {
            _container = container;
        }

        public IKernel Container { get { return _container; } }


        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }


        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
