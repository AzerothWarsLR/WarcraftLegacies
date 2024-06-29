using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.SpellSystem
{
  public interface IStartChannelEffect
  {
    /// <summary>
    /// An effect that occurs when the spell starts channeling.
    /// </summary>
    public void OnStartChannel(unit caster, Point targetPoint);
  }
}