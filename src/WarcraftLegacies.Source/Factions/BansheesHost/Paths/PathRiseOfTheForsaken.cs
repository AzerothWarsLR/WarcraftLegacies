using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.BansheesHost.Quests;
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

  private readonly QuestData _bansheesVengeance;
  private readonly QuestData _rangerLord;

  protected PathRiseOfTheForsaken(QuestData bansheesVengeance, QuestData rangerLord)
  {
    _bansheesVengeance = bansheesVengeance;
    _rangerLord = rangerLord;
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
    ArthasDialogue.SetupForsakenBetrayal();
    SylvanasDialogue.SetupForsaken();
    SylvanasDialogue.PlayBrokenFree(forsaken);

    if (forsakenPlayer != null)
    {
      var bases = new ForsakenBases(forsakenPlayer);
      OnBecameForsaken(bases);
      bases.ConvertScourgeBuildings();
      bases.TrackPalaceName();
      var undercity = forsaken.AddQuest(new QuestUndercity(AllLegends.Lordaeron.CapitalPalace, bases));
      forsaken.DisplayDiscovered(undercity, false);
      CarryOverQuests(forsaken, AllLegends.Quel.Sylvanas);
      var spoilsOfDalaran = forsaken.AddQuest(new QuestSpoilsOfDalaran(AllLegends.Dalaran.Dalaran));
      forsaken.DisplayDiscovered(spoilsOfDalaran, false);
      forsakenPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\Forsaken1.ogg");
    }
  }

  /// <summary>Gives the Forsaken the Banshee's Host quests they haven't finished yet, or what those quests already earned.</summary>
  private void CarryOverQuests(ForsakenFaction forsaken, LegendaryHero sylvanas)
  {
    if (_rangerLord.Progress == QuestProgress.Complete)
    {
      forsaken.ModObjectLimit(UNIT_H049_RANGER_LORD_FORSAKEN, 1);
    }
    else
    {
      CarryOver(forsaken, _rangerLord, new QuestRangerLord(sylvanas));
    }

    if (_bansheesVengeance.Progress != QuestProgress.Complete)
    {
      CarryOver(forsaken, _bansheesVengeance, new QuestBansheesVengeance(AllLegends.Quel.Spire, sylvanas));
    }
  }

  private static void CarryOver(ForsakenFaction forsaken, QuestData oldQuest, QuestData newQuest)
  {
    oldQuest.SuppressFailureDisplay = true;
    oldQuest.Progress = QuestProgress.Failed;
    var carried = forsaken.AddQuest(newQuest);
    forsaken.DisplayDiscovered(carried, false);
  }

  /// <summary>Sets up the Forsaken's bases once they have broken free.</summary>
  protected abstract void OnBecameForsaken(ForsakenBases bases);
}
