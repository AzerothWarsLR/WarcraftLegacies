using MacroTools.Cheats;
using MacroTools.Wrappers;
using static War3Api.Common;
using MacroTools.Extensions;
using System.Collections.Generic;
using MacroTools.Libraries;
using MacroTools.CommandSystem;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A <see cref="Cheat"/> that adds a specified spell to all selected units.
  /// </summary>
  public sealed class CheatRawCode : Command
  {
    /// <inheritdoc />
    public override string CommandText => "id";

    /// <inheritdoc />
    public override int ParameterCount => 1;
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      List<unit> listOfUnits = CreateGroup().EnumSelectedUnits(cheater).EmptyToList();
      int IDType = listOfUnits[0].GetTypeId();
      string StringName = GeneralHelpers.DebugIdInteger2IdString(IDType);

      return StringName;
    }
  }
}