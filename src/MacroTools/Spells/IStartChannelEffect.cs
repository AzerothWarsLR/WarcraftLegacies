using WCSharp.Shared.Data;

namespace MacroTools.Spells;

public interface IStartChannelEffect
{
  /// <summary>
  /// An effect that occurs when the spell starts channeling.
  /// </summary>
  public void OnStartChannel(unit caster, Point targetPoint);
}
