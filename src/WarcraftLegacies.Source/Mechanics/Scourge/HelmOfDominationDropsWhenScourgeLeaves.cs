using WarcraftLegacies.Source.Setup.Legends;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using MacroTools.FactionSystem;
using MacroTools.Extensions;
using WCSharp.Shared.Data;

/// <summary>
///  When Scourge leaves the game, drop the Helm of Domination to an easily accessible position since the default position is hard to see.
/// </summary>
public class HelmOfDominationDropsWhenScourgeLeaves
{
    public static void Setup()
    {
        Faction.GameLeave += Faction_GameLeave;
    }

    private static void Faction_GameLeave(object? sender, Faction leavingFaction)
    {
        if (ArtifactSetup.ArtifactHelmofdomination == null || LegendScourge.LegendLichking?.Unit == null)
            return;
        
        if (leavingFaction == ScourgeSetup.Scourge && ArtifactSetup.ArtifactHelmofdomination.OwningUnit == LegendScourge.LegendLichking.Unit)
        {
            var lichKingPosition = LegendScourge.LegendLichking.Unit.GetPosition();
            LegendScourge.LegendLichking.Unit.DropAllItems();
            ArtifactSetup.ArtifactHelmofdomination.Item.SetPosition(new Point(lichKingPosition.X - 55, lichKingPosition.Y + 30));// Move item in front of the LK 
        }
    }
}

