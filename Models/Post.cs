using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinalPrac.Models;
public class Post {
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Text { get; set; }

    [DataType(DataType.Date)]
    public DateTime Created { get; set; }

    public PostStatus Status { get; set; }

    public List<Comment>? Comments { get; set; }
    
    public string? UserId { get; set; }

    public IdentityUser? User { get; set; }
    
}