using System;
using Autofac;//not system.componetn model
using todo;
using System.Reflection;
using System.Linq;

namespace todo
{
	public static class ContainerConfig
	{
		public static IContainer Configure()//this methods entire job is to configure the container
		{
			var builder = new ContainerBuilder();//builder=container builder

			builder.RegisterAssemblyTypes(Assembly.Load(nameof(todo)))
				.Where(t => t.Namespace.Contains(nameof(Controllers)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + i.Name));         // register the class
                                                                                                 // whenever you look for an interface Itodocontroller return an instance of todocontroller

            return builder.Build();//container is a place to store the definitions of all the classes we want to instantiate
		}
	}
}

