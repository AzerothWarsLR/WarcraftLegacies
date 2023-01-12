using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  /// <summary>
  /// Get Cenarius and some treants.
  /// </summary>
  public sealed class QuestAshenvale : QuestData
  {
    private readonly Rectangle _ashenvaleRect;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestAshenvale"/> class.
    /// </summary>
    /// <param name="ashenvaleRect">Units in this rectangle start invulnerable and are rescued when the quest is completed.</param>
    public QuestAshenvale(Rectangle ashenvaleRect) : base("The Spirits of Ashenvale",
      "The forest needs healing. Regain control of it to unleash its wrath on the Horde.",
      "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp")
    {
      _ashenvaleRect = ashenvaleRect;
      AddObjective(
        new ObjectiveLegendReachRect(LegendDruids.LegendMalfurion, Regions.AshenvaleUnlock, "Ashenvale"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N07C_FELWOOD_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01Q_NORTHERN_ASHENVALE_10GOLD_MIN)));
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R091_UNLEASH_THE_SPIRITS_OF_ASHENVALE_DRUID, Constants.UNIT_N002_NORDRASSIL_DRUID_OTHER));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_ETOE_TREE_OF_ETERNITY_DRUIDS, Constants.UNIT_ETOL_TREE_OF_LIFE_DRUIDS));
      AddObjective(new ObjectiveExpire(1440));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R06R_QUEST_COMPLETED_THE_SPIRITS_OF_ASHENVALE;
      _rescueUnits = ashenvaleRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour => "Ashenvale has awakened!";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Ashenvale";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
      if (GetLocalPlayer() == completingFaction.Player) 
        PlayThematicMusic("war3mapImported\\DruidTheme.mp3");
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(Constants.UPGRADE_R091_UNLEASH_THE_SPIRITS_OF_ASHENVALE_DRUID, 1);
    }
  }
}