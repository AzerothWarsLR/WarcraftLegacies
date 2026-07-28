namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Grants a research/upgrade to every player at once - shared by the Flight/Navigation Availability custom
/// options and Hard mode's universal tech unlocks.
/// </summary>
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
