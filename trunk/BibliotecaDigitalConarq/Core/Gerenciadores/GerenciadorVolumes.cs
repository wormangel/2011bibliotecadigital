using System.Collections.Generic;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorVolumes
    {
        private readonly IRepositorio<Volume> _repositorio;

        public GerenciadorVolumes(IRepositorio<Volume> repositorio)
        {
            _repositorio = repositorio;
        }

        public IList<Volume> RecuperarVolumes()
        {
            //logger.LogaAcaoVolume(vol.Id, usuario, "Recuperado todos os volumes");
            return _repositorio.RecuperarTodos();
        }

        public Volume RecuperarPorId(long id)
        {
            //logger.LogaAcaoVolume(vol.Id, usuario, "Volume recuperado");
            return _repositorio.RecuperarPorId(id);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
            //logger.LogaAcaoVolume(id, usuario, "Volume removido");
        }

        public void Atualizar(Volume volume)
        {
            _repositorio.Salvar(volume);
            //logger.LogaAcaoVolume(volume.Id, usuario, "Volume atualizado");
        }

        public void Criar(Volume volume)
        {
            _repositorio.Adicionar(volume);
            //logger.LogaAcaoVolume(volume.Id, usuario, "Volume criado");
        }
    }
}