using System;
using NUnit.Framework;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.UnitTests
{
    [TestFixture]
    public class MovieTests
    {
        private Movie movieInDb;
        private Movie editedMovie;

        [SetUp]
        public void SetUp()
        {
            movieInDb = new Movie();
            editedMovie = new Movie();
        }

        [Test]
        [TestCase(1, 1, 1, 1)]
        [TestCase(1, 1, 2, 2)]
        [TestCase(1, 1, 0, 0)]
        [TestCase(1, 2, 3, 2)]
        [TestCase(1, 2, 1, 0)]
        public void SetNewNumberAvailable_WhenCalled_AssignCalculatedNewValueOfNumberAvailable(int movieInDbNumberAvailable, int movieInDbNumberInStock, int editedMovieNumberInStock, int expectedResult)
        {
            movieInDb.NumberAvailable = editedMovie.NumberAvailable = movieInDbNumberAvailable;
            movieInDb.NumberInStock = movieInDbNumberInStock;
            editedMovie.NumberInStock = editedMovieNumberInStock;

            movieInDb.SetNewNumberAvailable(movieInDb, editedMovie);

            Assert.That(movieInDb.NumberAvailable, Is.EqualTo(expectedResult));
        }
    }
}
