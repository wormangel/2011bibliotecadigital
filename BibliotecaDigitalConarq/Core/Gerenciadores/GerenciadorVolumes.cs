using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public class GerenciadorVolumes
    {
        public GerenciadorVolumes(IRepositorio<Volume> repositorio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Volume> RecuperarVolumes()
        {
            throw new NotImplementedException();
        }

        public Volume RecuperarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Volume volume)
        {
            throw new NotImplementedException();
        }

        public void Remover(long id)
        {
            throw new NotImplementedException();
        }
    }
}
