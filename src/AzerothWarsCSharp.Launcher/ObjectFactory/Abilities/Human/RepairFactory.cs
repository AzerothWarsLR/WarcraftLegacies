using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;
using System.Collections.Generic;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class RepairFactory : ActiveAbilityFactory<RepairHuman>
  {
    public LeveledAbilityPropertyFloat NavalRangeBonus = new("Naval range bonus", 75);
    public LeveledAbilityPropertyFloat PowerbuildCost = new("Powerbuild cost", 0.15f);
    public LeveledAbilityPropertyFloat RepairCostRatio = new("Repair cost ratio", 0.35f);
    public LeveledAbilityPropertyFloat RepairTimeRatio = new("Repair time ratio", 1.5f);
    public LeveledAbilityPropertyFloat CastRange = new("Cast range", 50);
    public LeveledAbilityPropertyTargets TargetsAllowed = new("Targets allowed", new List<Target>());

    protected override void ApplyStats(RepairHuman ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataNavalRangeBonus[i + 1] = NavalRangeBonus[i];
        ability.DataPowerbuildCost[i + 1] = PowerbuildCost[i];
        ability.DataRepairCostRatio[i + 1] = RepairCostRatio[i];
        ability.DataRepairTimeRatio[i + 1] = RepairTimeRatio[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsTargetsAllowed[i + 1] = TargetsAllowed[i];
      }
    }

    public override RepairHuman Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new RepairHuman(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public RepairFactory() : base()
    {
      Properties.Add(NavalRangeBonus);
      Properties.Add(PowerbuildCost);
      Properties.Add(RepairCostRatio);
      Properties.Add(RepairTimeRatio);
      Properties.Add(CastRange);
      Properties.Add(TargetsAllowed);
    }
  }
}