using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;

namespace WarcraftLegacies.Source.Quests.Sunfury
{
  /// <summary>
  /// Build various structures inside <see cref="Regions.UpperNetherstorm"/>
  /// </summary>
  public sealed class QuestUpperNetherstorm : QuestData
  {
    private readonly List<unit> _rescueUnits;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestUpperNetherstorm"/> class.
    /// </summary>
    public QuestUpperNetherstorm(Rectangle rescueRect) : base("Upper Netherstorm", "The Sunfury will need to settle the surrounding lands, Upper Netherstorm is ripe for the taking", "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp")
    {
      Required = true;
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.UpperNetherstorm }, "in upper Netherstorm"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0CW_FARAHLON_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1430, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.AddGold(400);
        whichFaction.Player.AddLumber(200);
      if (whichFaction.Player != null)
        whichFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Upper Netherstorm area is now settled by the Sunfury";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain 400 Gold, 200 Lumber and a base in Upper Netherstorm.";

   }
 }