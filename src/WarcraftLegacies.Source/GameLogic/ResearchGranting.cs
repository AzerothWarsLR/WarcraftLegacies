namespace WarcraftLegacies.Source.GameLogic;

public static class ResearchGranting
{
  public static void GrantToAllPlayers(int upgradeId)
  {
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      player.SetTechResearched(upgradeId, 1);
    }
  }
}
