using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.ControlPointSystem
{
  /// <summary>
  ///   An immobile and permanent unit on the map.
  ///   Increases the income of the controlling <see cref="Faction" />.
  ///   When a <see cref="ControlPoint" /> is reduced below a certain health threshold, it changes ownership to the attacker.
  /// </summary>
  public sealed class ControlPoint
  {
    private int _controlLevel;

    /// <summary>
    /// A tower that appears on the <see cref="ControlPoint"/> when its <see cref="ControlLevel"/> exceeds 0.
    /// </summary>
    private unit? Defender { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ControlPoint"/> class.
    /// </summary>
    /// <param name="representingUnit">The unit representing the <see cref="ControlPoint"/>.</param>
    /// <param name="value">The gold income granted by the <see cref="ControlPoint"/>.</param>
    public ControlPoint(unit representingUnit, float value)
    {
      Unit = representingUnit;
      Value = value;
    }

    /// <summary>
    /// The owner of the <see cref="ControlPoint"/>.
    /// </summary>
    public player Owner => GetOwningPlayer(Unit);

    /// <summary>
    ///   How much gold this <see cref="ControlPoint" /> grants per minute.
    /// </summary>
    public float Value { get; }

    /// <summary>
    /// The unit type ID of the <see cref="ControlPoint"/>.
    /// </summary>
    public int UnitType => GetUnitTypeId(Unit);

    /// <summary>
    /// A user-friendly name for the <see cref="ControlPoint"/>.
    /// </summary>
    public string Name => GetUnitName(Unit);

    /// <summary>
    /// The unit representing the <see cref="ControlPoint"/>.
    /// </summary>
    public unit Unit { get; }

    /// <summary>
    ///   Invoked when the <see cref="ControlPoint" /> changes its owner.
    /// </summary>
    public event EventHandler<ControlPointOwnerChangeEventArgs>? ChangedOwner;

    /// <summary>
    /// Invokes the <see cref="ChangedOwner"/> event with the provided arguments..
    /// </summary>
    public void SignalOwnershipChange(ControlPointOwnerChangeEventArgs args)
    {
      ChangedOwner?.Invoke(this, args);
    }
    
    /// <summary>
    /// When <see cref="ControlLevel"/> is higher than 0, the <see cref="ControlPoint"/> becomes a tower with
    /// attack damage and hit points based on its <see cref="ControlLevel"/>.
    /// </summary>
    public int ControlLevel
    {
      get => _controlLevel;
      set
      {
        _controlLevel = value;
        if (ControlLevel > 0)
        {
          Defender ??= CreateUnit(Owner, ControlPointManager.Instance.DefenderUnitTypeId, GetUnitX(Unit), GetUnitY(Unit), 0);
          Defender
            .SetDamageBase(100 + ControlLevel * 50)
            .SetDamageNumberOfDice(6)
            .SetDamageSidesPerDie(6)
            .SetSkin(FourCC("hfoo"))
            .AddAbility(FourCC("Aloc"))
            .SetInvulnerable(true);
          Unit
            .SetMaximumHitpoints(MaxHitpoints + ControlLevel * 500);
          CreateTrigger()
            .RegisterUnitEvent(Unit, EVENT_UNIT_CHANGE_OWNER)
            .AddAction(() =>
            {
              ControlLevel = 0;
              Defender?.Kill();
              DestroyTrigger(GetTriggeringTrigger());
            });
        }
        else
        {
          Defender?.Kill();
          Defender = null;
          Unit
            .SetInvulnerable(false)
            .SetMaximumHitpoints(MaxHitpoints);
        }
      }
    }
  }
}