using MacroTools.ChannelSystem;
using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.SpellSystem;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.Slipstream;

/// <summary>
/// Channel a portal to a predetermined location.
/// </summary>
public sealed class SlipstreamSpellSpecificDestination : Spell
{
  /// <summary>
  /// The unit to spawn to act as the actual portal.
  /// </summary>
  public int PortalUnitTypeId { get; init; }

  /// <summary>
  /// The portal won't be useable until the caster has channeled for this long.
  /// </summary>
  public float OpeningDelay { get; init; }

  /// <summary>
  /// It takes this long for the portal to close after the caster stops channeling.
  /// </summary>
  public float ClosingDelay { get; init; }

  /// <summary>
  /// The destination of any portal created by this spell.
  /// </summary>
  public Point TargetLocation { get; init; } = new(0, 0);

  /// <summary>
  /// The color of the created portals.
  /// </summary>
  public Color Color { get; init; } = new(255, 255, 255, 255);

  /// <summary>
  /// Initializes a new instance of the <see cref="SlipstreamSpell"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc /></param>
  public SlipstreamSpellSpecificDestination(int id) : base(id)
  {
  }

  /// <inheritdoc/>
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (!IsPointValidTarget(caster, targetPoint))
    {
      return;
    }

    var spellTarget = new Point(GetSpellTargetX(), GetSpellTargetY());
    ChannelManager.Add(new SlipstreamPortalChannel(caster, Id, spellTarget, TargetLocation)
    {
      Active = true,
      PortalUnitTypeId = PortalUnitTypeId,
      OpeningDelay = OpeningDelay,
      ClosingDelay = ClosingDelay,
      Color = Color,
      RefundFunc = Refund
    });
  }

  /// <inheritdoc/>
  public override void OnStartCast(unit caster, unit target, Point targetPoint)
  {
    if (IsPointValidTarget(caster, targetPoint))
    {
      return;
    }

    IssueImmediateOrder(caster, "stop");
    Refund(caster);
  }

  private void Refund(unit whichUnit)
  {
    whichUnit.RestoreMana(BlzGetUnitAbilityManaCost(whichUnit, Id, GetAbilityLevel(whichUnit)));
    BlzEndUnitAbilityCooldown(whichUnit, Id);
  }

  private bool IsPointValidTarget(unit caster, Point targetPoint) =>
    !IsTerrainPathable(targetPoint.X, targetPoint.Y, PATHING_TYPE_WALKABILITY)
    && !(Util.DistanceBetweenPoints(GetUnitX(caster), GetUnitY(caster), TargetLocation.X, TargetLocation.Y) < 500)
    && InstanceSystem.GetPointInstance(caster.GetPosition()) == InstanceSystem.GetPointInstance(targetPoint);
}
