using War3Api;
using WCSharp.Buffs;

namespace MacroTools.Spells.ExactJustice
{
  public sealed class ExactJusticeAura : Aura<ExactJusticeBuff>
  {
    public ExactJusticeAura(Common.unit caster) : base(caster)
    {
    }

    protected override ExactJusticeBuff CreateAuraBuff(Common.unit unit)
    {
      throw new System.NotImplementedException();
    }

    protected override bool UnitFilter(Common.unit unit)
    {
      throw new System.NotImplementedException();
    }
  }
}