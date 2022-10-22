using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestBlackrock : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestBlackrock(Rectangle rescueRect) : base("Blackrock Unification",
      "Make contact with the Blackrock clan and convince them to join Magtheridon",
      "ReplaceableTextures\\CommandButtons\\BTNBlackhand.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00S"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09Y"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0A9"))));
      AddObjective(new ObjectiveExpire(1451));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03C_QUEST_COMPLETED_BLACKROCK_UNIFICATION;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Blackrock Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

    protected override string RewardDescription =>
      "Control of all units in Blackrock Citadel and enable DalFourCC(rend Blackhand to be trained at the altar";

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