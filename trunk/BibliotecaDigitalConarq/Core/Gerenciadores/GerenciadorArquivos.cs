﻿using System;
using System.IO;
using System.Linq;
using Core.Objetos;
using Core.Properties;
using EntityAcessoADados.Interfaces;
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
        private readonly IGoldenIndex _goldenIndex;
        private readonly IRepositorio<Arquivo> _repositorio;
        //private readonly TrilhaAuditoria _trilhaAuditoria;
        private readonly User _usuarioGoldenIndex;

        public GerenciadorArquivos(IRepositorio<Arquivo> repositorio)
        {
            _repositorio = repositorio;

            _goldenIndex = GoldenIndexClient.Instance(Settings.Default.HostGoldenIndex,
                                                      uint.Parse(Settings.Default.PortaGoldenIndex),
                                                      Settings.Default.UriGoldenIndex,
                                                      Settings.Default.ProtocoloGoldenIndex);
            _usuarioGoldenIndex = GoldenIndexClient.Authenticate(Settings.Default.UsuarioGoldenIndex,
                                                                 Settings.Default.SenhaGoldenIndex,
                                                                 _goldenIndex);
        }

        // TODO: Há duas formas de indexar os arquivo, uma é utilizando o serviço (que é feito usando
        // TODO: o método abaixo). Essa forma tem a vantagem de não deixar o usuário esperando a 
        // TODO: indexação, mas é dependente do LightBase, pois tem que informar os campos e a
        // TODO: extent de onde o conteúdo será salvo.
        private void _Indexar(Arquivo arquivo)
        {
            try
            {
                if (!_goldenIndex.IsSupported(_usuarioGoldenIndex, arquivo.Formato))
                {
                    // NOTE: Se não for um arquivo suportado, não faz nada
                    return;
                }

                // TODO: Tem que dizer em qual campo e em qual base vai guardar o conteúdo extraído.
                var parametros = new IndexerParameters
                                     {
                                         //TODO: Alterar esses campos quando arrumar as coisas do LightBase
                                         ContentField = "NomeDoAtributoNaTabela",
                                         IdField = "NomeDoAtributoQueEhOIDNaTabela",
                                         IdFieldValue = arquivo.ArquivoId.ToString(),
                                         Table = "NomeDaTabelaNaBaseDeDados"
                                     };

                var conteudo = new FileData
                                   {
                                       Url = arquivo.CaminhoDoArquivo,
                                       IndexerParameters = parametros
                                   };
                _goldenIndex.SaveFile(_usuarioGoldenIndex, conteudo);
            }
            catch (Exception exception)
            {
                throw new Exception(
                    "Arquivo salvo, porém não indexado para buscas. Contate o administrador do sistema.", exception);
            }
        }

        // TODO: O método abaixo utiliza a forma sincrona de fazer a indexação, não é necessário o serviço
        // TODO: e fica independente da tecnologia da base de dados, mas o usuário teria que esperar a
        // TODO: indexação terminar. Poderiamos contornar esse problema com o uso de threads, o que acham?
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