using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A <see cref="Command"/> that adds a specified spell to all selected units.
  /// </summary>
  public sealed class CheatAddSpell : Command
  {
    /// <inheritdoc />
    public override string CommandText => "add";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Adds the specified spell to all selected units.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var spell = parameters[0];

      if (spell.Length != 4)
        return "You must specify an ability ID of exactly 4 characters.";

      var fourCc = FourCC(spell);
      var objectName = GetObjectName(fourCc);
      
      if (objectName == "Default string")
      {
        return "That is not a valid object ID for this map.";
      }
      
      foreach (var unit in CreateGroup().EnumSelectedUnits(cheater).EmptyToList())
        UnitAddAbility(unit, fourCc);

      return $"Adding {objectName} to selected units.";
    }
  }
}