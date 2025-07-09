using MacroTools.DummyCasters;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.WhimOfTheWinds
{
  public sealed class WhimOfTheWindsBuff : Buff
  {
    private readonly int _dummyAbilityId;
    private readonly int _dummyAbilityOrderId;
    
    public WhimOfTheWindsBuff(unit caster, unit target, int dummyAbilityId, int dummyAbilityOrderId) : base(caster, target)
    {
      _dummyAbilityId = dummyAbilityId;
      _dummyAbilityOrderId = dummyAbilityOrderId;
      IsBeneficial = true;
    }

    public override void OnApply()
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(Caster, _dummyAbilityId, _dummyAbilityOrderId, 1, Target, DummyCastOriginType.Caster);
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
}