using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public sealed class SummonWaterElementalFactory : ActiveAbilityFactory<ArchMageWaterElemental>
  {
    /// <summary>
    /// How long the summoned unit lasts before disappearing.
    /// </summary>
    public LeveledAbilityPropertyInt Duration { get; set; }

    /// <summary>
    /// Which unit types this ability summons, by level.
    /// </summary>
    public LeveledAbilityPropertyUnit SummonedUnit { get; set; }

    /// <summary>
    /// How many summons this ability makes, by level.
    /// </summary>
    public LeveledAbilityPropertyInt SummonCount { get; set; }

    protected override void ApplyStats(ArchMageWaterElemental ability)
    {
      ability.TextName = $"Summon {SummonedUnit[0].TextName}";
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.DataSummonedUnitType[i + 1] = SummonedUnit[i];
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

    public SummonWaterElementalFactory() : base()
    {
      Properties.Add(Duration);
      Properties.Add(SummonedUnit);
      Properties.Add(SummonCount);
    }
  }
}