using System.Data.Entity;
using Core.Objetos;

namespace Core
{
    /// <summary>
    /// Fornece acesso aos dados da Biblioteca.
    /// </summary>
    class AcessoADados : DbContext
    {
        public DbSet<Arquivo> ArquivoContext { get; set; }

        public AcessoADados() : base("BibliotecaConarq") { }
    }
}
