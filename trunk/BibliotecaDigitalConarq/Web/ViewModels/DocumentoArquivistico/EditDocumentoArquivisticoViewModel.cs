using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Objetos;

namespace Web.ViewModels.DocumentoArquivistico
{
    public class EditDocumentoArquivisticoViewModel
    {
        public Core.Objetos.DocumentoArquivistico DocumentoArquivistico { get; set; }

        public VersaoDocumentoArquivistico VersaoNova { get; set; }

        public EditDocumentoArquivisticoViewModel() {}

        public EditDocumentoArquivisticoViewModel(Core.Objetos.DocumentoArquivistico docArq)
        {
            DocumentoArquivistico = docArq;

            PreencheVersaoNova();
        }

        public void PreencheVersaoNova()
        {
            VersaoNova = new VersaoDocumentoArquivistico();
            VersaoNova.Assunto = DocumentoArquivistico.VersaoAtual.Assunto;
            VersaoNova.Autor = DocumentoArquivistico.VersaoAtual.Autor;
            VersaoNova.DataDeProducao = DocumentoArquivistico.VersaoAtual.DataDeProducao;
            VersaoNova.Descricao = DocumentoArquivistico.VersaoAtual.Descricao;
            VersaoNova.DestinacaoPrevista = DocumentoArquivistico.VersaoAtual.DestinacaoPrevista;
            VersaoNova.Destinatario = DocumentoArquivistico.VersaoAtual.Destinatario;
            VersaoNova.Interessado = DocumentoArquivistico.VersaoAtual.Interessado;
            VersaoNova.Localizacao = DocumentoArquivistico.VersaoAtual.Localizacao;
            VersaoNova.NumeracaoSequencialDosDocumentos = DocumentoArquivistico.VersaoAtual.NumeracaoSequencialDosDocumentos;
            VersaoNova.NumeroDoProcessoOuDossie = DocumentoArquivistico.VersaoAtual.NumeroDoProcessoOuDossie;
            VersaoNova.PrazoDeGuarda = DocumentoArquivistico.VersaoAtual.PrazoDeGuarda;
            VersaoNova.Procedencia = DocumentoArquivistico.VersaoAtual.Procedencia;
            VersaoNova.QuantidadeDeFolhas = DocumentoArquivistico.VersaoAtual.QuantidadeDeFolhas;
            VersaoNova.TipoDoDestinatario = DocumentoArquivistico.VersaoAtual.TipoDoDestinatario;
            VersaoNova.TipoDoMeio = DocumentoArquivistico.VersaoAtual.TipoDoMeio;
            VersaoNova.TipoDoTitulo = DocumentoArquivistico.VersaoAtual.TipoDoTitulo;
            VersaoNova.Titulo = DocumentoArquivistico.VersaoAtual.Titulo;
        }
    }
}