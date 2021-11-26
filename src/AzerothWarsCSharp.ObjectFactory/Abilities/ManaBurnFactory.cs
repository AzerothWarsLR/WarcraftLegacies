using AzerothWarsCSharp.ObjectFactory.AbilityProperties;
using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public sealed class ManaBurnFactory : ActiveAbilityFactory<DemonHunterManaBurn>
  {
    public LeveledAbilityPropertyFloat MaxManaDrained = new("Mana drained");
    public LeveledAbilityPropertyFloat CastRange = new("Range");

    protected override void ApplyStats(DemonHunterManaBurn ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataMaxManaDrained[i+1] = MaxManaDrained[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsDurationNormal[i + 1] = 1;
      }
    }

    public override DemonHunterManaBurn Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new DemonHunterManaBurn(newRawCode);
      Apply(newAbility);
      return newAbility;
    }

    public ManaBurnFactory() : base()
    {
      Properties.Add(MaxManaDrained);
      Properties.Add(CastRange);
    }
  }
}