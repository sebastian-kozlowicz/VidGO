using System;
using NUnit.Framework;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        private Game gameInDb;
        private Game editedGame;

        [SetUp]
        public void SetUp()
        {
            gameInDb = new Game();
            editedGame = new Game();
        }

        [Test]
        [TestCase(1, 1, 1, 1)]
        [TestCase(1, 1, 2, 2)]
        [TestCase(1, 1, 0, 0)]
        [TestCase(1, 2, 3, 2)]
        [TestCase(1, 2, 1, 0)]
        public void SetNewNumberAvailable_WhenCalled_AssignCalculatedNewValueOfNumberAvailable(int gameInDbNumberAvailable, int gameInDbNumberInStock, int editedGameNumberInStock, int expectedResult)
        {
            gameInDb.NumberAvailable = editedGame.NumberAvailable = gameInDbNumberAvailable;
            gameInDb.NumberInStock = gameInDbNumberInStock;
            editedGame.NumberInStock = editedGameNumberInStock;

            gameInDb.SetNewNumberAvailable(gameInDb, editedGame);

            Assert.That(gameInDb.NumberAvailable, Is.EqualTo(expectedResult));
        }
    }
}
