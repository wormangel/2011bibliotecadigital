using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using Core.Objetos.Classificacoes;
using EntityAcessoADados.Repositorios;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorGrupos : IGerenciadorGrupos
    {
        private readonly IRepositorio<Grupo> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorGrupos(IRepositorio<Grupo> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorGrupos(IRepositorio<Grupo> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Grupo> RecuperarGrupos()
        {
            _trilhaAuditoria.LogaAcaoDocumento("Recuperado todos os grupos");
            return _repositorio.RecuperarTodos();
        }

        public Grupo RecuperarPorId(long id)
        {
            var grupo = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Recuperado grupo: " + grupo);
            return grupo;
        }

        public void Salvar(Grupo grupo)
        {
            _repositorio.Salvar(grupo);
            _trilhaAuditoria.LogaAcaoDocumento(grupo.Id, -1, "Salvo grupo: " + grupo);
        }

        public void Adicionar(Grupo grupo)
        {
            _repositorio.Adicionar(grupo);
            _trilhaAuditoria.LogaAcaoDocumento(grupo.Id, -1, "Adicionado grupo: " + grupo);
        }

        public void Remover(long id)
        {
            // registrar desativação
            var grupo = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoDocumento(id, -1, "Removido grupo: " + grupo);
        }
    }
}