using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;


namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Causes the unit to summon a unit upon death.
  /// </summary>
  public sealed class CreateCorpseOnDeath : PassiveAbility
  {
    
    /// <summary>
    /// The unit type corpse to summon on death.
    /// </summary>
    public int CorpseUnitTypeId { get; init; }

    /// <summary>
    /// How many corpses to summon.
    /// </summary>
    public int CorpseCount { get; init; } = 1;
    
    /// <summary>
    /// The player must have this research for the ability to take effect.
    /// </summary>
    public int RequiredResearch { get; init; }
    
    /// <inheritdoc />
    public CreateCorpseOnDeath(int unitTypeId) : base(unitTypeId)
    {
    }
    
    /// <inheritdoc />
    public override void OnDeath()
    {
      var triggerUnit = GetTriggerUnit();
      if (RequiredResearch != 0 && (GetPlayerTechCount(triggerUnit.Owner, RequiredResearch, false) == 0))
        return;
      var pos = triggerUnit.GetPosition();
      for (var i = 0; i < CorpseCount; i++)
        CreateCorpse(triggerUnit.Owner, CorpseUnitTypeId, pos.X, pos.Y, triggerUnit.Facing);
      triggerUnit.Dispose();
    }
  }
}