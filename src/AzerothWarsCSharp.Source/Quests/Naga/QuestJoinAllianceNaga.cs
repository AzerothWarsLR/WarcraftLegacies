using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestJoinAllianceNaga : QuestData
  {
    public QuestJoinAllianceNaga() : base("Join the Alliance",
      "The Alliance has invited the Night Elves to join them in the face of a looming world threat.",
      "ReplaceableTextures\\CommandButtons\\BTNalliance.blp")
    {
      AddQuestItem(new QuestItemCastSpell(FourCC("A0IG"), true));
      AddQuestItem(new QuestItemControlLegend(LEGEND_ALTRUIS, true));
      this.AddQuestItem(new QuestItemResearch(FourCC("R062"),)n055)));
      ;
      ;
    }


    protected override string CompletionPopup => "The Illidari have joined the Alliance";

    protected override string CompletionDescription => "Join the Alliance team";

    protected override void OnComplete()
    {
      UnitRemoveAbilityBJ(FourCC("A0IG"), LEGEND_ALTRUIS.Unit);
      Holder.Team = TEAM_ALLIANCE;
    }
  }
}