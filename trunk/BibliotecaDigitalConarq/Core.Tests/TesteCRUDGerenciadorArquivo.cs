using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using NUnit.Framework;
using NUnit.Mocks;
using System.Collections.Generic;

namespace Core.Tests
{
    [TestFixture]
    internal class TesteCRUDGerenciadorArquivo
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _repositorioMock = new DynamicMock(typeof (IRepositorio<Arquivo>));
            _gerenciador = new GerenciadorArquivos((IRepositorio<Arquivo>) _repositorioMock.MockInstance);
        }

        #endregion

        private GerenciadorArquivos _gerenciador;
        private DynamicMock _repositorioMock;

        [Test]
        public void Precisa_Atualizar_Arquivo()
        {
            var arquivo = new Arquivo
                              {
                                  ArquivoId = 1,
                                  AmbienteHardware = "x86",
                                  AmbienteSoftware = "WindowsXP",
                                  Armazenamento = "C://arquivo.txt",
                                  Caracteristicas = "Arquivo Digital",
                                  Dependencias = "Notepad",
                                  Formato = "txt",
                                  Nome = "Teste"
                              };

            _repositorioMock.Expect("Adicionar", arquivo);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", arquivo, 1);
            _repositorioMock.Expect("Salvar", arquivo);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", arquivo, 1);

            _gerenciador.Adicionar(arquivo);
            Arquivo arquivoTemp = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual("WindowsXP", arquivo.AmbienteSoftware);
            arquivoTemp.AmbienteSoftware = "Windows7";
            _gerenciador.Atualizar(arquivo);
            Arquivo arquivoTemp2 = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Windows7", arquivoTemp2.AmbienteSoftware);

            _repositorioMock.Verify();
        }

        [Test]
        public void Precisa_Adicionar_Arquivo()
        {
            var arquivo = new Arquivo
                              {
                                  ArquivoId = 1,
                                  AmbienteHardware = "x86",
                                  AmbienteSoftware = "WindowsXP",
                                  Armazenamento = "C://arquivo.txt",
                                  Caracteristicas = "Arquivo Digital",
                                  Dependencias = "Notepad",
                                  Formato = "txt",
                                  Nome = "Teste"
                              };

            var arquivosRecuperados = new List<Arquivo> {arquivo};

            _repositorioMock.Expect("Adicionar", arquivo);
            _repositorioMock.ExpectAndReturn("RecuperarTodos", arquivosRecuperados);

            _gerenciador.Adicionar(arquivo);
            Assert.AreEqual(arquivosRecuperados, _gerenciador.RecuperarArquivos());

            _repositorioMock.Verify();
        }

        [Test]
        public void Precisa_Excluir_Arquivo()
        {
            var arq = new Arquivo { ArquivoId = 1, Nome = "Teste"};

            _repositorioMock.ExpectAndReturn("RecuperarPorId", arq, 1);
            _repositorioMock.Expect("Remover", 1);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            Arquivo temp = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Teste", temp.Nome);
            _gerenciador.Remover(1);
            Assert.Null(_gerenciador.RecuperarPorId(1));

            _repositorioMock.Verify();
        }

    }
}