using MacroTools.Commands;
using MacroTools.Extensions;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Destroys the Sunwell so Kael's Exodus and The Sunfury open.</summary>
public sealed class CheatTestSunwell : Command
{
  /// <inheritdoc />
  public override string CommandText => "testsunwell";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Destroys the Sunwell so Kael's Exodus and The Sunfury open.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (cheater.GetPlayerData().Faction is not QuelthalasFaction)
    {
      return "Play Quel'thalas to run this.";
    }

    var sunwell = AllLegends.Quel.Sunwell.Unit;
    if (sunwell != null && sunwell.Alive)
    {
      sunwell.Kill();
    }

    return "Sunwell destroyed. Open the Paths book.";
  }
}
