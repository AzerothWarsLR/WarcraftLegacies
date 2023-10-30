using System.Linq;
using MacroTools.Channels;
using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Absorb life and mana from multiple targets in an area.
  /// </summary>
  public sealed class SiphoningRitualSpell : Spell
  {
    /// <summary>
    /// The maximum number of targets that can be drained simultaneously.
    /// </summary>
    public int TargetCountBase { get; init; }
    
    /// <summary>
    /// Gets multiplied by the spell level and added to <see cref="TargetCountBase"/>.
    /// </summary>
    public int TargetCountLevel { get; init; }

    /// <summary>
    /// How many hit points to drain per second.
    /// </summary>
    public float LifeDrainedPerSecondBase { get; init; }

    /// <summary>
    /// How many hit points to drain per second. Gets multiplied by the spell level.
    /// </summary>
    public float LifeDrainedPerSecondLevel { get; init; }

    /// <summary>
    /// How much mana to drain per second. Gets multiplied by the spell level.
    /// </summary>
    public float ManaDrainedPerSecondBase { get; init; }

    /// <summary>
    /// How much mana to to drain per second. Gets multiplied by the spell level.
    /// </summary>
    public float ManaDrainedPerSecondLevel { get; init; }

    /// <summary>
    /// If a unit goes beyond this range, the drain breaks.
    /// </summary>
    public float Range { get; init; }

    /// <summary>
    /// The radius around the target position in which to get units for draining.
    /// </summary>
    public float Radius { get; init; }

    /// <summary>
    /// The interval at which to drain units.
    /// </summary>
    public float Interval { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SiphoningRitualSpell"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    public SiphoningRitualSpell(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var targets = CreateGroup()
        .EnumUnitsInRange(targetPoint, Radius)
        .EmptyToList().Where(unit => IsValidTarget(caster, unit))
        .Take(TargetCountBase + TargetCountLevel * GetAbilityLevel(caster));
      foreach (var unit in targets)
      {
        var channel = new SiphoningRitualChannel(caster, unit, Id)
        {
          Interval = Interval,
          LifeDrainedPerSecond = LifeDrainedPerSecondBase + LifeDrainedPerSecondLevel * GetAbilityLevel(caster),
          ManaDrainedPerSecond = ManaDrainedPerSecondBase + ManaDrainedPerSecondLevel * GetAbilityLevel(caster),
          Range = Range + Radius/2
        };
        ChannelManager.Add(channel);
      }
    }

    private static bool IsValidTarget(unit caster, unit target) =>
      caster != target && !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
      !IsUnitType(target, UNIT_TYPE_MECHANICAL) && UnitAlive(target);
  }
}