using System;
using TrilhaAuditoria.Enums;

namespace TrilhaAuditoria.Objetos
{
    internal class Log
    {
        private TipoDoLog Tipo { get; set; }
        private long Id { get; set; }
        private long Usuario { get; set; }
        private String Acao { get; set; }
        private DateTime Data { get; set; }

        public Log(TipoDoLog tipo, long id, long usuario, String acao)
        {
            Tipo = tipo;
            Id = id;
            Usuario = usuario;
            Acao = acao;
            Data = DateTime.MaxValue;
        }

        public Log(String acao)
        {
            Tipo = TipoDoLog.Normal;
            Acao = acao;
        }
        
    }
}