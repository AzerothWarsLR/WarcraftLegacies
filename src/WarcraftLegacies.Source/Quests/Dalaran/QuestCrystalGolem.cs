using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  public sealed class QuestCrystalGolem : QuestData
  {
    public QuestCrystalGolem() : base("Crystalsong Forest",
      "The living crystal of the Crystalsong Forest suffers from its proximity to the Legion. Freed from that corruption, it could be used to empower Dalaran's constructs."
      , "ReplaceableTextures\\CommandButtons\\BTNRockGolem.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02R"))));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.DraktharonKeep, false));
      ResearchId = FourCC("R045");
    }

    protected override string CompletionPopup => "Dalaran's Earth Golems have been infused with living crystal.";

    protected override string RewardDescription => "Transform your Earth Golems into Crystal Golems";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.DisplayResearchAcquired(ResearchId, 1);
      completingFaction.ModObjectLimit(FourCC("n096"), -6);
      completingFaction.ModObjectLimit(FourCC("n0AD"), 6);
    }
  }
}