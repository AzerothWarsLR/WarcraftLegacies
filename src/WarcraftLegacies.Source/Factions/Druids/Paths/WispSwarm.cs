using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;
using Environment = MacroTools.Utils.Environment;

namespace WarcraftLegacies.Source.Factions.Druids.Paths;

/// <summary>Wisps spiral in from all around a unit and detonate on it, like at the end of the Battle of Mount Hyjal.</summary>
public sealed class WispSwarm
{
  private const string WispModel = @"units\nightelf\Wisp\Wisp.mdl";
  private const string ExplodeModel = @"Units\NightElf\Wisp\WispExplode.mdl";
  private const string ShockwaveModel = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl";
  private const string LightModel = @"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl";
  private const string GlowModel = @"Abilities\Spells\NightElf\Tranquility\TranquilityTarget.mdl";
  private const string FlashMask = @"ReplaceableTextures\CameraMasks\White_mask.blp";

  private const int WispCount = 80;
  private const int LightBlueSlot = 9;
  private const float Interval = 0.03125f;
  private const float StartRadius = 1400;
  private const float MaxDelay = 5.5f;
  private const float FlightTime = 4.5f;
  private const float AngularSpeed = 3f;
  private const float FlyHeight = 160;
  private const float FlashRange = 3000;

  private readonly unit _target;
  private readonly Action _onClimax;
  private readonly List<Wisp> _wisps = new();
  private readonly timer _timer = timer.Create();
  private effect? _glow;
  private float _elapsed;
  private int _arrived;

  private sealed class Wisp
  {
    public float Angle;
    public float Delay;
    public effect? Effect;
    public bool Done;
  }

  /// <summary>Starts the swarm on a unit, calling back once the last wisp has hit it.</summary>
  public static void Start(unit target, Action onClimax) => new WispSwarm(target, onClimax).Run();

  private WispSwarm(unit target, Action onClimax)
  {
    _target = target;
    _onClimax = onClimax;
  }

  private void Run()
  {
    _target.SetPausedEx(true);
    _glow = effect.Create(GlowModel, _target, "origin");
    for (var i = 0; i < WispCount; i++)
    {
      _wisps.Add(new Wisp
      {
        Angle = 2 * MathF.PI * i / WispCount + GetRandomReal(-0.2f, 0.2f),
        Delay = GetRandomReal(0, MaxDelay)
      });
    }

    _timer.Start(Interval, true, Tick);
  }

  private void Tick()
  {
    _elapsed += Interval;
    var centre = new Point(_target.X, _target.Y);
    foreach (var wisp in _wisps)
    {
      if (wisp.Done || _elapsed < wisp.Delay)
      {
        continue;
      }

      var progress = Math.Min((_elapsed - wisp.Delay) / FlightTime, 1);
      var radius = StartRadius * (1 - progress * progress);
      var angle = wisp.Angle + AngularSpeed * progress;
      var x = centre.X + radius * MathF.Cos(angle);
      var y = centre.Y + radius * MathF.Sin(angle);
      var z = Environment.GetPositionZ(new Point(x, y)) + FlyHeight * (0.5f + 0.5f * MathF.Sin(progress * MathF.PI));
      if (wisp.Effect == null)
      {
        wisp.Effect = effect.Create(WispModel, x, y);
        wisp.Effect.SetColor(player.Create(LightBlueSlot));
      }

      wisp.Effect.SetPosition(x, y, z);

      if (progress >= 1)
      {
        wisp.Done = true;
        wisp.Effect.Dispose();
        effect.Create(ExplodeModel, x, y).Dispose();
        _arrived++;
      }
    }

    if (_arrived == WispCount)
    {
      Climax(centre);
    }
  }

  private void Climax(Point centre)
  {
    _timer.Dispose();
    _glow?.Dispose();
    _target.SetPausedEx(false);

    var shockwave = effect.Create(ShockwaveModel, centre.X, centre.Y);
    shockwave.Scale = 3;
    shockwave.Dispose();
    effect.Create(LightModel, centre.X, centre.Y).Dispose();
    Flash(centre);
    _onClimax();
  }

  private static void Flash(Point centre)
  {
    var dx = GetCameraTargetPositionX() - centre.X;
    var dy = GetCameraTargetPositionY() - centre.Y;
    if (dx * dx + dy * dy > FlashRange * FlashRange)
    {
      return;
    }

    SetCineFilterTexture(FlashMask);
    SetCineFilterBlendMode(blendmode.Blend);
    SetCineFilterTexMapFlags(texmapflags.None);
    SetCineFilterStartUV(0, 0, 1, 1);
    SetCineFilterEndUV(0, 0, 1, 1);
    SetCineFilterStartColor(255, 255, 255, 255);
    SetCineFilterEndColor(255, 255, 255, 0);
    SetCineFilterDuration(1.5f);
    DisplayCineFilter(true);
  }
}
