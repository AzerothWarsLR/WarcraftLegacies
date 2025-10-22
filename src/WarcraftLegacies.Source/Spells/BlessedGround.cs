using System;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class BlessedGroundSpell : Spell
{
  public float HealPerSecond { get; init; }
  public float InitialHeal { get; init; }
  public float MaxInitialHeal { get; set; }
  public float Duration { get; init; }
  public float Radius { get; init; }
  public string HealEffectPath { get; init; }
  public float MaxHealingOverTime { get; set; }

  public BlessedGroundSpell(int id) : base(id) { }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var healingData = new BlessedGroundHealingData
      {
        TotalHealingDone = 0,
        HealingOverTimeDone = 0,
        EffectDuration = Duration,
        HealPerSecond = HealPerSecond,
        InitialHeal = InitialHeal,
        MaxInitialHeal = MaxInitialHeal,
        MaxHealingOverTime = MaxHealingOverTime,
        TargetPoint = targetPoint,
        Caster = caster,
        Radius = Radius,
        HealEffectPath = HealEffectPath
      };

      ApplyInitialHealing(healingData);
      TimerUtils.StartRepeatingTimer(healingData, ApplyHealing);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to cast BlessedGround: {ex}");
    }
  }

  private static void ApplyInitialHealing(BlessedGroundHealingData data)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(data.TargetPoint, data.Radius))
    {
      if (!IsValidTarget(data.Caster, unit))
      {
        continue;
      }

      if (data.TotalHealingDone >= data.MaxInitialHeal)
      {
        break;
      }

      unit.Life += data.InitialHeal;
      data.TotalHealingDone += data.InitialHeal;

      if (!string.IsNullOrEmpty(data.HealEffectPath))
      {
        EffectSystem.Add(effect.Create(data.HealEffectPath, unit.X, unit.Y), 1.0f);
      }
    }
  }

  public static void ApplyHealing(BlessedGroundHealingData data)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(data.TargetPoint, data.Radius))
    {
      if (!IsValidTarget(data.Caster, unit))
      {
        continue;
      }

      if (data.HealingOverTimeDone >= data.MaxHealingOverTime)
      {
        break;
      }

      unit.Life += data.HealPerSecond;
      data.HealingOverTimeDone += data.HealPerSecond;

      if (!string.IsNullOrEmpty(data.HealEffectPath))
      {
        EffectSystem.Add(effect.Create(data.HealEffectPath, unit.X, unit.Y), 1.0f);
      }
    }
  }

  private static bool IsValidTarget(unit caster, unit target)
  {
    return target.Alive &&
           target.IsAllyTo(caster.Owner) &&
           !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient);
  }
}

public class BlessedGroundHealingData
{
  public float TotalHealingDone { get; set; }
  public float HealingOverTimeDone { get; set; }
  public float EffectDuration { get; set; }
  public float HealPerSecond { get; set; }
  public float InitialHeal { get; set; }
  public float MaxInitialHeal { get; set; }
  public float MaxHealingOverTime { get; set; }
  public Point TargetPoint { get; set; }
  public unit Caster { get; set; }
  public float Radius { get; set; }
  public string HealEffectPath { get; set; } = string.Empty;
  public float CurrentDuration { get; set; }
  public int CurrentTick { get; set; }
}

public static class TimerUtils
{
  public static void StartRepeatingTimer(BlessedGroundHealingData data, Action<BlessedGroundHealingData> applyHealing)
  {
    timer timer = timer.Create();
    timer.Start(1.0f, true, () =>
    {
      data.CurrentTick++;
      data.CurrentDuration += 1.0f;

      if (data.CurrentDuration > data.EffectDuration || data.HealingOverTimeDone >= data.MaxHealingOverTime)
      {
        timer.Pause();
        timer.Dispose();
        return;
      }

      applyHealing(data);
    });
  }
}
