using System.Collections.Generic;
using MacroTools.Exceptions;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.Scourge.Blight;

/// <summary>
///   Units can be registered to the <see cref="BlightSystem" /> so that when they are killed by allies of a specific
///   <see cref="Faction" />, they spread a certain amount of blight around them.
/// </summary>
public static class BlightSystem
{
  private static readonly Dictionary<unit, BlightParameters> _blightParameters = new();
  private static Faction? _blightFaction;

  private static bool _initialized;

  private static void UnitDies()
  {
    var triggerUnit = @event.Unit;
    var parameters = _blightParameters[triggerUnit];

    var blightPlayer = _blightFaction?.Player;
    var blightTeam = blightPlayer?.GetPlayerData().Team;
    var killerPlayer = @event.KillingUnit.Owner;

    if (blightPlayer == null || blightTeam == null || !blightTeam.Contains(killerPlayer))
    {
      return;
    }

    SetBlightRadius(blightPlayer, new Point(triggerUnit.X, triggerUnit.Y), parameters.PrimaryBlightRadius, true);
    if (parameters.RandomBlightRectangle is null)
    {
      return;
    }

    for (var i = 0; i < parameters.RandomBlightCount; i++)
    {
      SetBlightRadius(blightPlayer, parameters.RandomBlightRectangle.GetRandomPoint(), parameters.RandomBlightRadius, true);
    }
  }

  /// <summary>
  ///   Causes the specified unit to create blight around it when it dies.
  /// </summary>
  /// <param name="whichUnit">The dying unit.</param>
  /// <param name="blightParameters">Instructions as to how much blight should be created and where.</param>
  /// <exception cref="SystemNotInitializedException">Thrown if the system hasn't been initialized.</exception>
  public static void Register(unit whichUnit, BlightParameters blightParameters)
  {
    if (!_initialized)
    {
      throw new SystemNotInitializedException($"{nameof(BlightSystem)} has not been initialized.");
    }

    if (_blightParameters.ContainsKey(whichUnit))
    {
      return;
    }

    _blightParameters.Add(whichUnit, blightParameters);
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(whichUnit, unitevent.Death);
    deathTrigger.AddAction(UnitDies);
  }

  public static void Setup(Faction blightFaction)
  {
    if (_initialized)
    {
      throw new SystemAlreadyInitializedException($"{nameof(BlightSystem)} has already been initialized.");
    }

    _blightFaction = blightFaction;
    _initialized = true;
  }
}
