using GCD0803TodoManagement.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	[Authorize(Roles = "manager")]
	public class TeamsController : Controller
	{
		private ApplicationDbContext _context;
		public TeamsController()
		{
			_context = new ApplicationDbContext();
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
	}
}