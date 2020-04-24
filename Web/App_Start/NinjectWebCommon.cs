[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
	using System;
	using System.Web;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using Web.Common.IDataControllers;
	using DataControllers.DataControllers;

	//Prova

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Start applicazione
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// STOP applicazioni.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creazione del kernel
		/// </summary>
		/// <returns>Kernel creato.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel(new NinjectSettings { UseReflectionBasedInjection = true });
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		///// <summary>
		///// Caricamento o registrazione moduli NOSTRI
		///// </summary>
		///// <param name="kernel">Kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
       
		 
            kernel.Bind<IMuseoDataControllers>().To<MuseoDataController>();
        }
	}
}