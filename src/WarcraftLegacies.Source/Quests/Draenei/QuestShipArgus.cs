using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Draenei;

/// <summary>
/// Create a portal between Tempest Keep and Argus.
/// </summary>
public sealed class QuestShipArgus : QuestData
{
  private readonly unit _outlandToArgusWaygate;
  private readonly unit _argusToOutlandWaygate;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestShipArgus"/> class.
  /// </summary>
  /// <param name="outlandToArgusWaygate">Starts hidden, and gets enabled as a waygate when the quest is complete.</param>
  /// <param name="argusToOutlandWaygate">Starts hidden, and gets enabled as a waygate when the quest is complete.</param>
  /// <param name="velen">Needs to be brought somewhere to complete the quest.</param>
  public QuestShipArgus(unit outlandToArgusWaygate, unit argusToOutlandWaygate, LegendaryHero velen) : base("Reconquering Tempest Keep",
    "Tempest Keep still has the power to open a portal Argus, but Velen needs to channel it",
    @"ReplaceableTextures\CommandButtons\BTNArcaneCastle.blp")
  {
    ShowUnit(outlandToArgusWaygate, false);
    _outlandToArgusWaygate = outlandToArgusWaygate;
    ShowUnit(argusToOutlandWaygate, false);
    _argusToOutlandWaygate = argusToOutlandWaygate;
    AddObjective(new ObjectiveChannelRect(Regions.TempestKeepSpawn, "Tempest Keep", velen, 180, 0));
    Global = true;
    Progress = QuestProgress.Undiscovered;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "Velen has opened the portal to Argus";

  /// <inheritdoc />
  protected override string RewardDescription => "Open a Portal between Tempest Keep and Argus";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    ShowUnit(_outlandToArgusWaygate, true);
    _outlandToArgusWaygate
      .SetWaygateDestination(Regions.TempestKeepSpawn.Center);
    ShowUnit(_argusToOutlandWaygate, true);
    _argusToOutlandWaygate
      .SetWaygateDestination(Regions.OutlandToArgus.Center);
  }
}
