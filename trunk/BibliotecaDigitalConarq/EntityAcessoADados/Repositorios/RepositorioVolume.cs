using System.Data;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using Core.Objetos;

namespace EntityAcessoADados.Repositorios
{
    public class RepositorioVolume : Repositorio<Volume>
    {
        public RepositorioVolume(DbContext contexto) : base(contexto)
        {
        }

        public new void Adicionar(Volume item)
        {
            ((ContextoAcessoADados)contexto).DocumentosArquivisticos.Attach(item.DocumentoArquivistico);
            contexto.Set<Volume>().Add(item);
            contexto.SaveChanges();
        }

        public new void Salvar(Volume item)
        {
            ((ContextoAcessoADados)contexto).DocumentosArquivisticos.Attach(item.DocumentoArquivistico);
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}