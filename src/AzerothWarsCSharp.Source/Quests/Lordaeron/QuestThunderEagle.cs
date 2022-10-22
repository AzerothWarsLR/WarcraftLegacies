using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.Display;

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
      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendDraktharonkeep, false));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02S"))));
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "The Thunder Eagles are now in the safe hands of Lordaeron.";

    protected override string RewardDescription => "Learn to train " + GetObjectName(ThunderEagleId) + "s";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
      DisplayUnitTypeAcquired(completingFaction.Player, ThunderEagleId,
        "You can now train Thunder Eagles from upgraded Town Halls and from your capitals.");
    }
  }
}