//using System;
//using Autofac;
//using Autofac.Configuration;
//using Autofac.Core;
//using Org.BouncyCastle.Crypto.Tls;
//using todo.Data;
//using todo.Controllers;
//using System.Reflection;
//using System.Linq;

//namespace todo
//{
//    public class ContainerConfig
//    {
//        public static IContainer Configure()
//        {
//            //// Add the configuration to the ConfigurationBuilder.
//            //var config = new ConfigurationBuilder();
//            //// config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
//            //// config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
//            //config.AddXmlFile("autofac.xml");

//            //// Register the ConfigurationModule with Autofac.
//            //var module = new ConfigurationModule(config.Build());
//            //var builder = new ContainerBuilder();
//            //builder.RegisterModule(module);
//            //return builder.Build();

//            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddXmlFile("autofac.xml");
//            var configuration = configBuilder.Build();
//            //var containerBuilder = new ContainerBuilder();
//            var configModule = new ConfigurationModule(configuration);
//            //containerBuilder.RegisterModule(configModule);
//            //return containerBuilder.Build();

//            //// Create your builder.
//            //var builder = new ContainerBuilder();

//            //// Usually you're only interested in exposing the type
//            //// via its interface:
//            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(todo)))
//            //    .Where(t => t.Namespace.Contains("Data"))
//            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

//            //builder.RegisterType<AppDbContext>().As<IAppDbContext>();

//        }
//    }
//}