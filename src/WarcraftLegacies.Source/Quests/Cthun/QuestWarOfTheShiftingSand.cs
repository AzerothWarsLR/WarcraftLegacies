using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Cthun;

public sealed class QuestWarOfTheShiftingSand : QuestData
{
  private readonly LegendaryHero _cthun;
  private const int SkillPoints = 3;

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Nordrassil has been taken, and with it, the source of the Night Elves' immortality. The War of the Shifting Sands, begun anew a thousand years after its first conclusion, is over once more.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"C'thun gains {SkillPoints} skill points";

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestWarOfTheShiftingSand"/> class.
  /// </summary>
  public QuestWarOfTheShiftingSand(LegendaryHero cthun, Capital nordrassil) : base("War of the Shifting Sands",
    "A millenia ago, the Night Elves soundly defeated my Qiraji and drove them scurrying back into Ahn'qiraj. If I am to succeed in my domination of Azeroth, the second War of the Shifting Sands must begin with their demise.",
    @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
  {
    _cthun = cthun;
    AddObjective(new ObjectiveControlCapital(nordrassil, false));
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => _cthun.Unit.AddSkillPoints(SkillPoints);
}
