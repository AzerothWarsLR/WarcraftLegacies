using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestSpiderWar : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R03A");

    public QuestSpiderWar(unit spiderQueen) : base("War of the Spider",
      "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.",
      "ReplaceableTextures\\CommandButtons\\BTNNerubianQueen.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00I"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08D"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00G"))));
      AddQuestItem(new QuestItemKillUnit(spiderQueen));
      AddQuestItem(new QuestItemUpgrade(FourCC("unpl"), FourCC("unpl")));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());
    }
    
    protected override string CompletionPopup =>
      "Northrend && the Icecrown Citadel is now under full control of the Lich King and the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Access to the Plague Research at the Frozen Throne, KelFourCC(tuzad && Rivendare trainable && a base in Icecrown";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.Ice_Crown.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.Ice_Crown.Rect, Holder.Player);
      SetPlayerTechResearched(Holder.Player, FourCC("R03A"), 1);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\ScourgeTheme.mp3");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }
  }
}