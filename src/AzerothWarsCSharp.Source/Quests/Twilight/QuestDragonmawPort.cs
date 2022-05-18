using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestDragonmawPort : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestDragonmawPort(Rectangle rescueRect) : base("Dragonmaw Port",
      "The Dragonmaw Port will be the perfect staging ground of the invasion of Azeroth",
      "ReplaceableTextures\\CommandButtons\\BTNIronHordeSummoningCircle.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08T"))));
      AddQuestItem(new QuestItemExpire(1227));
      AddQuestItem(new QuestItemSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Dragonmaw Port has fallen under our control and its military is now free to assist the " + Holder.Team.Name +
      ".";

    protected override string RewardDescription => "Control of all buildings in Dragonmaw Port";

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