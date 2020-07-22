using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallenge.Models;

namespace TurtleChallenge.Testing
{
    [TestClass]
    public class TurtleChallengeTests
    {
        [TestMethod]
        public void GridTest()
        {
            Grid grid = new Grid(10, 12);
            Assert.AreEqual(grid.Height, 10);
        }

        [TestMethod]
        public void MoveTest()
        {
            Moves move = new Moves(10);
            Assert.AreEqual(move.Sequences.Length, 10);
        }

        [TestMethod]
        public void PointTest()
        {
            Point point = new Point(5, 4);
            Assert.AreEqual(point.X, 5);
        }
    }
}
