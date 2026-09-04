using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Warsong.Quests;

public sealed class QuestCaptureNordrassil : QuestData
{
  private int ExperienceReward { get; set; }
  private readonly LegendaryHero _grom;

  public QuestCaptureNordrassil(Capital MountHyjal, LegendaryHero grom) : base("Echoes of War",
    "The Old Gods C'Thun and N'Zoth threaten to spread chaos across the land. By eliminating these ancient terrors, the Warsong may claim victory and infuse their warriors with newfound strength.",
    @"ReplaceableTextures\CommandButtons\BTNOrcGrunt.blp")
  {
    _grom = grom;
    AddObjective(new ObjectiveControlCapital(MountHyjal, false));
    ResearchId = UPGRADE_R021_QUEST_COMPLETED_ECHOES_OF_WAR;
    ExperienceReward = 7000;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Both Kor'krons' and Blademasters' emerge reinvigorated to lead the Horde's conquests.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Permanently increases Kor'kron's and Blade master's attack damage by 25, hit points by 275, and total mana by 100.";
  protected override void OnComplete(Faction completingFaction)
  {
    AddHeroXP(_grom.Unit, ExperienceReward,true);
  }

}
