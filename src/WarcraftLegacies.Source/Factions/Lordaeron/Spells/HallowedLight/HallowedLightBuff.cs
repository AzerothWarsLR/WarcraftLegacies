using System;
using System.Collections.Generic;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;

public sealed class HallowedLightBuff : BoundBuff
{
  public int BuffId { get; init; }
  public int ArmorAbilityId { get; init; }
  public int ApplicatorAbilityId { get; init; }

  private static readonly Dictionary<unit, effect> ActiveFx = new();
  private effect fx;

  public HallowedLightBuff(unit caster, unit target)
    : base(caster, target)
  {
    EffectAttachmentPoint = "origin";
  }

  public override void OnApply()
  {
    Target.AddAbility(ArmorAbilityId);
    BindAura(ApplicatorAbilityId, BuffId);

    if (ActiveFx.TryGetValue(Target, out var existing) && existing != null)
    {
      DestroyEffect(existing);
    }

    fx = AddSpecialEffectTarget(EffectString, Target, EffectAttachmentPoint);
    ActiveFx[Target] = fx;

    base.OnApply();
  }

  public override void OnDispose()
  {
    Console.WriteLine("HALLOWED LIGHT DISPOSE " + GetUnitName(Target));

    if (fx != null)
    {
      DestroyEffect(fx);
    }

    Target.RemoveAbility(ArmorAbilityId);

    base.OnDispose();
  }
}
