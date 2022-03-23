using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestThunderEagle : QuestData{

  
    private static readonly int ResearchId = FourCC("R04L");
    private static readonly int ThunderEagleId = FourCC("nwe2");
  


    protected override string CompletionPopup => "The Thunder Eagles, now in safe hands " + Holder.Name + ".";

    protected override string CompletionDescription => "Learn to train " + GetObjectName(ThunderEagleId) + "s";

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, ThunderEagleId, "You can now train Thunder Eagles from upgraded Town Halls && from your capitals.");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("To the Skies!", "The Thunder Eagles of the Storm Peaks live in fear of the Legion. Wipe out the Legion Nexus to bring these great birds out into the open.", "ReplaceableTextures\\CommandButtons\\BTNWarEagle.blp");
      AddQuestItem(new QuestItemControlLegend(LEGEND_DRAKTHARONKEEP, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02S"))));
      ;;
    }


  }
}
