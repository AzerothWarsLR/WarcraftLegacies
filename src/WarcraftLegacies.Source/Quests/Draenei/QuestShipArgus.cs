using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

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
    outlandToArgusWaygate.IsVisible = false;
    _outlandToArgusWaygate = outlandToArgusWaygate;
    argusToOutlandWaygate.IsVisible = false;
    _argusToOutlandWaygate = argusToOutlandWaygate;
    AddObjective(new ObjectiveChannelRect(Regions.TempestKeepSpawn, "Tempest Keep", velen, 180, 0));
    Global = true;
    Progress = QuestProgress.Undiscovered;
  }

  /// <inheritdoc />
  protected override string RewardDescription => "Open a Portal between Tempest Keep and Argus";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    _outlandToArgusWaygate.IsVisible = true;
    _outlandToArgusWaygate
      .SetWaygateDestination(Regions.TempestKeepSpawn.Center);
    _argusToOutlandWaygate.IsVisible = true;
    _argusToOutlandWaygate
      .SetWaygateDestination(Regions.OutlandToArgus.Center);
  }
}
