using MacroTools.CommandSystem;

namespace WarcraftLegacies.Source.Cheats
{
  public sealed class PreviewForsaken : Command
  {
    /// <inheritdoc />
    public override string CommandText => "forsaken";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(0);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Spawns a Forsaken worker.";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      CreateUnit(commandUser, UNIT_U01K_ACOLYTE_FORSAKEN_CULT_WORKER, -17429, -25000, 270);
      return "Spawned a Forsaken worker.";
    }
  }
}