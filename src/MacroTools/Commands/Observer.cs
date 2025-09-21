using System;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;

namespace MacroTools.Commands;

/// <summary>
/// When a player types the command, they get removed from the game and made into an observer.
/// </summary>
public sealed class Observer : Command
{
  private Team? _observers;

  /// <inheritdoc />
  public override void OnRegister()
  {
    _observers = new Team("Observers");
    FactionManager.Register(_observers);
  }

  /// <inheritdoc />
  public override string CommandText => "obs";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description => "Forfeit the game and become an observer.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var triggerFaction = @event.Player.GetFaction();
    if (triggerFaction == null)
    {
      throw new InvalidOperationException(
        $"{@event.Player.Name} tried to execute {nameof(Observer)}, but they don't have a {nameof(Faction)}.");
    }

    triggerFaction.Defeat();
    triggerFaction.Player?.SetTeam(_observers!);

    return "You have become an observer.";
  }
}
