using MacroTools.Buffs;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;


namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// When the ability holder takes lethal damage, they transform into a Spirit of Vengeance.
  /// If they attack enough times while a Spirit, they revive with some health.
  /// Otherwise, they die.
  /// </summary>
  public sealed class Vengeance : TakeDamagePassiveAbility
  {
    /// <summary>
    /// How much extra damage the vengenace form has.
    /// </summary>
    public int BonusDamageBase { private get; init; }
    
    /// <summary>
    /// How much damage each level of the ability adds to the vengeance form.
    /// </summary>
    public int BonusDamageLevel { private get; init; }
    
    /// <summary>
    /// The amount of healing granted when exiting the vengenace form.
    /// </summary>
    public float HealBase { private get; init; }
    
    /// <summary>
    /// How much extra healing each level of the ability adds to exiting the vengeance form.
    /// </summary>
    public float HealLevel { private get; init; }
    
    /// <summary>
    /// How long the vengeance form lasts.
    /// </summary>
    public float Duration { private get; init; }
    
    /// <summary>
    /// A unit type ID with the model of the vengeance form.
    /// </summary>
    public int AlternateFormId { private get; init; }
    
    /// <summary>
    /// The number of hits the hero needs to make in the vengeance form to revive.
    /// </summary>
    public int HitsReviveThreshold { private get; init; }
    
    /// <summary>
    /// The visual effect that occurs 
    /// </summary>
    public string? ReviveEffect { private get; init; }

    /// <inheritdoc />
    public override void OnTakesDamage()
    {
      var damaged = GetTriggerUnit();
      var abilityLevel = GetUnitAbilityLevel(damaged, AbilityTypeId);
      if (abilityLevel == 0 || BlzGetUnitSkin(damaged) == AlternateFormId ||
          !(GetEventDamage() >= GetUnitState(damaged, UNIT_STATE_LIFE)) || !(GetUnitState(damaged, UNIT_STATE_MANA) >=
                                                                             BlzGetUnitAbilityManaCost(damaged,
                                                                               AbilityTypeId, abilityLevel))) 
        return;
      BlzSetEventDamage(0);
      var vengeanceBuff = new VengeanceBuff(damaged, damaged)
      {
        BonusDamage = BonusDamageBase + BonusDamageLevel * abilityLevel,
        Heal = HealBase + HealLevel * abilityLevel,
        Duration = Duration,
        AlternateFormId = AlternateFormId,
        HitsReviveThreshold = HitsReviveThreshold,
        ReviveEffect = ReviveEffect
      };
      BuffSystem.Add(vengeanceBuff);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vengeance"/> class.
    /// </summary>
    /// <param name="damagedUnitTypeId">The unit type ID that can take damage to trigger this effect.</param>
    /// <param name="abilityTypeId">The ability whose level is used to determine the magnitude of the effect.</param>
    public Vengeance(int damagedUnitTypeId, int abilityTypeId) : base(damagedUnitTypeId, abilityTypeId)
    {
    }
  }
}