using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;

public sealed class HallowedLightBuff : BoundBuff
{
  public int BuffId { get; init; }
  public int ArmorAbilityId { get; init; }

  public HallowedLightBuff(unit caster, unit target)
    : base(caster, target)
  {
    EffectAttachmentPoint = "origin";
  }

  public override void OnApply()
  {
    Target.AddAbility(ArmorAbilityId);
    BindAura(ABILITY_A00C_HALLOWED_LIGHT_BUFF_APPLICATOR, BuffId);
    base.OnApply();
  }

  public override void OnDispose()
  {
    Target.RemoveAbility(ArmorAbilityId);
    base.OnDispose();
  }
}
