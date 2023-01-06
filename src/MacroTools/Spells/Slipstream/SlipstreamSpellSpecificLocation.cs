using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells.Slipstream
{
  /// <summary>
  /// Channel a portal to a predetermined location.
  /// </summary>
  public sealed class SlipstreamSpellSpecificLocation : Spell
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
    /// How far away the caster the portal should be placed.
    /// </summary>
    public int PortalOffset { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SlipstreamSpell"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    public SlipstreamSpellSpecificLocation(int id) : base(id)
    {
    }

    /// <inheritdoc/>
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      ChannelManager.Add(new SlipstreamPortalChannel(caster, Id, TargetLocation)
      {
        Active = true,
        PortalUnitTypeId = PortalUnitTypeId,
        OpeningDelay = OpeningDelay,
        ClosingDelay = ClosingDelay,
        Color = Color,
        PortalOffset = PortalOffset
      });
    }

    /// <inheritdoc/>
    public override void OnStartCast(unit caster, unit target, Point targetPoint)
    {
      if (IsTerrainPathable(targetPoint.X, targetPoint.Y, PATHING_TYPE_WALKABILITY) 
          || WCSharp.Shared.Util.DistanceBetweenPoints(GetUnitX(caster), GetUnitY(caster), TargetLocation.X, TargetLocation.Y) < 500
          || InstanceSystem.GetPointInstance(caster.GetPosition()) != InstanceSystem.GetPointInstance(targetPoint)) 
        Refund(caster);
    }

    private void Refund(unit whichUnit)
    {
      whichUnit.IssueOrder("stop");
      whichUnit.RestoreMana(BlzGetUnitAbilityManaCost(whichUnit, Id, GetAbilityLevel(whichUnit)));
      BlzEndUnitAbilityCooldown(whichUnit, Id);
    }
  }
}