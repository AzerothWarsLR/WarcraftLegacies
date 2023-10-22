using static War3Api.Common;

namespace MacroTools.SpellSystem
{
  /// <summary>A dummy caster that has been predefined to only ever cast one specific instant ability.</summary>
  public sealed class AbilitySpecificDummyCaster
  {
    private readonly unit _unit;
    private readonly int _abilityTypeId;

    public AbilitySpecificDummyCaster(unit unit, int abilityTypeId)
    {
      _unit = unit;
      _abilityTypeId = abilityTypeId;
    }
  }
}