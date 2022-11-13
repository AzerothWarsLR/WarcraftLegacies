using MacroTools.ChannelSystem;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells.Slipstream
{
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
    /// Initializes a new instance of the <see cref="SlipstreamSpell"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    public SlipstreamSpell(int id) : base(id)
    {
    }

    /// <inheritdoc/>
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      ChannelManager.Add(new SlipstreamPortalChannel(caster, Id, targetPoint)
      {
        Active = true,
        PortalUnitTypeId = PortalUnitTypeId,
        OpeningDelay = OpeningDelay,
        ClosingDelay = ClosingDelay
      });
    }
  }
}