using eVoter.Data;
using eVoter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using eVoter.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace eVoter.Controllers
{
    public class CandidateController : Controller
    {
        private readonly eVoterContext _db;
        UserManager<IdentityUser> UserManager;
        SignInManager<IdentityUser> SignInManager;



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
        public  IActionResult Vote()
        {
            string id = Request.Form["user_id"];
            string c_id = Request.Form["candidate_id"];
            int votes = 0;

            string connectionString = "Server=DESKTOP-OI49JN6;Database=eVoter;Trusted_Connection=True;";  // typically, you get this from a config file
            string query = "UPDATE dbo.AspNetUsers SET vote_status = 1 WHERE Id='"+id+"';";

            string sqlCurrentVotes = "select votes from dbo.Candidates  WHERE CandidateID='" + c_id + "';";




            // set up your connection and command, in "using" blocks
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query,conn);

            SqlCommand sqlCommandCurrentVotes = new SqlCommand(sqlCurrentVotes, conn);
            

            {
                // open connection, execute query, close connection
                conn.Open();
                SqlDataReader reader = sqlCommandCurrentVotes.ExecuteReader();

                while (reader.Read())
                {
                    votes = (int)reader[0];
                }
                votes = votes + 1;
                conn.Close();
                // since you are doing an "INSERT" - use "ExecuteNonQuery"
                // this returns only the number of rows inserted - no result set
                conn.Open();
                string sqlVotes = "UPDATE dbo.Candidates SET votes = '" + votes + "'  WHERE CandidateID='" + c_id + "';";
                SqlCommand sqlCommandVotesUpdate = new SqlCommand(sqlVotes, conn);
                sqlCommandVotesUpdate.ExecuteNonQuery();
                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }





            return RedirectToAction("Index");
        }


    }
}
