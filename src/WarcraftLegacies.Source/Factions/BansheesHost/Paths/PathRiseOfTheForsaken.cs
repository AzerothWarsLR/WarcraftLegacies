using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Forsaken;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Paths;

/// <summary>Once the Lich King's grip weakens, Sylvanas breaks free and the Banshee's Host becomes the Forsaken.</summary>
public abstract class PathRiseOfTheForsaken : FactionPath
{
  private const int ObelisksDestroyed = 2;

  protected PathRiseOfTheForsaken(QuestData bansheesVengeance)
  {
    IconName = "BansheeRanger";
    AddRequirement(new ObjectiveEitherOf(
      new ObjectiveUnitsDestroyed(ObelisksDestroyed, "Two of the Icecrown Obelisks have been destroyed",
        AllPreplacedWidgets.Units.GetAll(UNIT_N094_ICECROWN_OBELISK_SCOURGE)),
      new ObjectiveQuestComplete(bansheesVengeance))
    { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    var forsakenPlayer = faction.Player;
    var forsaken = new ForsakenFaction();
    FactionTransition.AssignNewFaction(faction, forsaken);
    var sylvanas = AllLegends.Quel.Sylvanas;
    if (sylvanas.Unit == null || sylvanas.Unit.Alive)
    {
      sylvanas.UnitType = UNIT_USYL_DARK_RANGER_FORSAKEN;
    }

    ArthasDialogue.SetupForsakenBetrayal();

    if (forsakenPlayer != null)
    {
      var bases = new ForsakenBases(forsakenPlayer);
      OnBecameForsaken(bases);
      bases.ConvertScourgeBuildings();
      bases.TrackPalaceName();
      var undercity = forsaken.AddQuest(new QuestUndercity(AllLegends.Lordaeron.CapitalPalace, bases));
      forsaken.DisplayDiscovered(undercity, false);
      forsakenPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\Undercity.ogg");
    }
  }

  /// <summary>Sets up the Forsaken's bases once they have broken free.</summary>
  protected abstract void OnBecameForsaken(ForsakenBases bases);
}
