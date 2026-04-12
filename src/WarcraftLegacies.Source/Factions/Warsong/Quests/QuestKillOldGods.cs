using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Warsong.Quests;

public sealed class QuestKillOldGods : QuestData
{
  public QuestKillOldGods() : base("Echoes of War",
    "The Old Gods C'Thun and N'Zoth threaten to spread chaos across the land. By eliminating these ancient terrors, the Warsong may claim victory and infuse their warriors with newfound strength.",
    @"ReplaceableTextures\CommandButtons\BTNOrcGrunt.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ));
    AddObjective(new ObjectiveControlPoint(UNIT_NNYA_NY_ALOTHA_THE_WAKING_CITY));
    AddObjective(new ObjectiveLegendDead(AllLegends.Ahnqiraj.Cthun));
    AddObjective(new ObjectiveLegendDead(AllLegends.BlackE.Nzoth));
    ResearchId = UPGRADE_R021_QUEST_COMPLETED_ECHOES_OF_WAR;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "With the defeat of C'Thun and N'Zoth, the Warsong champions channel the lingering echoes of the Old Gods' power. Both Kor'krons' and Blademasters' emerge reinvigorated to lead the Horde's conquests.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Permanently increases Kor'kron's and Blade master's attack damage by 25, hit points by 275, and total mana by 100.";


}
