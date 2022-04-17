using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
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
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n05C"))));
      AddQuestItem(new QuestItemExpire(1522));
      AddQuestItem(new QuestItemSelfExists());
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

    protected override string RewardDescription =>
      "We can train Noggenfogger and Gadgetzan is now under our influence and its military is now free to assist the " +
      Holder.Team.Name + ".";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
    }
  }
}