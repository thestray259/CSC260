using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces; 

namespace VideoGameLibrary.Data
{
    public class MockVideoGameDB : IDataAccessLayer
    {
        private VideoGameContext db; 

        public MockVideoGameDB(VideoGameContext indb)
        {
            this.db = indb; 
        }

        public void AddGame(VideoGame videoGame)
        {
            videoGame.ID = 0; 
            db.Add(videoGame);
            db.SaveChanges(); 
        }

        public void DeleteGame(int? id)
        {
            if (id > 0)
            {
                db.VideoGames.Remove(db.VideoGames.Find(id));
                db.SaveChanges(); 
            }
        }

        public IEnumerable<VideoGame> FilterCollection(string genre, string platform, string esrbRating)
        {
            List<VideoGame> tmpGames = new List<VideoGame>();
            var games = from g in db.VideoGames select g;

            // if not null or empty, continue 
            if (!string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(platform) && !string.IsNullOrEmpty(esrbRating))
            {
                games = games.Where(g => g.Genre.Contains(genre) && g.Platform.Contains(platform) && g.Rating.Contains(esrbRating));
            }

            return games.ToList(); 
        }

        public IEnumerable<VideoGame> GetCollection()
        {
            return db.VideoGames.ToList(); 
        }

        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            var games = from g in db.VideoGames select g;

            if (!string.IsNullOrEmpty(key))
            {
                games = games.Where(g => g.Title.Contains(key)); 
            }

            return games.ToList();
        }

        public void ReturnGame(string title)
        {
            //var game = GameList.Find(x => x.Title == title);
            //game.ReturnGame();
        }

        public void LoanGame(string title, string loaner)
        {
            //var game = GameList.Find(x => x.Title == title);
            //game.Loan(loaner);
        }

        public void UpdateGame(VideoGame videoGame)
        {
            db.Update(videoGame);
            db.SaveChanges(); 
        }

        public VideoGame GetGame(int? id)
        {
            return db.VideoGames.FirstOrDefault(m => m.ID == id);
        }
    }
}
