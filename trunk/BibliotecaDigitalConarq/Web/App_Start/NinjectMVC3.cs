using System.Data.Entity;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using EntityAcessoADados;
using EntityAcessoADados.Gerenciadores;
using EntityAcessoADados.Repositorios;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Mvc;
using Web.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof (NinjectMVC3), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectMVC3), "Stop")]

namespace Web.App_Start
{
    public static class NinjectMVC3
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof (HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepositorio<DocumentoArquivistico>>().To<Repositorio<DocumentoArquivistico>>();
            kernel.Bind<IRepositorio<Documento>>().To<RepositorioDocumento>();
            kernel.Bind<IRepositorio<Volume>>().To<RepositorioVolume>();
            kernel.Bind<IRepositorio<Arquivo>>().To<Repositorio<Arquivo>>();
            kernel.Bind<IFachadaGerenciadores>().To<FachadaGerenciadores>();
            kernel.Bind<IGerenciadorArquivos>().To<GerenciadorArquivos>();
            kernel.Bind<IGerenciadorDocumentosArquivisticos>().To<GerenciadorDocumentosArquivisticos>();
            kernel.Bind<IGerenciadorDocumentos>().To<GerenciadorDocumentos>();
            kernel.Bind<IGerenciadorVolumes>().To<GerenciadorVolumes>();
            kernel.Bind<DbContext>().To<ContextoAcessoADados>().InRequestScope();
        }
    }
}