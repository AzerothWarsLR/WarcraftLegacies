using MacroTools;
using MacroTools.Wrappers;
using System;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Fel_Horde
{

 
  internal class FelHordeJuggernautDeath
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      var powerGenerator1 = preplacedUnitSystem.GetUnit(Constants.UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5511.9f, -29688.2f));
      var powerGenerator2 = preplacedUnitSystem.GetUnit(Constants.UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5513.1f, -30467.4f));
      var inferJuggernaut1 = preplacedUnitSystem.GetUnit(Constants.UNIT_N066_INFERNAL_JUGGERNAUT_TEAL_TOWER, new Point(4356.6f, -29397.8f));
      var inferJuggernaut2 = preplacedUnitSystem.GetUnit(Constants.UNIT_N066_INFERNAL_JUGGERNAUT_TEAL_TOWER, new Point(4245.3f, -29863.1f));
      var inferJuggernaut3 = preplacedUnitSystem.GetUnit(Constants.UNIT_N066_INFERNAL_JUGGERNAUT_TEAL_TOWER, new Point(4537.8f, -30988.1f));
      var inferJuggernaut4 = preplacedUnitSystem.GetUnit(Constants.UNIT_N066_INFERNAL_JUGGERNAUT_TEAL_TOWER, new Point(4631.4f, -31433.0f));

      var deathTrigger1 = new TriggerWrapper();
      deathTrigger1.RegisterUnitEvent(powerGenerator1, EVENT_UNIT_DEATH);
      deathTrigger1.AddAction(() =>
      {
        KillUnit(inferJuggernaut1);
        KillUnit(inferJuggernaut2);
      });

      var deathTrigger2 = new TriggerWrapper();
      deathTrigger2.RegisterUnitEvent(powerGenerator2, EVENT_UNIT_DEATH);
      deathTrigger2.AddAction(() =>
      {
        KillUnit(inferJuggernaut3);
        KillUnit(inferJuggernaut4);
      });
    }
  }
}
