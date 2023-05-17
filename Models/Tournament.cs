using System;
using System.Collections.Generic;

namespace NewLEaderboard.Models;

public partial class Tournament
{
    public int TournamentId { get; set; }

    public string TournamentName { get; set; }
    public string TournamentVodUrl { get; set; }
    public string ChallongeUrl { get; set; }

    public DateTime TournamentDate { get; set; }

    public int ParticipantsAmount { get; set; }
    public string TournamentNameAndDateDisplay { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();


    public void NameDateDisplay() 
    {
        TournamentNameAndDateDisplay = $"{TournamentName} - {TournamentDate}";
    }

    public void CalculateParticipantAmount() 
    {
        ParticipantsAmount = 0;
        foreach (var item in Results)
        {
            if (item.TournamentId == TournamentId)
            {
                ParticipantsAmount++;
            }
        }
    }

}
