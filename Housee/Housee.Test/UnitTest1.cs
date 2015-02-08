using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Housee.Business.Service;
using System.Diagnostics;
using Housee.Business.Model;

namespace Housee.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateGameTestCase()
        {
            var rng=new RandomNumberGenerator();
            Debug.WriteLine(rng.Next());
            Debug.WriteLine(rng.GenerationRandomNumbers(15));

            GameManager gm = new GameManager();

            gm.CreateGame("Game1", DateTime.Now);
            Debug.WriteLine(rng.Next());
            Debug.WriteLine(rng.GenerationRandomNumbers(15));

        }

        [TestMethod]
        public void SubscribToGameTestCase()
        {
            GameManager gm= new GameManager();
            PlayerManager pm = new PlayerManager();

            Game game=gm.GetGameByGameID(1);


            Chit chit = pm.SubScribTo(game, new Player { Email = "sameer1352@gmail.com", Name = "sameer" });

            Debug.WriteLine(chit.numbers.Count);
            Assert.AreEqual(chit.numbers.Count, 15);
        }
    }
}
