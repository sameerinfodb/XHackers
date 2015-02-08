using Housee.Business.Model;
using Housee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Business.Service
{
    public  class PlayerManager
    {
        RandomNumberGenerator rng = new RandomNumberGenerator();
        public Chit SubScribTo(Game game, Player player)
        {
            // Generate the Random numbers for the chit
            List<int> randomNumbers = rng.GenerationRandomNumbers(15);

            (new GameRepository()).AddPlayer(player);
    
            Chit chit = new Chit { Game = game, Player = player, numbers = randomNumbers };

            (new GameRepository()).AddChit(chit);

            return chit;
        }

        public void CallBingo(int GameID, int ContestID, Player player)
        {
            //Check if alreay Winner is declared if not declare the player a contest winner
            if (!IsWinnerDeclared(GameID, ContestID))
            {
                Game game = (new GameRepository()).GetGamesById(GameID);
                Contest contest = game.Contests.Find(m => m.ID == ContestID);
                if (contest.Winner != null)
                {
                    contest.Winner = player;
                }
            }
        }

        public bool IsWinnerDeclared(int GameID, int ContestID)
        {
            Game game = (new GameRepository()).GetGamesById(GameID);
            Contest contest = game.Contests.Find(m => m.ID == ContestID);
            if (contest.Winner != null)
            {
                return true;
            }
            return false;
        }
    }
}
