using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Damages a target over time; if it survives the full duration, the caster is struck instead.</summary>
public sealed class ShadowWordDeathSpell : Spell
{
  public required float DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required float BacklashFraction { get; init; }
  public required int BuffId { get; init; }
  public required string TickEffectPath { get; init; }
  public required string BacklashEffectPath { get; init; }

  public ShadowWordDeathSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    BuffSystem.Add(new ShadowWordDeathBuff(caster, target, BuffId)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerTick = DamagePerSecond,
      BacklashFraction = BacklashFraction,
      TickEffectPath = TickEffectPath,
      BacklashEffectPath = BacklashEffectPath
    }, StackBehaviour.Stack);
  }
}

/// <summary>The Shadow Word: Death debuff, bound to its in-game buff so that a dispel ends it without a backlash.</summary>
public sealed class ShadowWordDeathBuff : BoundBuff
{
  public required float DamagePerTick { get; init; }
  public required float BacklashFraction { get; init; }
  public required string TickEffectPath { get; init; }
  public required string BacklashEffectPath { get; init; }

  public ShadowWordDeathBuff(unit caster, unit target, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BuffId = buffId;
  }

  public override void OnTick()
  {
    effect.Create(TickEffectPath, Target, "chest").Dispose();
    Target.Damage(Caster, DamagePerTick, attacktype.Magic);
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override void OnExpire()
  {
    Target.RemoveAbility(BuffId);
    if (!Target.Alive || !Caster.Alive)
    {
      return;
    }

    effect.Create(BacklashEffectPath, Caster, "origin").Dispose();
    var backlash = Caster.MaxLife * BacklashFraction;
    if (Caster.Life <= backlash)
    {
      Caster.Kill();
      return;
    }

    Caster.Life -= backlash;
  }
}
