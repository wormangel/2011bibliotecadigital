using System;
using Core.Properties;
using LightInfocon.GoldenIndex.Extractors;
using LightInfocon.GoldenIndex.General;

namespace Core.Gerenciadores
{
    /// <summary>
    /// Responsável por gerenciar os Arquivos, realizando também o processo de
    /// extração e indexação de seu conteúdo.
    /// </summary>
    public class GerenciadorArquivos
    {
        private readonly IGoldenIndex goldenIndex;
        private readonly User usuarioGoldenIndex;

        public GerenciadorArquivos()
        {
            goldenIndex = GoldenIndexClient.Instance(Settings.Default.HostGoldenIndex,
                                                     uint.Parse(Settings.Default.PortaGoldenIndex),
                                                     Settings.Default.UriGoldenIndex,
                                                     Settings.Default.ProtocoloGoldenIndex);
            usuarioGoldenIndex = GoldenIndexClient.Authenticate(Settings.Default.UsuarioGoldenIndex,
                                                                Settings.Default.SenhaGoldenIndex,
                                                                goldenIndex);
        }

        //Exemplo de como indexar um arquivo.
        public void Indexar(long arquivoId, String caminhArquivo)
        {
            var conteudo = new FileData
                               {
                                   Url = caminhArquivo,
                                   IndexerParameters = new SimpleIndexerParameters {IdFieldValue = arquivoId.ToString()}
                               };
            goldenIndex.SaveFile(usuarioGoldenIndex, conteudo);
        }

        //Exemplo de como extrair o texto do arquivo
        public String Extrair(String caminhoArquivo)
        {
            return DocumentExtractor.Instance.Extract(caminhoArquivo);
        }
    }
}