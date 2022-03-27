using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestFrozenThrone : QuestData
  {
    public QuestFrozenThrone() : base("A Symphony of Frost and Flame",
      "Kil'jaeden has ordered Illidan to destroy the Frozen Throne, and he shall obey.",
      "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp")
    {
      AddQuestItem(new QuestItemKillUnit(LegendScourge.LegendLichking.Unit));
      this.AddQuestItem(new QuestItemResearch(FourCC("R063"),)n055)));
      Global = true;
    }

    protected override string CompletionPopup =>
      "As a reward for his mission, Illidan && his followers have been welcomed into the ranks of the Burning Legion";

    protected override string CompletionDescription => "The Illidari team will join the Burning Legion in their team";
    

    protected override void OnComplete()
    {
      if (QuelthalasSetup.FactionQuelthalas.Team == TeamSetup.TeamNaga)
      {
        QuelthalasSetup.FactionQuelthalas.Team = TeamSetup.TeamLegion;
        SUMMON_KIL.Progress = QUEST_PROGRESS_INCOMPLETE;
        GREAT_TREACHERY.Progress = QUEST_PROGRESS_FAILED;
        STAY_LOYAL.Progress = QUEST_PROGRESS_FAILED;
        UnitRemoveAbilityBJ(FourCC("A0IK"), LegendQuelthalas.LegendKael.Unit);
        UnitRemoveAbilityBJ(FourCC("A0IF"), LegendQuelthalas.LegendKael.Unit);
        UnitAddAbility(LegendQuelthalas.LegendKael.Unit, FourCC("A0R7"));
      }

      if (FelHordeSetup.FactionFelHorde.Team == TeamSetup.TeamNaga) 
        FelHordeSetup.FactionFelHorde.Team = TeamSetup.TeamLegion;
      NagaSetup.FactionNaga.Team = TeamSetup.TeamLegion;
      SetPlayerTechResearched(QuelthalasSetup.FactionQuelthalas.Player, FourCC("R075"), 1);
    }
  }
}