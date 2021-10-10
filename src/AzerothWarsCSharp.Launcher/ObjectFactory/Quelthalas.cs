using AzerothWarsCSharp.Launcher.ObjectFactory.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.Units;
using System.Drawing;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Quelthalas
  {
    public static void Setup()
    {
      //Immolation
      var aerialshacklesfactory = new AerialShacklesFactory()
      {
        DurationUnit = { 40 },
        CastRange = { 550 },
        Levels = 1,
        ArtIcon = @"ReplaceableTextures\CommandButtons\BTNMagicLariet.blp",
        TextName = "Aerial Shackles",
        ButtonPosition = new Point(0, 0),
        DamagePerSecond = { 8 },
        DurationHero = { 4 },
        Cooldown = { 0 }
      };
      var aerialshackles = aerialshacklesfactory.Generate("shac");

      //Dragonhawk Rider
      new UnitFactory(UnitType.Dragonhawk)
      {
        TextName = "Dragonhawk Rider",
        ArtIconGameInterface = @"ReplaceableTextures\CommandButtons\BTNDragonHawk.blp",
        AbilitiesNormal = new Ability[] { aerialshackles },
        DamageBase = 10,
        DamageNumberOfDice = 2,
        DamageSidesPerDie = 6,
        HitPoints = 600,
        Flavour = "Swift dragonhawk mounted by an elven warrior.",
      }.Generate("drag");
    }
  }
}