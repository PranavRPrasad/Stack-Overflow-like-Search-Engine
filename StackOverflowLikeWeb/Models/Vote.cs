﻿namespace StackOverflowLikeWeb.Models;

public partial class Vote
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int? UserId { get; set; }

    public int? BountyAmount { get; set; }

    public int VoteTypeId { get; set; }

    public DateTime CreationDate { get; set; }

    public Post Post { get; set; }
}
