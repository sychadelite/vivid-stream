using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vivid.Data.Interfaces;
using Vivid.Models;

namespace Vivid.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
               new Movie() { Id = 1, Title = "Ali", Url = "https://aligmail.com", Description = "Morocco"},
               new Movie() { Id = 2, Title = "Amine", Url = "https://aminegmail.com", Description = "Morocco"},
               new Movie() { Id = 3, Title = "Kumar", Url = "https://kumargmail.com", Description = "India"},
               new Movie() { Id = 4, Title = "Messi", Url = "https://messigmail.com", Description = "Spain"},
            };

            return movies;
        }
    }
}