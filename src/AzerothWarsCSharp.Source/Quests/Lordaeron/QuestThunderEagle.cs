using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestThunderEagle : QuestData{

  
    private const int RESEARCH_ID = FourCC("R04L");
    private const int THUNDER_EAGLE_ID = FourCC("nwe2");
  


    protected override string CompletionPopup => "The Thunder Eagles, now in safe hands " + Holder.Name + ".";

    protected override string CompletionDescription => "Learn to train " + GetObjectName(THUNDER_EAGLE_ID) + "s";

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(Holder.Player, THUNDER_EAGLE_ID, "You can now train Thunder Eagles from upgraded Town Halls && from your capitals.");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("To the Skies!", "The Thunder Eagles of the Storm Peaks live in fear of the Legion. Wipe out the Legion Nexus to bring these great birds out into the open.", "ReplaceableTextures\\CommandButtons\\BTNWarEagle.blp");
      AddQuestItem(new QuestItemControlLegend(LEGEND_DRAKTHARONKEEP, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02S"))));
      ;;
    }


  }
}
