using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Stormwind;

public sealed class QuestClosePortal : QuestData
{
  private readonly List<unit> _unitsToRemove;
  private readonly LegendaryHero _khadgar;

  public QuestClosePortal(LegendaryHero khadgar) : base("Seal the Dark Portal",
    "The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once and for all.",
    @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
  {
    _khadgar = khadgar;
    AddObjective(new ObjectiveChannelRect(Regions.ClosePortal, "the Dark Portal", khadgar, 480, 270, Title));
    Global = true;
    _unitsToRemove = new List<unit>
    {
      //Outside the portal
      PreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, 15579, -19546),
      PreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, 16549, -19145),
      PreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, 17447, -19214),
      //Inside the portal
      PreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, 4576, -24718),
      PreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, 4701, -25361),
      PreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, 5212, -25743),
      //Control Nexi
      PreplacedWidgets.Units.GetClosest(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, 17420, -17900),
      PreplacedWidgets.Units.GetClosest(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, 3703, -26045)
    };
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Khadgar has sealed the Dark Portal forever, finally correcting the mistake made by his former master decades ago.";

  /// <inheritdoc/>
  protected override string RewardDescription => "The Dark Portal closes permanently";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    _unitsToRemove.Clear();
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _unitsToRemove)
    {
      unit.Dispose();
    }
    _unitsToRemove.Clear();
    if (_khadgar.Unit != null)
    {
      AddHeroXP(_khadgar.Unit, 10000, true);
    }
  }
}
