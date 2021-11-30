using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.SpellSystem;
using AzerothWarsCSharp.Source.Spells;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class SpellSetup
  {
    public static void Setup()
    {
      var warStompCairne = new WarStomp(FourCC("A0WM"))
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

      var warStompImmoltar = new WarStomp(FourCC("A0LU"))
      {
        Radius = 200,
        DamageBase = 9000,
        DurationBase = 3,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompImmoltar);
      
      var warStompKazzak = new WarStomp(FourCC("A0AW"))
      {
        Radius = 300,
        DamageBase = 25,
        DurationBase = 3,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompKazzak);

      var massAntiMagicShell = new MassAnySpell(FourCC("A099"))
      {
        DummyAbilityId = FourCC("A0JN"),
        DummyAbilityOrderString = "antimagicshell",
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive
      };
      SpellSystem.Register(massAntiMagicShell);
      
      var massEnrage = new MassAnySpell(FourCC("A0QK"))
      {
        DummyAbilityId = FourCC("ACuf"),
        DummyAbilityOrderString = "unholyfrenzy",
        Radius = 200,
        CastFilter = CastFilters.IsTargetEnemyAndAlive
      };
      SpellSystem.Register(massEnrage);
      
      var massFrostArmor = new MassAnySpell(FourCC("A0H3"))
      {
        DummyAbilityId = FourCC("A0H6"),
        DummyAbilityOrderString = "frostarmor",
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive
      };
      SpellSystem.Register(massFrostArmor);

      var scattershot = new MassAnySpell(FourCC("A0GP"))
      {
        DummyAbilityId = FourCC("A0GL"),
        DummyAbilityOrderString = "thunderbolt",
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive
      };
      SpellSystem.Register(scattershot);

      var massBanish = new MassAnySpell(FourCC("A0FD"))
      {
        DummyAbilityId = FourCC("A0FE"),
        DummyAbilityOrderString = "banish",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive
      };
      SpellSystem.Register(massBanish);
    }
  }
}