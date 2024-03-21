using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StackOverflowLikeWeb.Models;

[Index(nameof(Name))]
public partial class VoteType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
