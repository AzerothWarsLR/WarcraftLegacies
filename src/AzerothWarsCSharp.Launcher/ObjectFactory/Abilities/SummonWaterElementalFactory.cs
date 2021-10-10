using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public sealed class SummonWaterElementalFactory : ActiveAbilityFactory<ArchMageWaterElemental>
  {
    protected override void ApplyTooltipLearnExtended(ArchMageWaterElemental archMageWaterElemental)
    {

    }

    protected override void ApplyTooltipNormalExtended(ArchMageWaterElemental archMageWaterElemental)
    {
      for (var i = 0; i < Levels; i++)
      {
        var summonedUnit = SummonedUnit[i];
        archMageWaterElemental.TextTooltipNormalExtended[i + 1] = $"Summons a {summonedUnit.TextName} to " +
          $"attack the caster's enemies for {Duration[i]} seconds." +
          $"|n|n|cffecce87{SummonedUnit[i].TextName}|r" +
          $"|n{SummonedUnit[i].TextTooltipExtended}";
      }
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

    public override ArchMageWaterElemental Generate(string newRawCode)
    {
      var newAbility = new ArchMageWaterElemental(newRawCode);
      Apply(newAbility);
      return newAbility;
    }

    /// <summary>
    /// How long the summoned unit lasts before disappearing.
    /// </summary>
    public int[] Duration { get; set; }

    /// <summary>
    /// Which unit types this ability summons, by level.
    /// </summary>
    public Unit[] SummonedUnit { get; set; }

    /// <summary>
    /// How many summons this ability makes, by level.
    /// </summary>
    public int[] SummonCount { get; set; }
  }
}