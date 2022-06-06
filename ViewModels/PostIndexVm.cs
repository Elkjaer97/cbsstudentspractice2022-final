namespace FinalPrac.Models;

public class PostIndexVm
{
    public IEnumerable<Post> Posts { get; set; }
    public string SearchString { get; set; }
    public Post Post { get; set;}
}