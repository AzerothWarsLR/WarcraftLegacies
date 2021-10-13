using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class ManaBurnFactory : ActiveAbilityFactory<DemonHunterManaBurn>
  {
    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Sends a bolt of negative energy that burns a target enemy unit's mana. Burned mana combusts, dealing damage to the target equal to the amount of mana burned.");
      stringBuilder.Append("|n");
      stringBuilder.Append(MaxManaDrained.ToConcatenatedString(level));
      stringBuilder.Append(CastRange.ToConcatenatedString(level));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(DemonHunterManaBurn ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataMaxManaDrained[i+1] = MaxManaDrained[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsDurationNormal[i + 1] = 1;
      }
    }

    public override DemonHunterManaBurn Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DemonHunterManaBurn(newRawCode);
      Apply(newAbility);
      return newAbility;
    }

    public LeveledAbilityProperty<float> MaxManaDrained = new("Mana drained");
    public LeveledAbilityProperty<float> CastRange = new("Range");
  }
}