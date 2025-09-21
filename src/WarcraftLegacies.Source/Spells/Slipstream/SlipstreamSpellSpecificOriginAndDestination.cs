using MacroTools.ChannelSystem;
using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.Slipstream;

/// <summary>
/// Channel a portal from a predetermined location to another one.
/// </summary>
public sealed class SlipstreamSpellSpecificOriginAndDestination : Spell
{
  /// <summary>
  /// The unit to spawn to act as the actual portal.
  /// </summary>
  public required int PortalUnitTypeId { get; init; }

  /// <summary>
  /// The portal won't be useable until the caster has channeled for this long.
  /// </summary>
  public required float OpeningDelay { get; init; }

  /// <summary>
  /// It takes this long for the portal to close after the caster stops channeling.
  /// </summary>
  public required float ClosingDelay { get; init; }

  /// <summary>
  /// The origin of any portal created by this spell.
  /// </summary>
  public required Point OriginLocation { get; init; }

  /// <summary>
  /// The destination of any portal created by this spell.
  /// </summary>
  public required Point TargetLocation { get; init; }

  /// <summary>
  /// The color of the created portals.
  /// </summary>
  public Color Color { get; init; } = new(255, 255, 255, 255);

  /// <summary>
  /// Initializes a new instance of the <see cref="SlipstreamSpell"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc /></param>
  public SlipstreamSpellSpecificOriginAndDestination(int id) : base(id)
  {
  }

  /// <inheritdoc/>
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    ChannelManager.Add(new SlipstreamPortalChannel(caster, Id, OriginLocation, TargetLocation)
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
    caster.IssueOrder("stop");
    Refund(caster);
  }

  private void Refund(unit whichUnit)
  {
    whichUnit.RestoreMana(whichUnit.GetAbilityManaCost(Id, GetAbilityLevel(whichUnit)));
    whichUnit.EndAbilityCooldown(Id);
  }
}
