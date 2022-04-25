using AzerothWarsCSharp.MacroTools.Libraries;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Buffs
{
  public sealed class ResurrectionAuraTarget : AuraBoundBuff
  {
    private readonly float _resurrectionChance;
    
    public override void OnDeath(bool killingBlow)
    {
      if (GetRandomReal(0, 1) < _resurrectionChance)
      {
        GeneralHelpers.UnitResurrect(Target);
      }
      base.OnDeath(killingBlow);
    }
    
    public ResurrectionAuraTarget(unit caster, unit target, float resurrectionChance) : base(caster, target)
    {
      Bind(FourCC("Hres"), FourCC("Ares"));
      EffectString = @"Abilities\Spells\Other\GeneralAuraTarget\GeneralAuraTarget.mdl";
      _resurrectionChance = resurrectionChance;
    }
  }
}