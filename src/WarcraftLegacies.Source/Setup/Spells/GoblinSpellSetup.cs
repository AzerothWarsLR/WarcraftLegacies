using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.FactionMechanics.Goblins;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class GoblinSpellSetup
{
  public static void Setup()
  {
    var zeppelinTradeTargets = new[]
    {
      Regions.Trade1.Center,
      Regions.Trade2.Center,
      Regions.Trade3.Center,
      Regions.Trade4.Center
    };
    PassiveAbilityManager.Register(new Trader(UNIT_NZEP_TRADING_ZEPPELIN_WARSONG, 15, zeppelinTradeTargets));

    var traderTradeTargets = new[]
    {
      Regions.Trader1.Center,
      Regions.Trader2.Center,
      Regions.Trader3.Center
    };
    PassiveAbilityManager.Register(new Trader(UNIT_O04S_TRADER_GOBLIN, 25, traderTradeTargets));

    SpellSystem.Register(new NuclearLaunch(ABILITY_A0RH_INTERCONTINENTAL_BOMBARDMENT_GOBLIN_ARTILLERY)
    {
      CastTime = 25,
      NuclearWarningUnitTypeId = UNIT_H06L_DUMMY_NUKE_WARNING,
      WarningSoundPath = "war3mapImported/NuclearLaunchDetected.mp3",
      DummyNukeLeftOverId = UNIT_H050_DUMMY_NUKE_LEFTOVER
    });

    PassiveAbilityManager.Register(new AnimationSpeedMultiplier(UNIT_H011_INTERCONTINENTAL_ARTILLERY_GOBLIN_TOWER, 0.4f));

    PassiveAbilityManager.Register(new OilUser(UNIT_H011_INTERCONTINENTAL_ARTILLERY_GOBLIN_TOWER));
    PassiveAbilityManager.Register(new OilUser(UNIT_NTIN_CHIEF_ENGINEER_GOBLIN));
    PassiveAbilityManager.Register(new OilUser(UNIT_N062_SHREDDER_GOBLIN));
    PassiveAbilityManager.Register(new OilUser(UNIT_H08Z_ASSAULT_TANK_GOBLIN));
    PassiveAbilityManager.Register(new OilUser(UNIT_H09H_WALKER_GOBLIN));
    PassiveAbilityManager.Register(new OilUser(UNIT_O01M_ENGINEER_S_GUILD_GOBLIN_SPECIALIST));
    PassiveAbilityManager.Register(new OilUser(UNIT_NTIN_CHIEF_ENGINEER_GOBLIN));
    PassiveAbilityManager.Register(new OilUser(UNIT_H09I_PERSONAL_TANK_GOBLIN));
    PassiveAbilityManager.Register(new OilProducer(UNIT_H04Z_KEZAN_OIL_SUPPLY_GOBLIN_OTHER)
    {
      OilProducedPerSecond = 20
    });
    PassiveAbilityManager.Register(new OilHarvester(UNIT_O04R_OIL_RIG_GOBLIN_OTHER)
    {
      OilHarvestedPerSecond = 5,
      Radius = 400
    });

    SpellSystem.Register(new PingOilDeposits(ABILITY_A0PJ_LOCATE_OIL_GOBLIN_OIL_RIG_CONSTRUCTOR)
    {
      Duration = 10
    });

    var overclock = new CooldownReset(ABILITY_A0RA_OVERCLOCK_GAZLOWEE);
    SpellSystem.Register(overclock);
  }
}
