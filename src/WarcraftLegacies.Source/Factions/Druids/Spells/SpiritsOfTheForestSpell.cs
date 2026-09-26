using System.Linq;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class SpiritsOfTheForestSpell : Spell
{
  public required int DismissAbilityId { get; init; }
  public required float ManaPerSecond { get; init; }
  public required float HealFractionPerSecond { get; init; }
  public required string CasterEffectPath { get; init; }
  public required string HealEffectPath { get; init; }

  public SpiritsOfTheForestSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (BuffSystem.GetBuffsOnUnit(caster).OfType<SpiritsOfTheForestBuff>().Any())
    {
      return;
    }

    BuffSystem.Add(new SpiritsOfTheForestBuff(caster)
    {
      Duration = float.MaxValue,
      Interval = 1,
      ActivateAbilityId = Id,
      DismissAbilityId = DismissAbilityId,
      Radius = caster.GetAbility(Id).GetAreaOfEffect_aare(0),
      ManaPerSecond = ManaPerSecond,
      HealFractionPerSecond = HealFractionPerSecond,
      CasterEffectPath = CasterEffectPath,
      HealEffectPath = HealEffectPath
    });
  }
}

public sealed class DismissSpiritsOfTheForestSpell : Spell
{
  public DismissSpiritsOfTheForestSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    foreach (var buff in BuffSystem.GetBuffsOnUnit(caster).OfType<SpiritsOfTheForestBuff>())
    {
      buff.Active = false;
    }
  }
}

public sealed class SpiritsOfTheForestBuff : TickingBuff
{
  private effect? _casterEffect;

  public required int ActivateAbilityId { get; init; }
  public required int DismissAbilityId { get; init; }
  public required float Radius { get; init; }
  public required float ManaPerSecond { get; init; }
  public required float HealFractionPerSecond { get; init; }
  public required string CasterEffectPath { get; init; }
  public required string HealEffectPath { get; init; }

  public SpiritsOfTheForestBuff(unit target) : base(target, target)
  {
  }

  public override void OnApply()
  {
    _casterEffect = effect.Create(CasterEffectPath, Target, "origin");
    SwapAbilities(ActivateAbilityId, DismissAbilityId);
  }

  public override void OnTick()
  {
    if (Target.Mana < ManaPerSecond)
    {
      Active = false;
      return;
    }

    Target.Mana -= ManaPerSecond;
    foreach (var ally in GlobalGroup.EnumUnitsInRange(Target.X, Target.Y, Radius))
    {
      if (ally == Target || !ally.Alive || !ally.IsAllyTo(Target.Owner) || ally.IsUnitType(unittype.Structure) ||
          ally.IsUnitType(unittype.Mechanical) || ally.Life >= ally.MaxLife)
      {
        continue;
      }

      ally.Life += ally.MaxLife * HealFractionPerSecond;
      EffectSystem.Add(effect.Create(HealEffectPath, ally, "origin"), 1);
    }
  }

  public override int OnDispel(unit dispeller, int dispelCount) => 0;

  public override void OnDeath(bool killingBlow)
  {
    Active = false;
    base.OnDeath(killingBlow);
  }

  public override void OnDispose()
  {
    _casterEffect?.Dispose();
    _casterEffect = null;
    if (Target.Alive)
    {
      SwapAbilities(DismissAbilityId, ActivateAbilityId);
    }

    base.OnDispose();
  }

  private void SwapAbilities(int removed, int added)
  {
    var caster = Target;
    timer.Create().Start(0, false, () =>
    {
      caster.RemoveAbility(removed);
      caster.AddAbility(added);
      @event.ExpiredTimer.Dispose();
    });
  }
}
