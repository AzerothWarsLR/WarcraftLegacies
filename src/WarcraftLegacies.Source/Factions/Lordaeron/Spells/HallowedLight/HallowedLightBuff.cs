using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;

public sealed class HallowedLightBuff : BoundBuff
{
  public int BuffId { get; init; }
  public int ArmorAbilityId { get; init; }
  private effect fx;

  public HallowedLightBuff(unit caster, unit target)
    : base(caster, target)
  {
    EffectAttachmentPoint = "origin";
  }

  public override void OnApply()
  {
    Target.AddAbility(ArmorAbilityId);
    BindAura(ArmorAbilityId, BuffId);
    fx = AddSpecialEffectTarget(EffectString, Target, EffectAttachmentPoint);
    base.OnApply();
  }

  public override void OnDispose()
  {
    if (fx != null)
    {
      DestroyEffect(fx);
    }

    Target.RemoveAbility(ArmorAbilityId);
    base.OnDispose();
  }
}
