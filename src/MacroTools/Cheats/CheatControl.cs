using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;


namespace MacroTools.Cheats
{
  /// <summary>
  /// Gives the cheater control of all players or a specific player.
  /// </summary>
  public sealed class CheatControl: Command
  {

    /// <inheritdoc />
    public override string CommandText => "control";
    
    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Gives the cheater control of all players or a specific player.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
 
      if (parameters[0] == "all")
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        {
          GetTriggerPlayer().SetAllianceState(player, AllianceState.AlliedAdvUnits);
          player.SetAllianceState(GetTriggerPlayer(), AllianceState.AlliedAdvUnits);
        }
       return "Granted control of all players.";
      }
      else
      {
        Player(S2I(parameters[0])).SetAllianceState(GetTriggerPlayer(), AllianceState.AlliedAdvUnits);
        GetTriggerPlayer().SetAllianceState(Player(S2I(parameters[0])), AllianceState.AlliedAdvUnits);
        return $"Granted control of player {GetPlayerName(Player(S2I(parameters[0])))}.";
      }
    }
  }
}