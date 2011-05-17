using System.Data;
using Core.Objetos;

namespace EntityAcessoADados.Repositorios
{
    public class RepositorioDocumento : Repositorio<Documento>
    {
        public RepositorioDocumento(ContextoAcessoADados contexto) : base(contexto)
        {
            this.contexto = contexto;
        }

        public new void Adicionar(Documento item)
        {
            contexto.Volumes.Attach(item.Volume);
            contexto.Set<Documento>().Add(item);
            contexto.SaveChanges();
        }

        public new void Salvar(Documento item)
        {
            contexto.Volumes.Attach(item.Volume);
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}