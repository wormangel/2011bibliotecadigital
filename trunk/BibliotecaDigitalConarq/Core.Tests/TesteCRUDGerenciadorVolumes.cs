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
    public class TesteCrudGerenciadorVolumes
    {
        private GerenciadorVolumes _gerenciador;
        private DynamicMock _repositorioMock;

        [SetUp]
        public void SetUp()
        {
            this._repositorioMock = new DynamicMock(typeof(IRepositorio<Volume>));
            this._gerenciador = new GerenciadorVolumes((IRepositorio<Volume>) this._repositorioMock.MockInstance);
        }

        [Test]
        public void CriarVolume()
        {
            var volume = new Volume();
            var volumesRecuperados = new List<Volume> { volume };
            
            this._repositorioMock.Call("Adicionar", volume);
            this._repositorioMock.ExpectAndReturn("RecuperarTodos", volumesRecuperados);

            this._gerenciador.Criar(volume);
            Assert.AreEqual(volumesRecuperados, this._gerenciador.RecuperarVolumes());
            
            this._repositorioMock.Verify();
        }

        [Test]
        public void RecuperarVolumePorId()
        {
            // quantidade de folhas string? lol.
            var volume = new Volume() {Id = 1, QuantidadeDeFolhas = "100"};
            var volumesRecuperados = new List<Volume> { volume };

            this._repositorioMock.Call("Adicionar", volume);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
            this._repositorioMock.ExpectAndReturn("RecuperarTodos", volumesRecuperados);

            this._gerenciador.Criar(volume);
            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual(volumesRecuperados, this._gerenciador.RecuperarVolumes());
            Assert.AreEqual("100", docTemp.QuantidadeDeFolhas);

            this._repositorioMock.Verify();
        }

        [Test]
        public void RecuperarVolumePorIdInexistente()
        {
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            // devemos ignorar ou lançar exceção dizendo que o id não existia?
            Assert.Null(this._gerenciador.RecuperarPorId(1));
                
            this._repositorioMock.Verify();    
        }

        [Test]
        public void RemoverVolume()
        {
            var volume = new Volume() { Id = 1, QuantidadeDeFolhas= "100" };

            this._repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
            this._repositorioMock.Call("Remover", 1);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

            var docTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual("100", volume.QuantidadeDeFolhas);
            this._gerenciador.Remover(1);
            Assert.Null(this._gerenciador.RecuperarPorId(1));

            this._repositorioMock.Verify();
        }

        [Test]
        public void RemoverVolumeInexistente()
        {
            this._repositorioMock.Call("Remover", 1);
            
            // devemos ignorar ou lançar exceção dizendo que o id não existia?
            this._gerenciador.Remover(1);

            this._repositorioMock.Verify();
        }

        [Test]
        public void AtualizarVolume()
        {
            var volume = new Volume() { Id = 1, QuantidadeDeFolhas= "100"};

            this._repositorioMock.Call("Adicionar", volume);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
            this._repositorioMock.Call("Salvar", volume);
            this._repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);

            this._gerenciador.Criar(volume);
            var volTemp = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual("100", volume.QuantidadeDeFolhas);
            volTemp.QuantidadeDeFolhas = "200";
            this._gerenciador.Atualizar(volume);
            var volTemp2 = this._gerenciador.RecuperarPorId(1);
            Assert.AreEqual("200", volTemp2.QuantidadeDeFolhas);

            this._repositorioMock.Verify();
        }
        
        [Test]
        public void RecuperarVolumes()
        {
            var volumesRecuperados = new List<Volume> { new Volume(), new Volume() };

            this._repositorioMock.ExpectAndReturn("RecuperarTodos", volumesRecuperados);

            Assert.AreEqual(volumesRecuperados, this._gerenciador.RecuperarVolumes());
            
            this._repositorioMock.Verify();
        }

    }
}
