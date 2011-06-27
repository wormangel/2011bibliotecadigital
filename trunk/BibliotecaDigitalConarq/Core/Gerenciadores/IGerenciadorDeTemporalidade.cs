using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objetos;

namespace Core.Gerenciadores
{
    public interface IGerenciadorDeTemporalidade
    {
        IQueryable<Temporalidade> RecuperarTemporalidades();
        Temporalidade RecuperarPorId(long id);
        void Adicionar(Temporalidade temporalidade);
        void Salvar(Temporalidade temporalidade);
        void Remover(long id);
    }
}
