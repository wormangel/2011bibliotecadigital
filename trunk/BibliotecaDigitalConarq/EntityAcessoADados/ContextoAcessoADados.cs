using System.Data.Entity;
using Core.Objetos;
using Core.Objetos.Classificacoes;

namespace EntityAcessoADados
{
    /// <summary>
    /// Contexto de acesso a dados para o Entity Framework. O gerenciador de
    /// acesso a dados utiliza este contexto para realizar suas operações.
    /// </summary>
    public class ContextoAcessoADados : DbContext
    {
        public DbSet<Arquivo> Arquivos { get; set; }

        public DbSet<DocumentoArquivistico> DocumentosArquivisticos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Subclasse> Subclasses { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Subgrupo> Subgrupos { get; set; }
        
        // String de conexão definida no app.config
        public ContextoAcessoADados() : base("BibliotecaConarq")
        {
            Database.SetInitializer(new ContextoInitializer());
        }
    }
}
