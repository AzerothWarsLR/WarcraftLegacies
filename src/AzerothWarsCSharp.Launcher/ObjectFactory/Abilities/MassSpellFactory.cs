using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Common;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class MassSpellFactory : ActiveAbilityFactory<PitLordRainOfFire>
  {
    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Casts {Spell.TextName} on all units in the target area.");
      stringBuilder.Append("|n");
      stringBuilder.Append(AreaOfEffect.ToConcatenatedString(level));
      stringBuilder.Append(ManaCost.ToConcatenatedString(level));
      stringBuilder.Append(CastRange.ToConcatenatedString(level));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(PitLordRainOfFire ability)
    {
      ability.ArtCaster = new string[] { "" };
      ability.ArtEffect = new string[] { "" };
      ability.ArtTarget = new string[] { "" };

      for (var i = 0; i < Levels; i++)
      {
        //ability.DataArtDuration[i + 1] = 0.98f;
        //ability.DataBaseOrderID[i + 1] = BaseOrderId;
        //ability.DataDisableOtherAbilities[i + 1] = false;
        //ability.DataFollowThroughTime[i + 1] = 1;
        //ability.DataOptionsRaw[i + 1] = 1;
        //ability.DataTargetType[i + 1] = ChannelType.InstantNoTarget;
        ability.StatsAreaOfEffect[i + 1] = AreaOfEffect[i];
        ability.StatsCastRange[i] = CastRange[i];
      }
    }

    public override PitLordRainOfFire Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new PitLordRainOfFire(newRawCode, objectDatabase);
      Apply(newAbility);
      var definition = new MassAnySpellEffectDefinition(newAbility.NewId)
      {
        AreaOfEffect = AreaOfEffect[1]
      };
      MassAnySpellEffectDefinition.Register(definition);
      return newAbility;
    }

    public string BaseOrderId { get; set; } = "channel";
    public LeveledAbilityProperty<float> AreaOfEffect { get; set; } = new("Area of effect");
    public LeveledAbilityProperty<float> CastRange { get; set; } = new("Cast range");
    public Ability Spell { get; set; } = null;
  }
}