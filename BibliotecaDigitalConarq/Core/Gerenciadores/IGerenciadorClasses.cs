using System.Linq;
using Core.Objetos;
using Core.Objetos.Classificacoes;

namespace Core.Gerenciadores
{
    public interface IGerenciadorClasses
    {
        void Adicionar(Classe doc);
        IQueryable<Classe> RecuperarClasses();
        Classe RecuperarPorId(long id);
        void Salvar(Classe documento);
        void Remover(long id);
    }
}