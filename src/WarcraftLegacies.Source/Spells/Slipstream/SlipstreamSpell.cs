using MacroTools.Channels;
using MacroTools.Data;
using MacroTools.Spells;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.Slipstream;

/// <summary>
/// Channel a portal to a target location.
/// </summary>
public sealed class SlipstreamSpell : Spell
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
  /// The color of the created portals.
  /// </summary>
  public Color Color { get; init; } = new(255, 255, 255, 255);

  /// <summary>
  /// How far away the caster the portal should be placed.
  /// </summary>
  public int PortalOffset { get; init; } = 200;

  /// <summary>
  /// Initializes a new instance of the <see cref="SlipstreamSpell"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc /></param>
  public SlipstreamSpell(int id) : base(id)
  {
  }

  /// <inheritdoc/>
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var (x, y) = Util.PositionWithPolarOffset(caster.X, caster.Y, PortalOffset, caster.Facing);
    ChannelManager.Add(new SlipstreamPortalChannel(caster, Id, new Point(x, y), targetPoint)
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
    if (!SlipstreamSpellHelper.IsPointValidTarget(caster, targetPoint))
    {
      return;
    }

    caster.IssueOrder("stop");
    Refund(caster);
  }

  private void Refund(unit whichUnit)
  {
    whichUnit.Mana += whichUnit.GetAbilityManaCost(Id, GetAbilityLevel(whichUnit));
    whichUnit.EndAbilityCooldown(Id);
  }
}
