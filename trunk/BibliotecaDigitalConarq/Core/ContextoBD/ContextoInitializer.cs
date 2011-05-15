using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Core.ContextoBD
{
    public class ContextoInitializer : DropCreateDatabaseIfModelChanges<ContextoAcessoADados>
    {
    }
}
