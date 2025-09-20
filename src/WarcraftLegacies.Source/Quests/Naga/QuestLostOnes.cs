using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestLostOnes : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <param name="rescueRect">Units in this area start invulnerable then get rescued when the quest is complete.</param>
  public QuestLostOnes(Rectangle rescueRect) : base("The Draenei",
    "The native Draenei of Outland, led by Elder Sage Akama, aided Illidan in his assault on the Black Temple, but abandoned him when he let Magtheridon live. With invaders on Outland's doorstep, the Draenei must be forced back into the fold.",
    @"ReplaceableTextures\CommandButtons\BTNDranaiAkama.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01J_ZANGARMARSH));
    AddObjective(new ObjectiveControlPoint(UNIT_N02N_BLADE_S_EDGE_MOUNTAINS));
    AddObjective(new ObjectiveControlPoint(UNIT_N00B_NAGRAND));
    AddObjective(new ObjectiveControlPoint(UNIT_N0CW_FARAHLON));
    AddObjective(new ObjectiveExpire(1450, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R05H_QUEST_COMPLETED_THE_DRAENEI;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
  }

  public override string RewardFlavour =>
    "Elder Sage Akama and his Draenei tribesmen have been brought to heel, now forced to fight alongside Illidan - and the Pit Lord that once threatened their extinction.";

  protected override string RewardDescription =>
    $"Gain control of the Draenei camp in Outland, learn to build {GetObjectName(UNIT_N08W_ASHTONGUE_LAIR_ILLIDARI_SIEGE)}s, and learn to train Akama from the {GetObjectName(UNIT_NNAD_ALTAR_OF_THE_BETRAYER_ILLIDARI_ALTAR)}";

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player?.RescueGroup(_rescueUnits);
  }

  protected override void OnFail(Faction completingFaction)
  {
    Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
  }
}
