using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestJoinCrusade : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R06U"); //This research is given when the quest is completed

    public QuestJoinCrusade() : base("Join the Crusade",
      "Daelin Proudmoore sees the plight of the Scarlet Crusade. As fellow human survivors of horrible war, they should join forces with Kul'tiras",
      "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
    {
      AddQuestItem(new QuestItemCastSpell(FourCC("A0JB"), true));
      ResearchId = QuestResearchId;
    }


    protected override string CompletionPopup => "Kul Tiras has joined the Scarlet Crusade";

    protected override string RewardDescription => "Unlock Order Inquisitor and join the Scarlet Crusade";

    protected override void OnComplete()
    {
      UnitRemoveAbilityBJ(FourCC("A0JB"), LegendKultiras.LegendAdmiral.Unit);
      Holder.Team = TeamSetup.ScarletCrusade;
    }
  }
}