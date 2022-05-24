using System.ComponentModel.DataAnnotations;

namespace FinalPrac.Models {
    public class Event {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }

        public string About { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public String Location { get; set; }

        
        public Profile profile { get; set; }

    }
}