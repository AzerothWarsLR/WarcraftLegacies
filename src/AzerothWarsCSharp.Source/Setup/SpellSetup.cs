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
    }
  }
}