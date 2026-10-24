using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>Turns Dalaran into Theramore, keeping only what it holds in Theramore and leaving its other buildings to its allies.</summary>
public sealed class TheramoreTransformation
{
  /// <summary>Turns <paramref name="dalaran"/>'s player into Theramore.</summary>
  public void Execute(Faction dalaran)
  {
    var whichPlayer = dalaran.Player;
    if (whichPlayer == null)
    {
      return;
    }

    DalaranHomeland.ClaimHeldLands(dalaran);
    var heir = DalaranHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Theramore);
    DalaranHomeland.MakeBookKeeper(heir);
    PathBase.RemoveAllUnitsOutside(whichPlayer, Regions.Theramore);
    FactionTransition.AssignNewFaction(dalaran, new TheramoreFaction());

    var center = Regions.Theramore.Center;
    PathBase.ClaimArea(Regions.Theramore, whichPlayer);
    if (dalaran is DalaranFaction dalaranFaction && dalaranFaction.TheramoreQuest != null)
    {
      dalaranFaction.TheramoreQuest.GiveTheramoreTo(whichPlayer);
    }
    PathBase.CreateUnits(whichPlayer, UNIT_H022_FARMER_DALARAN_WORKER, 5, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_H032_BATTLEMAGE_DALARAN, 4, center.X - 250, center.Y + 300);
    PathBase.CreateUnits(whichPlayer, UNIT_N0AK_INITIATE_MAGE_DALARAN, 4, center.X + 250, center.Y + 300);
    PathBase.SummonLegend(AllLegends.Dalaran.Jaina, whichPlayer, new Point(center.X, center.Y));
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\HumanX1.mp3");
  }
}
