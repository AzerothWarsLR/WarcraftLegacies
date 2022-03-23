using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestSummonKil : QuestData{

  
    private static readonly int RitualId = FourCC("A0R7");
  


    private bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "The greater demon KilFourCC(jaeden has been summoned to Azeroth";

    protected override string CompletionDescription => "The hero KilFourCC(jaeden";

    protected override void OnComplete(){
      UnitRemoveAbilityBJ( FourCC("A0R7"), LEGEND_KAEL.Unit);
      LEGEND_KILJAEDEN.Spawn(FACTION_QUELTHALAS.Player, GetRectCenterX(Regions.Sunwell), GetRectCenterY(gg_rct_Sunwell).Rect, 244);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Great Deceiver", "The greater demon KilFourCC("jaeden has been scheming for aeons. Will kael finally be the one to summon him && consume Azeroth?", "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp"");
      AddQuestItem(new QuestItemChannelRect(Regions.KaelSunwellChannel, "The Sunwell", LEGEND_KAEL, 180.Rect, 270));
      
    }


  }
}
