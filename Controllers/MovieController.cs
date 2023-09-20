using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vivid.Data.Interfaces;
using Vivid.Models;
using Vivid.ViewModels;

namespace Vivid.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "One Piece", Description = "..." },
                new Movie { Id = 2, Title = "Rings of Power", Description = "..." },
                new Movie { Id = 3, Title = "The Witcher", Description = "..." },
            };

            var moviesFromDI = _movieRepository.GetMovies();

            var moviesVM = new MoviesViewModel
            {
                Movies = (List<Movie>)moviesFromDI,
            };

            ViewData["Movies"] = moviesVM;

            return View(moviesVM);
        }

        public ActionResult Detail(int id = 1)
        {
            var movie = new Movie()
            {
                Id = id,
                Title = "One Piece",
                Description = "..."
            };

            var users = new List<User>
            {
                new User { Name = "Barj", Username = "Barj Lazuardi" },
                new User { Name = "Kazo", Username = "Kazo Yama" },
                new User { Name = "Ratan", Username = "Ratan Dragon" },
            };

            var movieDetailsVM = new MovieDetailsViewModel
            {
                Movie = movie,
                Users = users,
            };

            ViewBag.Details = movieDetailsVM;

            return View(movieDetailsVM);
        }

        // GET: Movie/Edit/1
        public ActionResult Edit(int id = 1)
        {
            var movie = new Movie
            {
                Id = id,
                Title = "One Piece Live Action",
                Description = "...",
                Url = "https://onepiecenetflix.com/"
            };

            return View(movie);
        }

        // GET: Movie/Search?pageIndex=1&sortBy=name&title=marvel
        public ActionResult Search(int? pageIndex, string sortBy, string title)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}&title={2}", pageIndex, sortBy, title));
        }

        // custom route implementation `App_Start/RouteConfig.cs`
        // GET: Movie/Released/2015/05
        [Route("Movie/Released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}