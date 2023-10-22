using static War3Api.Common;

namespace MacroTools.SpellSystem
{
  /// <summary>A dummy caster that can be used to cast any instant ability.</summary>
  public sealed class GlobalDummyCaster
  {
    private readonly unit _unit;

    public GlobalDummyCaster(unit unit)
    {
      _unit = unit;
    }
  }
}