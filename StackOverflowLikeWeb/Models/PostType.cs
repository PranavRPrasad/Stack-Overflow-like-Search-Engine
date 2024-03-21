using Microsoft.EntityFrameworkCore;

namespace StackOverflowLikeWeb.Models;

[Index(nameof(Type))]
public partial class PostType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;
}
