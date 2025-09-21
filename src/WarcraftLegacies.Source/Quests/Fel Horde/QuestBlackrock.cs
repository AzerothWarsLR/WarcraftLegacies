using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Fel_Horde;

/// <summary>
/// A <see cref="QuestData"/> that unlocks Blackrock when completed.
/// </summary>
public sealed class QuestBlackrock : QuestData
{
  private readonly List<unit> _rescueUnits1;
  private readonly List<unit> _rescueUnits2;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBlackrock"/> class.
  /// </summary>
  public QuestBlackrock(Rectangle rescueRect1, Rectangle rescueRect2, IEnumerable<QuestData> prequisites) : base("Blackrock Unification",
    "Make contact with the Blackrock clan and convince them to join Magtheridon",
    @"ReplaceableTextures\CommandButtons\BTNBlackhand.blp")
  {
    foreach (var prequisite in prequisites)
    {
      AddObjective(new ObjectiveQuestComplete(prequisite));
    }

    AddObjective(new ObjectiveResearch(UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, UNIT_O008_HELLFIRE_CITADEL_FEL_HORDE));
    AddObjective(new ObjectiveTime(540));
    AddObjective(new ObjectiveExpire(900, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R03C_QUEST_COMPLETED_BLACKROCK_UNIFICATION;
    _rescueUnits1 = rescueRect1.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _rescueUnits2 = rescueRect2.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  //Todo: bad flavour
  /// <inheritdoc />
  public override string RewardFlavour =>
    "Blackrock Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Control of all units in Blackrock Citadel, a small outpost near the Dark Portal and enable Dal'rend Blackhand to be trained at the altar";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits1);
    rescuer.RescueGroup(_rescueUnits2);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits1);
    completingFaction.Player.RescueGroup(_rescueUnits2);

    completingFaction.Player.PingMinimapSimple(12400.0f, -11800.0f, 3.0f);
  }


  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) =>
    whichFaction.ModObjectLimit(UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, Faction.Unlimited);
}
