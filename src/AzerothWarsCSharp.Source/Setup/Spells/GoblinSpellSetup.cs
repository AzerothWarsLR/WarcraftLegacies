using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.MacroTools.UnitEffects;
using AzerothWarsCSharp.Source.Mechanics.Goblins;

namespace AzerothWarsCSharp.Source.Setup.Spells
{
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
      SpellSystem.Register(new Trader(Constants.UNIT_NZEP_TRADING_ZEPPELIN_WARSONG, 0, 60, zeppelinTradeTargets));

      var traderTradeTargets = new[]
      {
        Regions.Trader1.Center,
        Regions.Trader2.Center,
        Regions.Trader3.Center
      };
      SpellSystem.Register(new Trader(Constants.UNIT_O04S_TRADER_GOBLIN, 40, 0, traderTradeTargets));

      var nuclearLaunch = new NuclearLaunch(Constants.ABILITY_A0RH_INTERCONTINENTAL_BOMBARDMENT_GOBLIN_ARTILLERY,
        @"war3mapImported/NuclearLaunchDetected.mp3", Constants.UNIT_H06L_DUMMY_NUKE_WARNING,
        Constants.UNIT_H050_DUMMY_NUKE_LEFTOVER, 25);
      SpellSystem.Register(nuclearLaunch);

      var artillerySpeedMult =
        new AnimationSpeedMultiplier(Constants.UNIT_H011_INTERCONTINENTAL_ARTILLERY_GOBLIN, 0.4f);
      SpellSystem.Register(artillerySpeedMult);

      SpellSystem.Register(new OilUser(Constants.UNIT_H011_INTERCONTINENTAL_ARTILLERY_GOBLIN));
      SpellSystem.Register(new OilUser(FourCC("Ntin")));
      SpellSystem.Register(new OilUser(Constants.UNIT_N062_SHREDDER_GOBLIN));
      SpellSystem.Register(new OilUser(Constants.UNIT_H08Z_ASSAULT_TANK_GOBLIN));
      SpellSystem.Register(new OilUser(Constants.UNIT_H091_WAR_ZEPPELIN_GOBLIN));
      SpellSystem.Register(new OilProducer(Constants.UNIT_O04R_OIL_PLATFORM_GOBLIN, 11.5f));
      SpellSystem.Register(new OilUser(Constants.UNIT_H04Z_KEZAN_OIL_SUPPLY_GOBLIN));
      SpellSystem.Register(new OilRigConstructor(Constants.UNIT_N0AQ_OIL_RIG_WARSONG, new[]
      {
        Regions.OilRig1.Center, 
        Regions.OilRig2.Center,
        Regions.OilRig3.Center,
        Regions.OilRig4.Center,
        Regions.OilRig5.Center,
        Regions.OilRig6.Center
      }));
    }
  }
}