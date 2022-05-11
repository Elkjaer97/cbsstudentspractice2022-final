using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;  
//using System.Linq;  
//using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalPrac.Models
{
    public class Profile
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please fill out your full name")]
        [MinLength(3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Name requires to start with a uppercase letter, no numbers or special characters, minimum length of 3 characters.")]
        public string? Name { get; set; }

        //[Required(ErrorMessage = "")]
        public string? About { get; set; }
        public string? Email { get; set; }
        public int Friends {get; set; } // foundation for add friends. Right now its only testing the model and data
        
        [Display(Name = "Profile picture")]
        public string? ProfileImageName { get; set; } // need to find a way to import a picture or use a api?

        [Display(Name = "User created")]
        [DataType(DataType.Date)] // refactor: user dont have to enter the day they're created. App need to solve it by itself.
        public DateTime UserCreated { get; set; } 
    }
}