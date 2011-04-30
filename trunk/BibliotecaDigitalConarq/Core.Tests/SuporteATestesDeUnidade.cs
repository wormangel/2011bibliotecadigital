using NUnit.Framework;

namespace Core.Tests
{
    /// <summary>
    /// Classe com métodos de suporte para dar mais legibilidade aos testes.
    /// </summary>
    public static class SuporteATestesDeUnidade
    {
        /// <summary>
        /// Verifica ser o valor recebido do teste é igual ao valor atual. Esse
        /// extension method foi criado para deixar os testes mais legíveis.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto que esta sendo comparado</typeparam>
        /// <param name="valorAtual">Valor atual que temos.</param>
        /// <param name="valorEsperado">Valor obtido pelo teste.</param>
        public static void DeveSerIgualA<T>(this T valorAtual, T valorEsperado)
        {
            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}
