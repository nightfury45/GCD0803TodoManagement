using GCD0803TodoManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminController : Controller
	{
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;
		public AdminController()
		{
			_context = new ApplicationDbContext();
			_userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(new ApplicationDbContext()));
		}
		// GET: Admin
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult ShowManagers()
		{
			var users = _context.Users.ToList();

			var managers = new List<ApplicationUser>();

			foreach (var user in users)
			{
				if (_userManager.GetRoles(user.Id)[0].Equals("manager"))
				{
					managers.Add(user);
				}
			}

			return View(managers);
		}
	}
}