using War3Api.Object;
using War3Api.Object.Abilities;
using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class HarvestFactory : ActiveAbilityFactory<Harvest>
  {
    public LeveledAbilityPropertyInt DamageToTree = new("Lumber harvesed per hit", 1);
    public LeveledAbilityPropertyFloat SwingCooldown = new("Attack swing cooldown");
    public LeveledAbilityPropertyInt GoldCapacity = new("Gold capacity", 10);
    public LeveledAbilityPropertyInt LumberCapacity = new("Lumber capacity", 10);
    public LeveledAbilityPropertyFloat CastRange = new("Range", 116);

    //Derived
    private readonly LeveledAbilityPropertyFloat LumberPerSecond = new("Lumber harvested per second");

    protected override void ApplyStats(Harvest ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        LumberPerSecond[i + 1] = DamageToTree[i + 1] / SwingCooldown[i + 1];
        ability.DataDamageToTree[i + 1] = DamageToTree[i];
        ability.DataGoldCapacity[i + 1] = GoldCapacity[i];
        ability.DataLumberCapacity[i + 1] = LumberCapacity[i];
        ability.StatsCastRange[i + 1] = CastRange[i];
        ability.StatsAreaOfEffect[i + 1] = 900f;
        ability.StatsTargetsAllowed[i + 1] = new[] { Target.Tree, Target.Alive, Target.Dead };
      }
    }

    public override Harvest Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new Harvest(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public HarvestFactory() : base()
    {
      Properties.Add(LumberPerSecond);
      Properties.Add(GoldCapacity);
      Properties.Add(LumberCapacity);
      Properties.Add(CastRange);
    }
  }
}