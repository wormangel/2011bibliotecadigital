using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;

namespace EntityAcessoADados.Gerenciadores
{
    public class GerenciadorVolumes : IGerenciadorVolumes
    {
        private readonly IRepositorio<Volume> _repositorio;
        private readonly ILogger _trilhaAuditoria;

        public GerenciadorVolumes(IRepositorio<Volume> repositorio)
        {
            _repositorio = repositorio;
        }

        public GerenciadorVolumes(IRepositorio<Volume> repositorio, ILogger trilhaAuditoria)
        {
            _repositorio = repositorio;
            _trilhaAuditoria = trilhaAuditoria;
        }

        public IQueryable<Volume> RecuperarVolumes()
        {
            _trilhaAuditoria.LogaAcaoVolume("Recuperado todos os volumes.");
            return _repositorio.RecuperarTodos();
        }

        public Volume RecuperarPorId(long id)
        {
            var volume = _repositorio.RecuperarPorId(id);
            _trilhaAuditoria.LogaAcaoVolume(id, -1, "Recuperado volume: " + volume);
            return volume;
        }

        public void Remover(long id)
        {
            var volume = RecuperarPorId(id);
            _repositorio.Remover(id);
            _trilhaAuditoria.LogaAcaoVolume(id, -1, "Removido volume: " + volume);
        }

        public void Salvar(Volume volume)
        {
            _repositorio.Salvar(volume);
            _trilhaAuditoria.LogaAcaoVolume(volume.Id, -1, "Salvo volume: " + volume);
        }

        public void Adicionar(DocumentoArquivistico documentoArquivistico, Volume volume)
        {
            volume.DocumentoArquivistico = documentoArquivistico;
            _repositorio.Adicionar(volume);
            _trilhaAuditoria.LogaAcaoVolume(volume.Id, -1, "Adicionado volume: " + volume);
        }
    }
}