using WCSharp.SaveLoad;

namespace MacroTools.Save;

public sealed class PlayerMatchStats : Saveable
{
  public int Wins { get; set; }
  public int Losses { get; set; }
  public int GamesPlayed { get; set; }
  public int LastSlotPlayed { get; set; }
  public string? LastFactionPlayed { get; set; }
  public string? LastTeamName { get; set; }
}
