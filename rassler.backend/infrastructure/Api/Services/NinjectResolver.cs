using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

// Source: http://www.strathweb.com/2012/11/asp-net-web-api-and-dependencies-in-request-scope/

namespace rassler.backend.infrastructure.Api.Services
{
    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot ResolutionRoot { get; set; }

        public NinjectScope(IResolutionRoot kernel)
        {
            ResolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            var request = ResolutionRoot.CreateRequest(serviceType, null, new IParameter[0], true, true);
            return ResolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var request = ResolutionRoot.CreateRequest(serviceType, null, new IParameter[0], true, true);
            return ResolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
            var disposable = (IDisposable)ResolutionRoot;
            disposable?.Dispose();
            ResolutionRoot = null;
        }
    }

    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}