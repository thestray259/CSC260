using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models; 

namespace VideoGameLibrary.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<VideoGame> GetCollection();
        IEnumerable<VideoGame> SearchForGames(string key);
        IEnumerable<VideoGame> FilterCollection(string genre, string platform, string esrbRating); 
        void AddGame(VideoGame videoGame);
        void DeleteGame(int? id);
    }
}
