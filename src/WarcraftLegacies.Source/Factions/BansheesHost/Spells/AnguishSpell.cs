using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Damages a target over time and heals the caster for the damage dealt.</summary>
public sealed class AnguishSpell : Spell
{
  public required float DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required int BuffId { get; init; }
  public required string TickEffectPath { get; init; }
  public required string HealEffectPath { get; init; }

  public AnguishSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    BuffSystem.Add(new AnguishBuff(caster, target, BuffId)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerTick = DamagePerSecond,
      TickEffectPath = TickEffectPath,
      HealEffectPath = HealEffectPath
    }, StackBehaviour.Stack);
  }
}

/// <summary>The Anguish debuff, bound to its in-game buff so that a dispel ends it.</summary>
public sealed class AnguishBuff : BoundBuff
{
  public required float DamagePerTick { get; init; }
  public required string TickEffectPath { get; init; }
  public required string HealEffectPath { get; init; }

  public AnguishBuff(unit caster, unit target, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BuffId = buffId;
  }

  public override void OnTick()
  {
    effect.Create(TickEffectPath, Target, "chest").Dispose();
    Caster.DealDamage(Target, DamagePerTick, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    if (!Caster.Alive)
    {
      return;
    }

    Caster.Life += DamagePerTick;
    effect.Create(HealEffectPath, Caster, "origin").Dispose();
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override void OnExpire() => Target.RemoveAbility(BuffId);
}
