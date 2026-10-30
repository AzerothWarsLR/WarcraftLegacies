using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>The caster swoops onto an enemy, carries it into the air, then slams it back down.</summary>
public sealed class TalonsOfSkyreeSpell : Spell
{
  private const float Interval = 0.03f;
  private const float GrabDistance = 80;
  private const float MaximumDuration = 5;

  public required LeveledAbilityField<float> Damage { get; init; }
  public required float SwoopSpeed { get; init; }
  public required float LiftDuration { get; init; }
  public required float LiftHeight { get; init; }
  public required float RiseTime { get; init; }
  public required float SlamSpeed { get; init; }
  public required int StunAbilityId { get; init; }
  public required string SlamEffectPath { get; init; }

  public TalonsOfSkyreeSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (target.IsUnitType(unittype.Structure) || target.IsUnitType(unittype.Flying))
    {
      return;
    }

    var level = GetAbilityLevel(caster);
    var released = false;
    void ReleaseOnce()
    {
      if (released)
      {
        return;
      }

      released = true;
      Release(caster);
      SetUnitFlyHeight(target, GetUnitDefaultFlyHeight(target), 0);
    }

    caster.SetPausedEx(true);
    SetUnitPathing(caster, false);
    var failsafe = timer.Create();
    failsafe.Start(MaximumDuration, false, () =>
    {
      failsafe.Dispose();
      ReleaseOnce();
    });

    var step = SwoopSpeed * Interval;
    var swoopTime = 0f;
    var swoop = timer.Create();
    swoop.Start(Interval, true, () =>
    {
      swoopTime += Interval;
      if (released || !caster.Alive || !target.Alive || swoopTime >= MaximumDuration)
      {
        swoop.Dispose();
        ReleaseOnce();
        return;
      }

      var dx = target.X - caster.X;
      var dy = target.Y - caster.Y;
      var distance = SquareRoot(dx * dx + dy * dy);
      if (distance > GrabDistance)
      {
        var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, target.X, target.Y);
        var move = step;
        if (distance - GrabDistance < step)
        {
          move = distance - GrabDistance;
        }

        caster.X = MathEx.GetPolarOffsetX(caster.X, move, angle);
        caster.Y = MathEx.GetPolarOffsetY(caster.Y, move, angle);
        return;
      }

      swoop.Dispose();
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, target, DummyCastOriginType.Target);
      Raise(caster);
      Raise(target);

      var lift = timer.Create();
      lift.Start(LiftDuration, false, () =>
      {
        lift.Dispose();
        if (released)
        {
          return;
        }

        var defaultHeight = GetUnitDefaultFlyHeight(target);
        SetUnitFlyHeight(target, defaultHeight, SlamSpeed);
        SetUnitFlyHeight(caster, GetUnitDefaultFlyHeight(caster), SlamSpeed);
        var slam = timer.Create();
        slam.Start((LiftHeight - defaultHeight) / SlamSpeed, false, () =>
        {
          slam.Dispose();
          ReleaseOnce();
          effect.Create(SlamEffectPath, target.X, target.Y).Dispose();
          if (target.Alive)
          {
            caster.DealDamage(target, Damage.GetValue(level), false, false, attacktype.Normal, damagetype.Magic,
              weapontype.WhoKnows);
          }
        });
      });
    });
  }

  private void Raise(unit whichUnit)
  {
    whichUnit.AddAbility(ABILITY_ARAV_STORM_CROW_FORM_BROWN_DRUID_OF_THE_TALON);
    whichUnit.RemoveAbility(ABILITY_ARAV_STORM_CROW_FORM_BROWN_DRUID_OF_THE_TALON);
    SetUnitFlyHeight(whichUnit, LiftHeight, LiftHeight / RiseTime);
  }

  private static void Release(unit caster)
  {
    SetUnitFlyHeight(caster, GetUnitDefaultFlyHeight(caster), 0);
    SetUnitPathing(caster, true);
    caster.SetPausedEx(false);
  }
}
