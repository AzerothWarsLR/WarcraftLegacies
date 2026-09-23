using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestTheWorldTree : QuestData
{
  private const int CairneXpReward = 2000;
  private const int GoldReward = 500;

  private readonly LegendaryHero _cairne;

  public QuestTheWorldTree(LegendaryHero cairne, QuestData previousQuest) : base(
    "The World Tree",
    "Nordrassil, the World Tree, towers over the slopes of Mount Hyjal. If the Tauren claim it, the Earth Mother's blessing will flow through Cairne Bloodhoof.",
    @"ReplaceableTextures\CommandButtons\BTNTreeOfEternity.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01P_NORDRASSIL));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    _cairne = cairne;
  }

  public override string RewardFlavour =>
    "The Tauren stand beneath the boughs of Nordrassil. Cairne Bloodhoof feels the Earth Mother's strength surge through him.";

  protected override string RewardDescription =>
    "Cairne Bloodhoof gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, and you gain 500 gold";

  protected override void OnComplete(Faction completingFaction)
  {
    var cairne = _cairne.Unit;
    if (cairne != null)
    {
      cairne.AddHeroAttributes(5, 5, 5);
      AddHeroXP(cairne, CairneXpReward, true);
    }

    if (completingFaction.Player != null)
    {
      completingFaction.Player.Gold += GoldReward;
    }
  }
}
