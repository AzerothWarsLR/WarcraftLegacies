using System.Collections.Generic;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public sealed class MmdPlayerStats
{
  public int PlayerId { get; }

  public string? FactionName { get; set; }
  public string? PlayerName { get; set; }
  public string? TeamName { get; set; }

  public string? HeroName { get; set; }

  public int HeroKills { get; set; }
  public int HeroDeaths { get; set; }
  public float HeroDamageDealt { get; set; }
  public float HeroDamageTaken { get; set; }
  public int HeroRevives { get; set; }

  public int UnitsKilled { get; set; }
  public int UnitsLost { get; set; }

  public float DamageToUnits { get; set; }
  public float DamageToHeroes { get; set; }
  public float DamageTakenUnits { get; set; }
  public float DamageTakenHeroes { get; set; }

  public float GoldEarned { get; set; }
  public float GoldSpent { get; set; }

  public float CpMinutesOwned { get; set; }
  public int CpCaptures { get; set; }
  public int CpValueControlled { get; set; }

  public List<int> UpgradesCompleted { get; } = new();
  public List<string> CapitalsDestroyed { get; } = new();

  public string? TechPath { get; set; }

  public string Result { get; set; } = "Unknown";

  public MmdPlayerStats(int playerId)
  {
    PlayerId = playerId;
  }
}
