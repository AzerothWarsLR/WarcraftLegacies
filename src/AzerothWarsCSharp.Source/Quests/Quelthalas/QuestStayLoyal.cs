using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestStayLoyal : QuestData
  {
    private Global()
    {
      return true;
    }

    public QuestStayLoyal() : base("Refuse Kil'jaeden")

    protected override string CompletionPopup => "The Blood Elves stay loyal to Illidan";

    protected override string CompletionDescription => "Stay allied to Illidan";
    private s Offer",
    "Kil)jaeden has approached Kael with an offer of power && salvation. He should refuse it && resist the temptation of Fel power."
    ,
    "ReplaceableTextures\\CommandButtons\\BTNDemonHunter2blp")
    {
      AddQuestItem(new QuestItemCastSpell(FourCC("A0IK"), true));
      AddQuestItem(new QuestItemLegendLevel(LegendQuelthalas.LegendKael, 6));
      ;
      ;
    }


    private bool operator

    protected override void OnComplete()
    {
      GREAT_TREACHERY.Progress = QUEST_PROGRESS_FAILED;
      SUMMON_KIL.Progress = QUEST_PROGRESS_FAILED;
      UnitRemoveAbilityBJ(FourCC("A0IK"), LegendQuelthalas.LegendKael.Unit);
      UnitRemoveAbilityBJ(FourCC("A0IF"), LegendQuelthalas.LegendKael.Unit);
    }
  }
}