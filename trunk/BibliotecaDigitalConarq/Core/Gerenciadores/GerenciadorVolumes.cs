﻿using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Objetos;
using Core.Repositorios;

namespace Core.Gerenciadores
{
    public class GerenciadorVolumes
    {
        private readonly RepositorioVolume _repositorio;

        public GerenciadorVolumes(RepositorioVolume repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryable<Volume> RecuperarVolumes()
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

        public void Salvar(Volume volume)
        {
            _repositorio.Salvar(volume);
            //logger.LogaAcaoVolume(volume.Id, usuario, "Volume atualizado");
        }

        public void Adicionar(DocumentoArquivistico documentoArquivistico, Volume volume)
        {
            volume.DocumentoArquivistico = documentoArquivistico;
            _repositorio.Adicionar(volume);
            //logger.LogaAcaoVolume(volume.Id, usuario, "Volume criado");
        }
    }
}