using System;
using LightInfocon.GoldenIndex.Extractors;
using LightInfocon.GoldenIndex.General;

namespace Core.Gerenciadores
{
    /// <summary>
    /// Responsável por gerenciar os Arquivos, realizando também o processo de
    /// extração e indexação de seu conteúdo.
    /// </summary>
    class GerenciadorArquivos
    {
        private readonly IGoldenIndex goldenIndex;
        private readonly User usuarioGoldenIndex;

        public GerenciadorArquivos()
        {
            goldenIndex = GoldenIndexClient.Instance(Properties.Settings.Default.HostGoldenIndex,
                                                     uint.Parse(Properties.Settings.Default.PortaGoldenIndex),
                                                     Properties.Settings.Default.UriGoldenIndex,
                                                     Properties.Settings.Default.ProtocoloGoldenIndex);
            usuarioGoldenIndex = GoldenIndexClient.Authenticate(Properties.Settings.Default.UsuarioGoldenIndex,
                                                                Properties.Settings.Default.SenhaGoldenIndex,
                                                                goldenIndex);
        }

        //Exemplo de como indexar um arquivo.
        public void indexar(long arquivoId, String caminhArquivo)
        {
            FileData conteudo = new FileData
                                    {
                                        Url = caminhArquivo,
                                        IndexerParameters = new SimpleIndexerParameters {IdFieldValue = arquivoId.ToString()}
                                    };
            goldenIndex.SaveFile(usuarioGoldenIndex, conteudo);
        }

        //Exemplo de como extrair o texto do arquivo
        public String extrair(String caminhoArquivo)
        {
            return DocumentExtractor.Instance.Extract(caminhoArquivo);
        }
    }
}
