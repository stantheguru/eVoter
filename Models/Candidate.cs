using System.ComponentModel.DataAnnotations;


namespace eVoter.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Avatar { get; set; }

        public int Votes { get; set; }

        




    }
}
