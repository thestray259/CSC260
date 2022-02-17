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
        /*        public static DateTime dateTime = DateTime.Now;
                private static List<VideoGame> GameList = new List<VideoGame>
                {
                    new VideoGame("Genshin Impact", "PC", "Adventure Role-Playing", "T", 2020, "genshin.jfif"),
                    new VideoGame("Kingdom Hearts", "PlayStation2", "Action Role-Playing", "E10+", 2002, "kingdom_hearts.jpg"),
                    new VideoGame("Assassin's Creed: Brotherhood", "PlayStation4", "Action Adventure, Stealth", "M", 2010, "ac_brotherhood.jpg"),
                    new VideoGame("Dead By Daylight", "PC", "Action, Survival-Horror", "M", 2016, "dbd.jpg", "Jeff", dateTime),
                    new VideoGame("The Legend of Spyro: Dawn of the Dragon", "Wii", "Fantasy, Action-Adventure", "E10+", 2008, "spyro.jpg")
                };*/

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

            // if not null or empty, continue 
            if (!string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(platform) && !string.IsNullOrEmpty(esrbRating))
            {
/*                foreach (var g in GameList)
                {
                    if (g.Genre.ToUpper().Contains(genre.ToUpper()) &&
                        g.Platform.ToUpper().Contains(platform.ToUpper()) &&
                        g.Rating.ToUpper().Contains(esrbRating.ToUpper()))
                    {
                        tmpGames.Add(g);
                    }
                }*/
            }

            return tmpGames; 
        }

        public IEnumerable<VideoGame> GetCollection()
        {
            return db.VideoGames.ToList(); 
        }

        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            List<VideoGame> tmpGames = new List<VideoGame>();

            if (!string.IsNullOrEmpty(key))
            {
/*                foreach (var g in GameList)
                {
                    if (g.Title.ToUpper().Contains(key.ToUpper())) //exception thrown here - key was null
                    {
                        tmpGames.Add(g);
                    }
                }*/
            }

            return tmpGames;
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
