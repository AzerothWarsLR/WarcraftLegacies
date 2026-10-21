using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Utils;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.FallenPrince;

/// <summary>Raises the culled dead around Stratholme as zombies that serve no one, but spare the Fallen Prince's side.</summary>
public static class CulledOutbreak
{
  private const int CulledPlayerId = 21;
  private const int GroupCount = 20;
  private const int SpawnAttempts = 10;
  private const float CenterX = 14557;
  private const float CenterY = 12392;
  private const float MinRadius = 300;
  private const float MaxRadius = 1500;
  private const float MarchDistance = 4000;
  private const string RiseEffect = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl";

  /// <summary>Raises the zombies, allied to everyone on <paramref name="fallenPrince"/>'s team.</summary>
  public static void Unleash(player fallenPrince)
  {
    var culled = player.Create(CulledPlayerId);
    culled.Name = Loc.Get("The Culled");
    culled.SetState(playerstate.GivesBounty, 0);
    ControlPointManager.Instance.CaptureRedirects[culled] = fallenPrince;
    PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, () => PrepareZombie(@event.Unit),
      UNIT_U106_CULLED_ZOMBIE_FALLENPRINCE_CULLED);
    foreach (var other in WCSharp.Shared.Util.EnumeratePlayers())
    {
      if (other == culled)
      {
        continue;
      }

      var allianceState = other == fallenPrince || TeamChanges.AreTeammates(other, fallenPrince)
        ? AllianceState.Allied
        : AllianceState.Unallied;
      culled.SetAllianceState(other, allianceState);
      other.SetAllianceState(culled, allianceState);
    }

    for (var i = 0; i < GroupCount; i++)
    {
      var angle = 0f;
      var x = CenterX;
      var y = CenterY;
      for (var attempt = 0; attempt < SpawnAttempts; attempt++)
      {
        angle = GetRandomReal(0, 2 * MathEx.Pi);
        var radius = GetRandomReal(MinRadius, MaxRadius);
        x = CenterX + radius * Cos(angle);
        y = CenterY + radius * Sin(angle);
        if (!pathingtype.Walkability.GetPathable(x, y))
        {
          break;
        }
      }

      effect.Create(RiseEffect, x, y).Dispose();
      var groupSize = GetRandomInt(2, 3);
      for (var j = 0; j < groupSize; j++)
      {
        var zombie = unit.Create(culled, UNIT_U106_CULLED_ZOMBIE_FALLENPRINCE_CULLED, x, y, angle * MathEx.RadToDeg);
        PrepareZombie(zombie);
        zombie.IssueOrder(ORDER_ATTACK, x + MarchDistance * Cos(angle), y + MarchDistance * Sin(angle));
      }
    }
  }

  private static void PrepareZombie(unit zombie)
  {
    zombie.Level = 0;
    zombie.IssueOrder(ORDER_PARASITE_ON);
  }
}
