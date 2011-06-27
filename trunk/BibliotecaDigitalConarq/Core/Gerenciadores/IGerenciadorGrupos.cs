using System.Linq;
using Core.Objetos;
using Core.Objetos.Classificacoes;

namespace Core.Gerenciadores
{
    public interface IGerenciadorGrupos
    {
        void Adicionar(Subclasse subclasse, Grupo grupo);
        IQueryable<Grupo> RecuperarGrupos();
        Grupo RecuperarPorId(long id);
        void Salvar(Grupo grupo);
        void Remover(long id);
    }
}