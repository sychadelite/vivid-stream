using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Vivid.Models;
using Vivid.ViewModels;
using Vivid.Data.Interfaces;
using System.Threading.Tasks;

namespace Vivid.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;

        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        // GET: Actor
        public async Task<ActionResult> Index()
        {
            var actorList = await _actorRepository.GetAllActors();

            var actorVM = new IndexActorsViewModel
            {
                ActorList = actorList
            };

            return View(actorVM);
        }

        // GET: Actor/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Actor actor = await _actorRepository.GetActorById(id);
            return View(actor);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateActorViewModel createActorVM)
        {
            var isNameExists = await _actorRepository.IsNameExists(createActorVM.Name);

            if (isNameExists)
            {
                // Set the flag in ViewData
                ViewData["NameExists"] = true;

                // Return the view with validation error messages
                ModelState.AddModelError("Name", "Name already exists.");

                return View(createActorVM);
            }

            var result = await _actorRepository.CreateActor(createActorVM);

            return RedirectToAction("Index");
        }

        // GET: Actor/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Actor actor = await _actorRepository.GetActorById(id);

            if (actor == null)
            {
                return HttpNotFound();
            }

            var editActorVM = new EditActorViewModel
            {
                Name = actor.Name,
                Bio = actor.Bio,
                City = actor.City,
                BirthDate = actor.BirthDate
            };

            return View(editActorVM);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditActorViewModel editActorVM)
        {
            await _actorRepository.UpdateActor(id, editActorVM);
            return RedirectToAction("Index");
        }

        // GET: Actor/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Actor actor = await _actorRepository.GetActorById(id);

            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor); ;
        }

        // POST: Actor/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            await _actorRepository.DeleteActor(id);

            return RedirectToAction("Index");
        }
    }
}
