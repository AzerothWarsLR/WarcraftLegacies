using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells.Slipstream
{
  /// <summary>
  /// Channel a portal between two locations.
  /// </summary>
  public sealed class SlipstreamPortalChannel : Channel
  {
    private readonly Point _target;
    
    /// <inheritdoc />
    public override bool Active { get; set; }
    
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
    
    private unit? _portalOrigin;
    private unit? _portalDestination;
    private SlipstreamPortalBuff? _portalOriginBuff;
    private SlipstreamPortalBuff? _portalDestinationBuff;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SlipstreamPortalChannel"/> class.
    /// </summary>
    /// <param name="caster"><inheritdoc /></param>
    /// <param name="spellId"><inheritdoc /></param>
    /// <param name="target">The destination point of the portal.</param>
    public SlipstreamPortalChannel(unit caster, int spellId, Point target) : base(caster, spellId)
    {
      _target = target;
    }
    
    /// <inheritdoc />
    public override void OnCreate()
    {
      var casterPosition = WCSharp.Shared.Util.PositionWithPolarOffset(GetUnitX(Caster), GetUnitY(Caster), 200, Caster.GetFacing());
      _portalOrigin = CreateUnit(Caster.OwningPlayer(), PortalUnitTypeId, casterPosition.x, casterPosition.y, Caster.GetFacing() - 180)
        .SetWaygateDestination(_target);
      _portalOriginBuff = new SlipstreamPortalBuff(Caster, _portalOrigin);
      BuffSystem.Add(_portalOriginBuff);
      _portalOriginBuff.Open(OpeningDelay);
      
      _portalDestination = CreateUnit(Caster.OwningPlayer(), PortalUnitTypeId, _target.X, _target.Y, Caster.GetFacing())
        .SetWaygateDestination(new Point(casterPosition.x, casterPosition.y));
      _portalDestinationBuff = new SlipstreamPortalBuff(Caster, _portalDestination);
      BuffSystem.Add(_portalDestinationBuff);
      _portalDestinationBuff.Open(OpeningDelay);
    }

    /// <inheritdoc />
    protected override void OnDispose()
    {
      _portalOriginBuff?.Close(ClosingDelay);
      _portalDestinationBuff?.Close(ClosingDelay);
    }
  }
}