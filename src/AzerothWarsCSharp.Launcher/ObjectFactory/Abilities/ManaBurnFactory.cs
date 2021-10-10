using System.Text;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class ManaBurnFactory : ActiveAbilityFactory<DemonHunterManaBurn>
  {
    protected override void ApplyTooltipLearnExtended(DemonHunterManaBurn ability)
    {
      ability.TextName = TextName;

      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Sends a bolt of negative energy that burns a target enemy unit's mana. Burned mana combusts, dealing damage to the target equal to the amount of mana burned.");
      stringBuilder.Append("|n");
      stringBuilder.Append(MaxManaDrained.ToConcatenatedString());
      stringBuilder.Append(CastRange.ToConcatenatedString());
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

    protected override void ApplyTooltipNormalExtended(DemonHunterManaBurn ability)
    {

    }

    protected override void ApplyStats(DemonHunterManaBurn ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        //ability.DataBufferManaRequired[i+1] = i < BufferManaRequired.Length ? BufferManaRequired[i] : 0;
        //ability.DataDamagePerInterval[i+1] = i < DamagePerSecond.Length ? DamagePerSecond[i] : 0;
        //ability.DataManaDrainedPerSecond[i+1] = i < ManaDrainedPerSecond.Length ? ManaDrainedPerSecond[i] : 0;
        ability.StatsDurationNormal[i + 1] = 1;
      }
      ability.ArtIconNormal = ArtIcon;
      ability.ArtIconResearch = ArtIcon;
    }

    public override DemonHunterManaBurn Generate(string newRawCode)
    {
      var newAbility = new DemonHunterManaBurn(newRawCode);
      Apply(newAbility);
      return newAbility;
    }

    public LeveledAbilityProperty<float> MaxManaDrained = new("Mana drained");
    public LeveledAbilityProperty<float> CastRange = new("Range");
  }
}