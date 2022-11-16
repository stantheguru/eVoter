using eVoter.Data;
using eVoter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using eVoter.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;


namespace eVoter.Controllers
{
    public class CandidateController : Controller
    {
        private readonly eVoterContext _db;
        UserManager UserManager;

        public CandidateController()
            : this(new UserManager<Voter>(new UserStore<Voter>(new eVoterContext())))
        {
        }

        public CandidateController(UserManager<Voter> userManager)
        {
            UserManager = userManager;
        }
        public CandidateController(eVoterContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Candidate> candidates = _db.Candidates;
            return View(candidates);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Vote(string? username)
        {
            Voter voter = new Voter();
            UserManager = new UserManager();


            var user = (Voter)UserManager.FindByEmailAsync("morena@ruby.com");
            Console.WriteLine(user);
            user.vote_status = 1;
            UserManager.UpdateAsync(user);

            
            


            return View();
        }


    }
}
