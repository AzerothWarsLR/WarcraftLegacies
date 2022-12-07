using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Mechanics.Scourge
{
  /// <summary>
  ///  When Scourge leaves the game, drop the Helm of Domination to an easily accessible position since the default position is hard to see.
  /// </summary>
  public static class HelmOfDominationDropsWhenScourgeLeaves
  {
    /// <summary>
    /// Sets up <see cref="HelmOfDominationDropsWhenScourgeLeaves"/>.
    /// </summary>
    public static void Setup()
    {
      if (LegendScourge.LegendLichking == null)
        throw new SystemNotInitializedException(nameof(LegendScourge));
      if (ScourgeSetup.Scourge == null)
        throw new SystemNotInitializedException(nameof(ScourgeSetup));
      LegendScourge.LegendLichking.PermanentlyDied += OnLichKingDeath;
      ScourgeSetup.Scourge.LeftGame += OnScourgeLeaveGame;
    }

    private static void OnLichKingDeath(object? sender, Legend legend)
    {
      CheckHelmOfDomination();
      UnregisterEvents();
    }

    private static void OnScourgeLeaveGame(object? sender, Faction faction)
    {
      CheckHelmOfDomination();
      UnregisterEvents();
    }

    private static void UnregisterEvents()
    {
      if (LegendScourge.LegendLichking != null) 
        LegendScourge.LegendLichking.PermanentlyDied -= OnLichKingDeath;
      if (ScourgeSetup.Scourge != null) 
        ScourgeSetup.Scourge.LeftGame -= OnScourgeLeaveGame;
    }
    
    private static void CheckHelmOfDomination()
    {
      if (ArtifactSetup.ArtifactHelmofdomination == null
          || LegendScourge.LegendLichking?.Unit == null)
        return;

      var lichKingPosition = LegendScourge.LegendLichking.Unit.GetPosition();
      LegendScourge.LegendLichking.Unit.DropAllItems();
      ArtifactSetup.ArtifactHelmofdomination.Item.SetPosition(new Point(lichKingPosition.X - 55,
        lichKingPosition.Y + 30));
    }
  }
}