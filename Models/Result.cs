using System;
using System.Collections.Generic;

namespace NewLEaderboard.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int PlayerId { get; set; }

    public int TournamentId { get; set; }

    public int Placing { get; set; }

    public string CharacterUsed { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;
}
