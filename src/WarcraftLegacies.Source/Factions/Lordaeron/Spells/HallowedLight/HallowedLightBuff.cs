using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;

public sealed class HallowedLightBuff : BoundBuff
{
  public int BuffId { get; init; }
  public int ArmorAbilityId { get; init; }
  public int ApplicatorAbilityId { get; init; }
  public string BuffEffect { get; init; }
  public string DebuffEffect { get; init; }

  private effect _fx;

  public HallowedLightBuff(unit caster, unit target)
    : base(caster, target)
  {
  }

  public override void OnApply()
  {
    Target.AddAbility(ArmorAbilityId);
    BindAura(ApplicatorAbilityId, BuffId);

    if (_fx != null)
    {
      Common.DestroyEffect(_fx);
      _fx = null;
    }

    var model = IsBeneficial ? BuffEffect : DebuffEffect;
    _fx = Common.AddSpecialEffectTarget(model, Target, "origin");

    base.OnApply();
  }

  public override void OnDispose()
  {
    if (_fx != null)
    {
      Common.DestroyEffect(_fx);
      _fx = null;
    }

    Target.RemoveAbility(ArmorAbilityId);

    base.OnDispose();
  }
}
