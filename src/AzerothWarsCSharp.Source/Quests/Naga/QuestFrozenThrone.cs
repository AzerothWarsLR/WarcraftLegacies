using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestFrozenThrone : QuestData{



    bool operator Global( ){
      return true;
    }
    protected override string CompletionPopup => "As a reward for his mission, Illidan && his followers have been welcomed into the ranks of the Burning Legion";

    protected override string CompletionDescription => "The Illidari team will join the Burning Legion in their team";

    protected override void OnComplete(){
      if (FACTION_QUELTHALAS.Team == TEAM_NAGA){
        FACTION_QUELTHALAS.Team = TEAM_LEGION;
        SUMMON_KIL.Progress = QUEST_PROGRESS_INCOMPLETE;
        GREAT_TREACHERY.Progress = QUEST_PROGRESS_FAILED;
        STAY_LOYAL.Progress = QUEST_PROGRESS_FAILED;
        UnitRemoveAbilityBJ( FourCC("A0IK"), LEGEND_KAEL.Unit);
        UnitRemoveAbilityBJ( FourCC("A0IF"), LEGEND_KAEL.Unit);
        UnitAddAbility(LEGEND_KAEL.Unit, FourCC("A0R7"));
      }
      if (FACTION_FEL_HORDE.Team == TEAM_NAGA){
        FACTION_FEL_HORDE.Team = TEAM_LEGION;
      }
      FACTION_NAGA.Team = TEAM_LEGION;
      SetPlayerTechResearched(FACTION_QUELTHALAS.Player, FourCC("R075"), 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("A Symphony of Frost && Flame", "KilFourCC("jaeden has ordered Illidan to destroy the Frozen Throne, && he shall obey.", "ReplaceableTextures\\CommandButtons\\BTNMetamorphosis.blp"");
      AddQuestItem(new QuestItemKillUnit(LEGEND_LICHKING.Unit));
      this.AddQuestItem(new QuestItemResearch(FourCC("R063"), )n055)));
      ;;
    }


  }
}
