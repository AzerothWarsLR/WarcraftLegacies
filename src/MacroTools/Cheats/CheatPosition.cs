using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;


namespace MacroTools.Cheats
{
  /// <summary>
  /// A cheat that displays the position of the first selected unit.
  /// </summary>
  public sealed class CheatPosition : Command
  {
    /// <inheritdoc />
    public override string CommandText => "position";
    
    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Displays the position of the first selected unit.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var firstSelectedUnit = CreateGroup().EnumSelectedUnits(cheater).EmptyToList().First();
      return $"{firstSelectedUnit.Name} is at position {GetUnitX(firstSelectedUnit)}, {GetUnitY(firstSelectedUnit)}.";
    }
  }
}