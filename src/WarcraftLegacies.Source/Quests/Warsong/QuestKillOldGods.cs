using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestKillOldGods : QuestData
  {
    public QuestKillOldGods(Legend cthun, Legend nzoth) : base("Echoes of War",
      "The Old Gods C'Thun and N'Zoth threaten to spread chaos across the land. By eliminating these ancient terrors, the Warsong may claim victory and infuse their warriors with newfound strength.",
      @"ReplaceableTextures\CommandButtons\BTNOrcGrunt.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ));
      AddObjective(new ObjectiveControlPoint(UNIT_NNYA_NY_ALOTHA_THE_WAKING_CITY));
      AddObjective(new ObjectiveKillUnit(cthun.Unit));
      AddObjective(new ObjectiveKillUnit(nzoth.Unit));
      ResearchId = Constants.UPGRADE_R021_QUEST_COMPLETED_ECHOES_OF_WAR;
    }
    
    /// <inheritdoc/>
    public override string RewardFlavour =>
      "With the defeat of C'Thun and N'Zoth, the Warsong champions channel the lingering echoes of the Old Gods' power. Both Kor'krons' and Blademasters' emerge reinvigorated to lead the Horde's conquests.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Permanently increases Kor'kron's and Blade master's attack damage by 25, hit points by 275, and total mana by 100.";

  
  }
}