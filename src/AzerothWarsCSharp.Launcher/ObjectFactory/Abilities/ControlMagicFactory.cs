using System.Collections.Generic;
using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class ControlMagicFactory : ActiveAbilityFactory<ControlMagic>
  {
    public LeveledAbilityProperty<float> ManaPerSummonedHitpoint { get; set; } = new("Mana cost per hit points of target summoned unit");
    public LeveledAbilityProperty<IEnumerable<Target>> TargetsAllowed { get; set; } = new("Targets allowed");
    public LeveledAbilityProperty<int> MaximumCreepLevel { get; set; } = new("Maximum creep level");
    public LeveledAbilityProperty<float> CastRange { get; set; } = new("Cast range");
    public LeveledAbilityProperty<float> Duration { get; set; } = new("Duration");

    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Takes control of an enemy summoned unit.");
      stringBuilder.Append("|n");
      stringBuilder.Append(CastRange.ToConcatenatedString(level));
      stringBuilder.Append(TargetsAllowed.ToConcatenatedString(level));
      stringBuilder.Append(ManaPerSummonedHitpoint.ToConcatenatedString(level));
      stringBuilder.Append(Duration.ToConcatenatedString(level));
      stringBuilder.Append(MaximumCreepLevel.ToConcatenatedString(level, true));
      stringBuilder.Append(ManaCost.ToConcatenatedString(level));
      stringBuilder.Append(Cooldown.ToConcatenatedString(level));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(ControlMagic ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.StatsDurationHero[i + 1] = Duration[i];
        ability.DataManaPerSummonedHitpoint[i + 1] = ManaPerSummonedHitpoint[i];
        ability.DataMaximumCreepLevel[i + 1] = MaximumCreepLevel[i];
      }
    }

    public override ControlMagic Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new ControlMagic(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}