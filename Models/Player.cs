using System;
using System.Collections.Generic;

namespace NewLEaderboard.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string UserName { get; set; } = null!;
    public string DiscordTag { get; set; } = null!;

    public string MainCharacter { get; set; } = null!;

    public int WeeksCompeted { get; set; }
    public int AmountFirstPlace { get; set; }
    public int AmountSecondPlace { get; set; }
    public int AmountThirdPlace { get; set; }

    public int TotalPoints { get; set; }
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();




    public int CalculateTotalPoints()
    {
        int totalPoints = 0;

        foreach (var result in Results)
        {
            switch (result.Placing)
            {
                case 1:
                    totalPoints += 15;
                    break;
                case 2:
                    totalPoints += 12;
                    break;
                case 3:
                    totalPoints += 10;
                    break;
                case 4:
                    totalPoints += 8;
                    break;
                case 5:
                    totalPoints += 6;
                    break;
                case 7:
                    totalPoints += 4;
                    break;
                case 9:
                    totalPoints += 2;
                    break;
                default:
                    totalPoints += 1;
                    break;
            }
        }

        return totalPoints;
    }
    public void CalculateTotalTopThree()

    {
        int totalFirsts = 0;
        int totalSeconds = 0;
        int totalThirds = 0;

        foreach (var result in Results)
        {
            switch (result.Placing)
            {
                case 1:
                    totalFirsts++;
                    break;
                case 2:
                    totalSeconds++;
                    break;
                case 3:
                    totalThirds++;
                    break;
                default:
                    break;
            }
        }

        AmountFirstPlace = totalFirsts;
        AmountSecondPlace= totalSeconds;
        AmountThirdPlace= totalThirds;
    }
    public int CalculateTotalWeeksCompeted() 
    {
        int totalWeeksCompeted = 0;

        foreach (var result in Results)
        {
            if (result.PlayerId == PlayerId)
            {
                totalWeeksCompeted++;
            } 
        }

        return totalWeeksCompeted;
    }

}
