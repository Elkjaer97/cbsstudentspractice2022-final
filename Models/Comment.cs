using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinalPrac.Models;

public class Comment {
    public int CommentId { get; set; }

    public string? Text { get; set; }

    public DateTime TimeStamp { get; set; }



    public int PostId { get; set; }

    public Post? Post { get; set; }

    public IdentityUser? User { get; set;}
}