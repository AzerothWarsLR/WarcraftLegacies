using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.Display;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestThunderEagle : QuestData
  {
    private static readonly int ResearchId = FourCC("R04L");
    private static readonly int ThunderEagleId = FourCC("nwe2");

    public QuestThunderEagle() : base("To the Skies!",
      "The Thunder Eagles of the Storm Peaks live in fear of the Legion. Wipe out the Legion Nexus to bring these great birds out into the open.",
      "ReplaceableTextures\\CommandButtons\\BTNWarEagle.blp")
    {
      AddQuestItem(new ObjectiveControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02S"))));
    }

    protected override string CompletionPopup => "The Thunder Eagles, now in safe hands " + Holder.Name + ".";

    protected override string RewardDescription => "Learn to train " + GetObjectName(ThunderEagleId) + "s";

    protected override void OnComplete()
    {
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayUnitTypeAcquired(Holder.Player, ThunderEagleId,
        "You can now train Thunder Eagles from upgraded Town Halls and from your capitals.");
    }
  }
}