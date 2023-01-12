using MacroTools.CheatSystem;
using MacroTools.Wrappers;
using static War3Api.Common;
using MacroTools.Extensions;
using System.Collections.Generic;
using MacroTools.Libraries;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A <see cref="Cheat"/> that adds a specified spell to all selected units.
  /// </summary>
  public sealed class CheatRawCode : Cheat
  {
    /// <inheritdoc />
    public override string Command => "-id";

    /// <inheritdoc />
    public override int ParameterCount => 0;

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      List<unit> listOfUnits = new GroupWrapper().EnumSelectedUnits(cheater).EmptyToList();
      int IDType = listOfUnits[0].GetTypeId();
      string StringName = GeneralHelpers.DebugIdInteger2IdString(IDType);

      return StringName;
    }
  }
}