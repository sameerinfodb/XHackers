using Housee.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Data
{
    public class GameRepository : IDisposable
    {
        private Context _context;

        public GameRepository()
        {
            _context = new Context();
        }
        public void AddGame(Game game)
        {
            try
            {

                _context.Games.Add(game);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddPlayer(Player player)
        {

            try
            {

                _context.Players.Add(player);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public Game GetGamesById(int id)
        {
            return _context.Games.Where(m => m.ID == id).SingleOrDefault();
        }
        public List<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }
        public void AddChit(Chit chit)
        {
            try
            {

                _context.Chits.Add(chit);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Contest GetContestById(int contestId)
        {
            return _context.Contests.Where(m => m.ID == contestId).SingleOrDefault();
        }

        public List<Contest> GetAllContest()
        {
            return _context.Contests.ToList<Contest>();
        }


        public List<Contest> GetAllContestWinnerNotDeclared()
        {
            return _context.Contests.Where(m => m.Winner == null).ToList<Contest>();
        }

        public void UpdateContest(Game game, Contest contest, Player player, Status status)
        {
            contest.Winner = player;
            game.Status = status;
            _context.SaveChanges();

        }


        public void UpdateAnnouncementNo(int gameid, int annoucedNo)
        {
            Game game=this.GetGamesById(gameid);
            game.announcement.Add(new Announcement() { NumberAnnouced = annoucedNo, AnnoucedTime = DateTime.Now.ToUniversalTime() });
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
