using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using AzerothWarsCSharp.Source.Setup.QuestSetup;

using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestStayLoyal : QuestData
  {
    public QuestStayLoyal() : base("Refuse Kil'Jaeden's Offer", "Kil'jaeden has approached Kael with an offer of power and salvation. He should refuse it and resist the temptation of Fel power.", "ReplaceableTextures\\CommandButtons\\BTNDemonHunter2.blp")
    {
      AddObjective(new ObjectiveCastSpell(FourCC("A0IK"), true));
      AddObjective(new ObjectiveLegendLevel(LegendQuelthalas.LegendKael, 6));
      Global = true;
    }

    //Todo: boring flavour
    protected override string CompletionPopup => "The Blood Elves stay loyal to Illidan";

    protected override string RewardDescription => "Stay allied to Illidan";
    
    protected override void OnComplete(Faction completingFaction)
    {
      QuelthalasQuestSetup.GREAT_TREACHERY.Progress = QuestProgress.Failed;
      QuelthalasQuestSetup.SUMMON_KIL.Progress = QuestProgress.Failed;
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0IK"));
      UnitRemoveAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0IF"));
    }
  }
}