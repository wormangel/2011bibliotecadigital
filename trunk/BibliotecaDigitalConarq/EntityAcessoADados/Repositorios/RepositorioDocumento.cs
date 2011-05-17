using System.Data;
using System.Data.Entity;
using Core.Objetos;

namespace EntityAcessoADados.Repositorios
{
    public class RepositorioDocumento : Repositorio<Documento>
    {
        public RepositorioDocumento(DbContext contexto) : base(contexto)
        {
        }

        public new void Adicionar(Documento item)
        {
            ((ContextoAcessoADados)contexto).Volumes.Attach(item.Volume);
            contexto.Set<Documento>().Add(item);
            contexto.SaveChanges();
        }

        public new void Salvar(Documento item)
        {
            ((ContextoAcessoADados)contexto).Volumes.Attach(item.Volume);
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}