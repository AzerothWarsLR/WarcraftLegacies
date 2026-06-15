using WCSharp.SaveLoad;

namespace WarcraftLegacies.Source.Save;


public sealed class MmdSaveData : Saveable
{
  public int GamesPlayed { get; set; }
  public int Wins { get; set; }
  public int Losses { get; set; }
  public int TotalScore { get; set; }
  public int LastScore { get; set; }
  public int PlayerId { get; set; }
}
