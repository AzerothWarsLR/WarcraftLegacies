using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestRetakeSunwell : QuestData
  {
    public QuestRetakeSunwell(AllLegendSetup legendSetup) : base("Retaking the Sunwell",
      "Even in undeath, the Sunwell's energy call to the Forsaken banshees. Reclaim it to bolster their vitality",
      "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
    {
      AddObjective(new ObjectiveControlCapital(legendSetup.Quelthalas.Sunwell, false));
    }
    
    protected override string RewardFlavour => "Sylvanas and all the Banshee Hall units gain 500 bonus hit points";

    protected override string RewardDescription =>
      "Sylvanas and her Banshees will be empowered with 500 additional hitpoints each";

    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, FourCC("R07V"), 1);
    }
  }
}