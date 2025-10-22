using System;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Creates a Mirror Image (Illusion) of the casting unit, with level-based scaling.
/// </summary>
public sealed class PhantomStep : Spell
{
  /// <summary>
  /// Visual effect played when the spell is cast.
  /// </summary>
  public string CasterEffect { get; init; } = string.Empty;

  /// <summary>
  /// The dummy ability used to create the illusion.
  /// </summary>
  public int DummyAbilityId { get; init; }

  /// <summary>
  /// Order ID of the dummy ability.
  /// </summary>
  public int DummyOrderId { get; init; }

  // Scaling fields
  /// <summary>
  /// Base number of illusions created by the spell.
  /// </summary>
  public int IllusionCountBase { get; init; } = 1;

  /// <summary>
  /// Additional illusions per level of the spell.
  /// </summary>
  public int IllusionCountPerLevel { get; init; } = 0;

  /// <summary>
  /// Base duration of the created illusions (in seconds).
  /// </summary>
  public float IllusionDurationBase { get; init; } = 5f;

  /// <summary>
  /// Additional duration per level of the spell (in seconds).
  /// </summary>
  public float IllusionDurationPerLevel { get; init; } = 1f;

  /// <summary>
  /// Base scaling factor for the special effect.
  /// </summary>
  public float EffectScaleBase { get; init; } = 1.0f;

  /// <summary>
  /// Additional effect scaling factor per level.
  /// </summary>
  public float EffectScalePerLevel { get; init; } = 0.5f;

  /// <inheritdoc />
  public PhantomStep(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var casterLevel = GetAbilityLevel(caster);
      var illusionCount = IllusionCountBase + (IllusionCountPerLevel * (casterLevel - 1));
      var effectScale = EffectScaleBase + (EffectScalePerLevel * (casterLevel - 1));
      effect effect = effect.Create(CasterEffect, caster.X, caster.Y);
      effect.Scale = effectScale;
      effect.Dispose();
      for (var i = 0; i < illusionCount; i++)
      {
        DummyCasterManager.GetGlobalDummyCaster()
            .CastUnit(caster, DummyAbilityId, DummyOrderId, 1, caster, DummyCastOriginType.Target);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"[{nameof(PhantomStep)}] Error during spell execution: {ex}");
    }
  }
}
