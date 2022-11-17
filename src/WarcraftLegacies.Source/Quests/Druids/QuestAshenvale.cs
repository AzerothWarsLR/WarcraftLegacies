using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestAshenvale : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestAshenvale(Rectangle rescueRect) : base("The Spirits of Ashenvale",
      "The forest needs healing. Regain control of it to summon it's Guardian, the Demigod Cenarius",
      "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp")
    {
      AddObjective(
        new ObjectiveLegendReachRect(LegendDruids.LegendMalfurion, Regions.AshenvaleUnlock, "Ashenvale"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N07C_FELWOOD_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N01Q_NORTHERN_ASHENVALE_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N08U_SOUTHERN_ASHENVALE_10GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_ETOE_TREE_OF_ETERNITY_DRUIDS, Constants.UNIT_ETOL_TREE_OF_LIFE_DRUIDS));
      AddObjective(new ObjectiveExpire(1440));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R06R_QUEST_COMPLETED_THE_SPIRITS_OF_ASHENVALE;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      Required = true;
    }

    protected override string CompletionPopup => "Ashenvale is under control and Cenarius can now be awaken";

    protected override string RewardDescription =>
      "Control of all units in Ashenvale and make Cenarius trainable at the Altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      _rescueUnits.Clear();
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\DruidTheme.mp3");
      _rescueUnits.Clear();
    }
  }
}