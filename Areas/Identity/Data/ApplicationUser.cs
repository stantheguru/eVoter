
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eVoter.Areas.Identity.Data
{
    public class ApplicationUser:IdentityUser
    {
      
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public int vote_status { get; set; }

        

        
    }
}
