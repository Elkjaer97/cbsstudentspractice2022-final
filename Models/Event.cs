using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinalPrac.Models {
    public class Event {

        public int EventId { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        //public String Location { get; set; }

        //public Profile profile { get; set; }
        
    }
}