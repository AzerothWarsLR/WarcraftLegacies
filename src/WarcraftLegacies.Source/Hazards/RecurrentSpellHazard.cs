using MacroTools.DummyCasters;
using MacroTools.Hazards;

namespace WarcraftLegacies.Source.Hazards;

/// <summary>
/// A <see cref="Hazard"/> that causes a particular spell to be repeatedly cast at its location.
/// </summary>
public sealed class RecurrentSpellHazard : Hazard
{
  private readonly int _dummySpellId;
  private readonly int _dummySpellOrderId;
  private readonly int _level;

  /// <inheritdoc />
  protected override void OnPeriodic()
  {
    DummyCasterManager.GetGlobalDummyCaster().CastPoint(Caster.Owner, _dummySpellId, _dummySpellOrderId, _level, Position);
  }

  /// <inheritdoc />
  public override void OnCreate()
  {
    DummyCasterManager.GetGlobalDummyCaster().CastPoint(Caster.Owner, _dummySpellId, _dummySpellOrderId, _level, Position);
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="RecurrentSpellHazard"/> class.
  /// </summary>
  public RecurrentSpellHazard(unit caster, float x, float y, int dummySpellOrderId, int level, int dummySpellId) : base(caster, x, y)
  {
    _dummySpellOrderId = dummySpellOrderId;
    _level = level;
    _dummySpellId = dummySpellId;
  }
}
