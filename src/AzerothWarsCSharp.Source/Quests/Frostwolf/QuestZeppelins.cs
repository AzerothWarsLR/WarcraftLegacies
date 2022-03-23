using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestZeppelins : QuestData{

  
    private const int RESEARCH_ID = FourCC("R058");
    private const int UNITTYPE_ID = FourCC("nzep");
    private const int LIMIT_CHANGE = 2;
  


    protected override string CompletionPopup => "The Sentinels have been slain. With their Hippogryphs no longer terrorizing the skies, the Horde can field its refurbished Zeppelins.";

    protected override string CompletionDescription => "Learn to train " + GetObjectName(UNITTYPE_ID) + "s";

    private void OnAdd( ){
      Holder.ModObjectLimit(UNITTYPE_ID, LIMIT_CHANGE);
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, UNITTYPE_ID, "You can now train Zeppelins from the Goblin Laboratory.");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Spirits of Ashenvale", "The Sentinels have laid claim over Kalimdor. As long as they survive, the Orcs will never be safe.", "ReplaceableTextures\\CommandButtons\\BTNGoblinZeppelin.blp");
      AddQuestItem(new QuestItemLegendDead(LEGEND_AUBERDINE));
      AddQuestItem(new QuestItemLegendDead(LEGEND_FEATHERMOON));
      ;;
    }


  }
}
