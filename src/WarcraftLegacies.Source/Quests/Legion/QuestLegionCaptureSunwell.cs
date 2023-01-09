using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestLegionCaptureSunwell : QuestData
  {
    public QuestLegionCaptureSunwell() : base("Fall of Silvermoon",
      "The Sunwell is the source of the High Elves' immortality and magical prowess. Under control of the Scourge, it would be the source of immense necromantic power.",
      "ReplaceableTextures\\CommandButtons\\BTNOrbOfCorruption.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendQuelthalas.LegendSunwell, false));
      ResearchId = FourCC("R054");
    }

    protected override string CompletionPopup =>
      "The Sunwell has been captured by the Scourge. It now writhes with necromantic energy.";

    protected override string RewardDescription => "A research improving your Dreadlords";


    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}