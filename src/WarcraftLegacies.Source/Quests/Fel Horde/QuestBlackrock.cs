using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestBlackrock : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestBlackrock(Rectangle rescueRect, IEnumerable<QuestData> prequisites) : base("Blackrock Unification",
      "Make contact with the Blackrock clan and convince them to join Magtheridon",
      "ReplaceableTextures\\CommandButtons\\BTNBlackhand.blp")
    {
      foreach (var prequisite in prequisites) 
        AddObjective(new ObjectiveCompleteQuest(prequisite));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N0A9_BLASTED_LANDS_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1451));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03C_QUEST_COMPLETED_BLACKROCK_UNIFICATION;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup =>
      "Blackrock Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

    protected override string RewardDescription =>
      "Control of all units in Blackrock Citadel and enable Dal'rend Blackhand to be trained at the altar";

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