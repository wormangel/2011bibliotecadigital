using System;
using System.Collections.Generic;
using System.Linq;
using Core.Gerenciadores;
using Core.Interfaces;
using Core.Objetos;
using EntityAcessoADados.Gerenciadores;
using NUnit.Framework;
using NUnit.Mocks;
using TrilhaAuditoria.Objetos;

namespace Core.Tests
{
    [TestFixture]
    public class TesteCrudGerenciadorDocumentos
    {
        private GerenciadorDocumentos _gerenciador;
        private DynamicMock _repositorioMock;

        [SetUp]
        public void SetUp()
        {
            this._repositorioMock = new DynamicMock(typeof(IRepositorio<Documento>));
            this._gerenciador = new GerenciadorDocumentos((IRepositorio<Documento>) _repositorioMock.MockInstance, new DebugLogger());
        }

        [Test]
        public void CriarDocumento()
        {
            var documento = new Documento();
            var documentosRecuperados = new List<Documento> { documento };

            this._repositorioMock.Call("Adicionar", documento);
            this._repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados.AsQueryable());

            this._gerenciador.Adicionar(null, documento);
            Assert.AreEqual(documentosRecuperados, this._gerenciador.RecuperarDocumentos());
            
            this._repositorioMock.Verify();
        }

        [Test]
        public void RecuperarDocumentoPorId()
        {
            var documento = new Documento() {Id = 1, QuantidadeDeFolhas = 100};
            var documentosRecuperados = new List<Documento> { documento };

            this._repositorioMock.Call("Adicionar", documento);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            this._repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados.AsQueryable());

            this._gerenciador.Adicionar(null, documento);
            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual(documentosRecuperados, this._gerenciador.RecuperarDocumentos());
            Assert.AreEqual(100, docTemp.QuantidadeDeFolhas);

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
            var documento = new Documento() { Id = 1, QuantidadeDeFolhas = 100 };

            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", documento, 1);
            this._repositorioMock.Call("Remover", 1);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual(100, documento.QuantidadeDeFolhas);
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
            var volume = new Documento() { Id = 1, QuantidadeDeFolhas= 100};

            this._repositorioMock.Call("Adicionar", volume);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
            this._repositorioMock.Call("Salvar", volume);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);

            this._gerenciador.Adicionar(null, volume);
            var volTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual(100, volume.QuantidadeDeFolhas);
            volTemp.QuantidadeDeFolhas = 200;
            this._gerenciador.Salvar(volume);
            var volTemp2 = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual(200, volTemp2.QuantidadeDeFolhas);

            this._repositorioMock.Verify();
        }
        
        [Test]
        public void RecuperarDocumentos()
        {
            var documentosRecuperados = new List<Documento> { new Documento(), new Documento() };

            this._repositorioMock.ExpectAndReturn("RecuperarTodos", documentosRecuperados.AsQueryable());

            Assert.AreEqual(documentosRecuperados.AsQueryable(), _gerenciador.RecuperarDocumentos());
            
            this._repositorioMock.Verify();
        }

    }
}
