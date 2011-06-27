//using System.Collections.Generic;
//using System.Linq;
//using Core.Gerenciadores;
//using Core.Interfaces;
//using Core.Objetos;
//using EntityAcessoADados.Gerenciadores;
//using EntityAcessoADados.Repositorios;
//using NUnit.Framework;
//using NUnit.Mocks;
//using TrilhaAuditoria.Objetos;

//namespace Core.Tests
//{
//    [TestFixture]
//    public class TesteCrudGerenciadorVolumes
//    {
//        #region Setup/Teardown

//        [SetUp]
//        public void SetUp()
//        {
//            _repositorioMock = new DynamicMock(typeof (IRepositorio<Volume>));
//            _gerenciador = new GerenciadorVolumes((IRepositorio<Volume>) _repositorioMock.MockInstance, new DebugLogger());
//        }

//        #endregion

//        private GerenciadorVolumes _gerenciador;
//        private DynamicMock _repositorioMock;

//        [Test]
//        public void AtualizarVolume()
//        {
//            var volume = new Volume {Id = 1, QuantidadeDeFolhas = 100};

//            _repositorioMock.Call("Adicionar", volume);
//            _repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
//            _repositorioMock.Call("Salvar", volume);
//            _repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);

//            _gerenciador.Adicionar(null, volume);
//            Volume volTemp = _gerenciador.RecuperarPorId(1);
//            Assert.AreEqual(100, volume.QuantidadeDeFolhas);
//            volTemp.QuantidadeDeFolhas = 200;
//            _gerenciador.Salvar(volume);
//            Volume volTemp2 = _gerenciador.RecuperarPorId(1);
//            Assert.AreEqual(200, volTemp2.QuantidadeDeFolhas);

//            _repositorioMock.Verify();
//        }

//        [Test]
//        public void CriarVolume()
//        {
//            var volume = new Volume();
//            var volumesRecuperados = new List<Volume> {volume};

//            _repositorioMock.Call("Adicionar", volume);
//            _repositorioMock.ExpectAndReturn("RecuperarTodos", volumesRecuperados.AsQueryable());

//            _gerenciador.Adicionar(null, volume);
//            Assert.AreEqual(volumesRecuperados, _gerenciador.RecuperarVolumes());

//            _repositorioMock.Verify();
//        }

//        [Test]
//        public void RecuperarVolumePorId()
//        {
//            // quantidade de folhas string? lol.
//            var volume = new Volume {Id = 1, QuantidadeDeFolhas = 100};
//            var volumesRecuperados = new List<Volume> {volume};

//            _repositorioMock.Call("Adicionar", volume);
//            _repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
//            _repositorioMock.ExpectAndReturn("RecuperarTodos", volumesRecuperados.AsQueryable());

//            _gerenciador.Adicionar(null, volume);
//            Volume docTemp = _gerenciador.RecuperarPorId(1);
//            Assert.AreEqual(volumesRecuperados, _gerenciador.RecuperarVolumes());
//            Assert.AreEqual(100, docTemp.QuantidadeDeFolhas);

//            _repositorioMock.Verify();
//        }

//        [Test]
//        public void RecuperarVolumePorIdInexistente()
//        {
//            _repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

//            // devemos ignorar ou lançar exceção dizendo que o id não existia?
//            Assert.Null(_gerenciador.RecuperarPorId(1));

//            _repositorioMock.Verify();
//        }

//        [Test]
//        public void RecuperarVolumes()
//        {
//            var volumesRecuperados = new List<Volume> {new Volume(), new Volume()};

//            _repositorioMock.ExpectAndReturn("RecuperarTodos", volumesRecuperados.AsQueryable());

//            Assert.AreEqual(volumesRecuperados, _gerenciador.RecuperarVolumes());

//            _repositorioMock.Verify();
//        }

//        [Test]
//        public void RemoverVolume()
//        {
//            var volume = new Volume {Id = 1, QuantidadeDeFolhas = 100};

//            _repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
//            _repositorioMock.ExpectAndReturn("RecuperarPorId", volume, 1);
//            _repositorioMock.Call("Remover", 1);
//            _repositorioMock.ExpectAndReturn("RecuperarPorId", null, 1);

//            Volume docTemp = _gerenciador.RecuperarPorId(1);
//            Assert.AreEqual(100, volume.QuantidadeDeFolhas);
//            _gerenciador.Remover(1);
//            Assert.Null(_gerenciador.RecuperarPorId(1));

//            _repositorioMock.Verify();
//        }

//        [Test]
//        public void RemoverVolumeInexistente()
//        {
//            _repositorioMock.Call("Remover", 1);

//            // devemos ignorar ou lançar exceção dizendo que o id não existia?
//            _gerenciador.Remover(1);

//            _repositorioMock.Verify();
//        }
//    }
//}