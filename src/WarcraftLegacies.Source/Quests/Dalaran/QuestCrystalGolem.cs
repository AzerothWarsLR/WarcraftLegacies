using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  public sealed class QuestCrystalGolem : QuestData
  {
    public QuestCrystalGolem(Capital draktharonKeep) : base("Crystalsong Forest",
      "The living crystal of the Crystalsong Forest suffers from its proximity to the Legion. Freed from that corruption, it could be used to empower Dalaran's constructs."
      , "ReplaceableTextures\\CommandButtons\\BTNRockGolem.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n02R"))));
      AddObjective(new ObjectiveControlCapital(draktharonKeep, false));
      ResearchId = FourCC("R045");
    }

    protected override string RewardFlavour => "Dalaran's Earth Golems have been infused with living crystal.";

    protected override string RewardDescription => "Transform your Earth Golems into Crystal Golems";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.DisplayResearchAcquired(ResearchId, 1);
      completingFaction.ModObjectLimit(FourCC("n096"), -6);
      completingFaction.ModObjectLimit(FourCC("n0AD"), 6);
    }
  }
}