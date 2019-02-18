namespace MyServices.Web
{
    using System.IO;
    using System.Web;
    using System.Web.Http;
    using Data;
    using Microsoft.Practices.Unity;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            var dataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
            var productRepositoryPath = Path.Combine(dataPath, "products.json");
            var userRepositoryPath = Path.Combine(dataPath, "users.json");
            container.RegisterType<IProductRepository, ProductRepository>(new InjectionConstructor(productRepositoryPath));
            container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(userRepositoryPath));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}