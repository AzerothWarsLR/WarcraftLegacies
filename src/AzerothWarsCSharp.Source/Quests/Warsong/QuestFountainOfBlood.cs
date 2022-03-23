using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestFountainOfBlood : QuestData{

  
    private static readonly int ResearchId = FourCC("R00X");
  


    protected override string CompletionPopup => "The Fountain of Blood is under Warsong control. As the orcs drink from it, they feel a a familiar fury awake within them.";

    protected override string CompletionDescription => "Allows Orcish units to increase their attack rate && movement speed temporarily";

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Blood of Mannoroth", "Long ago, the orcs drank the blood of Mannoroth && were infused with demonic fury. A mere taste of his blood would reignite those powers.", "ReplaceableTextures\\CommandButtons\\BTNFountainOfLifeBlood.blp");
      AddQuestItem(new QuestItemControlLegend(LEGEND_FOUNTAINOFBLOOD, false));
      
    }


  }
}
