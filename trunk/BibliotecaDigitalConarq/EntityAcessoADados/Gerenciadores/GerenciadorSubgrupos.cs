using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Core.Objetos.Classificacoes;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorSubgrupos : IGerenciadorSubgrupos
    {
        private readonly IRepositorio<Subgrupo> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorSubgrupos(IRepositorio<Subgrupo> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorSubgrupos(IRepositorio<Subgrupo> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Subgrupo> RecuperarSubgrupos()
        {
            _trilhaAuditoria.LogaAcaoDocumento("Recuperado todos os subgrupos");
            return _repositorio.RecuperarTodos();
        }

        public Subgrupo RecuperarPorId(long id)
        {
            var subgrupo = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Recuperado subgrupo: " + subgrupo);
            return subgrupo;
        }

        public void Salvar(Subgrupo subgrupo)
        {
            _repositorio.Salvar(subgrupo);
            _trilhaAuditoria.LogaAcaoDocumento(subgrupo.Id, -1, "Salvo subgrupo: " + subgrupo);
        }

        public void Adicionar(Grupo grupo, Subgrupo subgrupo)
        {
            subgrupo.Grupo = grupo;
            _repositorio.Adicionar(subgrupo);
            _trilhaAuditoria.LogaAcaoDocumento(subgrupo.Id, -1, "Adicionado subgrupo: " + subgrupo);
        }

        public void Remover(long id)
        {
            // registrar desativação
            var subgrupo = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Removido subgrupo: " + subgrupo);
        }
    }
}