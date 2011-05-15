using System;

namespace TrilhaAuditoria.Interfaces
{
    interface ILogger
    {

        void LogaMensagem(String mensagem);

        void LogaAcaoDocumentoArquivistico(long idDocumentoArquivistico, long usuario, String acao);
        
        void LogaAcaoVolume(long idVolume, long usuario, String acao);
        
        void LogaAcaoDocumento(long idDocumento, long usuario, String acao);

        void LogaAcaoDoArquivo(long idArquivo, long usuario, String acao);
    }
}
