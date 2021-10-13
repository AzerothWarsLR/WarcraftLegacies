using System.Text;
using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class DefendFactory : ActiveAbilityFactory<Defend>
  {
    public LeveledAbilityProperty<float> AttackSpeedFactor = new("Attack speed factor");
    public LeveledAbilityProperty<float> ChanceToDeflect = new("Chance to deflect");
    public LeveledAbilityProperty<float> DamageDealt = new("Damage dealt");
    public LeveledAbilityProperty<float> DamageTaken = new("Damage taken");
    public LeveledAbilityProperty<float> DeflectDamageTakenPiercing = new("Deflect damage taken (piercing)");
    public LeveledAbilityProperty<float> DeflectDamageTakenSpells = new("Deflect damage taken (spells)");
    public LeveledAbilityProperty<float> MagicDamageReduction = new("Magic damage reduction");
    public LeveledAbilityProperty<float> MovementSpeedFactor = new("Movement speed factor");

    protected override string GenerateTooltipExtended(int level)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(@$"Activate to have a chance to reflect Piercing attacks upon the source, 
        and to take reduced the damage from attacks that are not reflected. 
        While active, movement speed is reduced.");
      stringBuilder.Append("|n");
      stringBuilder.Append(AttackSpeedFactor.ToConcatenatedString(level, true));
      stringBuilder.Append(ChanceToDeflect.ToConcatenatedString(level, true));
      stringBuilder.Append(DamageDealt.ToConcatenatedString(level, true));
      stringBuilder.Append(DamageTaken.ToConcatenatedString(level, true));
      stringBuilder.Append(DeflectDamageTakenPiercing.ToConcatenatedString(level, true));
      stringBuilder.Append(DeflectDamageTakenSpells.ToConcatenatedString(level, true));
      stringBuilder.Append(MagicDamageReduction.ToConcatenatedString(level, true));
      stringBuilder.Append(MovementSpeedFactor.ToConcatenatedString(level, true));
      return stringBuilder.ToString();
    }

    protected override void ApplyStats(Defend ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.DataAttackSpeedFactor[i+1] = AttackSpeedFactor[i];
        ability.DataChanceToDeflect[i + 1] = ChanceToDeflect[i];
        ability.DataDamageDealt[i + 1] = DamageDealt[i];
        ability.DataDamageTaken[i + 1] = DamageTaken[i];
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
  }
}