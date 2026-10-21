using System;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Setup;

/// <summary>Dresses up Nordrassil with floating lights, and leaves its charred remains standing if it is destroyed.</summary>
public static class NordrassilSetup
{
  private const string LightsModel = @"war3mapImported\Prop_AshenvaleLights.mdl";
  private const string TreeModel = @"Doodads\Ashenvale\Structures\Worldtree\Worldtree.mdl";
  private const string SmokeModel = @"Doodads\LordaeronSummer\Props\SmokeSmudge\SmokeSmudge.mdl";
  private const string FireModel = @"Environment\LargeBuildingFire\LargeBuildingFire1.mdl";
  private const string EmberModel = @"Environment\SmallBuildingFire\SmallBuildingFire2.mdl";
  private const float LightsX = -9686;
  private const float LightsY = 11374;
  private const float LightsZ = 940;
  private const float LightsScale = 2.05f;
  private const float TreeScale = 0.5f;
  private const int CharredRed = 40;
  private const int CharredGreen = 36;
  private const int CharredBlue = 34;
  private const float BurnDuration = 60;
  private const int ScorchedRadius = 6;
  private const float SmokeDistance = 220;
  private const float RemovalDelay = 1;

  private static readonly int _scorchedGround = FourCC("Ndrt");

  private static effect? _lights;

  public static void Setup()
  {
    _lights = effect.Create(LightsModel, LightsX, LightsY);
    _lights.SetPosition(LightsX, LightsY, LightsZ);
    _lights.Scale = LightsScale;

    var nordrassil = AllLegends.Druids.Nordrassil.Unit;
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(nordrassil, unitevent.Death);
    deathTrigger.AddAction(() => LeaveRemains(nordrassil));
  }

  private static void LeaveRemains(unit nordrassil)
  {
    if (_lights != null)
    {
      _lights.SetAlpha(0);
      _lights.Scale = 0;
      _lights.Dispose();
      _lights = null;
    }

    var x = nordrassil.X;
    var y = nordrassil.Y;
    var remains = effect.Create(TreeModel, x, y);
    remains.Scale = TreeScale;
    remains.SetYaw(nordrassil.Facing * MathF.PI / 180);
    remains.SetColor(CharredRed, CharredGreen, CharredBlue);

    SetTerrainType(x, y, _scorchedGround, -1, ScorchedRadius, 0);
    for (var i = 0; i < 3; i++)
    {
      var angle = i * 2 * MathF.PI / 3;
      var nearX = x + SmokeDistance * MathF.Cos(angle);
      var nearY = y + SmokeDistance * MathF.Sin(angle);
      effect.Create(SmokeModel, nearX, nearY);
      effect.Create(EmberModel, x + SmokeDistance * 0.5f * MathF.Cos(angle + 1), y + SmokeDistance * 0.5f * MathF.Sin(angle + 1));
      var fire = effect.Create(FireModel, nearX, nearY);
      var fireTimer = timer.Create();
      fireTimer.Start(BurnDuration, false, () =>
      {
        fire.Dispose();
        fireTimer.Dispose();
      });
    }

    nordrassil.IsVisible = false;
    var cleanup = timer.Create();
    cleanup.Start(RemovalDelay, false, () =>
    {
      nordrassil.Dispose();
      cleanup.Dispose();
    });
  }
}
