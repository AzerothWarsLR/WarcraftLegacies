using MacroTools.Extensions;
using MacroTools.Sound;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.Goblins
{
  /// <summary>
  /// Fire a giant delayed nuke, with a warning signal placed down beforehand.
  /// </summary>
  public sealed class NuclearLaunch : Spell, IStartChannelEffect
  {
    public required float CastTime { get; init; }
    
    public required int NuclearWarningUnitTypeId { get; init; }
    
    public required string WarningSoundPath { get; init; }
    
    /// <summary>
    /// Unit type ID for the unit to be left behind for a bit after the spell casts.
    /// </summary>
    public required int DummyNukeLeftOverId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="NuclearLaunch"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    public NuclearLaunch(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var dummyNukeLeftover = CreateUnit(caster.OwningPlayer(), DummyNukeLeftOverId, targetPoint.X, targetPoint.Y, 0);
      UnitApplyTimedLife(dummyNukeLeftover, 0, 3);
      dummyNukeLeftover.IssueOrder(OrderId("flamestrike"), targetPoint);
    }
    
    /// <inheritdoc />
    public void OnStartChannel(unit caster, Point targetPoint)
    {
      var sound = SoundUtils.CreateNormalSound(WarningSoundPath);
      StartSound(sound);
      var dummyNukeWarning =
        CreateUnit(caster.OwningPlayer(), NuclearWarningUnitTypeId, targetPoint.X, targetPoint.Y, 0);
      
      UnitApplyTimedLife(dummyNukeWarning, 0, CastTime);
    }
  }
}