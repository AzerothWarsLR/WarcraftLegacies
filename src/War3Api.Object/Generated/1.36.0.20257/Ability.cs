using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public abstract class Ability : BaseObject
    {
        protected readonly LevelObjectDataModifications _modifications;
        private readonly Lazy<ObjectProperty<string>> _textTooltipNormal;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextTooltipNormalModified;
        private readonly Lazy<ObjectProperty<string>> _textTooltipTurnOff;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextTooltipTurnOffModified;
        private readonly Lazy<ObjectProperty<string>> _textTooltipNormalExtended;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextTooltipNormalExtendedModified;
        private readonly Lazy<ObjectProperty<string>> _textTooltipTurnOffExtended;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextTooltipTurnOffExtendedModified;
        private readonly Lazy<ObjectProperty<string>> _statsTargetsAllowedRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsTargetsAllowedModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Target>>> _statsTargetsAllowed;
        private readonly Lazy<ObjectProperty<float>> _statsCastingTime;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsCastingTimeModified;
        private readonly Lazy<ObjectProperty<float>> _statsDurationNormal;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsDurationNormalModified;
        private readonly Lazy<ObjectProperty<float>> _statsDurationHero;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsDurationHeroModified;
        private readonly Lazy<ObjectProperty<float>> _statsCooldown;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsCooldownModified;
        private readonly Lazy<ObjectProperty<int>> _statsManaCost;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsManaCostModified;
        private readonly Lazy<ObjectProperty<float>> _statsAreaOfEffect;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsAreaOfEffectModified;
        private readonly Lazy<ObjectProperty<float>> _statsCastRange;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsCastRangeModified;
        private readonly Lazy<ObjectProperty<string>> _statsBuffsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsBuffsModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Buff>>> _statsBuffs;
        private readonly Lazy<ObjectProperty<string>> _statsEffectsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isStatsEffectsModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Buff>>> _statsEffects;
        internal Ability(int oldId): base(oldId)
        {
            _modifications = new(this);
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _isTextTooltipNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalModified));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _isTextTooltipTurnOffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffModified));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _isTextTooltipNormalExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalExtendedModified));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _isTextTooltipTurnOffExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffExtendedModified));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _isStatsTargetsAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsTargetsAllowedModified));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _isStatsCastingTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastingTimeModified));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _isStatsDurationNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationNormalModified));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _isStatsDurationHeroModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationHeroModified));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _isStatsCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCooldownModified));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _isStatsManaCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsManaCostModified));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _isStatsAreaOfEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsAreaOfEffectModified));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _isStatsCastRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastRangeModified));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _isStatsBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsBuffsModified));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _isStatsEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsEffectsModified));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, int newId): base(oldId, newId)
        {
            _modifications = new(this);
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _isTextTooltipNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalModified));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _isTextTooltipTurnOffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffModified));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _isTextTooltipNormalExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalExtendedModified));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _isTextTooltipTurnOffExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffExtendedModified));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _isStatsTargetsAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsTargetsAllowedModified));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _isStatsCastingTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastingTimeModified));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _isStatsDurationNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationNormalModified));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _isStatsDurationHeroModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationHeroModified));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _isStatsCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCooldownModified));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _isStatsManaCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsManaCostModified));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _isStatsAreaOfEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsAreaOfEffectModified));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _isStatsCastRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastRangeModified));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _isStatsBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsBuffsModified));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _isStatsEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsEffectsModified));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _modifications = new(this);
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _isTextTooltipNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalModified));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _isTextTooltipTurnOffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffModified));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _isTextTooltipNormalExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalExtendedModified));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _isTextTooltipTurnOffExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffExtendedModified));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _isStatsTargetsAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsTargetsAllowedModified));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _isStatsCastingTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastingTimeModified));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _isStatsDurationNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationNormalModified));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _isStatsDurationHeroModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationHeroModified));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _isStatsCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCooldownModified));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _isStatsManaCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsManaCostModified));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _isStatsAreaOfEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsAreaOfEffectModified));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _isStatsCastRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastRangeModified));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _isStatsBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsBuffsModified));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _isStatsEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsEffectsModified));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, ObjectDatabaseBase db): base(oldId, db)
        {
            _modifications = new(this);
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _isTextTooltipNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalModified));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _isTextTooltipTurnOffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffModified));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _isTextTooltipNormalExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalExtendedModified));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _isTextTooltipTurnOffExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffExtendedModified));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _isStatsTargetsAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsTargetsAllowedModified));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _isStatsCastingTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastingTimeModified));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _isStatsDurationNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationNormalModified));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _isStatsDurationHeroModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationHeroModified));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _isStatsCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCooldownModified));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _isStatsManaCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsManaCostModified));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _isStatsAreaOfEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsAreaOfEffectModified));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _isStatsCastRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastRangeModified));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _isStatsBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsBuffsModified));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _isStatsEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsEffectsModified));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, int newId, ObjectDatabaseBase db): base(oldId, newId, db)
        {
            _modifications = new(this);
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _isTextTooltipNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalModified));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _isTextTooltipTurnOffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffModified));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _isTextTooltipNormalExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalExtendedModified));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _isTextTooltipTurnOffExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffExtendedModified));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _isStatsTargetsAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsTargetsAllowedModified));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _isStatsCastingTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastingTimeModified));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _isStatsDurationNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationNormalModified));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _isStatsDurationHeroModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationHeroModified));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _isStatsCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCooldownModified));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _isStatsManaCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsManaCostModified));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _isStatsAreaOfEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsAreaOfEffectModified));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _isStatsCastRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastRangeModified));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _isStatsBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsBuffsModified));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _isStatsEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsEffectsModified));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, string newRawcode, ObjectDatabaseBase db): base(oldId, newRawcode, db)
        {
            _modifications = new(this);
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _isTextTooltipNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalModified));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _isTextTooltipTurnOffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffModified));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _isTextTooltipNormalExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipNormalExtendedModified));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _isTextTooltipTurnOffExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipTurnOffExtendedModified));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _isStatsTargetsAllowedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsTargetsAllowedModified));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _isStatsCastingTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastingTimeModified));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _isStatsDurationNormalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationNormalModified));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _isStatsDurationHeroModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsDurationHeroModified));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _isStatsCooldownModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCooldownModified));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _isStatsManaCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsManaCostModified));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _isStatsAreaOfEffectModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsAreaOfEffectModified));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _isStatsCastRangeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsCastRangeModified));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _isStatsBuffsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsBuffsModified));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _isStatsEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsStatsEffectsModified));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        public LevelObjectDataModifications Modifications => _modifications;
        public string TextName
        {
            get => _modifications.GetModification(1835101793).ValueAsString;
            set => _modifications[1835101793] = new LevelObjectDataModification{Id = 1835101793, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextNameModified => _modifications.ContainsKey(1835101793);
        public string TextEditorSuffix
        {
            get => _modifications.GetModification(1718840929).ValueAsString;
            set => _modifications[1718840929] = new LevelObjectDataModification{Id = 1718840929, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextEditorSuffixModified => _modifications.ContainsKey(1718840929);
        public int StatsHeroAbilityRaw
        {
            get => _modifications.GetModification(1919248481).ValueAsInt;
            set => _modifications[1919248481] = new LevelObjectDataModification{Id = 1919248481, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsHeroAbilityModified => _modifications.ContainsKey(1919248481);
        public bool StatsHeroAbility
        {
            get => StatsHeroAbilityRaw.ToBool(this);
            set => StatsHeroAbilityRaw = value.ToRaw(null, null);
        }

        public int StatsItemAbilityRaw
        {
            get => _modifications.GetModification(1702127969).ValueAsInt;
            set => _modifications[1702127969] = new LevelObjectDataModification{Id = 1702127969, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsItemAbilityModified => _modifications.ContainsKey(1702127969);
        public bool StatsItemAbility
        {
            get => StatsItemAbilityRaw.ToBool(this);
            set => StatsItemAbilityRaw = value.ToRaw(null, null);
        }

        public string StatsRaceRaw
        {
            get => _modifications.GetModification(1667330657).ValueAsString;
            set => _modifications[1667330657] = new LevelObjectDataModification{Id = 1667330657, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsStatsRaceModified => _modifications.ContainsKey(1667330657);
        public UnitRace StatsRace
        {
            get => StatsRaceRaw.ToUnitRace(this);
            set => StatsRaceRaw = value.ToRaw(null, null);
        }

        public int ArtButtonPositionNormalX
        {
            get => _modifications.GetModification(2020631137).ValueAsInt;
            set => _modifications[2020631137] = new LevelObjectDataModification{Id = 2020631137, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionNormalXModified => _modifications.ContainsKey(2020631137);
        public int ArtButtonPositionNormalY
        {
            get => _modifications.GetModification(2037408353).ValueAsInt;
            set => _modifications[2037408353] = new LevelObjectDataModification{Id = 2037408353, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionNormalYModified => _modifications.ContainsKey(2037408353);
        public int ArtButtonPositionTurnOffX
        {
            get => _modifications.GetModification(2019718497).ValueAsInt;
            set => _modifications[2019718497] = new LevelObjectDataModification{Id = 2019718497, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionTurnOffXModified => _modifications.ContainsKey(2019718497);
        public int ArtButtonPositionTurnOffY
        {
            get => _modifications.GetModification(2036495713).ValueAsInt;
            set => _modifications[2036495713] = new LevelObjectDataModification{Id = 2036495713, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionTurnOffYModified => _modifications.ContainsKey(2036495713);
        public int ArtButtonPositionResearchX
        {
            get => _modifications.GetModification(2020635233).ValueAsInt;
            set => _modifications[2020635233] = new LevelObjectDataModification{Id = 2020635233, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionResearchXModified => _modifications.ContainsKey(2020635233);
        public int ArtButtonPositionResearchY
        {
            get => _modifications.GetModification(2037412449).ValueAsInt;
            set => _modifications[2037412449] = new LevelObjectDataModification{Id = 2037412449, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionResearchYModified => _modifications.ContainsKey(2037412449);
        public string ArtIconNormalRaw
        {
            get => _modifications.GetModification(1953653089).ValueAsString;
            set => _modifications[1953653089] = new LevelObjectDataModification{Id = 1953653089, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtIconNormalModified => _modifications.ContainsKey(1953653089);
        public string ArtIconNormal
        {
            get => ArtIconNormalRaw.ToString(this);
            set => ArtIconNormalRaw = value.ToRaw(null, null);
        }

        public string ArtIconTurnOffRaw
        {
            get => _modifications.GetModification(1918989665).ValueAsString;
            set => _modifications[1918989665] = new LevelObjectDataModification{Id = 1918989665, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtIconTurnOffModified => _modifications.ContainsKey(1918989665);
        public string ArtIconTurnOff
        {
            get => ArtIconTurnOffRaw.ToString(this);
            set => ArtIconTurnOffRaw = value.ToRaw(null, null);
        }

        public string ArtIconResearchRaw
        {
            get => _modifications.GetModification(1918988897).ValueAsString;
            set => _modifications[1918988897] = new LevelObjectDataModification{Id = 1918988897, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtIconResearchModified => _modifications.ContainsKey(1918988897);
        public string ArtIconResearch
        {
            get => ArtIconResearchRaw.ToString(this);
            set => ArtIconResearchRaw = value.ToRaw(null, null);
        }

        public string ArtCasterRaw
        {
            get => _modifications.GetModification(1952539489).ValueAsString;
            set => _modifications[1952539489] = new LevelObjectDataModification{Id = 1952539489, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtCasterModified => _modifications.ContainsKey(1952539489);
        public IEnumerable<string> ArtCaster
        {
            get => ArtCasterRaw.ToIEnumerableString(this);
            set => ArtCasterRaw = value.ToRaw(null, null);
        }

        public string ArtTargetRaw
        {
            get => _modifications.GetModification(1952543841).ValueAsString;
            set => _modifications[1952543841] = new LevelObjectDataModification{Id = 1952543841, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetModified => _modifications.ContainsKey(1952543841);
        public IEnumerable<string> ArtTarget
        {
            get => ArtTargetRaw.ToIEnumerableString(this);
            set => ArtTargetRaw = value.ToRaw(null, null);
        }

        public string ArtSpecialRaw
        {
            get => _modifications.GetModification(1952543585).ValueAsString;
            set => _modifications[1952543585] = new LevelObjectDataModification{Id = 1952543585, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtSpecialModified => _modifications.ContainsKey(1952543585);
        public IEnumerable<string> ArtSpecial
        {
            get => ArtSpecialRaw.ToIEnumerableString(this);
            set => ArtSpecialRaw = value.ToRaw(null, null);
        }

        public string ArtEffectRaw
        {
            get => _modifications.GetModification(1952540001).ValueAsString;
            set => _modifications[1952540001] = new LevelObjectDataModification{Id = 1952540001, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtEffectModified => _modifications.ContainsKey(1952540001);
        public IEnumerable<string> ArtEffect
        {
            get => ArtEffectRaw.ToIEnumerableString(this);
            set => ArtEffectRaw = value.ToRaw(null, null);
        }

        public string ArtAreaEffectRaw
        {
            get => _modifications.GetModification(1634034017).ValueAsString;
            set => _modifications[1634034017] = new LevelObjectDataModification{Id = 1634034017, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtAreaEffectModified => _modifications.ContainsKey(1634034017);
        public IEnumerable<string> ArtAreaEffect
        {
            get => ArtAreaEffectRaw.ToIEnumerableString(this);
            set => ArtAreaEffectRaw = value.ToRaw(null, null);
        }

        public string ArtLightningEffectsRaw
        {
            get => _modifications.GetModification(1734962273).ValueAsString;
            set => _modifications[1734962273] = new LevelObjectDataModification{Id = 1734962273, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtLightningEffectsModified => _modifications.ContainsKey(1734962273);
        public IEnumerable<LightningEffect> ArtLightningEffects
        {
            get => ArtLightningEffectsRaw.ToIEnumerableLightningEffect(this);
            set => ArtLightningEffectsRaw = value.ToRaw(null, 3);
        }

        public string ArtMissileArtRaw
        {
            get => _modifications.GetModification(1952542049).ValueAsString;
            set => _modifications[1952542049] = new LevelObjectDataModification{Id = 1952542049, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtMissileArtModified => _modifications.ContainsKey(1952542049);
        public IEnumerable<string> ArtMissileArt
        {
            get => ArtMissileArtRaw.ToIEnumerableString(this);
            set => ArtMissileArtRaw = value.ToRaw(null, null);
        }

        public int ArtMissileSpeed
        {
            get => _modifications.GetModification(1886612833).ValueAsInt;
            set => _modifications[1886612833] = new LevelObjectDataModification{Id = 1886612833, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtMissileSpeedModified => _modifications.ContainsKey(1886612833);
        public float ArtMissileArc
        {
            get => _modifications.GetModification(1667329377).ValueAsFloat;
            set => _modifications[1667329377] = new LevelObjectDataModification{Id = 1667329377, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsArtMissileArcModified => _modifications.ContainsKey(1667329377);
        public int ArtMissileHomingEnabledRaw
        {
            get => _modifications.GetModification(1869114721).ValueAsInt;
            set => _modifications[1869114721] = new LevelObjectDataModification{Id = 1869114721, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtMissileHomingEnabledModified => _modifications.ContainsKey(1869114721);
        public bool ArtMissileHomingEnabled
        {
            get => ArtMissileHomingEnabledRaw.ToBool(this);
            set => ArtMissileHomingEnabledRaw = value.ToRaw(null, null);
        }

        public int ArtTargetAttachments
        {
            get => _modifications.GetModification(1667331169).ValueAsInt;
            set => _modifications[1667331169] = new LevelObjectDataModification{Id = 1667331169, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentsModified => _modifications.ContainsKey(1667331169);
        public string ArtTargetAttachmentPoint1Raw
        {
            get => _modifications.GetModification(811693153).ValueAsString;
            set => _modifications[811693153] = new LevelObjectDataModification{Id = 811693153, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentPoint1Modified => _modifications.ContainsKey(811693153);
        public IEnumerable<string> ArtTargetAttachmentPoint1
        {
            get => ArtTargetAttachmentPoint1Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint1Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint2Raw
        {
            get => _modifications.GetModification(828470369).ValueAsString;
            set => _modifications[828470369] = new LevelObjectDataModification{Id = 828470369, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentPoint2Modified => _modifications.ContainsKey(828470369);
        public IEnumerable<string> ArtTargetAttachmentPoint2
        {
            get => ArtTargetAttachmentPoint2Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint2Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint3Raw
        {
            get => _modifications.GetModification(845247585).ValueAsString;
            set => _modifications[845247585] = new LevelObjectDataModification{Id = 845247585, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentPoint3Modified => _modifications.ContainsKey(845247585);
        public IEnumerable<string> ArtTargetAttachmentPoint3
        {
            get => ArtTargetAttachmentPoint3Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint3Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint4Raw
        {
            get => _modifications.GetModification(862024801).ValueAsString;
            set => _modifications[862024801] = new LevelObjectDataModification{Id = 862024801, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentPoint4Modified => _modifications.ContainsKey(862024801);
        public IEnumerable<string> ArtTargetAttachmentPoint4
        {
            get => ArtTargetAttachmentPoint4Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint4Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint5Raw
        {
            get => _modifications.GetModification(878802017).ValueAsString;
            set => _modifications[878802017] = new LevelObjectDataModification{Id = 878802017, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentPoint5Modified => _modifications.ContainsKey(878802017);
        public IEnumerable<string> ArtTargetAttachmentPoint5
        {
            get => ArtTargetAttachmentPoint5Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint5Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint6Raw
        {
            get => _modifications.GetModification(895579233).ValueAsString;
            set => _modifications[895579233] = new LevelObjectDataModification{Id = 895579233, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtTargetAttachmentPoint6Modified => _modifications.ContainsKey(895579233);
        public IEnumerable<string> ArtTargetAttachmentPoint6
        {
            get => ArtTargetAttachmentPoint6Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint6Raw = value.ToRaw(null, 32);
        }

        public int ArtCasterAttachments
        {
            get => _modifications.GetModification(1667326817).ValueAsInt;
            set => _modifications[1667326817] = new LevelObjectDataModification{Id = 1667326817, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtCasterAttachmentsModified => _modifications.ContainsKey(1667326817);
        public string ArtCasterAttachmentPoint1Raw
        {
            get => _modifications.GetModification(1885430625).ValueAsString;
            set => _modifications[1885430625] = new LevelObjectDataModification{Id = 1885430625, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtCasterAttachmentPoint1Modified => _modifications.ContainsKey(1885430625);
        public IEnumerable<string> ArtCasterAttachmentPoint1
        {
            get => ArtCasterAttachmentPoint1Raw.ToIEnumerableString(this);
            set => ArtCasterAttachmentPoint1Raw = value.ToRaw(null, 32);
        }

        public string ArtCasterAttachmentPoint2Raw
        {
            get => _modifications.GetModification(828466017).ValueAsString;
            set => _modifications[828466017] = new LevelObjectDataModification{Id = 828466017, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtCasterAttachmentPoint2Modified => _modifications.ContainsKey(828466017);
        public IEnumerable<string> ArtCasterAttachmentPoint2
        {
            get => ArtCasterAttachmentPoint2Raw.ToIEnumerableString(this);
            set => ArtCasterAttachmentPoint2Raw = value.ToRaw(null, 32);
        }

        public string ArtSpecialAttachmentPointRaw
        {
            get => _modifications.GetModification(1953526625).ValueAsString;
            set => _modifications[1953526625] = new LevelObjectDataModification{Id = 1953526625, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtSpecialAttachmentPointModified => _modifications.ContainsKey(1953526625);
        public IEnumerable<string> ArtSpecialAttachmentPoint
        {
            get => ArtSpecialAttachmentPointRaw.ToIEnumerableString(this);
            set => ArtSpecialAttachmentPointRaw = value.ToRaw(null, 32);
        }

        public string ArtAnimationNamesRaw
        {
            get => _modifications.GetModification(1768841569).ValueAsString;
            set => _modifications[1768841569] = new LevelObjectDataModification{Id = 1768841569, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsArtAnimationNamesModified => _modifications.ContainsKey(1768841569);
        public IEnumerable<string> ArtAnimationNames
        {
            get => ArtAnimationNamesRaw.ToIEnumerableString(this);
            set => ArtAnimationNamesRaw = value.ToRaw(null, null);
        }

        public ObjectProperty<string> TextTooltipNormal => _textTooltipNormal.Value;
        public ReadOnlyObjectProperty<bool> IsTextTooltipNormalModified => _isTextTooltipNormalModified.Value;
        public ObjectProperty<string> TextTooltipTurnOff => _textTooltipTurnOff.Value;
        public ReadOnlyObjectProperty<bool> IsTextTooltipTurnOffModified => _isTextTooltipTurnOffModified.Value;
        public ObjectProperty<string> TextTooltipNormalExtended => _textTooltipNormalExtended.Value;
        public ReadOnlyObjectProperty<bool> IsTextTooltipNormalExtendedModified => _isTextTooltipNormalExtendedModified.Value;
        public ObjectProperty<string> TextTooltipTurnOffExtended => _textTooltipTurnOffExtended.Value;
        public ReadOnlyObjectProperty<bool> IsTextTooltipTurnOffExtendedModified => _isTextTooltipTurnOffExtendedModified.Value;
        public string TextTooltipLearn
        {
            get => _modifications.GetModification(1952805473).ValueAsString;
            set => _modifications[1952805473] = new LevelObjectDataModification{Id = 1952805473, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextTooltipLearnModified => _modifications.ContainsKey(1952805473);
        public string TextTooltipLearnExtended
        {
            get => _modifications.GetModification(1953854049).ValueAsString;
            set => _modifications[1953854049] = new LevelObjectDataModification{Id = 1953854049, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextTooltipLearnExtendedModified => _modifications.ContainsKey(1953854049);
        public string TextHotkeyLearnRaw
        {
            get => _modifications.GetModification(1802007137).ValueAsString;
            set => _modifications[1802007137] = new LevelObjectDataModification{Id = 1802007137, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextHotkeyLearnModified => _modifications.ContainsKey(1802007137);
        public char TextHotkeyLearn
        {
            get => TextHotkeyLearnRaw.ToChar(this);
            set => TextHotkeyLearnRaw = value.ToRaw(null, null);
        }

        public string TextHotkeyNormalRaw
        {
            get => _modifications.GetModification(2037082209).ValueAsString;
            set => _modifications[2037082209] = new LevelObjectDataModification{Id = 2037082209, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextHotkeyNormalModified => _modifications.ContainsKey(2037082209);
        public char TextHotkeyNormal
        {
            get => TextHotkeyNormalRaw.ToChar(this);
            set => TextHotkeyNormalRaw = value.ToRaw(null, null);
        }

        public string TextHotkeyTurnOffRaw
        {
            get => _modifications.GetModification(1802007905).ValueAsString;
            set => _modifications[1802007905] = new LevelObjectDataModification{Id = 1802007905, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextHotkeyTurnOffModified => _modifications.ContainsKey(1802007905);
        public char TextHotkeyTurnOff
        {
            get => TextHotkeyTurnOffRaw.ToChar(this);
            set => TextHotkeyTurnOffRaw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsRaw
        {
            get => _modifications.GetModification(1902473825).ValueAsString;
            set => _modifications[1902473825] = new LevelObjectDataModification{Id = 1902473825, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTechtreeRequirementsModified => _modifications.ContainsKey(1902473825);
        public IEnumerable<Tech> TechtreeRequirements
        {
            get => TechtreeRequirementsRaw.ToIEnumerableTech(this);
            set => TechtreeRequirementsRaw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsLevelsRaw
        {
            get => _modifications.GetModification(1634824801).ValueAsString;
            set => _modifications[1634824801] = new LevelObjectDataModification{Id = 1634824801, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTechtreeRequirementsLevelsModified => _modifications.ContainsKey(1634824801);
        public IEnumerable<int> TechtreeRequirementsLevels
        {
            get => TechtreeRequirementsLevelsRaw.ToIEnumerableInt(this);
            set => TechtreeRequirementsLevelsRaw = value.ToRaw(null, 100);
        }

        public int TechtreeCheckDependenciesRaw
        {
            get => _modifications.GetModification(1684562785).ValueAsInt;
            set => _modifications[1684562785] = new LevelObjectDataModification{Id = 1684562785, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsTechtreeCheckDependenciesModified => _modifications.ContainsKey(1684562785);
        public bool TechtreeCheckDependencies
        {
            get => TechtreeCheckDependenciesRaw.ToBool(this);
            set => TechtreeCheckDependenciesRaw = value.ToRaw(null, null);
        }

        public int StatsPriorityForSpellSteal
        {
            get => _modifications.GetModification(1769107553).ValueAsInt;
            set => _modifications[1769107553] = new LevelObjectDataModification{Id = 1769107553, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsPriorityForSpellStealModified => _modifications.ContainsKey(1769107553);
        public string TextOrderStringUseTurnOnRaw
        {
            get => _modifications.GetModification(1685221217).ValueAsString;
            set => _modifications[1685221217] = new LevelObjectDataModification{Id = 1685221217, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextOrderStringUseTurnOnModified => _modifications.ContainsKey(1685221217);
        public string TextOrderStringUseTurnOn
        {
            get => TextOrderStringUseTurnOnRaw.ToString(this);
            set => TextOrderStringUseTurnOnRaw = value.ToRaw(null, 32);
        }

        public string TextOrderStringTurnOffRaw
        {
            get => _modifications.GetModification(1970433889).ValueAsString;
            set => _modifications[1970433889] = new LevelObjectDataModification{Id = 1970433889, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextOrderStringTurnOffModified => _modifications.ContainsKey(1970433889);
        public string TextOrderStringTurnOff
        {
            get => TextOrderStringTurnOffRaw.ToString(this);
            set => TextOrderStringTurnOffRaw = value.ToRaw(null, 32);
        }

        public string TextOrderStringActivateRaw
        {
            get => _modifications.GetModification(1869770593).ValueAsString;
            set => _modifications[1869770593] = new LevelObjectDataModification{Id = 1869770593, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextOrderStringActivateModified => _modifications.ContainsKey(1869770593);
        public string TextOrderStringActivate
        {
            get => TextOrderStringActivateRaw.ToString(this);
            set => TextOrderStringActivateRaw = value.ToRaw(null, 32);
        }

        public string TextOrderStringDeactivateRaw
        {
            get => _modifications.GetModification(1718775649).ValueAsString;
            set => _modifications[1718775649] = new LevelObjectDataModification{Id = 1718775649, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsTextOrderStringDeactivateModified => _modifications.ContainsKey(1718775649);
        public string TextOrderStringDeactivate
        {
            get => TextOrderStringDeactivateRaw.ToString(this);
            set => TextOrderStringDeactivateRaw = value.ToRaw(null, 32);
        }

        public string SoundEffectSoundRaw
        {
            get => _modifications.GetModification(1936090465).ValueAsString;
            set => _modifications[1936090465] = new LevelObjectDataModification{Id = 1936090465, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsSoundEffectSoundModified => _modifications.ContainsKey(1936090465);
        public string SoundEffectSound
        {
            get => SoundEffectSoundRaw.ToString(this);
            set => SoundEffectSoundRaw = value.ToRaw(null, null);
        }

        public string SoundEffectSoundLoopingRaw
        {
            get => _modifications.GetModification(1818649953).ValueAsString;
            set => _modifications[1818649953] = new LevelObjectDataModification{Id = 1818649953, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsSoundEffectSoundLoopingModified => _modifications.ContainsKey(1818649953);
        public string SoundEffectSoundLooping
        {
            get => SoundEffectSoundLoopingRaw.ToString(this);
            set => SoundEffectSoundLoopingRaw = value.ToRaw(null, null);
        }

        public int StatsLevels
        {
            get => _modifications.GetModification(1986358369).ValueAsInt;
            set => _modifications[1986358369] = new LevelObjectDataModification{Id = 1986358369, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsLevelsModified => _modifications.ContainsKey(1986358369);
        public int StatsRequiredLevel
        {
            get => _modifications.GetModification(1986818657).ValueAsInt;
            set => _modifications[1986818657] = new LevelObjectDataModification{Id = 1986818657, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsRequiredLevelModified => _modifications.ContainsKey(1986818657);
        public int StatsLevelSkipRequirement
        {
            get => _modifications.GetModification(1802726497).ValueAsInt;
            set => _modifications[1802726497] = new LevelObjectDataModification{Id = 1802726497, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsLevelSkipRequirementModified => _modifications.ContainsKey(1802726497);
        public ObjectProperty<string> StatsTargetsAllowedRaw => _statsTargetsAllowedRaw.Value;
        public ReadOnlyObjectProperty<bool> IsStatsTargetsAllowedModified => _isStatsTargetsAllowedModified.Value;
        public ObjectProperty<IEnumerable<Target>> StatsTargetsAllowed => _statsTargetsAllowed.Value;
        public ObjectProperty<float> StatsCastingTime => _statsCastingTime.Value;
        public ReadOnlyObjectProperty<bool> IsStatsCastingTimeModified => _isStatsCastingTimeModified.Value;
        public ObjectProperty<float> StatsDurationNormal => _statsDurationNormal.Value;
        public ReadOnlyObjectProperty<bool> IsStatsDurationNormalModified => _isStatsDurationNormalModified.Value;
        public ObjectProperty<float> StatsDurationHero => _statsDurationHero.Value;
        public ReadOnlyObjectProperty<bool> IsStatsDurationHeroModified => _isStatsDurationHeroModified.Value;
        public ObjectProperty<float> StatsCooldown => _statsCooldown.Value;
        public ReadOnlyObjectProperty<bool> IsStatsCooldownModified => _isStatsCooldownModified.Value;
        public ObjectProperty<int> StatsManaCost => _statsManaCost.Value;
        public ReadOnlyObjectProperty<bool> IsStatsManaCostModified => _isStatsManaCostModified.Value;
        public ObjectProperty<float> StatsAreaOfEffect => _statsAreaOfEffect.Value;
        public ReadOnlyObjectProperty<bool> IsStatsAreaOfEffectModified => _isStatsAreaOfEffectModified.Value;
        public ObjectProperty<float> StatsCastRange => _statsCastRange.Value;
        public ReadOnlyObjectProperty<bool> IsStatsCastRangeModified => _isStatsCastRangeModified.Value;
        public ObjectProperty<string> StatsBuffsRaw => _statsBuffsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsStatsBuffsModified => _isStatsBuffsModified.Value;
        public ObjectProperty<IEnumerable<Buff>> StatsBuffs => _statsBuffs.Value;
        public ObjectProperty<string> StatsEffectsRaw => _statsEffectsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsStatsEffectsModified => _isStatsEffectsModified.Value;
        public ObjectProperty<IEnumerable<Buff>> StatsEffects => _statsEffects.Value;
        public string DataUnitSkinListRaw
        {
            get => _modifications.GetModification(1802728801).ValueAsString;
            set => _modifications[1802728801] = new LevelObjectDataModification{Id = 1802728801, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataUnitSkinListModified => _modifications.ContainsKey(1802728801);
        public IEnumerable<Unit> DataUnitSkinList
        {
            get => DataUnitSkinListRaw.ToIEnumerableUnit(this);
            set => DataUnitSkinListRaw = value.ToRaw(null, null);
        }

        public static explicit operator LevelObjectModification(Ability ability) => new LevelObjectModification{OldId = ability.OldId, NewId = ability.NewId, Modifications = ability.Modifications.ToList()};
        internal override bool TryGetLevelModifications([NotNullWhen(true)] out LevelObjectDataModifications? modifications)
        {
            modifications = _modifications;
            return true;
        }

        public void AddModifications(List<LevelObjectDataModification> modifications)
        {
            foreach (var modification in modifications)
                _modifications[modification.Id, modification.Level] = modification;
        }

        private string GetTextTooltipNormal(int level)
        {
            return _modifications.GetModification(829453409, level).ValueAsString;
        }

        private void SetTextTooltipNormal(int level, string value)
        {
            _modifications[829453409, level] = new LevelObjectDataModification{Id = 829453409, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextTooltipNormalModified(int level)
        {
            return _modifications.ContainsKey(829453409, level);
        }

        private string GetTextTooltipTurnOff(int level)
        {
            return _modifications.GetModification(829715809, level).ValueAsString;
        }

        private void SetTextTooltipTurnOff(int level, string value)
        {
            _modifications[829715809, level] = new LevelObjectDataModification{Id = 829715809, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextTooltipTurnOffModified(int level)
        {
            return _modifications.ContainsKey(829715809, level);
        }

        private string GetTextTooltipNormalExtended(int level)
        {
            return _modifications.GetModification(828536161, level).ValueAsString;
        }

        private void SetTextTooltipNormalExtended(int level, string value)
        {
            _modifications[828536161, level] = new LevelObjectDataModification{Id = 828536161, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextTooltipNormalExtendedModified(int level)
        {
            return _modifications.ContainsKey(828536161, level);
        }

        private string GetTextTooltipTurnOffExtended(int level)
        {
            return _modifications.GetModification(829781345, level).ValueAsString;
        }

        private void SetTextTooltipTurnOffExtended(int level, string value)
        {
            _modifications[829781345, level] = new LevelObjectDataModification{Id = 829781345, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextTooltipTurnOffExtendedModified(int level)
        {
            return _modifications.ContainsKey(829781345, level);
        }

        private string GetStatsTargetsAllowedRaw(int level)
        {
            return _modifications.GetModification(1918989409, level).ValueAsString;
        }

        private void SetStatsTargetsAllowedRaw(int level, string value)
        {
            _modifications[1918989409, level] = new LevelObjectDataModification{Id = 1918989409, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsStatsTargetsAllowedModified(int level)
        {
            return _modifications.ContainsKey(1918989409, level);
        }

        private IEnumerable<Target> GetStatsTargetsAllowed(int level)
        {
            return GetStatsTargetsAllowedRaw(level).ToIEnumerableTarget(this);
        }

        private void SetStatsTargetsAllowed(int level, IEnumerable<Target> value)
        {
            SetStatsTargetsAllowedRaw(level, value.ToRaw(null, null));
        }

        private float GetStatsCastingTime(int level)
        {
            return _modifications.GetModification(1935762273, level).ValueAsFloat;
        }

        private void SetStatsCastingTime(int level, float value)
        {
            _modifications[1935762273, level] = new LevelObjectDataModification{Id = 1935762273, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private bool GetIsStatsCastingTimeModified(int level)
        {
            return _modifications.ContainsKey(1935762273, level);
        }

        private float GetStatsDurationNormal(int level)
        {
            return _modifications.GetModification(1920296033, level).ValueAsFloat;
        }

        private void SetStatsDurationNormal(int level, float value)
        {
            _modifications[1920296033, level] = new LevelObjectDataModification{Id = 1920296033, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private bool GetIsStatsDurationNormalModified(int level)
        {
            return _modifications.ContainsKey(1920296033, level);
        }

        private float GetStatsDurationHero(int level)
        {
            return _modifications.GetModification(1969514593, level).ValueAsFloat;
        }

        private void SetStatsDurationHero(int level, float value)
        {
            _modifications[1969514593, level] = new LevelObjectDataModification{Id = 1969514593, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private bool GetIsStatsDurationHeroModified(int level)
        {
            return _modifications.ContainsKey(1969514593, level);
        }

        private float GetStatsCooldown(int level)
        {
            return _modifications.GetModification(1852072801, level).ValueAsFloat;
        }

        private void SetStatsCooldown(int level, float value)
        {
            _modifications[1852072801, level] = new LevelObjectDataModification{Id = 1852072801, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private bool GetIsStatsCooldownModified(int level)
        {
            return _modifications.ContainsKey(1852072801, level);
        }

        private int GetStatsManaCost(int level)
        {
            return _modifications.GetModification(1935895905, level).ValueAsInt;
        }

        private void SetStatsManaCost(int level, int value)
        {
            _modifications[1935895905, level] = new LevelObjectDataModification{Id = 1935895905, Type = ObjectDataType.Int, Value = value, Level = level};
        }

        private bool GetIsStatsManaCostModified(int level)
        {
            return _modifications.ContainsKey(1935895905, level);
        }

        private float GetStatsAreaOfEffect(int level)
        {
            return _modifications.GetModification(1701994849, level).ValueAsFloat;
        }

        private void SetStatsAreaOfEffect(int level, float value)
        {
            _modifications[1701994849, level] = new LevelObjectDataModification{Id = 1701994849, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private bool GetIsStatsAreaOfEffectModified(int level)
        {
            return _modifications.ContainsKey(1701994849, level);
        }

        private float GetStatsCastRange(int level)
        {
            return _modifications.GetModification(1851880033, level).ValueAsFloat;
        }

        private void SetStatsCastRange(int level, float value)
        {
            _modifications[1851880033, level] = new LevelObjectDataModification{Id = 1851880033, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private bool GetIsStatsCastRangeModified(int level)
        {
            return _modifications.ContainsKey(1851880033, level);
        }

        private string GetStatsBuffsRaw(int level)
        {
            return _modifications.GetModification(1718968929, level).ValueAsString;
        }

        private void SetStatsBuffsRaw(int level, string value)
        {
            _modifications[1718968929, level] = new LevelObjectDataModification{Id = 1718968929, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsStatsBuffsModified(int level)
        {
            return _modifications.ContainsKey(1718968929, level);
        }

        private IEnumerable<Buff> GetStatsBuffs(int level)
        {
            return GetStatsBuffsRaw(level).ToIEnumerableBuff(this);
        }

        private void SetStatsBuffs(int level, IEnumerable<Buff> value)
        {
            SetStatsBuffsRaw(level, value.ToRaw(null, null));
        }

        private string GetStatsEffectsRaw(int level)
        {
            return _modifications.GetModification(1717986657, level).ValueAsString;
        }

        private void SetStatsEffectsRaw(int level, string value)
        {
            _modifications[1717986657, level] = new LevelObjectDataModification{Id = 1717986657, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsStatsEffectsModified(int level)
        {
            return _modifications.ContainsKey(1717986657, level);
        }

        private IEnumerable<Buff> GetStatsEffects(int level)
        {
            return GetStatsEffectsRaw(level).ToIEnumerableBuff(this);
        }

        private void SetStatsEffects(int level, IEnumerable<Buff> value)
        {
            SetStatsEffectsRaw(level, value.ToRaw(null, null));
        }
    }
}
