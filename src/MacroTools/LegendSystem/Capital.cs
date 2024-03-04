using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;


namespace MacroTools.LegendSystem
{
  /// <summary>
  /// An important structure, such as the Black Temple or the Capital Palace.
  /// </summary>
  public sealed class Capital : Legend
  {
    /// <summary>
    ///   Whether or not the unit changes ownership to its attacker when its hitpoints are reduced past a threshold.
    /// </summary>
    public bool Capturable { get; init; }
    
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
        if (_protectors.Count != 0) return;
        if (!BlzIsUnitInvulnerable(Unit))
          throw new Exception(
            $"{GetUnitName(Unit)}'s last protector died, which should make it vulnerable, but it is already vulnerable.");
        unit tempQualifier = Unit;
        if (tempQualifier != null)
        {
          tempQualifier.IsInvulnerable = true;
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
        throw new InvalidOperationException($"{whichUnit.Name} is already registered as a Protector for {Name}.");
      
      var protector = new Protector(whichUnit);
      _protectors.Add(protector);
      ProtectorsByUnit.Add(whichUnit, protector);
      unit tempQualifier = Unit;
      if (tempQualifier != null)
      {
        tempQualifier.IsInvulnerable = true;
      }

      protector.ProtectorDied += OnProtectorDeath;
    }
    
    /// <inheritdoc />
    protected override void OnChangeUnit()
    {
      trigger tempQualifier = _deathTrig;
      if (tempQualifier != null)
      {
        tempQualifier.Dispose();
      }

      var deathTrig = CreateTrigger();
      deathTrig.RegisterUnitEvent(Unit, EVENT_UNIT_DEATH);
      deathTrig.AddAction(OnDeath);
      _deathTrig = deathTrig;

      trigger tempQualifier1 = _damageTrig;
      if (tempQualifier1 != null)
      {
        tempQualifier1.Dispose();
      }

      var damageTrig = CreateTrigger();
      damageTrig.RegisterUnitEvent(Unit, EVENT_UNIT_DAMAGED);
      damageTrig.AddAction(OnDamaged);
      _damageTrig = damageTrig;

      trigger tempQualifier2 = _ownerTrig;
      if (tempQualifier2 != null)
      {
        tempQualifier2.Dispose();
      }

      var ownerTrig = CreateTrigger();
      ownerTrig.RegisterUnitEvent(Unit, EVENT_UNIT_CHANGE_OWNER);
      ownerTrig.AddAction(() =>
        {
          OnChangeOwner(new LegendChangeOwnerEventArgs(this, GetChangingUnitPrevOwner()));
        });
      _ownerTrig = ownerTrig;
    }
    
    private void OnDamaged()
    {
      if (!Capturable || !(GetEventDamage() + 1 >= GetUnitState(Unit, UNIT_STATE_LIFE))) return;
      SetUnitOwner(Unit, GetOwningPlayer(GetEventDamageSource()), true);
      BlzSetEventDamage(0);
      SetUnitState(Unit, UNIT_STATE_LIFE, GetUnitState(Unit, UNIT_STATE_MAX_LIFE));
    }
    
    private void OnDeath()
    {
      if (string.IsNullOrEmpty(DeathMessage)) 
        return;
      if (Hivemind && OwningPlayer != null)
        PlayerDistributor.DistributePlayer(OwningPlayer);
      
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        DisplayTextToPlayer(player, 0, 0, $"\n|cffffcc00CAPITAL DESTROYED|r\n{DeathMessage}");
    }
  }
}