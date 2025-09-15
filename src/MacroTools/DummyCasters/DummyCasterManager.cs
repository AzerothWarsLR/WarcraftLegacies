using System.Collections.Generic;
using MacroTools.Systems;

namespace MacroTools.DummyCasters
{
  public static class DummyCasterManager
  {
    private static GlobalDummyCaster? _globalDummyCaster;
    private static readonly Dictionary<int, AbilitySpecificDummyCaster> DummyUnitByAbility = new();
    private static readonly int UnitTypeId = FourCC("u00X");

    /// <summary>Gets a dummy caster that can be used to cast any spell.</summary>
    public static GlobalDummyCaster GetGlobalDummyCaster() => _globalDummyCaster ??= new GlobalDummyCaster(InitializeDummyCasterUnit());

    /// <summary>
    /// A filter that can be applied to dummy casts so that the casts are only performed on particular targets.
    /// </summary>
    public delegate bool CastFilter(unit caster, unit target);
    
    /// <summary>
    /// Gets a dummy caster that should only ever cast the specified dummy spell.
    /// <para>Prefer using <see cref="GetGlobalDummyCaster"/> unless you have a special reason to use this one.</para>
    /// </summary>
    public static AbilitySpecificDummyCaster GetAbilitySpecificDummyCaster(int abilityId, int abilityOrderId)
    {
      if (!DummyUnitByAbility.ContainsKey(abilityId)) 
        DummyUnitByAbility.Add(abilityId, new AbilitySpecificDummyCaster(InitializeDummyCasterUnit(), abilityId, abilityOrderId));

      return DummyUnitByAbility[abilityId];
    }

    /// <summary>
    /// Gets a dummy caster that lasts for longer than an instant. Can be used to cast spells that need time to execute,
    /// like a spell with a casting time or channel duration.
    /// </summary>
    public static LongLivedDummyCaster GetLongLivedDummyCaster() => new(UnitTypeId);

    private static unit InitializeDummyCasterUnit()
    {
      var dummyUnit = CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), UnitTypeId, 0, 0, 0);
      
      UnitType.Register(new UnitType(FourCC("u00X"))
      {
        NeverDelete = true
      });
      return dummyUnit;
    }
  }
}