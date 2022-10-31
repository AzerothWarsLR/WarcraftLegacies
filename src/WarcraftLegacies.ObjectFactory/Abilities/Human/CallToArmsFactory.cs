using War3Api.Object;
using War3Api.Object.Abilities;
using WarcraftLegacies.ObjectFactory.AbilityProperties;

namespace WarcraftLegacies.ObjectFactory.Abilities.Human
{
  public class CallToArmsFactory : ActiveAbilityFactory<Militia>
  {
    public LeveledAbilityPropertyUnit AlternateFormUnit = new("Alternate form");
    public LeveledAbilityPropertyFloat Duration = new("Duration", 60);

    protected override void ApplyStats(Militia ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataAlternateFormUnit[i + 1] = AlternateFormUnit[i];
        ability.StatsDurationHero[i + 1] = Duration[i];
        ability.StatsDurationNormal[i + 1] = Duration[i];
      }
    }

    public override Militia Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new Militia(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}