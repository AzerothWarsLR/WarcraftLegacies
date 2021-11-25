using AzerothWarsCSharp.Launcher.ObjectFactory.AbilityProperties;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human
{
  public class DefendFactory : ToggledAbilityFactory<Defend>
  {
    public LeveledAbilityPropertyFloat AttackSpeedFactor = new("Attack speed factor");
    public LeveledAbilityPropertyFloat ChanceToDeflect = new("Chance to deflect");
    public LeveledAbilityPropertyFloat DamageDealt = new("Damage dealt");
    public LeveledAbilityPropertyFloat DamageTaken = new("Damage taken");
    public LeveledAbilityPropertyFloat DeflectDamageTakenPiercing = new("Deflect damage taken (piercing)");
    public LeveledAbilityPropertyFloat DeflectDamageTakenSpells = new("Deflect damage taken (spells)");
    public LeveledAbilityPropertyFloat MagicDamageReduction = new("Magic damage reduction");
    public LeveledAbilityPropertyFloat MovementSpeedFactor = new("Movement speed factor");

    protected override void ApplyStats(Defend ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataAttackSpeedFactor[i+1] = AttackSpeedFactor[i];
        ability.DataChanceToDeflect[i + 1] = ChanceToDeflect[i];
        //ability.DataDamageDealt[i + 1] = DamageDealt[i];
        //ability.DataDamageTaken[i + 1] = DamageTaken[i];
        ability.DataDeflectDamageTakenPiercing[i + 1] = DeflectDamageTakenPiercing[i];
        ability.DataDeflectDamageTakenSpells[i + 1] = DeflectDamageTakenSpells[i];
        ability.DataMagicDamageReduction[i + 1] = MagicDamageReduction[i];
        ability.DataMovementSpeedFactor[i + 1] = MovementSpeedFactor[i];
      }
    }

    public override Defend Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new Defend(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }

    public DefendFactory() : base()
    {
      Properties.Add(AttackSpeedFactor);
      Properties.Add(ChanceToDeflect);
      Properties.Add(DamageDealt);
      Properties.Add(DamageTaken);
      Properties.Add(DeflectDamageTakenPiercing);
      Properties.Add(DeflectDamageTakenSpells);
      Properties.Add(MagicDamageReduction);
      Properties.Add(MovementSpeedFactor);
    }
  }
}