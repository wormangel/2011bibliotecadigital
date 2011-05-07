using System;
using System.Collections.Generic;
using System.Linq;
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
        private GerenciadorDocumentosArquivisticos _gerenciador;
        private DynamicMock _repositorioMock;

        [SetUp]
        public void SetUp()
        {
            this._repositorioMock = new DynamicMock(typeof(IRepositorio<DocumentoArquivistico>));
            this._gerenciador = new GerenciadorDocumentosArquivisticos((IRepositorio<DocumentoArquivistico>) this._repositorioMock.MockInstance);
        }

        [Test]
        public void CriarDocumento()
        {
            var documento = new DocumentoArquivistico();
            var documentosRecuperados = new List<DocumentoArquivistico> { documento };
            
            this._repositorioMock.Call("Adicionar", documento);
            this._repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados);

            this._gerenciador.Criar(documento);
            Assert.AreEqual(documentosRecuperados, this._gerenciador.RecuperarDocumentos());
            
            this._repositorioMock.Verify();
        }

        [Test]
        public void RecuperarDocumentoPorId()
        {
            var documento = new DocumentoArquivistico {Id = 1, Descricao = "Descrição"};
            var documentosRecuperados = new List<DocumentoArquivistico> { documento };

            this._repositorioMock.Call("Adicionar", documento);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            this._repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados);

            this._gerenciador.Criar(documento);
            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual(documentosRecuperados, this._gerenciador.RecuperarDocumentos());
            Assert.AreEqual("Descrição", docTemp.Descricao);

            this._repositorioMock.Verify();
        }

        [Test]
        public void RecuperarDocumentoPorIdInexistente()
        {
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            // devemos ignorar ou lançar exceção dizendo que o id não existia?
            Assert.Null(this._gerenciador.RecuperarPorId(1));
                
            this._repositorioMock.Verify();    
        }

        [Test]
        public void RemoverDocumento()
        {
            var documento = new DocumentoArquivistico { Id = 1, Descricao = "Descrição" };

            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            this._repositorioMock.Call("Remover", 1);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Descrição", docTemp.Descricao);
            this._gerenciador.Remover(1);
            Assert.Null(this._gerenciador.RecuperarPorId(1));

            this._repositorioMock.Verify();
        }

        [Test]
        public void RemoverDocumentoInexistente()
        {
            this._repositorioMock.Call("Remover", 1);
            
            // devemos ignorar ou lançar exceção dizendo que o id não existia?
            this._gerenciador.Remover(1);

            this._repositorioMock.Verify();
        }

        [Test]
        public void AtualizarDocumento()
        {
            var documento = new DocumentoArquivistico { Id = 1, Descricao = "Descrição1"};

            this._repositorioMock.Call("Adicionar", documento);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            this._repositorioMock.Call("Salvar", documento);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);

            this._gerenciador.Criar(documento);
            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Descrição1", docTemp.Descricao);
            docTemp.Descricao = "Descrição2";
            this._gerenciador.Atualizar(docTemp);
            var docTemp2 = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual("Descrição2", docTemp2.Descricao);

            this._repositorioMock.Verify();
        }
        
        [Test]
        public void RecuperarDocumentosArquivisticos()
        {
            var documentosRecuperados = new List<DocumentoArquivistico> { new DocumentoArquivistico(), new DocumentoArquivistico() };

            this._repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados);

            Assert.AreEqual(documentosRecuperados, this._gerenciador.RecuperarDocumentos());
            
            this._repositorioMock.Verify();
        }

    }
}
