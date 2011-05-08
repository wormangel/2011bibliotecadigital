using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Objetos;
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
        private readonly IRepositorio<Arquivo> _repositorio;

        public GerenciadorArquivos(IRepositorio<Arquivo> repositorio)
        {
            _repositorio = repositorio;

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

        public IList<Arquivo> RecuperarArquivos()
        {
            return _repositorio.RecuperarTodos();
        }

        public Arquivo RecuperarPorId(long id)
        {
            return _repositorio.RecuperarPorId(id);
        }

        public void Salvar(Arquivo documento)
        {
            _repositorio.Salvar(documento);
        }

        public void Adicionar(Arquivo documento)
        {
            _repositorio.Adicionar(documento);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
        }
    }
}