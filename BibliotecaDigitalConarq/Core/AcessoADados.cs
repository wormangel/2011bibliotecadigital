using System.Data.Entity;
using Core.Objetos;

namespace Core
{
    /// <summary>
    /// Fornece acesso aos dados da Biblioteca.
    /// </summary>
    class AcessoADados : DbContext
    {
        /// <summary>
        /// Recupera todos os Arquivos.
        /// </summary>
        public DbSet<Arquivo> ArquivoContext { get; set; }

        public DbSet<DocumentoArquivistico> DocumentoArquivisticoContext { get; set; }
        public DbSet<Documento> DocumentoContext { get; set; }
        public DbSet<Volume> VolumeContext { get; set; }
        
        public AcessoADados() : base("BibliotecaConarq") { }
    }
}
