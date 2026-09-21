using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Commands;

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
    if (!FactionManager.TryGetFactionByName(parameters[0], out var targetFaction))
    {
      return Loc.Format("There is no faction named {value}.", ("{value}", parameters[0]));
    }

    if (targetFaction.Player == null)
    {
      return Loc.Format("There is nobody playing the {faction} faction.", ("{faction}", targetFaction.Name));
    }

    var cheaterTeam = cheater.GetPlayerData().Team;
    if (cheaterTeam != targetFaction.Player.GetPlayerData().Team)
    {
      return Loc.Format("{faction} isn't on your team, so you can't give them gold.", ("{faction}", targetFaction.Name));
    }

    if (!int.TryParse(parameters[1], out var goldGift))
    {
      return "You must specify a gold value as the second parameter.";
    }

    if (goldGift < 0)
    {
      return "You must send at least 1 gold.";
    }

    if (cheater.Gold < goldGift)
    {
      return Loc.Format("You don't have {gold} gold to send.", ("{gold}", goldGift.ToString()));
    }

    cheater.Gold -= goldGift;
    targetFaction.Player.Gold += goldGift;

    return Loc.Format("Sent {gold} gold to {faction}.",
      ("{gold}", goldGift.ToString()), ("{faction}", targetFaction.Name));
  }
}
