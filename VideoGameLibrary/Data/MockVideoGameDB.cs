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
        public static DateTime dateTime = DateTime.Now;
        private static List<VideoGame> GameList = new List<VideoGame>
        {
            new VideoGame("Genshin Impact", "PC", "Adventure Role-Playing", "T", 2020, "genshin.jfif"),
            new VideoGame("Kingdom Hearts", "PlayStation2", "Action Role-Playing", "E10+", 2002, "kingdom_hearts.jpg"),
            new VideoGame("Assassin's Creed: Brotherhood", "PlayStation4", "Action Adventure, Stealth", "M", 2010, "ac_brotherhood.jpg"),
            new VideoGame("Dead By Daylight", "PC", "Action, Survival-Horror", "M", 2016, "dbd.jpg", "Jeff", dateTime),
            new VideoGame("The Legend of Spyro: Dawn of the Dragon", "Wii", "Fantasy, Action-Adventure", "E10+", 2008, "spyro.jpg")
        };

        public void AddGame(VideoGame videoGame)
        {
            GameList.Add(videoGame); 
        }

        public void DeleteGame(int? id)
        {
            var foundGame = GetGame(id);
            if (foundGame != null)
            {
                GameList.Remove(foundGame);
            }
        }

        public IEnumerable<VideoGame> FilterCollection(string genre, string platform, string esrbRating)
        {
            List<VideoGame> tmpGames = new List<VideoGame>();

            // if not null or empty, continue 
            if (!string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(platform) && !string.IsNullOrEmpty(esrbRating))
            {
                foreach (var g in GameList)
                {
                    if (g.Genre.ToUpper().Contains(genre.ToUpper()) &&
                        g.Platform.ToUpper().Contains(platform.ToUpper()) &&
                        g.Rating.ToUpper().Contains(esrbRating.ToUpper()))
                    {
                        tmpGames.Add(g);
                    }
                }
            }

            return tmpGames; 
        }

        public IEnumerable<VideoGame> GetCollection()
        {
            return GameList; 
        }

        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            List<VideoGame> tmpGames = new List<VideoGame>();

            if (!string.IsNullOrEmpty(key))
            {
                foreach (var g in GameList)
                {
                    if (g.Title.ToUpper().Contains(key.ToUpper())) //exception thrown here - key was null
                    {
                        tmpGames.Add(g);
                    }
                }
            }

            return tmpGames;
        }

        public VideoGame GetGame(int? id)
        {
            VideoGame foundGame = null;

            if (id != null)
            {
                GameList.ForEach(m =>
                {
                    if (m.ID == id)
                    {
                        foundGame = m;
                    }
                });
            }

            return foundGame;
        }
    }
}
