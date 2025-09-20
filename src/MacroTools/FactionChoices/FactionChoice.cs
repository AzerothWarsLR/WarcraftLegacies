using MacroTools.FactionSystem;
using MacroTools.UserInterface;
using WCSharp.Shared.Data;

namespace MacroTools.FactionChoices;

public sealed class FactionChoice : IChoice
{
  public required Faction Faction { get; init; }

  /// <summary>
  /// Indicates how difficult it is to learn the basic mechanics of this <see cref="Faction"/>.
  /// <para>This isn't about how difficult the Faction is to play optimally, but rather how difficult it is to
  /// play at a very basic level. For instance, a Faction with a very complex starting quest would be very hard
  /// even if it doesn't have to perform a lot of micro in fights.</para>
  /// </summary>
  public required FactionLearningDifficulty Difficulty { get; init; }

  /// <inheritdoc />
  public string Name
  {
    get
    {
      var name = $"{Faction.Name} {Difficulty.ToColoredText()}";
      if (RequiresCheats)
      {
        name += " |cffD27575(CHEAT)|r";
      }

      return name;
    }
  }

  /// <summary>Where the player will start the game if they pick this faction.</summary>
  public required Rectangle StartingArea { get; init; }

  /// <summary>If true, can only be chosen if the player has cheats enabled.</summary>
  public bool RequiresCheats { get; init; }
}
