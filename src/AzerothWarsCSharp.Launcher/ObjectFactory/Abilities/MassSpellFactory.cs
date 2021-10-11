using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class MassSpellFactory : ActiveAbilityFactory<IllidanChannel>
  {
    protected override void ApplyTooltipLearnExtended(IllidanChannel ability)
    {
      ability.TextName = TextName;

      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Casts {Spell.TextName} on all units in the target area.");
      stringBuilder.Append("|n");
      stringBuilder.Append(AreaOfEffect.ToConcatenatedString());
      stringBuilder.Append(ManaCost.ToConcatenatedString());
      stringBuilder.Append(CastRange.ToConcatenatedString());
      ability.TextTooltipLearnExtended = stringBuilder.ToString();
    }

    protected override void ApplyTooltipNormalExtended(IllidanChannel ability)
    {
      ability.TextName = TextName;

      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Casts {Spell.TextName} on all units in the target area.");
      stringBuilder.Append("|n");
      stringBuilder.Append(CastRange.ToConcatenatedString());
      for (var i = 0; i < Levels; i++)
      {
        ability.TextTooltipNormalExtended[i] = stringBuilder.ToString();
      }
    }

    protected override void ApplyStats(IllidanChannel ability)
    {
      ability.ArtCaster = new string[] { "" };
      ability.ArtEffect = new string[] { "" };
      ability.ArtTarget = new string[] { "" };

      for (var i = 0; i < Levels; i++)
      {
        ability.DataArtDuration[i + 1] = 0.98f;
        ability.DataBaseOrderID[i + 1] = BaseOrderId;
        ability.DataDisableOtherAbilities[i + 1] = false;
        ability.DataFollowThroughTime[i + 1] = 1;
        ability.DataOptionsRaw[i + 1] = 1;
        ability.DataTargetType[i + 1] = ChannelType.InstantNoTarget;
        ability.StatsAreaOfEffect[i + 1] = AreaOfEffect[i];
        ability.StatsCastRange[i] = CastRange[i];
      }
    }

    public override IllidanChannel Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new IllidanChannel(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public string BaseOrderId { get; set; } = "channel";
    public LeveledAbilityProperty<float> AreaOfEffect { get; set; } = new("Area of effect");
    public LeveledAbilityProperty<float> CastRange { get; set; } = new("Cast range");
    public Ability Spell { get; set; } = null;
  }
}