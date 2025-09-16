using MacroTools.DummyCasters;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.WarpedMalediction;

public sealed class WarpedMaledictionBuff : Buff
{
  private readonly int _dummyAbilityId;
  private readonly int _dummyAbilityOrderId;

  public WarpedMaledictionBuff(unit caster, unit target, int dummyAbilityId, int dummyAbilityOrderId) : base(caster, target)
  {
    _dummyAbilityId = dummyAbilityId;
    _dummyAbilityOrderId = dummyAbilityOrderId;
    IsBeneficial = false;
  }

  public override void OnApply()
  {
    DummyCaster
      .Cast(Caster, _dummyAbilityId, _dummyAbilityOrderId, 1, Target);
  }

  public override void OnDispose()
  {
  }

  public override void Apply()
  {
    OnApply();
  }

  public override void Action()
  {
  }

  public override void Dispose()
  {
    OnDispose();
  }
}
