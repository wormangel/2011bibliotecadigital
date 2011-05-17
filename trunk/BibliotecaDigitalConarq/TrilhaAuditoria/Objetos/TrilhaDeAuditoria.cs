using Core.Interfaces;
using TrilhaAuditoria.Enums;

namespace TrilhaAuditoria.Objetos
{
    public class TrilhaDeAuditoria : ILogger
    {
        private readonly IRepositorio<Log> repositorio;
        private readonly DebugLogger _debugger;

        public TrilhaDeAuditoria(IRepositorio<Log> repositorio)
        {
            this.repositorio = repositorio;
            _debugger = new DebugLogger();
        }

        #region ILogger Members

        public void LogaMensagem(string mensagem)
        {
            repositorio.Adicionar(new Log(mensagem));
            _debugger.LogaMensagem(mensagem);
        }

        public void LogaAcaoDocumentoArquivistico(long idDocumentoArquivistico, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.DocumentoArquivistico, idDocumentoArquivistico, usuario, acao));
            _debugger.LogaAcaoDocumentoArquivistico(idDocumentoArquivistico, usuario, acao);
        }

        public void LogaAcaoVolume(long idVolume, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.Volume, idVolume, usuario, acao));
            _debugger.LogaAcaoVolume(idVolume, usuario, acao);
        }

        public void LogaAcaoDocumento(long idDocumento, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.Documento, idDocumento, usuario, acao));
            _debugger.LogaAcaoDocumento(idDocumento, usuario, acao);
        }

        public void LogaAcaoDoArquivo(long idArquivo, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.Arquivo, idArquivo, usuario, acao));
            _debugger.LogaAcaoDoArquivo(idArquivo, usuario, acao);
        }

        #endregion
    }
}