using Core.Interfaces;
using TrilhaAuditoria.Enums;
using TrilhaAuditoria.Interfaces;

namespace TrilhaAuditoria
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
