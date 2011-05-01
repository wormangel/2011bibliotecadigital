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
    public class GerenciadorDocumentosArquivisticosTests
    {
        [Test]
        public void Tenta_Pegar_Todos_Os_Documentos_Arquivisticos()
        {
            // Arrange
            List<DocumentoArquivistico> documentos = new List<DocumentoArquivistico> { new DocumentoArquivistico(), new DocumentoArquivistico() };
            var repositorioMock = new DynamicMock(typeof(IRepositorio<DocumentoArquivistico>));

            // Diz ao mock que quando for chamado o método "RecuperarTodos" retornar
            // a lista de documentos definidos.
            repositorioMock.ExpectAndReturn("RecuperarTodos", documentos);

            // Instancia o gerenciador com o repositório mock
            GerenciadorDocumentosArquivisticos servico = new GerenciadorDocumentosArquivisticos((IRepositorio<DocumentoArquivistico>) repositorioMock.MockInstance);
            
            // Act e Assert
            documentos.DeveSerIgualA(servico.RecuperarDocumentos());
        }
    }
}
