using Fetch_Colors.Helpers;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Fetch_Colors
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IApiHelper, ApiHelper>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}