using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;


namespace MacroTools.Commands
{
  /// <summary>Give lumber to another player.</summary>
  public sealed class GiveLumber : Command
  {
    private readonly string _commandText;

    /// <summary>Initializes a new instance of the <see cref="GiveLumber"/> class.</summary>
    public GiveLumber(string commandText) => _commandText = commandText;

    /// <inheritdoc />
    public override string CommandText => _commandText;

    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 2;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Gives lumber to another player.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var targetFaction = FactionManager.GetFactionByName(parameters[0]);
      if (targetFaction == null) 
        return $"There is no faction named {parameters[0]}.";

      if (targetFaction.Player == null)
        return $"There is nobody playing the {targetFaction.Name} faction.";

      var cheaterTeam = cheater.GetTeam();
      if (cheaterTeam != targetFaction.Player.GetTeam())
        return $"{targetFaction.Name} isn't on your team, so you can't give them lumber.";

      if (!int.TryParse(parameters[1], out var lumberGift))
        return "You must specify a lumber value as the second parameter.";

      if (lumberGift < 0)
        return "You must send at least 1 lumber.";
      
      if (GetPlayerState(cheater, PLAYER_STATE_RESOURCE_LUMBER) < lumberGift)
        return $"You don't have {lumberGift} lumber to send.";

      cheater.AddLumber(-lumberGift);
      targetFaction.Player.AddLumber(lumberGift);
      
      return $"Sent {lumberGift} lumber to {targetFaction.Name}.";
    }
  }
}