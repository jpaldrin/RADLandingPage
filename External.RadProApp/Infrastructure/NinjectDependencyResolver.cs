using DAL.Radio.IRepository;
using DAL.Radio.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace External.RadProApp.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private IKernel Kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            Kernel = kernelParam;

            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Kernel.Bind<ISiteRepository>().To<SiteRepository>();
            Kernel.Bind<IImgRepository>().To<ImgRepository>();
            Kernel.Bind<IEmailRepository>().To<EmailRepository>();
        }
    }
}