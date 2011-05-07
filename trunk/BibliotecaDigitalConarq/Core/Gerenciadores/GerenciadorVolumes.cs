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
            return this._repositorio.RecuperarTodos();
        }

        public Volume RecuperarPorId(long id)
        {
            return this._repositorio.RecuperarPorId(id);
        }

        public void Remover(long id)
        {
            this._repositorio.Remover(id);
        }

        public void Atualizar(Volume volume)
        {
            this._repositorio.Salvar(volume);
        }

        public void Criar(Volume volume)
        {
            this._repositorio.Adicionar(volume);
        }
    }
}
