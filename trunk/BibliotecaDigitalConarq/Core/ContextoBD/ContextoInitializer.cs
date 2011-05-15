using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Core.Repositorios;

namespace Core.Repositorios
{
    public class ContextoInitializer : DropCreateDatabaseAlways<ContextoAcessoADados>
    {
    }
}
