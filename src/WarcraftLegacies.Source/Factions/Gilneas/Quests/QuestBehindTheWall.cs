using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.Gilneas.Quests;

/// <summary>Hold Gilneas City and Greymane's Gate for ten turns after Gilneas leaves the Alliance.</summary>
public sealed class QuestBehindTheWall : QuestData
{
  private const int TurnsToHold = 10;
  private const int FullGoldReward = 750;
  private const int HalfGoldReward = 375;

  private readonly bool _halfReward;

  /// <param name="gilneasCastle">The capital Gilneas must keep.</param>
  /// <param name="halfReward">Whether the gold and hero levels are halved, for Gilneas with allies at its side.</param>
  public QuestBehindTheWall(Capital gilneasCastle, bool halfReward) : base("Behind the Wall",
    "Gilneas has turned its back on the Alliance, and its old allies will soon come to test the wall. Hold Gilneas City and Greymane's Gate, and prove that Gilneas will not break.",
    @"ReplaceableTextures\CommandButtons\BTNGreymane.blp")
  {
    _halfReward = halfReward;
    AddObjective(new ObjectiveTurn(GameTimeManager.Turn + TurnsToHold));
    AddObjective(new ObjectiveControlCapital(gilneasCastle, true));
    AddObjective(new ObjectiveGateStands("Greymane's Gate", GreymaneFortification.GateTypes[0], GreymaneFortification.GateTypes[1]));
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The wall has held. Gilneas stands unbroken, and its heroes are stronger for every siege they turned away.";

  /// <inheritdoc />
  protected override string RewardDescription => _halfReward
    ? "You gain 375 gold and each of your heroes gains half a level"
    : "You gain 750 gold and each of your heroes gains a level";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    var gold = _halfReward ? HalfGoldReward : FullGoldReward;
    owner.Gold += gold;
    var levels = _halfReward ? 0.5f : 1f;
    foreach (var hero in GlobalGroup.EnumUnitsOfPlayer(owner))
    {
      if (hero.IsUnitType(unittype.Hero))
      {
        HeroLevelExperience.GrantLevels(hero, levels);
      }
    }
  }
}
