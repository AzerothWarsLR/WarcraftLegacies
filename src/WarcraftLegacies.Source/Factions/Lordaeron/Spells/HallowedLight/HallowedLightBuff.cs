using System.Collections.Generic;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;

public sealed class HallowedLightBuff : BoundBuff
{
  public int BuffId { get; init; }
  public int ArmorAbilityId { get; init; }
  public int ApplicatorAbilityId { get; init; }

  private static readonly Dictionary<int, effect> ActiveFx = new();
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

    var id = GetHandleId(Target);
    if (ActiveFx.TryGetValue(id, out var existing) && existing != null)
    {
      DestroyEffect(existing);
    }

    fx = AddSpecialEffectTarget(EffectString, Target, EffectAttachmentPoint);
    ActiveFx[id] = fx;

    base.OnApply();
  }

  public override void OnDispose()
  {
    var id = GetHandleId(Target);
    if (fx != null)
    {
      DestroyEffect(fx);
    }

    ActiveFx.Remove(id);

    Target.RemoveAbility(ArmorAbilityId);
    base.OnDispose();
  }
}
