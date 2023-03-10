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

        [DataRow(Allegiance.None)]
        [DataRow(Allegiance.Rebellion)]
        [DataRow(Allegiance.Empire)]
        [TestMethod]
        public void ListCharactersByAllegianceAsyncReturnsOnlyCharactersWithThatAllegiance(
            Allegiance allegiance
        )
        {
            // Arrange
            StarWarsProxy proxy = new StarWarsProxy();

            // Act
            IList<CharacterModel> characters = proxy
                .ListCharactersByAllegianceAsync(allegiance)
                .Result;

            // Assert
            if (characters.Count == 0)
            {
                Assert.Inconclusive();
            }
            foreach (CharacterModel character in characters)
            {
                Assert.AreEqual(allegiance, character.Allegiance);
            }
        }
    }
}
