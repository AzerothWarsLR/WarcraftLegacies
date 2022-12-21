using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  public sealed class QuestTownWatch : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R077"); //This research is given when the quest is completed

    public QuestTownWatch() : base("The Cult of the Damned",
      "Unholy Cultists are spreading a deadly plague among the villages of Lordaeron. We must stop them, prevent the corruption, and kill all the Cultists.",
      "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
    {
      AddObjective(new ObjectiveResearch(FourCC("Rhse"), FourCC("h083")));
      AddObjective(new ObjectiveBuild(FourCC("h084"), 8));
      AddObjective(new ObjectiveKillXUnit(FourCC("u01U"), 3));
      ResearchId = QuestResearchId;
      Required = true;
    }

    protected override string CompletionPopup => "The Cultists have been eliminated. Our towns are now safe.";

    protected override string RewardDescription => "Gain 4000 lumber and 500 gold";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 500);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 4000);
    }
  }
}