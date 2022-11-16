
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eVoter.Areas.Identity.Data
{
    public class Voter:IdentityUser
    {
      
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public int vote_status { get; set; }

        public static explicit operator Voter(Task<IdentityUser> v)
        {
            throw new NotImplementedException();
        }
    }
}
