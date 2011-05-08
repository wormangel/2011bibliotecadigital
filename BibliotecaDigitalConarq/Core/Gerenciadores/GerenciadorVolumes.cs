using System;
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
            this._repositorio = repositorio;
        }

        public IList<Volume> RecuperarVolumes()
        {
            //logger.LogaAcaoVolume(vol.Id, usuario, "Recuperado todos os volumes");
            return this._repositorio.RecuperarTodos();
        }

        public Volume RecuperarPorId(long id)
        {
            //logger.LogaAcaoVolume(vol.Id, usuario, "Volume recuperado");
            return this._repositorio.RecuperarPorId(id);
        }

        public void Remover(long id)
        {
            this._repositorio.Remover(id);
            //logger.LogaAcaoVolume(id, usuario, "Volume removido");
        }

        public void Atualizar(Volume volume)
        {
            this._repositorio.Salvar(volume);
            //logger.LogaAcaoVolume(volume.Id, usuario, "Volume atualizado");
        }

        public void Criar(Volume volume)
        {
            this._repositorio.Adicionar(volume);
            //logger.LogaAcaoVolume(volume.Id, usuario, "Volume criado");
        }
    }
}
