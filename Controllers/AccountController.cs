using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vivid.Data.Interfaces;
using Vivid.ViewModels;

namespace Vivid.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Account
        public ActionResult Index(int id = 0)
        {
            var usersFromDI = _userRepository.GetUsers();

            var accountVM = new AccountViewModel()
            {
                Id = id,
                Username = "barjlazuardi",
                Name = "Barj",
                Email = "barj.corp@gmail.com",
                Bio = null,
                AllUsers = (List<Models.User>)usersFromDI
            };

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});

            return View(accountVM);
        }

        // GET: Account/Edit
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}