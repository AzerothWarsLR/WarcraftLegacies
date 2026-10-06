using MacroTools.Channels;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Druids.Spells.LivingWall;

public sealed class LivingWallChannel : Channel
{
  private const float GrowDuration = 0.55f;
  private const float MinScale = 0.1f;
  private const float MaxScale = 0.55f;

  public float ChannelDuration { get; init; }

  public float TargetX { get; init; }

  public float TargetY { get; init; }

  public required int TreeUnitTypeId { get; init; }

  private unit? _tree;
  private float _growElapsed;

  public LivingWallChannel(unit caster, int spellId) : base(caster, spellId)
  {
  }

  public override void OnCreate()
  {
    Duration = ChannelDuration;

    var facing = Atan2(TargetY - Caster.Y, TargetX - Caster.X) * (180f / MathEx.Pi);
    _tree = unit.Create(Caster.Owner, TreeUnitTypeId, TargetX, TargetY, facing);
    _tree.IsInvulnerable = true;
    _tree.AddType(unittype.Summoned);
    _tree.SetScale(MinScale, MinScale, MinScale);
    _tree.SetAnimation("birth");
    _tree.QueueAnimation("stand");
  }

  protected override void OnPeriodic()
  {
    if (_growElapsed >= GrowDuration || _tree == null)
    {
      return;
    }

    _growElapsed += Interval;
    var progress = _growElapsed / GrowDuration;
    if (progress > 1f)
    {
      progress = 1f;
    }

    var scale = MinScale + (MaxScale - MinScale) * progress;
    _tree.SetScale(scale, scale, scale);
  }

  protected override void OnDispose()
  {
    Caster.IssueOrder("stop");

    if (_tree != null)
    {
      _tree.IsInvulnerable = false;
      _tree.Kill();
      _tree = null;
    }
  }
}
