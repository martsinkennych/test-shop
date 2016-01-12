using Microsoft.Practices.Unity;
using ShopApp.BL;
using ShopApp.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShopApp.Dependency
{
    public class MyDepResolver : IDependencyResolver
    {
        IUnityContainer container;

        public MyDepResolver()
        {
            container = new UnityContainer();
            container.RegisterType<IContext, GoodRepository>();
            container.RegisterType<IGoodService, GoodService>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}
