using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestShadowfang : QuestData
  {
    public QuestShadowfang(unit worgenToKill) : base("Shadows of Silverspine Forest",
      "The woods of Silverspine are unsafe for travellers, they need to be investigated",
      "ReplaceableTextures\\CommandButtons\\BTNworgen.blp")
    {
      AddQuestItem(new QuestItemKillUnit(worgenToKill)); //Worgen
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01D"))));
      AddQuestItem(new QuestItemExpire(1444));
      AddQuestItem(new QuestItemSelfExists());
    }
    
    protected override string CompletionPopup =>
      "Shadowfang has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Shadowfang";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.ShadowfangUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.ShadowfangUnlock.Rect, Holder.Player);
    }
  }
}