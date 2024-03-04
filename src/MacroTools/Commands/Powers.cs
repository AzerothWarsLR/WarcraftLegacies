using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;


namespace MacroTools.Commands
{
  public sealed class Powers : Command
  {
    /// <inheritdoc />
    public override string CommandText => "powers";

    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Lists all of your Powers.";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      var faction = commandUser.GetFaction();
      return faction == null
        ? "You have no faction and thus can't have powers."
        : $"\n{string.Join("\n\n", faction.GetAllPowers().Select(ParsePowerInfo))}";
    }

    private static string ParsePowerInfo(Power power) =>
      $"|cffff8c00{power.Name}|r\n{power.Description}";
  }
}