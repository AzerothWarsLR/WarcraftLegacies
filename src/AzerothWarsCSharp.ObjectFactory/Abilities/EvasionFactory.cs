using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public sealed class EvasionFactory : PassiveAbilityFactory<DemonHunterEvasion>
  {
    public LeveledAbilityPropertyFloat ChanceToEvade { get; set; } = new("Evasion chance");

    protected override void ApplyStats(DemonHunterEvasion ability)
    {
      ability.StatsLevels = Levels;
      ability.StatsHeroAbility = true;
      ability.StatsItemAbility = false;
      for (var i = 0; i < Levels; i++)
      {
        ability.DataChanceToEvade[i+1] = ChanceToEvade[i];
      }
    }

    public override DemonHunterEvasion Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DemonHunterEvasion(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public EvasionFactory() : base()
    {
      Properties.Add(ChanceToEvade);
    }
  }
}