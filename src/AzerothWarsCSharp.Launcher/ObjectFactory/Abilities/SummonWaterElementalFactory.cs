using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class SummonWaterElementalFactory : ActiveAbilityFactory<ArchMageWaterElemental>
  {
    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Summons a unit to attack the caster's enemies.");
      stringBuilder.Append("|n");
      stringBuilder.Append(SummonedUnit.ToConcatenatedString(level));
      stringBuilder.Append(SummonCount.ToConcatenatedString(level));
      stringBuilder.Append(Duration.ToConcatenatedString(level));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(ArchMageWaterElemental ability)
    {
      ability.TextName = $"Summon {SummonedUnit[0].TextName}";
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.DataSummonedUnitType[i + 1] = SummonedUnit[i];
        ability.TextTooltipNormal[i + 1] = $"Summon {SummonedUnit[i].TextName}";
        ability.TextTooltipNormal[i + 1] = $"Summon {SummonedUnit[i].TextName}";
        ability.DataSummonedUnitCount[i + 1] = SummonCount[i];
      }
    }

    public Buff GenerateBuff(string newRawCode)
    {
      var newBuff = new Buff(BuffType.WaterElemental, newRawCode)
      {
        TextTooltip = SummonedUnit[0].TextName,
        ArtIcon = Icon
      };
      return newBuff;
    }

    public override ArchMageWaterElemental Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new ArchMageWaterElemental(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    /// <summary>
    /// How long the summoned unit lasts before disappearing.
    /// </summary>
    public LeveledAbilityProperty<float> Duration { get; set; }

    /// <summary>
    /// Which unit types this ability summons, by level.
    /// </summary>
    public LeveledAbilityProperty<Unit> SummonedUnit { get; set; }

    /// <summary>
    /// How many summons this ability makes, by level.
    /// </summary>
    public LeveledAbilityProperty<int> SummonCount { get; set; }
  }
}