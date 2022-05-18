using WCSharp.Buffs;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Mechanics.Scourge.Plague
{
  /// <summary>
  /// Causes the buff holder to periodically spawn a Zombie unit nearby.
  /// </summary>
  public sealed class PlagueCauldronBuff : TickingBuff
  {
    public int ZombieUnitTypeId { get; init; }

    public override void OnDispose()
    {
      RemoveUnit(Target);
    }
    
    public override void OnApply()
    {
      var tempLocation = Location(GetUnitX(Caster), GetUnitY(Caster));
      EnumDestructablesInCircleBJ(50, tempLocation, () => RemoveDestructable(GetEnumDestructable()));
      RemoveLocation(tempLocation);
    }
    
    public PlagueCauldronBuff(unit caster, unit target) : base(caster, target)
    {
      Duration = 3000;
      Interval = 30f;
    }

    public override void OnTick()
    {
      CreateUnit(GetOwningPlayer(Target), ZombieUnitTypeId, GetUnitX(Target), GetUnitY(Target), 0);
    }
  }
}