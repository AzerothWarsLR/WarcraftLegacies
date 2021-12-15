using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class SpellSetup
  {
    public static void Setup()
    {
      var warStompCairne = new Stomp(FourCC("A0WM"))
      {
        Radius = 300,
        DamageBase = 20,
        DamageLevel = 30,
        DurationBase = 0,
        DurationLevel = 1,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompCairne);

      var warStompImmoltar = new Stomp(FourCC("A0LU"))
      {
        Radius = 200,
        DamageBase = 9000,
        DurationBase = 3,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompImmoltar);
      
      var warStompKazzak = new Stomp(FourCC("A0AW"))
      {
        Radius = 300,
        DamageBase = 25,
        DurationBase = 3,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompKazzak);

      var thunderClap = new Stomp(FourCC("A0QC"))
      {
        Radius = 225,
        DamageBase = 65,
        DurationBase = 1,
        StunAbilityId = FourCC("S00H"),
        StunOrderString = "cripple"
      };
      SpellSystem.Register(thunderClap);

      var consecration = new Stomp(FourCC("A0WE"))
      {
        Radius = 225,
        DamageBase = 0,
        DamageLevel = 60,
        DurationBase = 1,
        StunAbilityId = FourCC("S00H"),
        StunOrderString = "cripple"
      };
      SpellSystem.Register(consecration);
      
      var massAntiMagicShell = new MassAnySpell(FourCC("A099"))
      {
        DummyAbilityId = FourCC("A0JN"),
        DummyAbilityOrderString = "antimagicshell",
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massAntiMagicShell);
      
      var massEnrage = new MassAnySpell(FourCC("A0QK"))
      {
        DummyAbilityId = FourCC("ACuf"),
        DummyAbilityOrderString = "unholyfrenzy",
        Radius = 200,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massEnrage);
      
      var massFrostArmor = new MassAnySpell(FourCC("A0H3"))
      {
        DummyAbilityId = FourCC("A0H6"),
        DummyAbilityOrderString = "frostarmor",
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massFrostArmor);

      var scattershot = new MassAnySpell(FourCC("A0GP"))
      {
        DummyAbilityId = FourCC("A0GL"),
        DummyAbilityOrderString = "thunderbolt",
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(scattershot);

      var massBanish = new MassAnySpell(FourCC("A0FD"))
      {
        DummyAbilityId = FourCC("A0FE"),
        DummyAbilityOrderString = "banish",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massBanish);

      var thunderFists = new SpellOnAttack(FourCC("A0LN"))
      {
        DummyAbilityId = FourCC("A0LN"),
        DummyOrderString = "forkedlightning",
        ProcChance = 0.15f
      };

      var seismicShard = new MassAnySpell(FourCC("A0OD"))
      {
        DummyAbilityId = FourCC("A0OE"),
        DummyAbilityOrderString = "thunderbolt",
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(seismicShard);

      var elunesGaze = new MassAnySpell(FourCC("A0VX"))
      {
        DummyAbilityId = FourCC("A0VY"),
        DummyAbilityOrderString = "invisibility",
        Radius = 350,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(elunesGaze);

      var massSimulacrum = new MassSimulacrum(FourCC("A0DG"))
      {
        Radius = 150,
        CountBase = 2,
        CountLevel = 4,
        Duration = 60,
        Effect = @"war3mapImported\Soul Discharge Blue.mdx",
        EffectScale = 1.1f,
        EffectTarget = @"Abilities\Spells\Items\AIil\AIilTarget.mdl",
        EffectScaleTarget = 1.0f,
        HealthBonusBase = -0.5f,
        HealthBonusLevel = 0.2f,
        DamageBonusBase = -0.5f,
        DamageBonusLevel = 0.2f,
      };
      SpellSystem.Register(massSimulacrum);

      var bombingRun = new ChannelAnySpell(FourCC("A0S5"))
      {
        DummyAbilityId = FourCC("A0S1"),
        DummyAbilityOrderString = "locustswarm"
      };
      SpellSystem.Register(bombingRun);

      var inspireMadness = new InspireMadness(FourCC("A10M"))
      {
        Radius = 400,
        CountBase = 2,
        CountLevel = 4,
        Duration = 16,
        Effect = @"war3mapImported\Call of Dread Purple.mdx",
        EffectScale = 1.1f,
        EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
        EffectScaleTarget = 0.5f
      };
      SpellSystem.Register(inspireMadness);

      var summonGraniteGolems = new SummonUnits(FourCC("A0EP"))
      {
        SummonUnitTypeId = FourCC("nggr"),
        SummonCount = 4,
        Duration = 60,
        Radius = 400,
        AngleOffset = 45,
        Effect = @"war3mapImported\Earth NovaTarget.mdx"
      };
      SpellSystem.Register(summonGraniteGolems);

      var solarJudgement = new SolarJudgementSpell(FourCC("A01F"))
      {
        DamageBase = 20,
        DamageLevel = 20,
        Duration = 14,
        Period = 0.25f,
        HealMultiplier = 1.5f,
        UndeadDamageMultiplier = 1.1f,
        Radius = 250,
        BoltRadius = 125,
        EffectPath = "Shining Flare.mdx",
        EffectHealPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      };
      SpellSystem.Register(solarJudgement);
    }
  }
}