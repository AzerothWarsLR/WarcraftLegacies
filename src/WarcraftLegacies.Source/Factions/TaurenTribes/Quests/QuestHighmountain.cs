using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestHighmountain : QuestData
{
  private const int CairneLevel = 8;
  private const int CairneXpReward = 1500;

  private readonly LegendaryHero _cairne;
  private readonly List<unit> _rescueUnits;

  public QuestHighmountain(LegendaryHero cairne, Rectangle rescueRect, QuestData longMarch, QuestData stonemaulDiplomacy) : base(
    "A Feast for Our Kin",
    "Scouts report sighting the Highmountain totem, thought lost when the Broken Isles were shattered long ago. If Cairne Bloodhoof travels there himself, the Highmountain tauren may yet answer the call of their kin.",
    @"ReplaceableTextures\CommandButtons\BTNPigHead.blp")
  {
    AddObjective(new ObjectiveLegendLevel(cairne, CairneLevel));
    AddObjective(new ObjectiveLegendInRect(cairne, rescueRect, "Highmountain"));
    AddObjective(new ObjectiveQuestResolved(longMarch)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddObjective(new ObjectiveQuestResolved(stonemaulDiplomacy)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_R0A9_QUEST_COMPLETED_A_FEAST_FOR_OUR_KIN;
    _cairne = cairne;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
  }

  public override string RewardFlavour =>
    "Cairne is welcomed in Highmountain like a long-lost friend. The Highmountain tauren open their home to the Tribes, and their finest warriors share the strength of the mountain with their kin.";

  protected override string RewardDescription =>
    "Control of Highmountain and its defenders, Cairne Bloodhoof gains 10 Strength, 5 Agility, 5 Intelligence and 1500 experience, and your Tauren, Sunwalker Champions, Tauren Chieftains, Spirit Walkers and Bluffwatchers gain 100 hit points and 2 armor";

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);

    var cairne = _cairne.Unit;
    if (cairne != null)
    {
      cairne.AddHeroAttributes(10, 5, 5);
      AddHeroXP(cairne, CairneXpReward, true);
    }
  }

  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
