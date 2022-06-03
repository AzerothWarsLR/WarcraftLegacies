using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Buffs;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.TwilightHammer
{
  public sealed class CorruptWorkerPeriodicAction : IPeriodicAction
  {
    private readonly player _powerHolder;

    public CorruptWorkerPeriodicAction(player powerHolder, Continent continent)
    {
      _powerHolder = powerHolder;
      Continent = continent;
    }

    public Continent Continent { get; set; }
    public bool Active { get; set; } = true;

    public void Action()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Continent.Area).EmptyToList())
      {
        if (!UnitAlive(unit) || !IsUnitType(unit, UNIT_TYPE_PEON) || IsUnitType(unit, UNIT_TYPE_SUMMONED) ||
            IsUnitType(unit, UNIT_TYPE_MECHANICAL))
        {
          continue;
        }

        var buff = new CorruptWorkerBuff(unit, unit)
        {
          CastingPlayer = _powerHolder,
          BonusIncome = 1
        };
        BuffSystem.Add(buff, StackBehaviour.Stack);
      }
    }
  }
}