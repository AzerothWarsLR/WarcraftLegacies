using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Quelthalas
{
  public class QuestSummonKil{

  
    private const int RITUAL_ID = FourCC(A0R7);
  


    private boolean operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The greater demon KilFourCC(jaeden has been summoned to Azeroth";
    }

    protected override string CompletionDescription => 
      return "The hero KilFourCC(jaeden";
    }

    protected override void OnComplete(){
      UnitRemoveAbilityBJ( FourCC(A0R7), LEGEND_KAEL.Unit);
      LEGEND_KILJAEDEN.Spawn(FACTION_QUELTHALAS.Player, GetRectCenterX(gg_rct_Sunwell), GetRectCenterY(gg_rct_Sunwell), 244);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Great Deceiver", "The greater demon KilFourCC(jaeden has been scheming for aeons. Will Kael finally be the one to summon him && consume Azeroth?", "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp");
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_KaelSunwellChannel, "The Sunwell", LEGEND_KAEL, 180, 270));
      ;;
    }


  }
}
