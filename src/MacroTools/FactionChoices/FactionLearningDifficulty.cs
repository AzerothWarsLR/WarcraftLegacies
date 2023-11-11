using System;
using MacroTools.FactionSystem;

namespace MacroTools.FactionChoices
{
  /// <summary>
  /// Indicates how difficult it is to learn the basic mechanics of a particular <see cref="Faction"/>.
  /// </summary>
  public enum FactionLearningDifficulty
  {
    Basic,
    Advanced
  }

  public static class FactionLearningDifficultyExtensions
  {
    public static string ToColoredText(this FactionLearningDifficulty difficulty)
    {
      switch (difficulty)
      {
        case FactionLearningDifficulty.Basic:
          return "|c0096FF96(Basic)|r";
        case FactionLearningDifficulty.Advanced:
          return "|c00FF7F00(Advanced)|r";
        default:
          throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
      }
    }
  }
}