using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sunfury;

/// <summary>
/// Build various structures inside <see cref="Regions.UpperNetherstorm"/>
/// </summary>
public sealed class QuestUpperNetherstorm : QuestData
{
  private readonly List<unit> _rescueUnits;
  private const int GoldReward = 200;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestUpperNetherstorm"/> class.
  /// </summary>
  public QuestUpperNetherstorm(Rectangle rescueRect) : base("Upper Netherstorm",
    "Upper Netherstorm is continously wracked by devastating magical storms. Lands such as these represent opportunity for our people, as starved for mana as they are.",
    @"ReplaceableTextures\CommandButtons\BTNArcaneCastle.blp")
  {
    AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.UpperNetherstorm },
      "in upper Netherstorm"));
    AddObjective(new ObjectiveControlPoint(UNIT_N0CW_FARAHLON, 0));
    AddObjective(new ObjectiveExpire(600, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction whichFaction)
  {
    var player = whichFaction.Player;
    if (player != null)
    {
      player.Gold += GoldReward;
      player.RescueGroup(_rescueUnits);
    }
    else
    {
      player.NeutralAggressive.RescueGroup(_rescueUnits);
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Our people spread throughout the lands of Upper Netherstorm, erecting their homes amidst its arcane crystals and basking in its magical storms.";

  /// <inheritdoc/>
  protected override string RewardDescription => $"Gain {GoldReward} gold and a base in Upper Netherstorm";
}
