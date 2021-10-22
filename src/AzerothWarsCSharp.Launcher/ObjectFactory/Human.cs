using AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human;
using AzerothWarsCSharp.Launcher.ObjectFactory.Units;
using System.Drawing;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Human
  {
    public static void GenerateObjectData(ObjectDatabase objectDatabase)
    {
      //Militia
      var militiaFactory = new WorkerFactory(UnitType.Peasant_hpea)
      {
        TextName = "Deckhand",
        DamageBase = 11,
        DamageNumberOfDice = 1,
        DamageSidesPerDie = 2,
        HitPoints = 230,
        Flavour = "Basic worker unit that has taken up arms."
      };
      var militia = militiaFactory.Generate("zmil", objectDatabase);

      //Harvest
      var harvestfactory = new HarvestFactory()
      {
        Icon = @"GatherGold",
        TextName = "Gather",
        ButtonPosition = new Point(3, 1),
      };
      var harvest = harvestfactory.Generate("zhar", objectDatabase);

      //Repair
      var repairfactory = new RepairFactory()
      {
        Icon = @"RepairOn",
        TextName = "Repair",
        ButtonPosition = new Point(1, 1),
      };
      var repair = repairfactory.Generate("zrep", objectDatabase);

      //Call to Arms
      var calltoarmsfactory = new CallToArmsFactory()
      {
        Icon = @"CallToArms",
        TextName = "Call to Arms",
        ButtonPosition = new Point(1, 2),
        AlternateFormUnit = { militia }
      };
      var calltoarms = calltoarmsfactory.Generate("zcal", objectDatabase);

      //Peasant
      new WorkerFactory(UnitType.Peasant_hpea)
      {
        TextName = "Deckhand",
        DamageBase = 4,
        DamageNumberOfDice = 1,
        DamageSidesPerDie = 2,
        HitPoints = 230,
        AbilitiesNormal = new Ability[] { harvest, calltoarms, repair },
        Flavour = "Basic worker unit.",
      }.Generate("zpea", objectDatabase);
    }
  }
}