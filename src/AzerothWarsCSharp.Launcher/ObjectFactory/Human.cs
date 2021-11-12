using AzerothWarsCSharp.Launcher.ObjectFactory.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human;
using AzerothWarsCSharp.Launcher.ObjectFactory.Units;
using System.Drawing;
using War3Api.Object;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Human
  {
    public static void GenerateObjectData(ObjectDatabase objectDatabase)
    {
      //Militia
      var militiaFactory = new WorkerFactory(UnitType.Peasant_hpea)
      {
        Name = "Deckhand",
        DamageBase = 11,
        DamageNumberOfDice1 = 1,
        DamageSidesPerDie1 = 2,
        HitPoints = 230,
        Flavour = "Basic worker unit that has taken up arms.",
        Icon = "Militia"
      };
      var militia = militiaFactory.Generate("zmil", objectDatabase);

      //Harvest
      var harvestfactory = new HarvestFactory()
      {
        Icon = @"GatherGold",
        TextName = "Gather",
        ButtonPosition = new Point(3, 1),
        Flavor = "Mines gold from gold mines and harvests lumber from trees."
      };
      var harvest = harvestfactory.Generate("zhar", objectDatabase);

      //Repair
      var repairfactory = new RepairFactory()
      {
        Icon = @"Repair",
        TextName = "Repair",
        ButtonPosition = new Point(1, 1),
        Flavor = "Repairs mechanical units and structures at the cost of resources."
      };
      var repair = repairfactory.Generate("zrep", objectDatabase);

      //Call to Arms
      var calltoarmsfactory = new CallToArmsFactory()
      {
        Icon = @"CallToArms",
        TextName = "Call to Arms",
        ButtonPosition = new Point(1, 2),
        AlternateFormUnit = { militia },
        Flavor = "Return to a nearby compatible structure to turn into a different unit."
      };
      var calltoarms = calltoarmsfactory.Generate("zcal", objectDatabase);

      //Peasant
      new WorkerFactory(UnitType.Peasant_hpea)
      {
        Name = "Deckhand",
        DamageBase = 4,
        DamageNumberOfDice1 = 1,
        DamageSidesPerDie1 = 2,
        HitPoints = 230,
        AbilitiesNormal = new Ability[] { harvest, calltoarms, repair },
        Flavour = "Basic worker unit.",
        Icon = "Peasant"
      }.Generate("zpea", objectDatabase);

      //Defend
      var defendfactory = new DefendFactory()
      {
        Icon = @"Defend",
        TextName = "Defend",
        ButtonPosition = new Point(0, 2),
        Flavor = "Increases damage dealt to enemies with a particular armor type."
      };
      var defend = defendfactory.Generate("zdef", objectDatabase);

      //Footman
      new UnitFactory(UnitType.Footman)
      {
        Name = "Footman",
        DamageBase = 11,
        DamageNumberOfDice1 = 1,
        DamageSidesPerDie1 = 2,
        HitPoints = 420,
        AbilitiesNormal = new Ability[] { defend },
        Flavour = "Versatile foot soldier.",
        Armor = 2,
        Model = @"units\human\Footman\Footman",
        Icon = "Footman",
      }.Generate("zfoo", objectDatabase);

      //Sundering Blades
      var sunderingbladesfactory = new SunderingBladesFactory()
      {
        Icon = @"SunderingBlades",
        TextName = "Sundering Blades",
        ButtonPosition = new Point(0, 2),
        Flavor = "Increases damage dealt to enemies with a particular armor type.",
        DamageBonusFlat = { 5 },
        DamageBonusPercent = { 0.1f },
        DefenseTypeAffected = { DefenseTypeInt.Divine }
      };
      var sunderingblades = sunderingbladesfactory.Generate("zsun", objectDatabase);

      //Knight
      new UnitFactory(UnitType.Knight)
      {
        Name = "Knight",
        DamageBase = 28,
        DamageNumberOfDice1 = 2,
        DamageSidesPerDie1 = 5,
        HitPoints = 885,
        AbilitiesNormal = new Ability[] { sunderingblades },
        Flavour = "Powerful mounted warrior.",
        Armor = 5,
        Model = @"units\human\Knight\Knight",
        Icon = "Knight",
      }.Generate("zkni", objectDatabase);

      //Holy Light
      var holyLightFactory = new HolyLightFactory()
      {
        AmountHealed = { 50, 100, 200, 250 },
        CastRange = { 300 },
        Levels = 4,
        Icon = @"HolyBolt",
        TextName = "Holy Light",
        ButtonPosition = new Point(0, 2),
        IsHeroAbility = false
      };
      var holyLight = holyLightFactory.Generate("zhol", objectDatabase);

      //Arthas
      new HeroFactory(UnitType.Paladin_Hpal)
      {
        AbilitiesHero = new Ability[] { holyLight },
        Strength = 100,
        Agility = 10,
        Intelligence = 5,
        ProperName = "Arthas",
        Name = "Prince",
        Model = @"units\human\Arthas\Arthas",
        Icon = "Arthas",
      }.Generate("Zart", objectDatabase);

      //Flare
      var flarefactory = new FlareFactory()
      {
        Icon = "Flare",
        TextName = "Flare",
        ButtonPosition = new Point(0, 2),
        Flavor = "Reveals a target area.",
      };
      var flare = flarefactory.Generate("zfla", objectDatabase);

      //Fragmentation Shards
      var fragmentationshardsfactory = new FragShardsFactory()
      {
        Icon = "FragmentationBombs",
        TextName = "Fragmentation Shards",
        ButtonPosition = new Point(1, 2),
        Flavor = "Causes this unit to deal bonus splash damage to Unarmored and Medium armor units.",
      };
      var fragmentationshards = fragmentationshardsfactory.Generate("zfra", objectDatabase);

      //Mortar Team
      new UnitFactory(UnitType.Mortarteam)
      {
        Name = "Mortar Team",
        DamageBase = 28,
        DamageNumberOfDice1 = 2,
        DamageSidesPerDie1 = 5,
        HitPoints = 885,
        AbilitiesNormal = new Ability[] { flare, fragmentationshards },
        Flavour = "Long-range siege weaponry. Exceptional damage versus buildings, but slow and vulnerable.",
        Armor = 5,
        Model = @"units\human\MortarTeam\MortarTeam",
        Icon = "MortarTeam",
      }.Generate("zmor", objectDatabase);

      //True Sight
      var truesightfactory = new TrueSightFactory()
      {
        Icon = "FlakCannons",
        TextName = "Flak Cannons",
        ButtonPosition = new Point(0, 2),
        Flavor = "Reveals invisible units in a radius around this unit.",
      };
      var truesight = truesightfactory.Generate("ztru", objectDatabase);

      //Flak cannons
      var flakcannonsfactory = new FlakCannonFactory()
      {
        Icon = "FlyingMachineTrueSight",
        TextName = "Flying Machine",
        ButtonPosition = new Point(2, 2),
        Flavor = "Causes this unit to deal bonus splash damage to attacked units.",
      };
      var flakcannons = flakcannonsfactory.Generate("zflc", objectDatabase);

      //FlyingMachineBombs
      var bombsfactory = new DummyPassiveFactory()
      {
        Icon = "HumanArtilleryUpOne",
        TextName = "Flying Machine Bombs",
        ButtonPosition = new Point(1, 2),
        Flavor = "Allows this unit to attack land units.",
      };
      var flyingmachinebombs = bombsfactory.Generate("zbom", objectDatabase);

      //Flying Machine
      new UnitFactory(UnitType.Flyingmachine)
      {
        Name = "Flying Machine",
        DamageBase = 28,
        DamageNumberOfDice1 = 2,
        DamageSidesPerDie1 = 5,
        HitPoints = 885,
        AbilitiesNormal = new Ability[] { flakcannons, truesight, flyingmachinebombs },
        Flavour = "Fast moving flying machine. Excellent at scouting, and effective against air units.",
        Armor = 5,
        Model = @"units\human\Gyrocopter\Gyrocopter",
        Icon = "Gyrocopter",
      }.Generate("zfly", objectDatabase);

      //Gryphon Rider
      new UnitFactory(UnitType.Gryphonrider)
      {
        Name = "Gryphon Rider",
        DamageBase = 28,
        DamageNumberOfDice1 = 2,
        DamageSidesPerDie1 = 5,
        HitPoints = 885,
        AbilitiesNormal = System.Array.Empty<Ability>(),
        Flavour = "Powerful flying creature, mounted by a Dwarven hammer-thrower.",
        Armor = 5,
        Model = @"units\human\GryphonRider\GryphonRider",
        Icon = "GryphonRider"
      }.Generate("zgry", objectDatabase);

      //Heal
      var healfactory = new HealFactory()
      {
        Icon = "Heal",
        TextName = "Heal",
        ButtonPosition = new Point(0, 2),
        Flavor = "Heals a target unit.",
      };
      healfactory.Buffs[0] = new[] { healfactory.GenerateBuff("bhea", objectDatabase) };
      var heal = healfactory.Generate("zhea", objectDatabase);

      //Dispel Magic
      var dispelmagicfactory = new DispelMagicFactory()
      {
        Icon = "DispelMagic",
        TextName = "Dispel Magic",
        ButtonPosition = new Point(1, 2),
        Flavor = "Removes all buffs from units in a target area and deals damage to summoned units.",
      };
      var dispelmagic = dispelmagicfactory.Generate("zdis", objectDatabase);

      //Inner Fire
      var innerfirefactory = new InnerFireFactory()
      {
        Icon = "InnerFire",
        TextName = "Inner Fire",
        ButtonPosition = new Point(2, 2),
        Flavor = "Increases a target unit's damage, armor, and hit point regeneration.",
      };
      innerfirefactory.Buffs[0] = new[] { healfactory.GenerateBuff("binn", objectDatabase) };
      var innerfire = innerfirefactory.Generate("zinn", objectDatabase);

      //Priest
      new UnitFactory(UnitType.Priest)
      {
        Name = "Priest",
        DamageBase = 28,
        DamageNumberOfDice1 = 2,
        DamageSidesPerDie1 = 5,
        HitPoints = 885,
        AbilitiesNormal = new Ability[] { heal, dispelmagic, innerfire },
        Flavour = "Supporting spellcaster.",
        Armor = 5,
        Model = @"units\human\Priest\Priest",
        Icon = "Priest",
      }.Generate("zpri", objectDatabase);

      //Slow
      var slowfactory = new SlowFactory()
      {
        Icon = "Slow",
        TextName = "Slow",
        ButtonPosition = new Point(0, 2),
        Flavor = "Slows a target unit.",
      };
      slowfactory.Buffs[0] = new[] { slowfactory.GenerateBuff("bslo", objectDatabase) };
      var slow = slowfactory.Generate("zslo", objectDatabase);

      //Sorceress
      new UnitFactory(UnitType.Sorceress)
      {
        Name = "Sorceress",
        DamageBase = 28,
        DamageNumberOfDice1 = 2,
        DamageSidesPerDie1 = 5,
        HitPoints = 885,
        AbilitiesNormal = new Ability[] { slow },
        Flavour = "Versatile spellcaster.",
        Armor = 5,
        Model = @"units\human\Sorceress\Sorceress",
        Icon = "Sorceress",
      }.Generate("zsor", objectDatabase);
    }
  }
}