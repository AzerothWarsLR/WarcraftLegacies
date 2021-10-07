using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class WorkerFactory : UnitFactory
  {
    public WorkerFactory(UnitType baseType, string newRawCode) : base(baseType, newRawCode)
    {
      _unit.StatsUnitClassification = new UnitClassification[] { UnitClassification.Peon };
    }
  }
}