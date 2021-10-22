using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public sealed class HolyLightFactory : ActiveAbilityFactory<PaladinHolyLight>
  {
    public LeveledAbilityPropertyFloat AmountHealed = new("Amount healed");
    public LeveledAbilityPropertyFloat CastRange = new("Range");

    protected override void ApplyStats(PaladinHolyLight ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.DataAmountHealedDamaged[i + 1] = AmountHealed[i];
      }
    }

    public override PaladinHolyLight Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new PaladinHolyLight(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public HolyLightFactory() : base()
    {
      Properties.Add(AmountHealed);
      Properties.Add(CastRange);
    }
  }
}