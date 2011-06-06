using Core.Objetos;

namespace Web.ViewModels.Documento
{
    public class EditDocumentoViewModel
    {
        public Core.Objetos.Documento Documento { get; set; }

        public VersaoDocumento VersaoNova { get; set; }

        public EditDocumentoViewModel() {}

        public EditDocumentoViewModel(Core.Objetos.Documento documento)
        {
            Documento = documento;

            PreencheVersaoNova();
        }

        public void PreencheVersaoNova()
        {
            VersaoNova = new VersaoDocumento();
            VersaoNova.Assunto = Documento.VersaoAtual.Assunto;
            VersaoNova.Autor = Documento.VersaoAtual.Autor;
            VersaoNova.Classe = Documento.VersaoAtual.Classe;
            VersaoNova.DataDeProducao = Documento.VersaoAtual.DataDeProducao;
            VersaoNova.Descricao = Documento.VersaoAtual.Descricao;
            VersaoNova.DestinacaoPrevista = Documento.VersaoAtual.DestinacaoPrevista;
            VersaoNova.Destinatario = Documento.VersaoAtual.Destinatario;
            VersaoNova.Especie = Documento.VersaoAtual.Especie;
            VersaoNova.Genero = Documento.VersaoAtual.Genero;
            VersaoNova.Idioma = Documento.VersaoAtual.Idioma;
            VersaoNova.Localizacao = Documento.VersaoAtual.Localizacao;
            VersaoNova.NumeroDoDocumento = Documento.VersaoAtual.NumeroDoDocumento;
            VersaoNova.NumeroDoProtocolo = Documento.VersaoAtual.NumeroDoProtocolo;
            VersaoNova.Originador = Documento.VersaoAtual.Originador;
            VersaoNova.PrazoDeGuarda = Documento.VersaoAtual.PrazoDeGuarda;
            VersaoNova.Procedencia = Documento.VersaoAtual.Procedencia;
            VersaoNova.QuantidadeDeFolhas = Documento.VersaoAtual.QuantidadeDeFolhas;
            VersaoNova.Redator = Documento.VersaoAtual.Redator;
            VersaoNova.Status = Documento.VersaoAtual.Status;
            VersaoNova.Tipo = Documento.VersaoAtual.Tipo;
            VersaoNova.TipoDoDestinatario = Documento.VersaoAtual.TipoDoDestinatario;
            VersaoNova.TipoDoMeio = Documento.VersaoAtual.TipoDoMeio;
            VersaoNova.TipoDoTitulo = Documento.VersaoAtual.TipoDoTitulo;
            VersaoNova.Titulo = Documento.VersaoAtual.Titulo;
            VersaoNova.TemAnexos = Documento.VersaoAtual.TemAnexos;
        }
    }
}