using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// The Scourge can corrupt Arthas, turning him into a Death Knight in their service.
  /// </summary>
  public sealed class QuestCorruptArthas : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCorruptArthas"/> class.
    /// </summary>
    public QuestCorruptArthas() : base("The Culling",
      "When the city of Stratholme falls, Prince Arthas will abandon his people and join the Scourge as their champion.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroDeathKnight.blp")
    {
      AddObjective(new ObjectiveCapitalDead(LegendLordaeron.Stratholme));
      AddObjective(new ObjectiveEitherOf(new ObjectiveLegendDead(LegendLordaeron.Arthas),
        new ObjectiveFactionDefeated(LordaeronSetup.Lordaeron)));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
      ResearchId = Constants.UPGRADE_R01K_QUEST_COMPLETED_THE_CULLING_LORDAERON;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion.";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train {LegendScourge.Arthas?.Name} from the {GetObjectName(Constants.UNIT_UAOD_ALTAR_OF_DARKNESS)}";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var arthas = LegendLordaeron.Arthas?.Unit;
      if (arthas != null && UnitAlive(arthas))
      {
        arthas
          .Kill()
          .Remove();
      }
    }
  }
}