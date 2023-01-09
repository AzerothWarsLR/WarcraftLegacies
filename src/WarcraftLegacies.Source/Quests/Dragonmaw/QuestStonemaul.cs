using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  public sealed class QuestStonemaul : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestStonemaul(PreplacedUnitSystem preplacedUnitSystem, Rectangle rescueRect) : base("Ruins of Stonemaul",
      "The deserted base of Stonemaul is right next to a lair of Black Drakes. A perfect emplacement to lay the new foundations of the Dragonmaw Clan",
      "ReplaceableTextures\\CommandButtons\\BTNMercenaryCamp.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N022_STONEMAUL_20GOLD_MIN)));
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(Constants.UNIT_NOGA_STONEMAUL_WARCHIEF_KOR_GALL)));
      AddObjective(new ObjectiveLegendInRect(LegendDragonmaw.Zaela, Regions.StonemaulKeep, "Stonemaul"));
      AddObjective(new ObjectiveExpire(1327));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R08U_QUEST_COMPLETED_RUINS_OF_STONEMAUL;
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Stonemaul now belongs to the Dragonmaw Clan. Gorfax Angerfang has joined the Dragonmaw";

    protected override string RewardDescription => "Control of all buildings in Stonemaul and Gorfax is now trainable at the Altar";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}