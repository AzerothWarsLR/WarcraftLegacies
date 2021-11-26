using System.Collections.Generic;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.ObjectFactory
{
  public class ArtModel
  {
    public float Scale { get; set; } = 1;
    public string Path { get; set; } = "";
    public float BlendTime { get; set; } = 0;
    public float CastBackswing { get; set; } = 0;
    public float CastPoint { get; set; } = 0;
    public float RunSpeed { get; set; } = 0;
    public float WalkSpeed { get; set; } = 0;
    public float DeathTime { get; set; } = 0;
    public int ElevationSamplePoints { get; set; } = 0;
    public float ElevationSampleRadius { get; set; } = 0;
    public bool HasWaterShadow { get; set; } = false;
    public float MaximumPitchAngle { get; set; } = 0;
    public float MaximumRollAngle { get; set; } = 0;
    public float OccluderHeight { get; set; } = 0;
    public float ProjectileImpactZ { get; set; } = 0;
    public float ProjectileImpactZSwimming { get; set; } = 0;
    public float ProjectileLaunchX { get; set; } = 0;
    public float ProjectileLaunchY { get; set; } = 0;
    public float ProjectileLaunchZ { get; set; } = 0;
    public float ProjectileLaunchZSwimming { get; set; } = 0;
    public float PropulsionWindow { get; set; } = 0;
    public bool ScaleProjectiles { get; set; } = true;
    public float SelectionCircleHeight { get; set; } = 0;
    public bool SelectionCircleOnWater { get; set; } = false;
    public Shadow Shadow { get; set; } = new();
    /// <summary>
    /// Blood particles.
    /// </summary>
    public IEnumerable<string> Special { get; set; }
    public ArmorType ArmorType { get; set; } = ArmorType.Flesh;
    public float AttackAnimationBackswingPoint { get; set; } = 0;
    public float AttackAnimationDamagePoint { get; set; } = 0;
    public float TurnRate { get; set; } = 0.6f;
    public Tint Tint { get; set; } = new Tint(255, 255, 255);
    public bool AllowCustomTeamColor { get; set; }
    public int OrientationInterpolation { get; set; }
    public IEnumerable<string> RequiredAnimationNames { get; set; }
    public IEnumerable<string> RequiredAnimationNamesAttachments { get; set; }
    public TeamColor TeamColor { get; set; }
    public IEnumerable<string> RequiredAttachmentLinkNames { get; set;}
    public IEnumerable<string> RequiredBoneNames { get; set; }
    public float SelectionScale { get; set; }
  }
}