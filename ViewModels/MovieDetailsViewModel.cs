using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vivid.Models;

namespace Vivid.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public List<User> Users { get; set; }
    }
}