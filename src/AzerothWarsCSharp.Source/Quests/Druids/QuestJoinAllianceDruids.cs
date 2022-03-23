using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestJoinAllianceDruid : QuestData{



    protected override string CompletionPopup => "The Druids have joined the Alliance";

    protected override string CompletionDescription => "Join the Alliance team";


    protected override void OnComplete(){
      UnitRemoveAbilityBJ( FourCC("A0IG"), LEGEND_MALFURION.Unit);
      this.Holder.Team = TEAM_ALLIANCE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Join the Alliance", "With a world ending threat happening, the Alliance has reached to the Night Elves to join them", "ReplaceableTextures\\CommandButtons\\BTNalliance.blp");
      this.AddQuestItem(new QuestItemCastSpell(FourCC("A0IG"), true));
      ;;
    }


  }
}
