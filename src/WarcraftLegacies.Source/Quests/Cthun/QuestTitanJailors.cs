using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Rocks;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun;

public sealed class QuestTitanJailors : QuestData
{
  private readonly List<unit> _rescueUnits;
  private readonly List<RockGroup> _rockGroups;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestTitanJailors"/> class.
  /// </summary>
  public QuestTitanJailors(Rectangle rescueRect)
      : base("Titan Jailors",
            "C'thun is currently watched by a Titan Construct. We must rid the temple of hostiles and destroy the Titan to free our god.",
            @"ReplaceableTextures\CommandButtons\BTNArmorGolem.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ, 1500));
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveUpgrade(UNIT_U022_NEXUS_CTHUN_T3, UNIT_U020_MONUMENT_CTHUN_T1));
    _rockGroups = new List<RockGroup>();
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    RegisterRockGroups();
  }
  /// <inheritdoc />
  public override string RewardFlavour => "The Titan Construct has fallen, and C'thun stirs within his prison. The Old God is free to spread chaos once more.";
  // <inheritdoc />
  protected override string RewardDescription => "Control of all units in Ahn'Qiraj Temple and C'thun becomes active";


  /// <summary>
  /// Registers the RockGroups associated with this quest.
  /// </summary>
  private void RegisterRockGroups()
  {
    _rockGroups.Add(new RockGroup(Regions.AQ_Blockers, FourCC("LTrc"), 0));
    foreach (var rockGroup in _rockGroups)
    {
      RockSystem.Register(rockGroup);
    }
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    CleanupRocks();

    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? player.NeutralAggressive
        : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    CleanupRocks();
    completingFaction.Player.RescueGroup(_rescueUnits);
    var cthun = AllLegends.Ahnqiraj.Cthun.Unit;
    if (cthun != null)
    {
      UnitTypeTraitRegistry.ForceOnCreated(cthun);
    }
  }

  /// <summary>
  /// Removes all rocks associated with this quest.
  /// </summary>
  private void CleanupRocks()
  {
    foreach (var rockGroup in _rockGroups)
    {
      RockSystem.Remove(rockGroup);
    }
  }
}
