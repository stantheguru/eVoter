using eVoter.Data;
using eVoter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eVoter.Controllers
{
    public class HomeController : Controller
    {
        private readonly eVoterContext _db;

        public HomeController(eVoterContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Candidate> candidates = _db.Candidates;
            return View(candidates);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}