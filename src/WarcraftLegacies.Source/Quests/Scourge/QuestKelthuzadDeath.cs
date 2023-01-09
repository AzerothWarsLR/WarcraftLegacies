using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// When Kel'thuzad dies, he becomes a ghost.
  /// </summary>
  public sealed class QuestKelthuzadDies : QuestData
  {
    private readonly ObjectiveEitherOf _objectiveEitherOf;

    /// <inheritdoc />
    protected override string CompletionPopup => 
      _objectiveEitherOf.ObjectiveA.Progress == QuestProgress.Complete
        ? "As foretold by the Lich King, Kel'thuzad has been slain. Unseen to his assailants, his spirit is carried away by the howling winds of Northrend and reconstituted at the base of Icecrown Citadel."
        : "In a rare twist of fate, the Lich King's prophecy did not come to pass: Kel'thuzad survived long enough to reach the Sunwell under his own power.";

    /// <inheritdoc />
    protected override string RewardDescription => "If Kel'thuzad dies, he revives in spectral form at Icecrown Citadel. Otherwise, he gains 1000 experience";

    /// <inheritdoc />
    public QuestKelthuzadDies(QuestData questKelthuzadLich) : base("Life Beyond Death",
      "The Lich King has foretold that the human necromancer Kel'thuzad will be slain by the enemies of the Scourge. Fortunately for him, he will live on in an ethereal form.",
      @"ReplaceableTextures\CommandButtons\BTNGhostOfKelThuzad.blp")
    {
      _objectiveEitherOf = new ObjectiveEitherOf(
        new ObjectiveLegendDead(LegendScourge.Kelthuzad),
        new ObjectiveCompleteQuest(questKelthuzadLich));
      AddObjective(_objectiveEitherOf);
    }
    
    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      if (LegendScourge.Kelthuzad == null)
        return;

      if (_objectiveEitherOf.ObjectiveA.Progress == QuestProgress.Complete)
      {
        LegendScourge.Kelthuzad.UnitType = FourCC("U00M");
        LegendScourge.Kelthuzad.PermaDies = false;
        LegendScourge.Kelthuzad.ForceCreate(ScourgeSetup.Scourge.Player, Regions.FTSummon.Center,
          270);
      }
      else
      {
        LegendScourge.Kelthuzad.Unit?.AddExperience(1000);
      }
    }
  }
}