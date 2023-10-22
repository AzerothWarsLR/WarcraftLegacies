using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.SpellSystem
{
  public static class DummyCasterManager
  {
    private static GlobalDummyCaster? _globalDummyCaster;
    private static readonly Dictionary<int, AbilitySpecificDummyCaster> DummyUnitByAbility = new();

    public static int UnitTypeId { get; } = FourCC("u00X");

    /// <summary>Gets a dummy caster that can be used to cast any spell.</summary>
    public static GlobalDummyCaster GetGlobalDummyCaster() => _globalDummyCaster ??= new GlobalDummyCaster(InitializeDummyCasterUnit());

    /// <summary>
    /// Gets a dummy caster that should only ever cast the specified dummy spell.
    /// <para>Prefer using <see cref="GetGlobalDummyCaster"/> unless you have a special reason to use this one.</para>
    /// </summary>
    public static AbilitySpecificDummyCaster GetAbilitySpecificDummyCaster(int abilityId)
    {
      if (!DummyUnitByAbility.ContainsKey(abilityId)) 
        DummyUnitByAbility.Add(abilityId, new AbilitySpecificDummyCaster(InitializeDummyCasterUnit(), abilityId));

      return DummyUnitByAbility[abilityId];
    }
    
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