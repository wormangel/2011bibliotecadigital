using System.Collections.Generic;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using NUnit.Framework;
using NUnit.Mocks;

namespace Core.Tests
{
    [TestFixture]
    public class TesteCrudGerenciadorDocumentosArquivisticos
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _repositorioMock = new DynamicMock(typeof (IRepositorio<DocumentoArquivistico>));
            _gerenciador =
                new GerenciadorDocumentosArquivisticos(
                    (IRepositorio<DocumentoArquivistico>) _repositorioMock.MockInstance);
        }

        #endregion

        private GerenciadorDocumentosArquivisticos _gerenciador;
        private DynamicMock _repositorioMock;

        [Test]
        public void AtualizarDocumento()
        {
            var documento = new DocumentoArquivistico {Id = 1, Descricao = "Descrição1"};

            _repositorioMock.Call("Adicionar", documento);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            _repositorioMock.Call("Salvar", documento);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);

            _gerenciador.Adicionar(documento);
            DocumentoArquivistico docTemp = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Descrição1", docTemp.Descricao);
            docTemp.Descricao = "Descrição2";
            _gerenciador.Salvar(docTemp);
            DocumentoArquivistico docTemp2 = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Descrição2", docTemp2.Descricao);

            _repositorioMock.Verify();
        }

        [Test]
        public void CriarDocumento()
        {
            var documento = new DocumentoArquivistico();
            var documentosRecuperados = new List<DocumentoArquivistico> {documento};

            _repositorioMock.Call("Adicionar", documento);
            _repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados);

            _gerenciador.Adicionar(documento);
            Assert.AreEqual(documentosRecuperados, _gerenciador.RecuperarDocumentos());

            _repositorioMock.Verify();
        }

        [Test]
        public void RecuperarDocumentoPorId()
        {
            var documento = new DocumentoArquivistico {Id = 1, Descricao = "Descrição"};
            var documentosRecuperados = new List<DocumentoArquivistico> {documento};

            _repositorioMock.Call("Adicionar", documento);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            _repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados);

            _gerenciador.Adicionar(documento);
            DocumentoArquivistico docTemp = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual(documentosRecuperados, _gerenciador.RecuperarDocumentos());
            Assert.AreEqual("Descrição", docTemp.Descricao);

            _repositorioMock.Verify();
        }

        [Test]
        public void RecuperarDocumentoPorIdInexistente()
        {
            _repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            // devemos ignorar ou lançar exceção dizendo que o id não existia?
            Assert.Null(_gerenciador.RecuperarPorId(1));

            _repositorioMock.Verify();
        }

        [Test]
        public void RecuperarDocumentosArquivisticos()
        {
            var documentosRecuperados = new List<DocumentoArquivistico>
                                            {new DocumentoArquivistico(), new DocumentoArquivistico()};

            _repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados);

            Assert.AreEqual(documentosRecuperados, _gerenciador.RecuperarDocumentos());

            _repositorioMock.Verify();
        }

        [Test]
        public void RemoverDocumento()
        {
            var documento = new DocumentoArquivistico {Id = 1, Descricao = "Descrição"};

            _repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            _repositorioMock.Call("Remover", 1);
            _repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            DocumentoArquivistico docTemp = _gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Descrição", docTemp.Descricao);
            _gerenciador.Remover(1);
            Assert.Null(_gerenciador.RecuperarPorId(1));

            _repositorioMock.Verify();
        }

        [Test]
        public void RemoverDocumentoInexistente()
        {
            _repositorioMock.Call("Remover", 1);

            // devemos ignorar ou lançar exceção dizendo que o id não existia?
            _gerenciador.Remover(1);

            _repositorioMock.Verify();
        }
    }
}