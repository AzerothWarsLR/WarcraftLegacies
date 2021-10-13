using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class HolyLightFactory : ActiveAbilityFactory<PaladinHolyLight>
  {
    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"very holy spell.");
      stringBuilder.Append("|n");
      return stringBuilder.ToString();
    }

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

    public LeveledAbilityProperty<float> AmountHealed = new("Amount healed");
    public LeveledAbilityProperty<float> CastRange = new("Range");
  }
}