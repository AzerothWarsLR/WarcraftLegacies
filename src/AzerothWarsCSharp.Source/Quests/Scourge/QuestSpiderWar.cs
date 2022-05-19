using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestSpiderWar : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R03A");
    private readonly List<unit> _rescueUnits = new();

    public QuestSpiderWar(Rectangle rescueRect, unit spiderQueen) : base("War of the Spider",
      "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.",
      "ReplaceableTextures\\CommandButtons\\BTNNerubianQueen.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00I"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08D"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00G"))));
      AddQuestItem(new QuestItemKillUnit(spiderQueen));
      AddQuestItem(new QuestItemUpgrade(FourCC("unp2"), FourCC("unp1")));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Northrend and the Icecrown Citadel is now under full control of the Lich King and the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Access to the Plague Research at the Frozen Throne, Kel'thuzad and Rivendare trainable and a base in Icecrown";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      SetPlayerTechResearched(Holder.Player, FourCC("R03A"), 1);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusic("war3mapImported\\ScourgeTheme.mp3");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }
  }
}