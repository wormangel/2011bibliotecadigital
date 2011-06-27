using System.Linq;
using Core.Objetos;
using Core.Objetos.Classificacoes;

namespace Core.Gerenciadores
{
    public interface IGerenciadorSubgrupos
    {
        void Adicionar(Grupo grupo, Subgrupo subgrupo);
        IQueryable<Subgrupo> RecuperarSubgrupos();
        Subgrupo RecuperarPorId(long id);
        void Salvar(Subgrupo subgrupo);
        void Remover(long id);
    }
}