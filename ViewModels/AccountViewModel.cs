﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vivid.Models;

namespace Vivid.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public List<User> AllUsers { get; set; }
    }
}