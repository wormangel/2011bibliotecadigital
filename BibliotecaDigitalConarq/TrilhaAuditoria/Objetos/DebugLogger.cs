using System;
using Core.Interfaces;
using TrilhaAuditoria.Enums;

namespace TrilhaAuditoria.Objetos
{
    class DebugLogger : ILogger
    {
        
        public void LogaMensagem(string mensagem)
        {
            Console.WriteLine(new Log(mensagem));
        }

        public void LogaAcaoDocumentoArquivistico(long idDocumentoArquivistico, long usuario, string acao)
        {
            Console.WriteLine(new Log(TipoDoLog.DocumentoArquivistico, idDocumentoArquivistico, usuario, acao));
        }

        public void LogaAcaoVolume(long idVolume, long usuario, string acao)
        {
            Console.WriteLine(new Log(TipoDoLog.Volume, idVolume, usuario, acao));
        }

        public void LogaAcaoDocumento(long idDocumento, long usuario, string acao)
        {
            Console.WriteLine(new Log(TipoDoLog.Documento, idDocumento, usuario, acao));
        }

        public void LogaAcaoDoArquivo(long idArquivo, long usuario, string acao)
        {
            Console.WriteLine(new Log(TipoDoLog.Arquivo, idArquivo, usuario, acao));
        }
    }
}
