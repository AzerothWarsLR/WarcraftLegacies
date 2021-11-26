using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Common;
using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public class MassSpellFactory : ActiveAbilityFactory<IllidanChannel>
  {
    public string BaseOrderId { get; set; } = "channel";
    public LeveledAbilityPropertyFloat AreaOfEffect { get; set; } = new("Area of effect");
    public LeveledAbilityPropertyFloat CastRange { get; set; } = new("Cast range");
    public Ability Spell { get; set; } = null;

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
      var definition = new MassAnySpellEffectDefinition(newAbility.NewId)
      {
        AreaOfEffect = AreaOfEffect[1]
      };
      MassAnySpellEffectDefinition.Register(definition);
      return newAbility;
    }

    public MassSpellFactory() : base()
    {
      Properties.Add(AreaOfEffect);
      Properties.Add(CastRange);
    }
  }
}