using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
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
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N07C_FELWOOD_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01Q_NORTHERN_ASHENVALE_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N08U_SOUTHERN_ASHENVALE_10GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_ETOE_TREE_OF_ETERNITY_DRUIDS, Constants.UNIT_ETOL_TREE_OF_LIFE_DRUIDS));
      AddObjective(new ObjectiveExpire(1440));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R06R_QUEST_COMPLETED_THE_SPIRITS_OF_ASHENVALE;
      _rescueUnits = ashenvaleRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Ashenvale is under control, and the forest has been awakened.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Ashenvale and summon Saplings all around the Warsong Lumber Camp";

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
      
      EnumDestructablesInRect(_ashenvaleRect.Rect, null, () =>
      {
        var enumDestructable = GetEnumDestructable();
        DestructableRestoreLife(enumDestructable, GetDestructableMaxLife(enumDestructable), true);
      });
      foreach (var rectAncient in new[]
               {
                 (Regions.ForestSpirits1, Constants.UNIT_N0CY_ENRAGED_ANCIENT_OF_LORE_EVENT),
                 (Regions.ForestSpirits2, Constants.UNIT_N0CX_ENRAGED_ANCIENT_OF_WAR_EVENT),
                 (Regions.ForestSpirits3, Constants.UNIT_N0CZ_ENRAGED_ANCIENT_OF_WIND_EVENT),
                 (Regions.ForestSpirits4, Constants.UNIT_N0D0_ENRAGED_ANCIENT_OF_WONDER_EVENT),
                 (Regions.ForestSpirits5, Constants.UNIT_N0D1_ENRAGED_TREE_OF_LIFE_EVENT),
                 (Regions.ForestSpirits6, 0)
               })
      {
        CreateUnit(completingFaction.Player, Constants.UNIT_H05B_FORESTSPIRIT_DUMMY, rectAncient.Item1.Center.X, rectAncient.Item1.Center.Y, 270)
          .SetTimedLife(4)
          .IssueOrder("forceofnature", rectAncient.Item1.Center);
        if (rectAncient.Item2 != 0)
        {
          CreateTimer()
            .Start(3, false, () =>
            {
              CreateUnit(completingFaction.Player, rectAncient.Item2, rectAncient.Item1.Center.X, rectAncient.Item1.Center.Y, 270)
                .SetTimedLife(90);
            });
        }
      }
    }
  }
}