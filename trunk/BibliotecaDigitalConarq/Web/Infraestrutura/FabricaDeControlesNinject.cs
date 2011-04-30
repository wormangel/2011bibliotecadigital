using System;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;

namespace Web.Infraestrutura
{
    public class FabricaDeControlesNinject : DefaultControllerFactory
    {
        // "kernel" é a coisa que  pode fornecer instâncias de classes
        private readonly IKernel kernel = new StandardKernel(new ServicosBibliotecaConarq());

        // O ASP.NET MVC chama esse método para pegar o controller para cada request
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext context, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)kernel.Get(controllerType);
        }
        
        // Configura os tipos de abstração de servico que são mapeados em implementações concretas.
        private class ServicosBibliotecaConarq : NinjectModule
        {
            public override void Load()
            {
                //Exemplo

            }
        }
    }
    
    
}