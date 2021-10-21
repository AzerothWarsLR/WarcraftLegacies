using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public abstract class Ability : BaseObject
    {
        protected readonly LevelObjectDataModifications _modifications = new LevelObjectDataModifications();
        private readonly Lazy<ObjectProperty<string>> _textTooltipNormal;
        private readonly Lazy<ObjectProperty<string>> _textTooltipTurnOff;
        private readonly Lazy<ObjectProperty<string>> _textTooltipNormalExtended;
        private readonly Lazy<ObjectProperty<string>> _textTooltipTurnOffExtended;
        private readonly Lazy<ObjectProperty<string>> _statsTargetsAllowedRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Target>>> _statsTargetsAllowed;
        private readonly Lazy<ObjectProperty<float>> _statsCastingTime;
        private readonly Lazy<ObjectProperty<float>> _statsDurationNormal;
        private readonly Lazy<ObjectProperty<float>> _statsDurationHero;
        private readonly Lazy<ObjectProperty<float>> _statsCooldown;
        private readonly Lazy<ObjectProperty<int>> _statsManaCost;
        private readonly Lazy<ObjectProperty<float>> _statsAreaOfEffect;
        private readonly Lazy<ObjectProperty<float>> _statsCastRange;
        private readonly Lazy<ObjectProperty<string>> _statsBuffsRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Buff>>> _statsBuffs;
        private readonly Lazy<ObjectProperty<string>> _statsEffectsRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Buff>>> _statsEffects;
        internal Ability(int oldId): base(oldId)
        {
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, int newId): base(oldId, newId)
        {
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, ObjectDatabase db): base(oldId, db)
        {
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, int newId, ObjectDatabase db): base(oldId, newId, db)
        {
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        internal Ability(int oldId, string newRawcode, ObjectDatabase db): base(oldId, newRawcode, db)
        {
            _textTooltipNormal = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormal, SetTextTooltipNormal));
            _textTooltipTurnOff = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOff, SetTextTooltipTurnOff));
            _textTooltipNormalExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipNormalExtended, SetTextTooltipNormalExtended));
            _textTooltipTurnOffExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipTurnOffExtended, SetTextTooltipTurnOffExtended));
            _statsTargetsAllowedRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsTargetsAllowedRaw, SetStatsTargetsAllowedRaw));
            _statsTargetsAllowed = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetStatsTargetsAllowed, SetStatsTargetsAllowed));
            _statsCastingTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastingTime, SetStatsCastingTime));
            _statsDurationNormal = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationNormal, SetStatsDurationNormal));
            _statsDurationHero = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsDurationHero, SetStatsDurationHero));
            _statsCooldown = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCooldown, SetStatsCooldown));
            _statsManaCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetStatsManaCost, SetStatsManaCost));
            _statsAreaOfEffect = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsAreaOfEffect, SetStatsAreaOfEffect));
            _statsCastRange = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetStatsCastRange, SetStatsCastRange));
            _statsBuffsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsBuffsRaw, SetStatsBuffsRaw));
            _statsBuffs = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsBuffs, SetStatsBuffs));
            _statsEffectsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetStatsEffectsRaw, SetStatsEffectsRaw));
            _statsEffects = new Lazy<ObjectProperty<IEnumerable<Buff>>>(() => new ObjectProperty<IEnumerable<Buff>>(GetStatsEffects, SetStatsEffects));
        }

        public LevelObjectDataModifications Modifications => _modifications;
        public string TextName
        {
            get => _modifications[1835101793].ValueAsString;
            set => _modifications[1835101793] = new LevelObjectDataModification{Id = 1835101793, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string TextEditorSuffix
        {
            get => _modifications[1718840929].ValueAsString;
            set => _modifications[1718840929] = new LevelObjectDataModification{Id = 1718840929, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool StatsHeroAbility
        {
            get => _modifications[1919248481].ValueAsBool;
            set => _modifications[1919248481] = new LevelObjectDataModification{Id = 1919248481, Type = ObjectDataType.Bool, Value = value, Level = 0};
        }

        public bool StatsItemAbility
        {
            get => _modifications[1702127969].ValueAsBool;
            set => _modifications[1702127969] = new LevelObjectDataModification{Id = 1702127969, Type = ObjectDataType.Bool, Value = value, Level = 0};
        }

        public string StatsRaceRaw
        {
            get => _modifications[1667330657].ValueAsString;
            set => _modifications[1667330657] = new LevelObjectDataModification{Id = 1667330657, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public UnitRace StatsRace
        {
            get => StatsRaceRaw.ToUnitRace(this);
            set => StatsRaceRaw = value.ToRaw(null, null);
        }

        public int ArtButtonPositionNormalX
        {
            get => _modifications[2020631137].ValueAsInt;
            set => _modifications[2020631137] = new LevelObjectDataModification{Id = 2020631137, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int ArtButtonPositionNormalY
        {
            get => _modifications[2037408353].ValueAsInt;
            set => _modifications[2037408353] = new LevelObjectDataModification{Id = 2037408353, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int ArtButtonPositionTurnOffX
        {
            get => _modifications[2019718497].ValueAsInt;
            set => _modifications[2019718497] = new LevelObjectDataModification{Id = 2019718497, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int ArtButtonPositionTurnOffY
        {
            get => _modifications[2036495713].ValueAsInt;
            set => _modifications[2036495713] = new LevelObjectDataModification{Id = 2036495713, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int ArtButtonPositionResearchX
        {
            get => _modifications[2020635233].ValueAsInt;
            set => _modifications[2020635233] = new LevelObjectDataModification{Id = 2020635233, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int ArtButtonPositionResearchY
        {
            get => _modifications[2037412449].ValueAsInt;
            set => _modifications[2037412449] = new LevelObjectDataModification{Id = 2037412449, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public string ArtIconNormalRaw
        {
            get => _modifications[1953653089].ValueAsString;
            set => _modifications[1953653089] = new LevelObjectDataModification{Id = 1953653089, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string ArtIconNormal
        {
            get => ArtIconNormalRaw.ToString(this);
            set => ArtIconNormalRaw = value.ToRaw(null, null);
        }

        public string ArtIconTurnOffRaw
        {
            get => _modifications[1918989665].ValueAsString;
            set => _modifications[1918989665] = new LevelObjectDataModification{Id = 1918989665, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string ArtIconTurnOff
        {
            get => ArtIconTurnOffRaw.ToString(this);
            set => ArtIconTurnOffRaw = value.ToRaw(null, null);
        }

        public string ArtIconResearchRaw
        {
            get => _modifications[1918988897].ValueAsString;
            set => _modifications[1918988897] = new LevelObjectDataModification{Id = 1918988897, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string ArtIconResearch
        {
            get => ArtIconResearchRaw.ToString(this);
            set => ArtIconResearchRaw = value.ToRaw(null, null);
        }

        public string ArtCasterRaw
        {
            get => _modifications[1952539489].ValueAsString;
            set => _modifications[1952539489] = new LevelObjectDataModification{Id = 1952539489, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtCaster
        {
            get => ArtCasterRaw.ToIEnumerableString(this);
            set => ArtCasterRaw = value.ToRaw(null, null);
        }

        public string ArtTargetRaw
        {
            get => _modifications[1952543841].ValueAsString;
            set => _modifications[1952543841] = new LevelObjectDataModification{Id = 1952543841, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTarget
        {
            get => ArtTargetRaw.ToIEnumerableString(this);
            set => ArtTargetRaw = value.ToRaw(null, null);
        }

        public string ArtSpecialRaw
        {
            get => _modifications[1952543585].ValueAsString;
            set => _modifications[1952543585] = new LevelObjectDataModification{Id = 1952543585, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtSpecial
        {
            get => ArtSpecialRaw.ToIEnumerableString(this);
            set => ArtSpecialRaw = value.ToRaw(null, null);
        }

        public string ArtEffectRaw
        {
            get => _modifications[1952540001].ValueAsString;
            set => _modifications[1952540001] = new LevelObjectDataModification{Id = 1952540001, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtEffect
        {
            get => ArtEffectRaw.ToIEnumerableString(this);
            set => ArtEffectRaw = value.ToRaw(null, null);
        }

        public string ArtAreaEffectRaw
        {
            get => _modifications[1634034017].ValueAsString;
            set => _modifications[1634034017] = new LevelObjectDataModification{Id = 1634034017, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtAreaEffect
        {
            get => ArtAreaEffectRaw.ToIEnumerableString(this);
            set => ArtAreaEffectRaw = value.ToRaw(null, null);
        }

        public string ArtLightningEffectsRaw
        {
            get => _modifications[1734962273].ValueAsString;
            set => _modifications[1734962273] = new LevelObjectDataModification{Id = 1734962273, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<LightningEffect> ArtLightningEffects
        {
            get => ArtLightningEffectsRaw.ToIEnumerableLightningEffect(this);
            set => ArtLightningEffectsRaw = value.ToRaw(null, 3);
        }

        public string ArtMissileArtRaw
        {
            get => _modifications[1952542049].ValueAsString;
            set => _modifications[1952542049] = new LevelObjectDataModification{Id = 1952542049, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtMissileArt
        {
            get => ArtMissileArtRaw.ToIEnumerableString(this);
            set => ArtMissileArtRaw = value.ToRaw(null, null);
        }

        public int ArtMissileSpeed
        {
            get => _modifications[1886612833].ValueAsInt;
            set => _modifications[1886612833] = new LevelObjectDataModification{Id = 1886612833, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public float ArtMissileArc
        {
            get => _modifications[1667329377].ValueAsFloat;
            set => _modifications[1667329377] = new LevelObjectDataModification{Id = 1667329377, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool ArtMissileHomingEnabled
        {
            get => _modifications[1869114721].ValueAsBool;
            set => _modifications[1869114721] = new LevelObjectDataModification{Id = 1869114721, Type = ObjectDataType.Bool, Value = value, Level = 0};
        }

        public int ArtTargetAttachments
        {
            get => _modifications[1667331169].ValueAsInt;
            set => _modifications[1667331169] = new LevelObjectDataModification{Id = 1667331169, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public string ArtTargetAttachmentPoint1Raw
        {
            get => _modifications[811693153].ValueAsString;
            set => _modifications[811693153] = new LevelObjectDataModification{Id = 811693153, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTargetAttachmentPoint1
        {
            get => ArtTargetAttachmentPoint1Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint1Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint2Raw
        {
            get => _modifications[828470369].ValueAsString;
            set => _modifications[828470369] = new LevelObjectDataModification{Id = 828470369, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTargetAttachmentPoint2
        {
            get => ArtTargetAttachmentPoint2Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint2Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint3Raw
        {
            get => _modifications[845247585].ValueAsString;
            set => _modifications[845247585] = new LevelObjectDataModification{Id = 845247585, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTargetAttachmentPoint3
        {
            get => ArtTargetAttachmentPoint3Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint3Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint4Raw
        {
            get => _modifications[862024801].ValueAsString;
            set => _modifications[862024801] = new LevelObjectDataModification{Id = 862024801, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTargetAttachmentPoint4
        {
            get => ArtTargetAttachmentPoint4Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint4Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint5Raw
        {
            get => _modifications[878802017].ValueAsString;
            set => _modifications[878802017] = new LevelObjectDataModification{Id = 878802017, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTargetAttachmentPoint5
        {
            get => ArtTargetAttachmentPoint5Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint5Raw = value.ToRaw(null, 32);
        }

        public string ArtTargetAttachmentPoint6Raw
        {
            get => _modifications[895579233].ValueAsString;
            set => _modifications[895579233] = new LevelObjectDataModification{Id = 895579233, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtTargetAttachmentPoint6
        {
            get => ArtTargetAttachmentPoint6Raw.ToIEnumerableString(this);
            set => ArtTargetAttachmentPoint6Raw = value.ToRaw(null, 32);
        }

        public int ArtCasterAttachments
        {
            get => _modifications[1667326817].ValueAsInt;
            set => _modifications[1667326817] = new LevelObjectDataModification{Id = 1667326817, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public string ArtCasterAttachmentPoint1Raw
        {
            get => _modifications[1885430625].ValueAsString;
            set => _modifications[1885430625] = new LevelObjectDataModification{Id = 1885430625, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtCasterAttachmentPoint1
        {
            get => ArtCasterAttachmentPoint1Raw.ToIEnumerableString(this);
            set => ArtCasterAttachmentPoint1Raw = value.ToRaw(null, 32);
        }

        public string ArtCasterAttachmentPoint2Raw
        {
            get => _modifications[828466017].ValueAsString;
            set => _modifications[828466017] = new LevelObjectDataModification{Id = 828466017, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtCasterAttachmentPoint2
        {
            get => ArtCasterAttachmentPoint2Raw.ToIEnumerableString(this);
            set => ArtCasterAttachmentPoint2Raw = value.ToRaw(null, 32);
        }

        public string ArtSpecialAttachmentPointRaw
        {
            get => _modifications[1953526625].ValueAsString;
            set => _modifications[1953526625] = new LevelObjectDataModification{Id = 1953526625, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtSpecialAttachmentPoint
        {
            get => ArtSpecialAttachmentPointRaw.ToIEnumerableString(this);
            set => ArtSpecialAttachmentPointRaw = value.ToRaw(null, 32);
        }

        public string ArtAnimationNamesRaw
        {
            get => _modifications[1768841569].ValueAsString;
            set => _modifications[1768841569] = new LevelObjectDataModification{Id = 1768841569, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<string> ArtAnimationNames
        {
            get => ArtAnimationNamesRaw.ToIEnumerableString(this);
            set => ArtAnimationNamesRaw = value.ToRaw(null, null);
        }

        public ObjectProperty<string> TextTooltipNormal => _textTooltipNormal.Value;
        public ObjectProperty<string> TextTooltipTurnOff => _textTooltipTurnOff.Value;
        public ObjectProperty<string> TextTooltipNormalExtended => _textTooltipNormalExtended.Value;
        public ObjectProperty<string> TextTooltipTurnOffExtended => _textTooltipTurnOffExtended.Value;
        public string TextTooltipLearn
        {
            get => _modifications[1952805473].ValueAsString;
            set => _modifications[1952805473] = new LevelObjectDataModification{Id = 1952805473, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string TextTooltipLearnExtended
        {
            get => _modifications[1953854049].ValueAsString;
            set => _modifications[1953854049] = new LevelObjectDataModification{Id = 1953854049, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public char TextHotkeyLearn
        {
            get => _modifications[1802007137].ValueAsChar;
            set => _modifications[1802007137] = new LevelObjectDataModification{Id = 1802007137, Type = ObjectDataType.Char, Value = value, Level = 0};
        }

        public char TextHotkeyNormal
        {
            get => _modifications[2037082209].ValueAsChar;
            set => _modifications[2037082209] = new LevelObjectDataModification{Id = 2037082209, Type = ObjectDataType.Char, Value = value, Level = 0};
        }

        public char TextHotkeyTurnOff
        {
            get => _modifications[1802007905].ValueAsChar;
            set => _modifications[1802007905] = new LevelObjectDataModification{Id = 1802007905, Type = ObjectDataType.Char, Value = value, Level = 0};
        }

        public string TechtreeRequirementsRaw
        {
            get => _modifications[1902473825].ValueAsString;
            set => _modifications[1902473825] = new LevelObjectDataModification{Id = 1902473825, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<Tech> TechtreeRequirements
        {
            get => TechtreeRequirementsRaw.ToIEnumerableTech(this);
            set => TechtreeRequirementsRaw = value.ToRaw(null, null);
        }

        public string TechtreeRequirementsLevelsRaw
        {
            get => _modifications[1634824801].ValueAsString;
            set => _modifications[1634824801] = new LevelObjectDataModification{Id = 1634824801, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<int> TechtreeRequirementsLevels
        {
            get => TechtreeRequirementsLevelsRaw.ToIEnumerableInt(this);
            set => TechtreeRequirementsLevelsRaw = value.ToRaw(null, 100);
        }

        public bool TechtreeCheckDependencies
        {
            get => _modifications[1684562785].ValueAsBool;
            set => _modifications[1684562785] = new LevelObjectDataModification{Id = 1684562785, Type = ObjectDataType.Bool, Value = value, Level = 0};
        }

        public int StatsPriorityForSpellSteal
        {
            get => _modifications[1769107553].ValueAsInt;
            set => _modifications[1769107553] = new LevelObjectDataModification{Id = 1769107553, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public string TextOrderStringUseTurnOnRaw
        {
            get => _modifications[1685221217].ValueAsString;
            set => _modifications[1685221217] = new LevelObjectDataModification{Id = 1685221217, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string TextOrderStringUseTurnOn
        {
            get => TextOrderStringUseTurnOnRaw.ToString(this);
            set => TextOrderStringUseTurnOnRaw = value.ToRaw(null, 32);
        }

        public string TextOrderStringTurnOffRaw
        {
            get => _modifications[1970433889].ValueAsString;
            set => _modifications[1970433889] = new LevelObjectDataModification{Id = 1970433889, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string TextOrderStringTurnOff
        {
            get => TextOrderStringTurnOffRaw.ToString(this);
            set => TextOrderStringTurnOffRaw = value.ToRaw(null, 32);
        }

        public string TextOrderStringActivateRaw
        {
            get => _modifications[1869770593].ValueAsString;
            set => _modifications[1869770593] = new LevelObjectDataModification{Id = 1869770593, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string TextOrderStringActivate
        {
            get => TextOrderStringActivateRaw.ToString(this);
            set => TextOrderStringActivateRaw = value.ToRaw(null, 32);
        }

        public string TextOrderStringDeactivateRaw
        {
            get => _modifications[1718775649].ValueAsString;
            set => _modifications[1718775649] = new LevelObjectDataModification{Id = 1718775649, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string TextOrderStringDeactivate
        {
            get => TextOrderStringDeactivateRaw.ToString(this);
            set => TextOrderStringDeactivateRaw = value.ToRaw(null, 32);
        }

        public string SoundEffectSoundRaw
        {
            get => _modifications[1936090465].ValueAsString;
            set => _modifications[1936090465] = new LevelObjectDataModification{Id = 1936090465, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string SoundEffectSound
        {
            get => SoundEffectSoundRaw.ToString(this);
            set => SoundEffectSoundRaw = value.ToRaw(null, null);
        }

        public string SoundEffectSoundLoopingRaw
        {
            get => _modifications[1818649953].ValueAsString;
            set => _modifications[1818649953] = new LevelObjectDataModification{Id = 1818649953, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public string SoundEffectSoundLooping
        {
            get => SoundEffectSoundLoopingRaw.ToString(this);
            set => SoundEffectSoundLoopingRaw = value.ToRaw(null, null);
        }

        public int StatsLevels
        {
            get => _modifications[1986358369].ValueAsInt;
            set => _modifications[1986358369] = new LevelObjectDataModification{Id = 1986358369, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int StatsRequiredLevel
        {
            get => _modifications[1986818657].ValueAsInt;
            set => _modifications[1986818657] = new LevelObjectDataModification{Id = 1986818657, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public int StatsLevelSkipRequirement
        {
            get => _modifications[1802726497].ValueAsInt;
            set => _modifications[1802726497] = new LevelObjectDataModification{Id = 1802726497, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public ObjectProperty<string> StatsTargetsAllowedRaw => _statsTargetsAllowedRaw.Value;
        public ObjectProperty<IEnumerable<Target>> StatsTargetsAllowed => _statsTargetsAllowed.Value;
        public ObjectProperty<float> StatsCastingTime => _statsCastingTime.Value;
        public ObjectProperty<float> StatsDurationNormal => _statsDurationNormal.Value;
        public ObjectProperty<float> StatsDurationHero => _statsDurationHero.Value;
        public ObjectProperty<float> StatsCooldown => _statsCooldown.Value;
        public ObjectProperty<int> StatsManaCost => _statsManaCost.Value;
        public ObjectProperty<float> StatsAreaOfEffect => _statsAreaOfEffect.Value;
        public ObjectProperty<float> StatsCastRange => _statsCastRange.Value;
        public ObjectProperty<string> StatsBuffsRaw => _statsBuffsRaw.Value;
        public ObjectProperty<IEnumerable<Buff>> StatsBuffs => _statsBuffs.Value;
        public ObjectProperty<string> StatsEffectsRaw => _statsEffectsRaw.Value;
        public ObjectProperty<IEnumerable<Buff>> StatsEffects => _statsEffects.Value;
        public string DataUnitSkinListRaw
        {
            get => _modifications[1802728801].ValueAsString;
            set => _modifications[1802728801] = new LevelObjectDataModification{Id = 1802728801, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public IEnumerable<Unit> DataUnitSkinList
        {
            get => DataUnitSkinListRaw.ToIEnumerableUnit(this);
            set => DataUnitSkinListRaw = value.ToRaw(null, null);
        }

        public static explicit operator LevelObjectModification(Ability ability) => new LevelObjectModification{OldId = ability.OldId, NewId = ability.NewId, Modifications = ability.Modifications.ToList()};
        private string GetTextTooltipNormal(int level)
        {
            return _modifications[829453409, level].ValueAsString;
        }

        private void SetTextTooltipNormal(int level, string value)
        {
            _modifications[829453409, level] = new LevelObjectDataModification{Id = 829453409, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private string GetTextTooltipTurnOff(int level)
        {
            return _modifications[829715809, level].ValueAsString;
        }

        private void SetTextTooltipTurnOff(int level, string value)
        {
            _modifications[829715809, level] = new LevelObjectDataModification{Id = 829715809, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private string GetTextTooltipNormalExtended(int level)
        {
            return _modifications[828536161, level].ValueAsString;
        }

        private void SetTextTooltipNormalExtended(int level, string value)
        {
            _modifications[828536161, level] = new LevelObjectDataModification{Id = 828536161, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private string GetTextTooltipTurnOffExtended(int level)
        {
            return _modifications[829781345, level].ValueAsString;
        }

        private void SetTextTooltipTurnOffExtended(int level, string value)
        {
            _modifications[829781345, level] = new LevelObjectDataModification{Id = 829781345, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private string GetStatsTargetsAllowedRaw(int level)
        {
            return _modifications[1918989409, level].ValueAsString;
        }

        private void SetStatsTargetsAllowedRaw(int level, string value)
        {
            _modifications[1918989409, level] = new LevelObjectDataModification{Id = 1918989409, Type = ObjectDataType.String, Value = value, Level = level};
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
            return _modifications[1935762273, level].ValueAsFloat;
        }

        private void SetStatsCastingTime(int level, float value)
        {
            _modifications[1935762273, level] = new LevelObjectDataModification{Id = 1935762273, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private float GetStatsDurationNormal(int level)
        {
            return _modifications[1920296033, level].ValueAsFloat;
        }

        private void SetStatsDurationNormal(int level, float value)
        {
            _modifications[1920296033, level] = new LevelObjectDataModification{Id = 1920296033, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private float GetStatsDurationHero(int level)
        {
            return _modifications[1969514593, level].ValueAsFloat;
        }

        private void SetStatsDurationHero(int level, float value)
        {
            _modifications[1969514593, level] = new LevelObjectDataModification{Id = 1969514593, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private float GetStatsCooldown(int level)
        {
            return _modifications[1852072801, level].ValueAsFloat;
        }

        private void SetStatsCooldown(int level, float value)
        {
            _modifications[1852072801, level] = new LevelObjectDataModification{Id = 1852072801, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private int GetStatsManaCost(int level)
        {
            return _modifications[1935895905, level].ValueAsInt;
        }

        private void SetStatsManaCost(int level, int value)
        {
            _modifications[1935895905, level] = new LevelObjectDataModification{Id = 1935895905, Type = ObjectDataType.Int, Value = value, Level = level};
        }

        private float GetStatsAreaOfEffect(int level)
        {
            return _modifications[1701994849, level].ValueAsFloat;
        }

        private void SetStatsAreaOfEffect(int level, float value)
        {
            _modifications[1701994849, level] = new LevelObjectDataModification{Id = 1701994849, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private float GetStatsCastRange(int level)
        {
            return _modifications[1851880033, level].ValueAsFloat;
        }

        private void SetStatsCastRange(int level, float value)
        {
            _modifications[1851880033, level] = new LevelObjectDataModification{Id = 1851880033, Type = ObjectDataType.Unreal, Value = value, Level = level};
        }

        private string GetStatsBuffsRaw(int level)
        {
            return _modifications[1718968929, level].ValueAsString;
        }

        private void SetStatsBuffsRaw(int level, string value)
        {
            _modifications[1718968929, level] = new LevelObjectDataModification{Id = 1718968929, Type = ObjectDataType.String, Value = value, Level = level};
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
            return _modifications[1717986657, level].ValueAsString;
        }

        private void SetStatsEffectsRaw(int level, string value)
        {
            _modifications[1717986657, level] = new LevelObjectDataModification{Id = 1717986657, Type = ObjectDataType.String, Value = value, Level = level};
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