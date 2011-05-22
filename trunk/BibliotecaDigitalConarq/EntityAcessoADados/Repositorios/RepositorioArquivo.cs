using System.Data.Entity;
using System.Linq;
using Core.Interfaces;
using Core.Objetos;

namespace EntityAcessoADados.Repositorios
{
    public class RepositorioArquivo : Repositorio<Arquivo>, IRepositorioArquivo
    {
        public RepositorioArquivo(DbContext contexto) : base(contexto)
        {
        }

        public IQueryable<Arquivo> BuscaTextual(string query, bool buscaExata)
        {
            return (  (ContextoAcessoADados)contexto  ).Arquivos.FullTextSearch(query, buscaExata);
        }
    }
}
