using System;
using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class PhantomStep : Spell
  {
    public required LeveledAbilityField<float> IllusionDuration { get; init; }
    public required LeveledAbilityField<int> IllusionHealth { get; init; }
    public required LeveledAbilityField<int> IllusionDamage { get; init; }
    public string Effect { get; init; } = @"Abilities\Spells\Orc\MirrorImage\MirrorImageCaster.mdl";
    public float EffectScale { get; init; } = 1.25f;

    public PhantomStep(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        // Get ability level
        var level = GetAbilityLevel(caster);

        // Trigger visual effect
        var effect = AddSpecialEffect(Effect, GetUnitX(caster), GetUnitY(caster));
        BlzSetSpecialEffectScale(effect, EffectScale);
        DestroyEffect(effect);

        // Spawn the illusion
        CreateIllusion(caster, level);

        Console.WriteLine($"Phantom Step successfully cast at level {level}.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error while executing Phantom Step: {ex}");
      }
    }

    private void CreateIllusion(unit caster, int level)
    {
      var illusionX = GetUnitX(caster) + 25;
      var illusionY = GetUnitY(caster) + 25;

      // Create the illusion as a summoned unit
      var illusion = CreateUnit(
        GetOwningPlayer(caster),
        GetUnitTypeId(caster),
        illusionX,
        illusionY,
        GetUnitFacing(caster)
      );
      UnitAddType(illusion, UNIT_TYPE_SUMMONED); // Mark as summoned

      // Customize illusion's health
      BlzSetUnitRealField(illusion, UNIT_RF_HP, IllusionHealth.Base + IllusionHealth.PerLevel * level);

      // Customize illusion's attributes
      illusion
        .SetDamageBase(IllusionDamage.Base + IllusionDamage.PerLevel * level) // Adjust illusion damage
        .SetTimedLife(IllusionDuration.Base + IllusionDuration.PerLevel * level) // Set timed life
        .SetLifePercent(100); // Set illusion to full health

      // Add a visual effect near the illusion's creation point
      var effect = AddSpecialEffect(Effect, illusionX, illusionY);
      BlzSetSpecialEffectScale(effect, EffectScale);
      DestroyEffect(effect);

      Console.WriteLine($"Summoned illusion of unit {GetUnitName(caster)} with custom stats created.");
    }
  }
}