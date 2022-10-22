using AzerothWarsCSharp.MacroTools.Libraries;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge.Plague
{
  /// <summary>
  ///   Causes the buff holder to periodically spawn a Zombie unit nearby.
  /// </summary>
  public sealed class PlagueCauldronBuff : TickingBuff
  {
    public PlagueCauldronBuff(unit caster, unit target) : base(caster, target)
    {
      Duration = 3000;
      Interval = 30f;
    }

    public int ZombieUnitTypeId { get; init; }

    public override void OnDispose()
    {
      RemoveUnit(Target);
    }

    public override void OnApply()
    {
      GeneralHelpers.EnumDestructablesInCircle(50, new Point(GetUnitX(Caster), GetUnitY(Caster)),
        () => RemoveDestructable(GetEnumDestructable()));
    }

    public override void OnTick()
    {
      CreateUnit(GetOwningPlayer(Target), ZombieUnitTypeId, GetUnitX(Target), GetUnitY(Target), 0);
    }
  }
}