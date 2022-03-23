using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestShadowfang : QuestData
  {
    public QuestShadowfang() : base("Shadows of Silverspine Forest",
      "The woods of Silverspine are unsafe for travellers, they need to be investigated",
      "ReplaceableTextures\\CommandButtons\\BTNworgen.blp")
    {
      AddQuestItem(QuestItemKillUnit.create(gg_unit_o02J_0984)); //Worgen
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01D"))));
      AddQuestItem(new QuestItemExpire(1444));
      AddQuestItem(new QuestItemSelfExists());
      ;
      ;
    }


    protected override string CompletionPopup =>
      "Shadowfang has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Shadowfang";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.ShadowfangUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.ShadowfangUnlock.Rect, Holder.Player);
    }

    protected override void OnAdd()
    {
    }
  }
}