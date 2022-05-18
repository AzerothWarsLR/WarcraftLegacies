using WCSharp.Buffs;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.Buffs
{
  public sealed class DarkConversionBuff : PassiveBuff
  {
    /// <summary>
    /// The unit type to transform the target into.
    /// </summary>
    public int TransformUnitTypeId { get; init; } = FourCC("hfoo");

    /// <summary>
    /// The effect that appears when the unit transforms.
    /// </summary>
    public string TransformEffect { get; init; } = @"Abilities\Spells\Demon\DarkConversion\ZombifyTarget.mdl";

    /// <summary>
    /// The ability that gets given to the unit when it finishes transforming.
    /// </summary>
    public int DiseaseCloudAbilityId { get; init; }

    /// <summary>
    /// The player that should own the unit after it has been converted.
    /// </summary>
    private player ZombieOwningPlayer { get; }

    public DarkConversionBuff(player caster, unit target) : base(target, target)
    {
      ZombieOwningPlayer = caster;
      if (EffectString == null)
      {
        EffectString = @"Abilities\Spells\Undead\Sleep\SleepTarget.mdl";
      }

      if (EffectAttachmentPoint == null)
      {
        EffectAttachmentPoint = "overhead";
      }
    }

    public override void OnApply()
    {
      PauseUnit(Target, true);
    }

    public override void OnDispose()
    {
      DestroyEffect(AddSpecialEffect(TransformEffect, GetUnitX(Target), GetUnitY(Target)));
      var zombie = ReplaceUnitBJ(Target, TransformUnitTypeId, bj_UNIT_STATE_METHOD_MAXIMUM);
      UnitAddAbility(zombie, DiseaseCloudAbilityId);
      SetUnitOwner(zombie, ZombieOwningPlayer, true);
    }
  }
}