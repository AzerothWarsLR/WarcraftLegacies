using AzerothWarsCSharp.Launcher.ObjectFactory.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.Units;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class Kultiras
  {
    public static void Setup()
    {
      var seaElemental = new GenericUnit(UnitType.Seaelemental, "ksea")
      {
        TextName = "Sea Elemental",
        ArtIconGameInterface = @"ReplaceableTextures\CommandButtons\BTNSeaElemental.blp",
        AbilitiesNormal = System.Array.Empty<Ability>(),
        DamageBase = 10,
        DamageNumberOfDice = 2,
        DamageSidesPerDie = 6,
        HitPoints = 600,
        Flavour = "Avatar of the sea's primordial force.",
      }.Generate();

      var summonSeaElemental = new SummonWaterElemental("asea") {
        Levels = 1,
        SummonedUnit = new Unit[] { seaElemental },
        SummonCount = new int[] { 1 },
        ArtIcon = seaElemental.ArtIconGameInterface,
        Duration = new int[] { 40 },
      }.Generate();

      var tidesage = new GenericUnit(UnitType.Priest, "ktid")
      {
        TextName = "Tidepriest",
        ArtModelFile = @"MageKulTirasV1.01.mdl",
        ArtIconGameInterface = @"ReplaceableTextures\CommandButtons\BTNEmissary.blp",
        Flavour = "Spellcaster empowered with mystical control over the tides.",
        AbilitiesNormal = new Ability[] {summonSeaElemental},
        DamageBase = 4,
        DamageNumberOfDice = 2,
        DamageSidesPerDie = 7,
        HitPoints = 600,
      }.Generate();

      var deckhand = new Worker(UnitType.Peasant, "kdec")
      {
        TextName = "Deckhand",
        ArtModelFile = @"MageKulTirasV1.01.mdl",
        ArtIconGameInterface = @"ReplaceableTextures\CommandButtons\BTNEmissary.blp",
        DamageBase = 2,
        DamageNumberOfDice = 2,
        DamageSidesPerDie = 12,
        HitPoints = 600,
        AbilitiesNormal = System.Array.Empty<Ability>(),
      }.Generate();
    }
  }
}