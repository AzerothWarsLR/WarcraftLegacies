using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.Utils;


namespace MacroTools.Cheats
{
  public sealed class CheatRemove : Command
  {
    /// <inheritdoc />
    public override string CommandText => "remove";
    
    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Removes all selected units.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      foreach (var unit in GroupUtils.GetSelectedUnits(cheater)) 
        RemoveUnit(unit);
      return "Permanently removing selected units.";
    }
  }
}