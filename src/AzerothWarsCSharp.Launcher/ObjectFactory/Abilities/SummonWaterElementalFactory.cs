using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class SummonWaterElementalFactory : ActiveAbilityFactory<ArchMageWaterElemental>
  {
    private void GenerateTooltip(ArchMageWaterElemental archMageWaterElemental)
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

    private void GenerateStats(ArchMageWaterElemental ability)
    {
      ability.TextName = $"Summon {SummonedUnit[0].TextName}";
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsDurationNormal[i + 1] = Duration[i];
        ability.DataSummonedUnitType[i + 1] = SummonedUnit[i];
        ability.TextTooltipNormal[i + 1] = $"Summon {SummonedUnit[i].TextName}";
        ability.TextTooltipNormal[i + 1] = $"Summon {SummonedUnit[i].TextName}";
        ability.DataSummonedUnitCount[i + 1] = SummonCount[i];
        ability.ArtIconNormal = ArtIcon;
        ability.ArtIconResearch = ArtIcon;
      }
    }

    public Buff GenerateBuff(string newRawCode)
    {
      var newBuff = new Buff(BuffType.WaterElemental, newRawCode)
      {
        TextTooltip = SummonedUnit[0].TextName,
        ArtIcon = ArtIcon
      };
      return newBuff;
    }

    public Ability Generate(string newRawCode)
    {
      var newAbility = new ArchMageWaterElemental(newRawCode);
      GenerateStats(newAbility);
      GenerateTooltip(newAbility);
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

    /// <summary>
    /// The icon for this ability and its associated buff.
    /// </summary>
    public string ArtIcon { get; set; }
  }
}