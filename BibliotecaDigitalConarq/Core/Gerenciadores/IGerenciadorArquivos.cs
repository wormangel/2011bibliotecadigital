using System.IO;
using System.Linq;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public interface IGerenciadorArquivos
    {
        IQueryable<Arquivo> RecuperarArquivos();
        Arquivo RecuperarPorId(long id);
        void Salvar(Arquivo arquivo);
        void Adicionar(Arquivo arquivo, Stream conteudo);
        void Remover(long id);
        void Atualizar(Arquivo arquivo);
    }
}
