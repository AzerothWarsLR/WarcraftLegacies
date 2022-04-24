using System;
using System.Collections.Generic;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  /// <summary>
  ///   Passively applies a buff to the ability holder.
  ///   Otherwise has no effect at all.
  /// </summary>
  public sealed class EffectlessAuraFactory : PassiveAbilityFactory<AuraSlow>
  {
    public string AttachmentPoint { get; init; } = "overhead";
    public string TextTooltipExtended { get; init; } = "This buff does some cool but unspecified stuff.";

    /// <summary>
    ///   If true, the buff tooltip will be green. Otherwise it will be red.
    /// </summary>
    public bool IsPositive { get; init; }

    public Buff GenerateBuff(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newBuff = new Buff(BuffType.AuraSlow, newRawCode, objectDatabase)
      {
        TextNameEditorOnly = TextName,
        TextTooltip = IsPositive ? $"|cff00ff00{TextName}" : TextName,
        TextTooltipExtended = TextTooltipExtended,
        ArtIcon = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp",
        ArtEffectAttachmentPoint = Array.Empty<string>(),
        ArtTarget = Array.Empty<string>()
      };
      return newBuff;
    }

    protected override void ApplyStats(AuraSlow ability)
    {
      for (var i = 0; i < Levels; i++)
      {
        ability.StatsTargetsAllowed[i + 1] = new List<Target> {Target.Self};
        ability.StatsAreaOfEffect[i + 1] = 5;
        ability.DataMovementSpeedFactor[i + 1] = 0;
      }
    }

    public AuraSlow Generate(string abilityRawCode, Buff buff, ObjectDatabase objectDatabase)
    {
      var ability = Generate(abilityRawCode, objectDatabase);
      for (var i = 0; i < Levels; i++) ability.StatsBuffs[i + 1] = new List<Buff> {buff};
      return ability;
    }

    public override AuraSlow Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new AuraSlow(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}