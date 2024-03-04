using MacroTools.CommandSystem;


namespace MacroTools.Cheats
{
  public sealed class CheatUncontrol : Command
  {
    /// <inheritdoc />
    public override string CommandText => "uncontrol";
    
    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Description => "Revokes control of the specified player numbers, or all players if you specify \"all\".";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!int.TryParse(parameters[0], out var playerNumber) && parameters[0] != "all")
        return "You must specify a valid player number or \"all\" as the first parameter.";

      if (parameters[0] == "all")
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        {
          SetPlayerAlliance(player, GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
          SetPlayerAlliance(player, GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
        }
        return "Revoked control of all players.";
      }

      SetPlayerAlliance(Player(playerNumber), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
      SetPlayerAlliance(Player(playerNumber), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
      return $"Revoked control of player {GetPlayerName(Player(playerNumber))}.";
    }
  }
}