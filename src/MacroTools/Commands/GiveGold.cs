using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>Give gold to another player.</summary>
  public sealed class GiveGold : Command
  {
    private readonly string _commandText;

    /// <summary>Initializes a new instance of the <see cref="GiveGold"/> class.</summary>
    public GiveGold(string commandText) => _commandText = commandText;

    /// <inheritdoc />
    public override string CommandText => _commandText;

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(2);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Gives gold to another player.";

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
        return $"{targetFaction.Name} isn't on your team, so you can't give them gold.";

      if (!int.TryParse(parameters[1], out var goldGift))
        return "You must specify a gold value as the second parameter.";

      if (goldGift < 0)
        return "You must send at least 1 gold.";
      
      if (GetPlayerState(cheater, PLAYER_STATE_RESOURCE_GOLD) < goldGift)
        return $"You don't have {goldGift} gold to send.";

      cheater.AddGold(-goldGift);
      targetFaction.Player.AddGold(goldGift);
      
      return $"Sent {goldGift} gold to {targetFaction.Name}.";
    }
  }
}