using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Buffs;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Mechanics.TwilightHammer
{
  public sealed class CorruptWorkerPeriodicAction : IPeriodicAction
  {
    private readonly List<unit> _corruptedWorkers;
    private readonly player _powerHolder;

    public CorruptWorkerPeriodicAction(player powerHolder, Continent continent, List<unit> corruptedWorkers)
    {
      _powerHolder = powerHolder;
      _corruptedWorkers = corruptedWorkers;
      Continent = continent;
    }

    /// <summary>
    /// The <see cref="Continent"/> in which to corrupt workers.
    /// </summary>
    public Continent Continent { get; set; }

    /// <inheritdoc />
    public bool Active { get; set; } = true;

    /// <summary>
    /// Adds the <see cref="CorruptWorkerBuff"/> to one uncorrupted worker in <see cref="Continent"/>.
    /// </summary>
    public void Action()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Continent.Area).EmptyToList())
      {
        if (UnitAlive(unit) && IsUnitType(unit, UNIT_TYPE_PEON) && !IsUnitType(unit, UNIT_TYPE_SUMMONED) &&
            !IsUnitType(unit, UNIT_TYPE_MECHANICAL) && !typeof(CorruptWorkerBuff).ExistsAsBuffOnUnit(unit) &&
            IsUnitEnemy(unit, _powerHolder))
        {
          var buff = new CorruptWorkerBuff(unit, unit)
          {
            CastingPlayer = _powerHolder,
            BonusIncome = 1
          };
          BuffSystem.Add(buff, StackBehaviour.Stack);
          _corruptedWorkers.Add(unit);
          return;
        }
      }
    }
  }
}