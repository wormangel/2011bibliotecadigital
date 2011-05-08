using System;
using TrilhaAuditoria.Enums;

namespace TrilhaAuditoria.Objetos
{
    class Log
    {

        // id
        // tipo
        // quem
        // acao
        // quando
        
        private TipoDoLog tipo { get; set; }
        private long id { get; set; }
        private long usuario { get; set; }
        private String acao { get; set; }
        private DateTime data { get; set; }

        public Log(TipoDoLog tipo, long id, long usuario, String acao)
        {
            this.tipo = tipo;
            this.id = id;
            this.usuario = usuario;
            this.acao = acao;
            this.data = DateTime.MaxValue;
        }

        public Log(String acao)
        {
            this.tipo = TipoDoLog.Normal;
            this.acao = acao;
        }

    }
}
