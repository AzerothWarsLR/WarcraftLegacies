using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class TreeOfRenewal : Spell
{
  public required int TreeTypeId { get; init; }

  public required float Duration { get; init; }

  public required LeveledAbilityField<float> TreeLife { get; init; }

  public required List<int> AuraAbilityIds { get; init; }

  public float TreeScale { get; init; } = 1f;

  public float GrowSeconds { get; init; } = 1.5f;

  public string GlowEffect { get; init; } = @"Abilities\Spells\NightElf\Rejuvenation\RejuvenationTarget.mdl";

  public string BirthEffect { get; init; } = @"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl";

  public TreeOfRenewal(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var tree = unit.Create(caster.Owner, TreeTypeId, targetPoint.X, targetPoint.Y, GetRandomReal(0, 360));
    foreach (var auraAbilityId in AuraAbilityIds)
    {
      tree.SetAbilityLevel(auraAbilityId, level);
    }

    var life = TreeLife.GetValue(level);
    tree.MaxLife = (int)life;
    tree.Life = life;
    tree.SetTimedLife(Duration);

    effect.Create(BirthEffect, targetPoint.X, targetPoint.Y).Dispose();
    var glow = effect.Create(GlowEffect, tree, "origin");
    PlayerUnitEvents.Register(UnitEvent.Dies, () => glow.Dispose(), tree);

    GrowFromGround(tree, TreeScale, GrowSeconds);
  }

  private static void GrowFromGround(unit whichUnit, float finalScale, float seconds)
  {
    var elapsed = 0f;
    whichUnit.SetScale(0.05f, 0.05f, 0.05f);
    PeriodicEvents.AddPeriodicEvent(() =>
    {
      elapsed += PeriodicEvents.SYSTEM_INTERVAL;
      var scale = Math.Max(0.05f, finalScale * Math.Min(1f, elapsed / seconds));
      whichUnit.SetScale(scale, scale, scale);
      return elapsed < seconds && whichUnit.Alive;
    }, PeriodicEvents.SYSTEM_INTERVAL);
  }
}
