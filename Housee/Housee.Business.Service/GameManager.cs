using Housee.Business.Model;
using Housee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Business.Service
{

    public class GameManager
    {


        RandomNumberGenerator rng = new RandomNumberGenerator();
        GameRepository _gameRepository = new GameRepository();

        public void CreateGame(string name, DateTime scheduleTime)
        {

            List<Contest> contest = new List<Contest> {
                                               new  Contest { Name = "Full House", Winner = null }
            };
            _gameRepository.AddGame(
                new Game
                {
                    Name = name,
                    ScduledDateTime = scheduleTime,
                    Status = Status.NotStarted,
                    Contests = contest
                });
        }

        public List<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames();
        }

        public Game GetGameByGameID(int gameID)
        {
            return _gameRepository.GetGamesById(gameID);
        }

        public int AnnounceNumber(int gameID)
        {
            int number = rng.Next();

            _gameRepository.UpdateAnnouncementNo(gameID, number);

            return number;
        }

        public Contest GetContestByID(int contestID)
        {
            return _gameRepository.GetContestById(contestID);
        }

        public void UpdateGameContest(int GameID, int ContestID, Player player)
        {
            Game game = this.GetGameByGameID(GameID);
            List<Contest> contests = _gameRepository.GetAllContestWinnerNotDeclared();

            if (contests.Count() != 0) // check if there are any contest where Winner is null
            {
                if (contests.Count == 1) // last contest is left
                {
                    if (contests.Single().ID == ContestID)//check if contest.ID match
                    {
                        _gameRepository.UpdateContest(game, contests.Single(), player, Status.Completed);
                      
                    }

                }

            }

        }

    

    }
}
