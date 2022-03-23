using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestBlueDragons : QuestData{

  
    private static readonly int RESEARCH_ID = FourCC("R00U");
    private static readonly int DRAGON_ID = FourCC("n0AC");
    private static readonly int MANADAM_ID = FourCC("R00N");
  


    protected override string CompletionPopup => "The Nexus has been captured. The Blue Dragonflight fights for " + Holder.Name + ".";

    protected override string CompletionDescription => "Learn to train Blue Dragons";

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, DRAGON_ID, "You can now train Blue Dragons from Military Quarters && the Nexus.");
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(DRAGON_ID, 6);
      Holder.ModObjectLimit(MANADAM_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Blue Dragonflight", "The Blue Dragons of Northrend are the wardens of magic on Azeroth. They might be convinced to willingly join the mages of Dalaran.", "ReplaceableTextures\\CommandButtons\\BTNAzureDragon.blp");
      AddQuestItem(new QuestItemControlLegend(LEGEND_NEXUS, false));
      
    }


  }
}
