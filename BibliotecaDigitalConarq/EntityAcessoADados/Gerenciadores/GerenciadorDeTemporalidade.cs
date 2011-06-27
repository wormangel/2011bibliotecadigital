using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorDeTemporalidade : IGerenciadorDeTemporalidade
    {
        private readonly IRepositorio<Temporalidade> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorDeTemporalidade(IRepositorio<Temporalidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorDeTemporalidade(IRepositorio<Temporalidade> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Temporalidade> RecuperarTemporalidades()
        {
            _trilhaAuditoria.LogaAcaoTemporalidade("Recuperadas todas as entradas da tabela de temporalidade");
            return _repositorio.RecuperarTodos();
        }

        public Temporalidade RecuperarPorId(long id)
        {
            var temporalidade = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoTemporalidade(id, -1, "Recuperada entrada na tabela de temporalidade: " + temporalidade);
            return temporalidade;
        }

        public void Adicionar(Temporalidade temporalidade)
        {
            _repositorio.Adicionar(temporalidade);
            _trilhaAuditoria.LogaAcaoTemporalidade(temporalidade.Id, -1, "Adicionada entrada na tabela de temporalidade: " + temporalidade);
        }

        public void Salvar(Temporalidade temporalidade)
        {
            _repositorio.Salvar(temporalidade);
            _trilhaAuditoria.LogaAcaoTemporalidade(temporalidade.Id, -1, "Salva entrada na tabela de temporalidade: " + temporalidade);
        }

        public void Remover(long id)
        {
            var temporalidade = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoTemporalidade(id, -1, "Removida entrada na tabela de temporalidade: " + temporalidade);
        }
    }
}
