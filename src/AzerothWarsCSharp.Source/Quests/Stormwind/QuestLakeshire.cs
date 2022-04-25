using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestLakeshire : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestLakeshire(Rectangle rescueRect, unit ogreLordToKill) : base("Marauding Ogres",
      "The town of Lakeshire is invaded by Ogres, wipe them out!",
      "ReplaceableTextures\\CommandButtons\\BTNOgreLord.blp")
    {
      AddQuestItem(new QuestItemKillUnit(ogreLordToKill));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n011"))));
      AddQuestItem(new QuestItemExpire(1427));
      AddQuestItem(new QuestItemSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Lakeshire has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Lakeshire";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
    }
  }
}