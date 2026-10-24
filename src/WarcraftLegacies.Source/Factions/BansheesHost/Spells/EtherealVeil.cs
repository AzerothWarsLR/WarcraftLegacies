using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Fades the caster into the spirit world, where attacks can't harm it and its own attacks burn mana.</summary>
public sealed class EtherealVeilSpell : Spell
{
  public required int BuffId { get; init; }
  public required LeveledAbilityField<float> Duration { get; init; }
  public required int Alpha { get; init; }

  public EtherealVeilSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    BuffSystem.Add(new EtherealVeilBuff(caster, BuffId)
    {
      Duration = Duration.GetValue(GetAbilityLevel(caster)),
      Alpha = Alpha
    }, StackBehaviour.Stack);
  }
}

/// <summary>Shows the caster faded while <see cref="EtherealVeilSpell"/> lasts.</summary>
public sealed class EtherealVeilBuff : BoundBuff
{
  public required int Alpha { get; init; }

  public EtherealVeilBuff(unit caster, int buffId) : base(caster, caster)
  {
    IsBeneficial = true;
    BuffId = buffId;
  }

  public override void OnApply() => Target.SetVertexColor(255, 255, 255, Alpha);

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override void OnDispose() => Target.SetVertexColor(255, 255, 255, 255);
}

/// <summary>While veiled, attacks can't harm the unit and its own attacks burn mana from their target.</summary>
public sealed class EtherealVeilTrait : UnitTrait, IEffectOnDamaged, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required int BuffId { get; init; }
  public required LeveledAbilityField<float> ManaBurned { get; init; }
  public required string BurnEffectPath { get; init; }

  /// <inheritdoc />
  public void OnDamaged()
  {
    if (@event.IsAttack && @event.Unit.GetAbilityLevel(BuffId) > 0)
    {
      @event.Damage = 0;
    }
  }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    if (!@event.IsAttack || attacker.GetAbilityLevel(BuffId) == 0 || target.Mana <= 0)
    {
      return;
    }

    var burned = ManaBurned.GetValue(attacker.GetAbilityLevel(AbilityTypeId));
    if (burned > target.Mana)
    {
      burned = target.Mana;
    }

    target.Mana -= burned;
    @event.Damage += burned;
    effect.Create(BurnEffectPath, target, "chest").Dispose();
  }
}
