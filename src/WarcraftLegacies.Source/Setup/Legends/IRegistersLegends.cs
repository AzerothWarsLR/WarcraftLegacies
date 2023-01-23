using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Has the ability to register multiple <see cref="Legend"/>s.
  /// </summary>
  public interface IRegistersLegends
  {
    /// <summary>
    /// Registers many <see cref="Legend"/>s.
    /// </summary>
    public void RegisterLegends();
  }
}