using System.Linq;
using Core.Objetos;
using Core.Objetos.Classificacoes;

namespace Core.Gerenciadores
{
    public interface IGerenciadorSubclasses
    {
        void Adicionar(Classe classe, Subclasse subclasse);
        IQueryable<Subclasse> RecuperarSubclasses();
        Subclasse RecuperarPorId(long id);
        void Salvar(Subclasse subclasse);
        void Remover(long id);
    }
}