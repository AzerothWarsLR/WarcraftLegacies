using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestEmbassy : QuestData{

  
    private static readonly int HeroId = FourCC("U00L");
    private static readonly int AltarId = FourCC("u01N");
  


    protected override string CompletionPopup => "The Legion has secured a foothold on Azeroth.";

    protected override string CompletionDescription => 
      return "You can build the Infernal Machine Factory && summon Anetheron from the " + GetObjectName(ALTAR_ID);
    }

    protected override void OnAdd( ){
    }

    public  QuestEmbassy ( ){
      thistype this = thistype.allocate("Infernal Foothold", "A stronger foothold in this world will be required to field the Burning LegionFourCC("s war machines && to in more of its lieutenants.", "ReplaceableTextures\\CommandButtons\\BTNDemonBlackCitadel.blp"");
      this.AddQuestItem(new QuestItemUpgrade(FourCC("e01H"), )e01F)));
      this.ResearchId = FourCC("R042");
      
    }


  }
}
