using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class Worker : GenericUnit
  {
    public Worker(UnitType baseType, string newRawCode) : base(baseType, newRawCode)
    {
      _unit.StatsUnitClassification = new UnitClassification[] { UnitClassification.Peon };
    }
  }
}