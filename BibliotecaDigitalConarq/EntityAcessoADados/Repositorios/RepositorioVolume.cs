using System.Data;
using Core.Objetos;

namespace EntityAcessoADados.Repositorios
{
    public class RepositorioVolume : Repositorio<Volume>
    {
        protected new readonly ContextoAcessoADados contexto;

        public RepositorioVolume(ContextoAcessoADados contexto) : base(contexto)
        {
            this.contexto = contexto;
        }

        public new void Adicionar(Volume item)
        {
            contexto.DocumentosArquivisticos.Attach(item.DocumentoArquivistico);
            contexto.Set<Volume>().Add(item);
            contexto.SaveChanges();
        }

        public new void Salvar(Volume item)
        {
            contexto.Set<Volume>().Attach(item);
            contexto.DocumentosArquivisticos.Attach(item.DocumentoArquivistico);
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}