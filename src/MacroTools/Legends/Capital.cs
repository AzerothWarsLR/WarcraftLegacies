using System;
using System.Collections.Generic;
using MacroTools.Factions;

namespace MacroTools.Legends;

/// <summary>
/// An important structure, such as the Black Temple or the Capital Palace.
/// </summary>
public sealed class Capital : Legend
{
  /// <summary>
  ///   Whether or not the unit changes ownership to its attacker when its hitpoints are reduced past a threshold.
  /// </summary>
  public bool Capturable { get; set; }

  /// <summary>
  /// The number of living <see cref="Protector"/> making this <see cref="Legend"/> invulnerable.
  /// </summary>
  public int ProtectorCount => _protectors.Count;

  public readonly Dictionary<unit, Protector> ProtectorsByUnit = new();

  /// <summary>
  /// A user-friendly name for the <see cref="Capital"/>.
  /// </summary>
  public string Name => GetObjectName(UnitType);

  private readonly List<Protector> _protectors = new();
  private trigger? _damageTrig;
  private trigger? _deathTrig;
  private trigger? _ownerTrig;

  private void OnProtectorDeath(object? sender, Protector protector)
  {
    try
    {
      _protectors.Remove(protector);
      protector.ProtectorDied -= OnProtectorDeath;
      if (_protectors.Count != 0)
      {
        return;
      }

      if (!Unit.IsInvulnerable)
      {
        throw new Exception(
          $"{Unit.Name}'s last protector died, which should make it vulnerable, but it is already vulnerable.");
      }

      if (Unit != null)
      {
        Unit.IsInvulnerable = false;
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  /// <summary>
  ///   Adds a protector to the Legend.
  ///   Legends are invulnerable until all of their protectors are destroyed.
  /// </summary>
  public void AddProtector(unit whichUnit)
  {
    if (ProtectorsByUnit.ContainsKey(whichUnit))
    {
      throw new InvalidOperationException($"{whichUnit.Name} is already registered as a Protector for {Name}.");
    }

    var protector = new Protector(whichUnit);
    _protectors.Add(protector);
    ProtectorsByUnit.Add(whichUnit, protector);
    if (Unit != null)
    {
      Unit.IsInvulnerable = true;
    }

    protector.ProtectorDied += OnProtectorDeath;
  }

  /// <inheritdoc />
  protected override void OnChangeUnit()
  {
    if (_deathTrig != null)
    {
      _deathTrig.Dispose();
    }

    _deathTrig = trigger.Create();
    _deathTrig.RegisterUnitEvent(Unit, unitevent.Death);
    _deathTrig.AddAction(OnDeath);

    if (_damageTrig != null)
    {
      _damageTrig.Dispose();
    }

    _damageTrig = trigger.Create();
    _damageTrig.RegisterUnitEvent(Unit, unitevent.Damaged);
    _damageTrig.AddAction(OnDamaged);

    if (_ownerTrig != null)
    {
      _ownerTrig.Dispose();
    }

    _ownerTrig = trigger.Create();
    _ownerTrig.RegisterUnitEvent(Unit, unitevent.ChangeOwner);
    _ownerTrig.AddAction(() =>
    {
      OnChangeOwner(new LegendChangeOwnerEventArgs(this, @event.ChangingUnitPrevOwner));
    });
  }

  private void OnDamaged()
  {
    if (!Capturable || !(@event.Damage + 1 >= Unit.Life))
    {
      return;
    }

    Unit.SetOwner(@event.DamageSource.Owner);
    @event.Damage = 0;
    Unit.Life = Unit.MaxLife;
  }

  private void OnDeath()
  {
    if (string.IsNullOrEmpty(DeathMessage))
    {
      return;
    }

    if (Hivemind && OwningPlayer != null)
    {
      PlayerDistributor.DistributePlayer(OwningPlayer);
    }

    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      player.DisplayTextTo($"\n|cffffcc00CAPITAL DESTROYED|r\n{DeathMessage}");
    }
  }
}
