using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>Damages nearby enemies and marks them, so the caster's next attack against each deals bonus damage.</summary>
public sealed class FanOfFelBladesSpell : Spell
{
  private readonly Dictionary<unit, MarkedBuff> _marks = new();

  public required float Radius { get; init; }
  public required LeveledAbilityField<float> Damage { get; init; }
  public required LeveledAbilityField<float> BonusDamage { get; init; }
  public required float MarkDuration { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required string CastEffectPath { get; init; }
  public required string MarkEffectPath { get; init; }

  public FanOfFelBladesSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    effect.Create(CastEffectPath, caster.X, caster.Y).Dispose();
    foreach (var enemy in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, enemy) || enemy.UnitType == DummyCasterManager.UnitTypeId ||
          enemy.IsUnitType(unittype.Structure))
      {
        continue;
      }

      caster.DealDamage(enemy, Damage.GetValue(level), false, false, attacktype.Normal, damagetype.Magic,
        weapontype.WhoKnows);
      if (!enemy.Alive)
      {
        continue;
      }

      var mark = new MarkedBuff(caster, enemy, BuffApplicatorId, BuffId, MarkEffectPath)
      {
        Duration = MarkDuration,
        BonusDamage = BonusDamage.GetValue(level)
      };
      BuffSystem.Add(mark, StackBehaviour.Stack);
      if (mark.Active)
      {
        _marks[enemy] = mark;
      }
    }
  }

  /// <summary>Ends <paramref name="target"/>'s mark and returns its bonus damage, or 0 if it isn't marked.</summary>
  public float Consume(unit target)
  {
    if (!_marks.TryGetValue(target, out var mark))
    {
      return 0;
    }

    _marks.Remove(target);
    if (!mark.Active)
    {
      return 0;
    }

    mark.Active = false;
    return mark.BonusDamage;
  }
}

/// <summary>A mark left by <see cref="FanOfFelBladesSpell"/>.</summary>
public sealed class MarkedBuff : BoundBuff
{
  private readonly string _markEffectPath;
  private effect? _markEffect;

  public required float BonusDamage { get; set; }

  public MarkedBuff(unit caster, unit target, int buffApplicatorId, int buffId, string markEffectPath) :
    base(caster, target)
  {
    _markEffectPath = markEffectPath;
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply() => _markEffect = effect.Create(_markEffectPath, Target, "overhead");

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    BonusDamage = ((MarkedBuff)newStack).BonusDamage;
    return StackResult.Stack;
  }

  public override void OnDispose()
  {
    if (_markEffect != null)
    {
      _markEffect.Dispose();
    }

    base.OnDispose();
  }
}

/// <summary>Spends a <see cref="MarkedBuff"/> when the unit attacks a marked target, adding its bonus damage.</summary>
public sealed class FanOfFelBladesTrait : UnitTrait, IAppliesEffectOnDamage
{
  public required FanOfFelBladesSpell Spell { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    if (!@event.IsAttack)
    {
      return;
    }

    @event.Damage += Spell.Consume(@event.Unit);
  }
}
