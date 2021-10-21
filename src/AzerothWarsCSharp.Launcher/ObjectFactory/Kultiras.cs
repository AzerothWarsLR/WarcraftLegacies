using AzerothWarsCSharp.Launcher.ObjectFactory.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.Units;
using System.Drawing;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Kultiras
  {
    public static void GenerateObjectData(ObjectDatabase objectDatabase)
    {
      ////Sea Elemental
      //var seaElemental = new UnitFactory(UnitType.Seaelemental)
      //{
      //  TextName = "Sea Elemental",
      //  ArtIconGameInterface = "SeaElemental",
      //  AbilitiesNormal = System.Array.Empty<Ability>(),
      //  DamageBase = 10,
      //  DamageNumberOfDice = 2,
      //  DamageSidesPerDie = 6,
      //  HitPoints = 600,
      //  Flavour = "Avatar of the sea's primordial force.",
      //}.Generate("ksea", objectDatabase);

      ////Summon Sea Elemental
      //var summonSeaElemental = new SummonWaterElementalFactory()
      //{
      //  Levels = 1,
      //  SummonedUnit = new Unit[] { seaElemental },
      //  SummonCount = new int[] { 1 },
      //  Icon = seaElemental.ArtIconGameInterface,
      //  Duration = new int[] { 40 },
      //}.Generate("asea", objectDatabase);

      ////Tidesage
      //new UnitFactory(UnitType.Priest)
      //{
      //  TextName = "Tidepriest",
      //  Flavour = "Spellcaster empowered with mystical control over the tides.",
      //  AbilitiesNormal = new Ability[] { summonSeaElemental },
      //  DamageBase = 4,
      //  DamageNumberOfDice = 2,
      //  DamageSidesPerDie = 7,
      //  HitPoints = 600,
      //}.Generate("ktid", objectDatabase);

      ////Blacksmith
      //var blacksmith = new BuildingFactory(UnitType.Blacksmith)
      //{
      //  ButtonPosition = new Point(2, 0),
      //  ScalingValue = 0.85F,
      //  HitPoints = 200,
      //  UnitsTrained = System.Array.Empty<Unit>(),
      //  ResearchesAvailable = System.Array.Empty<Upgrade>(),
      //  Flavour = "Where the weapons and armor of Kul'tiras are forged.",
      //  AbilitiesNormal = System.Array.Empty<Ability>()
      //}.Generate("kbla", objectDatabase);

      ////Scout Tower
      //var scoutTowerFactory = new BuildingFactory(UnitType.Scouttower)
      //{
      //  TextName = "Scout Tower",
      //  HitPoints = 300,
      //  ArtModelFile = @"buildings\human\HumanTower\HumanTower"
      //};
      //var scoutTower = scoutTowerFactory.Generate("ksco", objectDatabase);

      ////Guard Tower
      //var guardTowerFactory = new BuildingFactory(UnitType.Scouttower)
      //{
      //  TextName = "Guard Tower",
      //  HitPoints = 500,
      //  Parent = scoutTowerFactory,
      //  RequiredAnimationNames = new string[] { "upgrade", "first" }
      //};
      //var guardTower = guardTowerFactory.Generate("kgua", objectDatabase);

      ////Cannon Tower
      //var cannonTowerFactory = new BuildingFactory(UnitType.Scouttower)
      //{
      //  TextName = "Cannon Tower",
      //  HitPoints = 600,
      //  Parent = scoutTowerFactory,
      //  RequiredAnimationNames = new string[] { "upgrade", "second" }
      //};
      //var cannonTower = cannonTowerFactory.Generate("kcan", objectDatabase);

      ////Evasion
      //var evasionFactory = new EvasionFactory()
      //{
      //  ChanceToEvade = { 10F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F },
      //  Levels = 10,
      //  Icon = "Evasion",
      //  TextName = "EvasionAAAAA",
      //  ButtonPosition = new Point(2, 2),
      //  IsHeroAbility = true
      //};
      //var evasion = evasionFactory.Generate("Greb", objectDatabase);

      //Immolation
      var immolationFactory = new ImmolationFactory()
      {
        DamagePerSecond = { 10F, 20F, 30F, 40F },
        Levels = 4,
        Icon = "ImmolationOn",
        TextName = "Immolation",
        ButtonPosition = new Point(1, 2),
        IsHeroAbility = true,
        ManaCost = { 5 },
        Cooldown = { 0 },
        Flavor = "Engulfs the caster in flames, causing damage to nearby enemy land units. " +
          "|nDrains mana until deactivated."
      };
      var immolation = immolationFactory.Generate("imm1", objectDatabase);

      //Mana Burn
      var manaburnfactory = new ManaBurnFactory()
      {
        MaxManaDrained = { 50, 100, 200, 250 },
        CastRange = { 300 },
        Levels = 4,
        Icon = @"ManaBurn",
        TextName = "Mana Burn",
        ButtonPosition = new Point(0, 2),
        IsHeroAbility = true
      };
      var manaburn = manaburnfactory.Generate("mbur", objectDatabase);

      ////Metamorphosis
      //var metamorphosisFactory = new MetamorphosisFactory()
      //{
      //  Levels = 3,
      //  Icon = @"Metamorphosis",
      //  TextName = "Metamorphosis",
      //  ButtonPosition = new Point(3, 2),
      //  BonusHitPoints = { 200, 100, 6000 },
      //  AlternateForm = { scoutTower, cannonTower, guardTower },
      //  NormalForm = { blacksmith, blacksmith, blacksmith },
      //  MorphFlags = { MorphFlags.Uninterruptable },
      //  Duration = { 60, 60, 120 },
      //  TransformTime = { 1, 1, 1 },
      //  IsHeroAbility = true
      //};
      //var metamorphosis = metamorphosisFactory.Generate("meta", objectDatabase);

      ////Blademaster
      //new HeroFactory(UnitType.Demonhunter)
      //{
      //  AbilitiesHero = new Ability[] {immolation, manaburn },
      //  Strength = 100,
      //  Agility = 10,
      //  Intelligence = 5,
      //  ProperName = "YakaryBovine",
      //  TextName = "Blademaster",
      //}.Generate("Yakb", objectDatabase);

      ////Deckhand
      //new WorkerFactory(UnitType.Peasant)
      //{
      //  TextName = "Deckhand",
      //  DamageBase = 4,
      //  DamageNumberOfDice = 1,
      //  DamageSidesPerDie = 2,
      //  HitPoints = 230,
      //  AbilitiesNormal = new Ability[] { evasion },
      //  StructuresBuilt = new Unit[] { blacksmith, scoutTower, guardTower, cannonTower },
      //  Flavour = "The backbone of Kul'tiran seafaring society.",
      //}.Generate("kdec", objectDatabase);

      //Mass Mana Burn
      var massmanaburnfactory = new MassSpellFactory()
      {
        CastRange = { 300, 300, 300, 300 },
        ManaCost = { 50, 50, 50, 50 },
        Cooldown = { 2, 2, 2, 2 },
        AreaOfEffect = { 500, 500, 500, 500 },
        Levels = 4,
        Icon = @"ManaBurn",
        TextName = "Mass Mana Burn",
        Spell = manaburn,
        ButtonPosition = new Point(0, 2),
        IsHeroAbility = true
      };
      var massmanaburn = massmanaburnfactory.Generate("ydfg", objectDatabase);

      //Kazzak
      new HeroFactory(UnitType.Doomguard)
      {
        AbilitiesHero = new Ability[] { massmanaburn, immolation },
        Strength = 100,
        Agility = 10,
        Intelligence = 5,
        ProperName = "Kazzak",
        TextName = "Doomlord",
      }.Generate("Kazz", objectDatabase);

      ////Aerial Shackles
      //var aerialshacklesfactory = new AerialShacklesFactory()
      //{
      //  DurationUnit = { 40 },
      //  CastRange = { 550 },
      //  Levels = 1,
      //  Icon = "MagicLariet",
      //  TextName = "Aerial Shackles",
      //  ButtonPosition = new Point(0, 0),
      //  DamagePerSecond = { 8 },
      //  DurationHero = { 4 },
      //  Cooldown = { 0 }
      //};
      //var aerialshackles = aerialshacklesfactory.Generate("shac", objectDatabase);

      ////Dragonhawk Rider
      //new UnitFactory(UnitType.Dragonhawk)
      //{
      //  TextName = "Dragonhawk Rider",
      //  ArtIconGameInterface = "DragonHawk",
      //  AbilitiesNormal = new Ability[] { aerialshackles },
      //  DamageBase = 10,
      //  DamageNumberOfDice = 2,
      //  DamageSidesPerDie = 6,
      //  HitPoints = 600,
      //  Flavour = "Swift dragonhawk mounted by an elven warrior.",
      //}.Generate("drag", objectDatabase);

      ////Holy Light
      //var holyLightFactory = new HolyLightFactory()
      //{
      //  AmountHealed = { 50, 100, 200, 250 },
      //  CastRange = { 300 },
      //  Levels = 4,
      //  Icon = @"HolyBolt",
      //  TextName = "Holy Light",
      //  ButtonPosition = new Point(0, 2),
      //  IsHeroAbility = false
      //};
      //var holyLight = holyLightFactory.Generate("keko", objectDatabase);

      ////Arthas
      //new HeroFactory(UnitType.Paladin_Hpal)
      //{
      //  AbilitiesHero = new Ability[] { holyLight },
      //  Strength = 100,
      //  Agility = 10,
      //  Intelligence = 5,
      //  ProperName = "Arthas",
      //  TextName = "Prince",
      //  ArtModelFile = @"units\human\Arthas\Arthas"
      //}.Generate("Bang", objectDatabase);
    }
  }
}