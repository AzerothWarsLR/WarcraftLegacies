using System;
using MacroTools;
using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Spells.Slipstream
{
  /// <summary>
  /// Channel a portal between two locations.
  /// </summary>
  public sealed class SlipstreamPortalChannel : Channel
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
    /// A function that tells the <see cref="SlipstreamPortalChannel"/> how to refund its cost to its caster if necessary.
    /// </summary>
    public Action<unit>? RefundFunc { get; init; }

    /// <summary>
    /// The color of the created portals.
    /// </summary>
    public Color Color { get; init; } = new(255, 255, 255, 255);

    private unit? _portalOrigin;
    private unit? _portalDestination;
    private SlipstreamPortalBuff? _portalOriginBuff;
    private SlipstreamPortalBuff? _portalDestinationBuff;
    private readonly Point _origin;
    private readonly Point _target;

    /// <summary>
    /// Initializes a new instance of the <see cref="SlipstreamPortalChannel"/> class.
    /// </summary>
    /// <param name="caster"><inheritdoc /></param>
    /// <param name="spellId"><inheritdoc /></param>
    /// <param name="origin">The position of the portal that spawns near the caster.</param>
    /// <param name="target">The destination point of the portal.</param>
    public SlipstreamPortalChannel(unit caster, int spellId, Point origin, Point target) : base(caster, spellId)
    {
      _target = target;
      _origin = origin;
    }
    
    /// <inheritdoc />
    public override void OnCreate()
    {
      var portalOrigin = CreateUnit(Caster.Owner, PortalUnitTypeId, _origin.X, _origin.Y, Caster.Facing - 180);
      portalOrigin.WaygateActive = true;
      portalOrigin.WaygateDestinationX = _target.X;
      portalOrigin.WaygateDestinationY = _target.Y;
      portalOrigin.SetVertexColor(Color.Red, Color.Green, Color.Blue, Color.Alpha);
      _portalOrigin = portalOrigin;
      _portalOriginBuff = new SlipstreamPortalBuff(Caster, _portalOrigin);
      BuffSystem.Add(_portalOriginBuff);
      _portalOriginBuff.Open(OpeningDelay);

      var portalDestination = CreateUnit(Caster.Owner, PortalUnitTypeId, _target.X, _target.Y, Caster.Facing);
      Point destination = new Point(_origin.X, _origin.Y);
      portalDestination.WaygateActive = true;
      portalDestination.WaygateDestinationX = destination.X;
      portalDestination.WaygateDestinationY = destination.Y;
      portalDestination.SetVertexColor(Color.Red, Color.Green, Color.Blue, Color.Alpha);
      _portalDestination = portalDestination;
      _portalDestinationBuff = new SlipstreamPortalBuff(Caster, _portalDestination)
      {
        RefundFunc = RefundFunc
      };
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