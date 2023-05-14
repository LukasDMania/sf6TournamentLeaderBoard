﻿using System;
using System.Collections.Generic;

namespace NewLEaderboard.Models;

public partial class Tournament
{
    public int TournamentId { get; set; }

    public string TournamentName { get; set; } = null!;

    public DateTime TournamentDate { get; set; }

    public int ParticipantsAmount { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
