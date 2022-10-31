using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common; 

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  public sealed class QuestJoinCrusade : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R06U"); //This research is given when the quest is completed

    public QuestJoinCrusade() : base("Join the Crusade",
      "Daelin Proudmoore sees the plight of the Scarlet Crusade. As fellow human survivors of horrible war, they should join forces with Kul'tiras",
      "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
    {
      AddObjective(new ObjectiveCastSpell(FourCC("A0JB"), true));
      ResearchId = QuestResearchId;
    }


    protected override string CompletionPopup => "Kul Tiras has joined the Scarlet Crusade";

    protected override string RewardDescription => "Unlock Order Inquisitor and join the Scarlet Crusade";

    protected override void OnComplete(Faction completingFaction)
    {
      UnitRemoveAbility(LegendKultiras.LegendAdmiral.Unit, FourCC("A0JB"));
      completingFaction.Player?.SetTeam(TeamSetup.ScarletCrusade);
    }
  }
}