using EntityAcessoADados.Interfaces;
using TrilhaAuditoria.Enums;
using TrilhaAuditoria.Interfaces;

namespace TrilhaAuditoria.Objetos
{
    internal class TrilhaAuditoria : ILogger
    {
        private readonly IRepositorio<Log> repositorio;

        public TrilhaAuditoria(IRepositorio<Log> repositorio)
        {
            this.repositorio = repositorio;
        }

        #region ILogger Members

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

        public void LogaAcaoDoArquivo(long idArquivo, long usuario, string acao)
        {
            repositorio.Adicionar(new Log(TipoDoLog.Arquivo, idArquivo, usuario, acao));
        }

        #endregion
    }
}