using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Core.Objetos.Classificacoes;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorSubclasses : IGerenciadorSubclasses
    {
        private readonly IRepositorio<Subclasse> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorSubclasses(IRepositorio<Subclasse> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorSubclasses(IRepositorio<Subclasse> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Subclasse> RecuperarSubclasses()
        {
            _trilhaAuditoria.LogaAcaoDocumento("Recuperado todos as subclasses");
            return _repositorio.RecuperarTodos();
        }

        public Subclasse RecuperarPorId(long id)
        {
            var subclasse = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Recuperado subclasse: " + subclasse);
            return subclasse;
        }

        public void Salvar(Subclasse subclasse)
        {
            _repositorio.Salvar(subclasse);
            _trilhaAuditoria.LogaAcaoDocumento(subclasse.Id, -1, "Salvo subclasse: " + subclasse);
        }

        public void Adicionar(Classe classe, Subclasse subclasse)
        {
            subclasse.Classe = classe;
            _repositorio.Adicionar(subclasse);
            _trilhaAuditoria.LogaAcaoDocumento(subclasse.Id, -1, "Adicionado subclasse: " + subclasse);
        }

        public void Remover(long id)
        {
            // registrar desativação
            var subclasse = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Removido subclasse: " + subclasse);
        }
    }
}