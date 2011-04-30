using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Objetos.Enums;

namespace Core.Objetos.Logger
{
    class SQLLogger : ILogger
    {
        
        private readonly IRepositorio<Log> repositorio = null;

        public void LogaMensagem(string mensagem)
        {
            repositorio.Adicionar(new Log(mensagem));
        }

        public void LogaAcaoDocumentoArquivistico(long idDocumentoArquivistico, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.DocumentoArquivistico, idDocumentoArquivistico, usuario, acao));
        }

        public void LogaAcaoVolume(long idVolume, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.Volume, idVolume, usuario, acao));
        }

        public void LogaAcaoDocumento(long idDocumento, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.Documento, idDocumento, usuario, acao));
        }
    }
}
