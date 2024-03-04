using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;


namespace MacroTools.Spells
{
  public sealed class MassAnySpell : Spell
  {
    public int DummyAbilityId { get; init; }
    
    public int DummyAbilityOrderId { get; init; }
    
    public float Radius { get; init; }
    
    public DummyCasterManager.CastFilter CastFilter { get; init; }
    
    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

    public DummyCasterType DummyCasterType { get; init; } = DummyCasterType.Global;
    
    /// <summary>
    /// Determines where the spell's dummmy units spawn when they cast <see cref="DummyAbilityId"/>.
    /// </summary>
    public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target;
    
    public MassAnySpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
      
      if (DummyCasterType == DummyCasterType.Global)
        DummyCasterManager.GetGlobalDummyCaster().CastOnUnitsInCircle(caster, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster),
          center, Radius, CastFilter, DummyCastOriginType);
      
      if (DummyCasterType == DummyCasterType.AbilitySpecific)
        DummyCasterManager.GetAbilitySpecificDummyCaster(DummyAbilityId, DummyAbilityOrderId)
          .CastOnUnitsInCircle(caster, GetAbilityLevel(caster), center, Radius, CastFilter, DummyCastOriginType);
    }
  }
}