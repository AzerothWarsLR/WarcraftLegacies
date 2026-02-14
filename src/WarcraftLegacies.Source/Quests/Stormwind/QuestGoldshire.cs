using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Stormwind;

public sealed class QuestGoldshire : QuestData
{
  private readonly List<unit> _rescueUnits = new();

  public QuestGoldshire(Rectangle rescueRect) : base("The Scourge of Elwynn",
    "Hogger and his pack have taken over Goldshire, clear them out!",
    @"ReplaceableTextures\CommandButtons\BTNGnoll.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N00Z_ELWYNN_FOREST));
    AddObjective(new ObjectiveExpire(GameTimeManager.ConvertGameTimeToTurn(600), Title));
    AddObjective(new ObjectiveSelfExists());
    foreach (var unit in GlobalGroup.EnumUnitsInRect(rescueRect))
    {
      if (unit.Owner == player.NeutralPassive)
      {
        unit.IsInvulnerable = true;
        _rescueUnits.Add(unit);
      }
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "The Gnolls have been defeated, Goldshire is safe.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Goldshire";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }
}
