//When Hellfire Citadel is destroyed, give Honor Hold to Stormwind if they are in the game, and modify doodads for visuals.
//If Stormwind is not in the game, do nothing.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestHonorHold : QuestData{


    protected override string CompletionPopup => "Honor Hold is now free from the const looming threat of Hellfire Citadel. Danath Trollbane && his people elect to rejoin the Alliance.";

    protected override string CompletionDescription => "The demihero Danath Trollbane, && control of all units at Honor Hold";

    protected override void OnComplete(){
      group tempGroup = CreateGroup();
      //Transfer all Neutral Passive units in HonorHold to one of the above factions
      UnitRescue(gg_unit_h05Z_3325, Holder.Player)  ;//Honor Hold
      UnitRescue(gg_unit_hbla_3319, Holder.Player)  ;//Blacksmith
      UnitRescue(gg_unit_h03W_1656, Holder.Player)  ;//Danath Trollbane
      UnitRescue(gg_unit_hgtw_3320, Holder.Player)  ;//Guard Tower
      UnitRescue(gg_unit_hars_3321, Holder.Player)  ;//Arcane Sanctum
      FACTION_STORMWIND.ModObjectLimit(FourCC("h03W"),1)               ;//Danath Trollbane
      //Set animations of doodads within Honor Hold
      SetDoodadAnimationRectBJ( "hide", FourCC("ISrb"), gg_rct_HonorHold );
      SetDoodadAnimationRectBJ( "hide", FourCC("LSst"), gg_rct_HonorHold );
      SetDoodadAnimationRectBJ( "unhide", FourCC("CSra"), gg_rct_HonorHold );
      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    public  QuestHonorHold ( ){
      thistype this = thistype.allocate("Honor Hold", "Despite OutlandFourCC("s incredibly harsh climate, some Alliance forces have managed to make a home there - a town called Honor Hold", "ReplaceableTextures\\CommandButtons\\BTNHumanBarracks.blp"");
      AddQuestItem(new QuestItemLegendDead(LEGEND_HELLFIRECITADEL));
      ;;
    }


  }
}
