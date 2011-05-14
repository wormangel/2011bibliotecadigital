using System;
using System.IO;
using System.Linq;
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
        private readonly IRepositorio<Arquivo> _repositorio;
        private readonly IGoldenIndex goldenIndex;
        private readonly User usuarioGoldenIndex;

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
        private void _Indexar(Arquivo arquivo)
        {
            try
            {
                if (!goldenIndex.IsSupported(usuarioGoldenIndex, arquivo.Formato))
                {
                    // NOTE: Se não for um arquivo suportado, não faz nada
                    return;
                }

                // TODO: Tem que dizer em qual campo e em qual base vai guardar o conteúdo extraído.
                var parametros = new IndexerParameters
                                     {
                                         ContentField = "TextoArquivo",
                                         IdField = "Id",
                                         IdFieldValue = arquivo.ArquivoId.ToString(),
                                         Table = ""
                                     };

                var conteudo = new FileData
                                   {
                                       Url = arquivo.CaminhoDoArquivo,
                                       IndexerParameters = parametros
                                   };
                goldenIndex.SaveFile(usuarioGoldenIndex, conteudo);
            }
            catch (Exception exception)
            {
                throw new Exception("Arquivo salvo, porém não indexado para buscas. Contate o administrador do sistema.", exception);
            }
        }

        //Exemplo de como extrair o texto do arquivo
        private String _Extrair(String caminhoArquivo)
        {
            return DocumentExtractor.Instance.Extract(caminhoArquivo);
        }

        public IQueryable<Arquivo> RecuperarArquivos()
        {
            return _repositorio.RecuperarTodos();
        }

        public Arquivo RecuperarPorId(long id)
        {
            return _repositorio.RecuperarPorId(id);
        }

        public void Salvar(Arquivo arquivo)
        {
            _repositorio.Salvar(arquivo);
        }

        public void Adicionar(Arquivo arquivo, Stream conteudo)
        {
            // Primeiro define aonde o arquivo será salvo
            // TODO: Diretório temporário, precisa mudar.
            const string repositoryFiles = "C://biblioteca/";
            arquivo.CaminhoDoArquivo = repositoryFiles + arquivo.Nome + arquivo.Formato;

            // Segundo cria o arquivo físico (conteúdo)
            Directory.CreateDirectory(repositoryFiles);

            var anexo = new FileStream(arquivo.CaminhoDoArquivo, FileMode.Create);
            conteudo.CopyTo(anexo);
            anexo.Close();

            // Terceiro cria o arquivo lógico (com metadados)
            _repositorio.Adicionar(arquivo);

            // Quarto, indexa o arquivo
            _Indexar(arquivo);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
        }

        public void Atualizar(Arquivo arquivo)
        {
            _repositorio.Salvar(arquivo);
        }
    }

    // PipesAndFilters
    public static class ArquivoFilters
    {
        public static IQueryable<Arquivo> FiltraPorCaminho(this IQueryable<Arquivo> consulta, string caminho)
        {
            return consulta.Where(arquivo => arquivo.CaminhoDoArquivo.Equals(caminho));
        }
    }
}