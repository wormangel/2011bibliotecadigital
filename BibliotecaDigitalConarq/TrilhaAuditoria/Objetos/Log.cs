using System;
using TrilhaAuditoria.Enums;

namespace TrilhaAuditoria.Objetos
{
    public class Log
    {
        public TipoDoLog Tipo { get; set; }
        public long Id { get; set; }
        public long Usuario { get; set; }
        public String Acao { get; set; }
        public DateTime Data { get; set; }

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