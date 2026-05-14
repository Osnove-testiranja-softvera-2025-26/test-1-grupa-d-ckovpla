using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OTS2026_GrupaD.Models;
using OTS2026_GrupaD.Exceptions;
using OTS2026_GrupaD;
namespace OTS2026_GrupaD.Test
{
    [TestFixture]
    public class GameTest
    {
        [SetUp]
        public void setup()
        {
            Game game = new Game(new playerLocation(1, 2, 0), new playerLocation(30, 30, 30));

        }
        [Test]
        public void testPlayerLocation()
        {
            Exception exec = Assert.Throws<LocationOutsideOfMapException>((TestDelegate)(() => new Game(new playerLocation(), null)));
            Assert.That(exec.Message, Is.EqualTo("Player location is outside of the map"));

        }
        [TestCaseSource(typeof(moveupsuccsesfull_GameTestData), " moveupsuccsesfull_GameTestData")]
        public void MoveUp_SuccsesfulPlayerPositionChange(int x, int y, int z, int expectedXcordination, object game1)
        {
            Game game = new Game(new playerLocation(x, y, z), new playerLocation(30, 30, 30));
            game.Player.Location = new playerLocation(x, y, z);
            game.MovePlayer(Direction.Up);
            Assert.That(game.Player.Location.Y, Is.EqualTo(y - 1));

        }

        [TestCase(-1, -1, true)]
        [TestCase(31, 31, false)]
        [TestCase(12, 23, false)]

        public void PlayerHasBee()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            game.Player.Location = new playerLocation(12, 23, 0);
            game.UpdatePlayer();
            Assert.That(game.Player.BeeCollected, Is.EqualTo(true));


        }
        public void PlayerDoesNotHaveBee()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            game.Player.Location = new playerLocation(11, 22, 0);
            game.UpdatePlayer();
            Assert.That(game.Player.BeeCollected, Is.EqualTo(false));





        }
        [Test]

        public void PlayerTakesFlower()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            game.Player.Location = new playerLocation(12, 23, 0);
            game.Player.BeeCollected = true;
            game.UpdatePlayer();
            int brojcvetova = game.Player.AmountOfFlowers;
            Assert.That(game.Player.AmountOfFlowers, Is.EqualTo(brojcvetova + 1));
        }
        public void PlayerMakesHoneyJar()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            game.Player.Location = new playerLocation(12, 23, 0);
            game.Player.BeeCollected = true;
            game.Player.AmountOfFlowers = 2;
            int brojcvetova = game.Player.AmountOfFlowers;
            game.UpdatePlayer();
            int brojtegli = game.Player.AmountOfHoneyJars;

            Assert.That(game.Player.AmountOfHoneyJars, Is.EqualTo(brojtegli + brojcvetova));

        }

        public void GoodPlayerScore()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            if (game.Player.AmountOfHoneyJars > 15)
            {
                Assert.That(Score.Good, Is.EqualTo(Score.Good));
            }

        }
        public void AveragePlayerScore()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            if (game.Player.AmountOfFlowers >= 12 && game.Player.BeeCollected)
            {
                Assert.That(Score.Average, Is.EqualTo(Score.Average));
            }
            else if (game.Player.AmountOfHoneyJars > 6)
            {
                Assert.That(Score.Good, Is.EqualTo(Score.Good));


            }
        }
            public void PoorPlayerScore()
        {
            Game game = new Game(new playerLocation(12, 23, 0), new playerLocation(12, 23, 0));
            if (game.Player.AmountOfFlowers < 12 || !game.Player.BeeCollected)
            {
                Assert.That(Score.Poor, Is.EqualTo(Score.Poor));
            }
             else if (game.Player.AmountOfHoneyJars <= 6)
            {
                Assert.That(Score.Poor, Is.EqualTo(Score.Poor));
            }

        }
    }
}




