using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using static War3Api.Common;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;

namespace WarcraftLegacies.Source.Quests.Sunfury
{
  /// <summary>
  /// Build various structures inside <see cref="Regions.TempestKeep"/>
  /// </summary>
  public sealed class QuestTempestKeep : QuestData
  {
    private readonly List<unit> _rescueUnits;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTempestKeep"/> class.
    /// </summary>
    public QuestTempestKeep(Rectangle rescueRect, Rectangle questRect1, Rectangle questRect2, Rectangle questRect3) : base("Eco-domes", "The Sunfury will need to adapt to the hostile environement of Netherstorm. The existing eco-domes are perfect for food production.", "ReplaceableTextures\\CommandButtons\\BTNFeatherMoonAura.blp")
    {
      Required = true;
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.DraeneiQuestKill }, "in Desolace"));
      AddObjective(new ObjectiveBuildInRect(questRect1, "in one of the 3 Eco-dome in Netherstorm", Constants.UNIT_H0C7_BIODOME_SUNFURY_FARM, 1));
      AddObjective(new ObjectiveBuildInRect(questRect2, "in one of the 3 Eco-dome in Netherstorm", Constants.UNIT_H0C7_BIODOME_SUNFURY_FARM, 1));
      AddObjective(new ObjectiveBuildInRect(questRect3, "in one of the 3 Eco-dome in Netherstorm", Constants.UNIT_H0C7_BIODOME_SUNFURY_FARM, 1));
      AddObjective(new ObjectiveExpire(1430, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      ResearchId = Constants.UPGRADE_R09I;
    }

    protected override void OnFail(Faction completingFaction) =>
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "With enough food, we can settle Tempest Keep and start growing Ancients of the Arcane";

    /// <inheritdoc/>
    protected override string RewardDescription => "Unlock Tempest Keep and the ability to train Ancients of the Arcane";

   }
 }