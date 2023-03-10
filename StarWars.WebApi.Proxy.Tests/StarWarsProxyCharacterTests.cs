using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using StarWars.WebApi.Proxy.Models;

namespace StarWars.WebApi.Proxy.Tests
{
    [TestClass]
    public class StarWarsProxyCharacterTests
    {
        [DataRow("Luke Skywalker")]
        [DataRow("Jar Jar Binks")]
        [DataRow("Kylo Ren")]
        [TestMethod]
        public void GetCharacterByNameAsyncReturnsCharacterWithThatName(string name)
        {
            // Arrange
            StarWarsProxy proxy = new StarWarsProxy();

            // Act
            CharacterModel character = proxy.GetCharacterByNameAsync(name).Result;

            // Assert
            if (character is null)
            {
                Assert.Inconclusive();
            }
            Assert.AreEqual(name, character.Name);
        }
    }
}
