using System.Linq;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public interface IGerenciadorDocumentos
    {
        IQueryable<Documento> RecuperarDocumentos();
        Documento RecuperarPorId(long id);
        void Salvar(Documento documento);
        void Adicionar(Volume volume, Documento documento);
        void Remover(long id);
    }
}