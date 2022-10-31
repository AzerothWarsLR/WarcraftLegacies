using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestRetakeSunwell : QuestData
  {
    public QuestRetakeSunwell() : base("Retaking the Sunwell",
      "Even in undeath, the Sunwell's energy call to the Forsaken banshees. Reclaim it to bolster their vitality",
      "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendQuelthalas.LegendSunwell, false));
    }
    
    protected override string CompletionPopup => "Sylvanas and all the Banshee Hall units gain 500 bonus hit points";

    protected override string RewardDescription =>
      "Sylvanas and her Banshees will be empowered with 500 additional hitpoints each";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, FourCC("R07V"), 1);
    }
  }
}