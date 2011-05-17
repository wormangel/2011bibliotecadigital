using System.Linq;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public interface IGerenciadorVolumes
    {
        IQueryable<Volume> RecuperarVolumes();
        Volume RecuperarPorId(long id);
        void Remover(long id);
        void Salvar(Volume volume);
        void Adicionar(DocumentoArquivistico documentoArquivistico, Volume volume);
    }
}