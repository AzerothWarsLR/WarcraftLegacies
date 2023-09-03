using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// The Scourge can corrupt Arthas, turning him into a Death Knight in their service.
  /// </summary>
  public sealed class QuestCorruptArthas : QuestData
  {
    private readonly LegendaryHero _arthas;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestCorruptArthas"/> class.
    /// </summary>
    public QuestCorruptArthas(QuestData questDestroyStratholme, LegendaryHero arthas) : base("The Dark Champion",
      "Driven by vengeance, Prince Arthas will abandon his people and join the Scourge as their champion.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroDeathKnight.blp")
    {
      _arthas = arthas;
      AddObjective(new ObjectiveCompleteQuest(questDestroyStratholme));
      AddObjective(new ObjectiveEitherOf(new ObjectiveLegendDead(arthas),
        new ObjectiveFactionDefeated(LordaeronSetup.Lordaeron)));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
      ResearchId = Constants.UPGRADE_R01K_QUEST_COMPLETED_THE_CULLING_LORDAERON;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion.";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train {_arthas.Name} from the {GetObjectName(Constants.UNIT_UAOD_ALTAR_OF_DARKNESS)}";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var arthas = _arthas.Unit;
      if (arthas != null && UnitAlive(arthas))
      {
        arthas
          .Kill()
          .Remove();
        completingFaction.RemovePowerByName("Eye of the Lich King");
      }
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public sealed class QuestDestroyStratholme : QuestData
  {
    private readonly LegendaryHero _arthas;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stratholme"></param>
    /// <param name="arthas"></param>
    public QuestDestroyStratholme(Capital stratholme, LegendaryHero arthas) : base("The Culling", "When the city of Stratholme falls, Prince Arthas' despair will make him more susceptible to the power of the Lich King.", "ReplaceableTextures\\CommandButtons\\BTNRuneblade.blp")
    {
      _arthas = arthas;
      AddObjective(new ObjectiveCapitalDead(stratholme));
      Required = true;
    }

    private bool IsPointValidForArthas(Point whichPoint) =>
      !whichPoint.IsPathable(PATHING_TYPE_FLOATABILITY) && whichPoint.IsPathable(PATHING_TYPE_WALKABILITY);

    /// <inheritdoc />
    protected override string RewardFlavour => "Prince Arthas could not protect the people of Stratholme. The Lich King's hold over him grows stronger.";

    /// <inheritdoc />
    protected override string RewardDescription => $"You gain the power Eye of the Lich King.";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.AddPower(new PingPower(_arthas, "Eye of the Lich King", 5, 60));

      Point randomPoint;
      do
      {
        randomPoint = Regions.ArthasRandomPoint.GetRandomPoint();
      } while (!IsPointValidForArthas(randomPoint));

      ReviveHero(_arthas.Unit, randomPoint.X, randomPoint.Y, true);
    }
  }
}