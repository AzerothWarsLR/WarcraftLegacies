using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.SpellConduction
{
  public sealed class SpellConductionAbility : PassiveAbility
  {
    /// <summary>
    /// The research required for this ability to work.
    /// </summary>
    public required int RequiredResearch { get; init; }
    
    /// <summary>
    /// How much damage to redirect to the caster.
    /// </summary>
    public required float RedirectionPercentage { get; init; }
     
    /// <summary>
    /// Attack types that can be redirected.
    /// </summary>
    public required attacktype[] RedirectableAttackTypes { get; init; }
    
    /// <summary>
    /// Units this far away will get damage redirected from them.
    /// </summary>
    public required int Radius { get; init; }
    
    /// <inheritdoc />
    public SpellConductionAbility(int unitTypeId) : base(unitTypeId)
    {
    }

    /// <inheritdoc />
    public override void OnCreated(unit createdUnit)
    {
      var aura = new SpellConductionAura(createdUnit)
      {
        RedirectionPercentage = RedirectionPercentage,
        RedirectableAttackTypes = RedirectableAttackTypes,
        RequiredResearch = RequiredResearch,
        Radius = Radius
      };
      AuraSystem.Add(aura);
    }
  }
}