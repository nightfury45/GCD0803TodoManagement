﻿using GCD0803TodoManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	[Authorize(Roles = "manager")]
	public class TeamsController : Controller
	{
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;
		public TeamsController()
		{
			_context = new ApplicationDbContext();
			_userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(new ApplicationDbContext()));
		}
		// GET: Teams
		[HttpGet]
		public ActionResult Index()
		{
			var teams = _context.Teams.ToList();
			return View(teams);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Team team)
		{
			if (!ModelState.IsValid)
			{
				return View(team);
			}

			var newTeam = new Team
			{
				Name = team.Name
			};

			_context.Teams.Add(newTeam);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Members(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			var members = _context.TeamsUsers
				.Include(t => t.User)
				.Where(t => t.TeamId == id)
				.Select(t => t.User);

			return View(members);
		}
		[HttpGet]
		public ActionResult AddMembers(int id)
		{
			var usersInDb = _context.Users.ToList();

			var usersInTeam = _context.TeamsUsers
				.Include(t => t.User)
				.Where(t => t.TeamId == id)
				.Select(t => t.User)
				.ToList();

			var usersToAdd = new List<ApplicationUser>();

			foreach (var user in usersInDb)
			{
				if (!usersInTeam.Contains(user) &&
					_userManager.GetRoles(user.Id)[0].Equals("user"))
				{
					usersToAdd.Add(user);
				}
			}

			return View(usersToAdd);
		}

	}
}