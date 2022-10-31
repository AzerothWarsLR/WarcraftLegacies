using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Goblin
{
  public sealed class QuestGadgetzan : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestGadgetzan(Rectangle rescueRect) : base("Gadgetzan",
      "The city of Gadgetzan is a perfect foothold into Kalimdor.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroAlchemist.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n05C"))));
      AddObjective(new ObjectiveExpire(1522));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R07E");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Control of all buildings in Gadgetzan and enables Noggenfogger to be built at the altar";

    //Todo: terrible flavour
    protected override string RewardDescription =>
      "We can train Noggenfogger and Gadgetzan is now under our influence and its military is now free to assist the Horde.";

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