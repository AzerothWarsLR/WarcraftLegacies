using MacroTools.Commands;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Destroys Nordrassil straight away, to check its charred remains.</summary>
public sealed class CheatKillTree : Command
{
  /// <inheritdoc />
  public override string CommandText => "killtree";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Destroys Nordrassil.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var nordrassil = AllLegends.Druids.Nordrassil.Unit;
    if (!nordrassil.Alive)
    {
      return "Nordrassil is already destroyed.";
    }

    nordrassil.Kill();
    return "Destroyed Nordrassil.";
  }
}
