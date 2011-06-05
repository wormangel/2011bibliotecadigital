using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Core.Objetos.Classificacoes;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorClasses : IGerenciadorClasses
    {
        private readonly IRepositorio<Classe> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorClasses(IRepositorio<Classe> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorClasses(IRepositorio<Classe> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Classe> RecuperarClasses()
        {
            _trilhaAuditoria.LogaAcaoDocumento("Recuperado todos os documentos");
            return _repositorio.RecuperarTodos();
        }

        public Classe RecuperarPorId(long id)
        {
            var classe = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Recuperado documento: " + classe);
            return classe;
        }

        public void Salvar(Classe classe)
        {
            _repositorio.Salvar(classe);
            _trilhaAuditoria.LogaAcaoDocumento(classe.Id, -1, "Salvo documento: " + classe);
        }

        public void Adicionar(Classe classe)
        {
            _repositorio.Adicionar(classe);
            _trilhaAuditoria.LogaAcaoDocumento(classe.Id, -1, "Adicionado documento: " + classe);
        }

        public void Remover(long id)
        {
            // registrar desativação
            var classe = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Removido documento: " + classe);
        }
    }
}