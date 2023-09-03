using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class EvilIllidanMetamorphosis : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataNormalFormUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNormalFormUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataNormalFormUnit;
        private readonly Lazy<ObjectProperty<int>> _dataMorphingFlagsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMorphingFlagsModified;
        private readonly Lazy<ObjectProperty<MorphFlags>> _dataMorphingFlags;
        private readonly Lazy<ObjectProperty<float>> _dataAltitudeAdjustmentDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAltitudeAdjustmentDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataLandingDelayTime;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLandingDelayTimeModified;
        private readonly Lazy<ObjectProperty<float>> _dataAlternateFormHitPointBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAlternateFormHitPointBonusModified;
        private readonly Lazy<ObjectProperty<string>> _dataAlternateFormUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAlternateFormUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataAlternateFormUnit;
        public EvilIllidanMetamorphosis(): base(1769358657)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _isDataLandingDelayTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLandingDelayTimeModified));
            _dataAlternateFormHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAlternateFormHitPointBonus, SetDataAlternateFormHitPointBonus));
            _isDataAlternateFormHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormHitPointBonusModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public EvilIllidanMetamorphosis(int newId): base(1769358657, newId)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _isDataLandingDelayTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLandingDelayTimeModified));
            _dataAlternateFormHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAlternateFormHitPointBonus, SetDataAlternateFormHitPointBonus));
            _isDataAlternateFormHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormHitPointBonusModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public EvilIllidanMetamorphosis(string newRawcode): base(1769358657, newRawcode)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _isDataLandingDelayTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLandingDelayTimeModified));
            _dataAlternateFormHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAlternateFormHitPointBonus, SetDataAlternateFormHitPointBonus));
            _isDataAlternateFormHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormHitPointBonusModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public EvilIllidanMetamorphosis(ObjectDatabaseBase db): base(1769358657, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _isDataLandingDelayTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLandingDelayTimeModified));
            _dataAlternateFormHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAlternateFormHitPointBonus, SetDataAlternateFormHitPointBonus));
            _isDataAlternateFormHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormHitPointBonusModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public EvilIllidanMetamorphosis(int newId, ObjectDatabaseBase db): base(1769358657, newId, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _isDataLandingDelayTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLandingDelayTimeModified));
            _dataAlternateFormHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAlternateFormHitPointBonus, SetDataAlternateFormHitPointBonus));
            _isDataAlternateFormHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormHitPointBonusModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public EvilIllidanMetamorphosis(string newRawcode, ObjectDatabaseBase db): base(1769358657, newRawcode, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataLandingDelayTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLandingDelayTime, SetDataLandingDelayTime));
            _isDataLandingDelayTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLandingDelayTimeModified));
            _dataAlternateFormHitPointBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAlternateFormHitPointBonus, SetDataAlternateFormHitPointBonus));
            _isDataAlternateFormHitPointBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormHitPointBonusModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public ObjectProperty<string> DataNormalFormUnitRaw => _dataNormalFormUnitRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNormalFormUnitModified => _isDataNormalFormUnitModified.Value;
        public ObjectProperty<Unit> DataNormalFormUnit => _dataNormalFormUnit.Value;
        public ObjectProperty<int> DataMorphingFlagsRaw => _dataMorphingFlagsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataMorphingFlagsModified => _isDataMorphingFlagsModified.Value;
        public ObjectProperty<MorphFlags> DataMorphingFlags => _dataMorphingFlags.Value;
        public ObjectProperty<float> DataAltitudeAdjustmentDuration => _dataAltitudeAdjustmentDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataAltitudeAdjustmentDurationModified => _isDataAltitudeAdjustmentDurationModified.Value;
        public ObjectProperty<float> DataLandingDelayTime => _dataLandingDelayTime.Value;
        public ReadOnlyObjectProperty<bool> IsDataLandingDelayTimeModified => _isDataLandingDelayTimeModified.Value;
        public ObjectProperty<float> DataAlternateFormHitPointBonus => _dataAlternateFormHitPointBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataAlternateFormHitPointBonusModified => _isDataAlternateFormHitPointBonusModified.Value;
        public ObjectProperty<string> DataAlternateFormUnitRaw => _dataAlternateFormUnitRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAlternateFormUnitModified => _isDataAlternateFormUnitModified.Value;
        public ObjectProperty<Unit> DataAlternateFormUnit => _dataAlternateFormUnit.Value;
        private string GetDataNormalFormUnitRaw(int level)
        {
            return _modifications.GetModification(828730693, level).ValueAsString;
        }

        private void SetDataNormalFormUnitRaw(int level, string value)
        {
            _modifications[828730693, level] = new LevelObjectDataModification{Id = 828730693, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNormalFormUnitModified(int level)
        {
            return _modifications.ContainsKey(828730693, level);
        }

        private Unit GetDataNormalFormUnit(int level)
        {
            return GetDataNormalFormUnitRaw(level).ToUnit(this);
        }

        private void SetDataNormalFormUnit(int level, Unit value)
        {
            SetDataNormalFormUnitRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMorphingFlagsRaw(int level)
        {
            return _modifications.GetModification(845507909, level).ValueAsInt;
        }

        private void SetDataMorphingFlagsRaw(int level, int value)
        {
            _modifications[845507909, level] = new LevelObjectDataModification{Id = 845507909, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMorphingFlagsModified(int level)
        {
            return _modifications.ContainsKey(845507909, level);
        }

        private MorphFlags GetDataMorphingFlags(int level)
        {
            return GetDataMorphingFlagsRaw(level).ToMorphFlags(this);
        }

        private void SetDataMorphingFlags(int level, MorphFlags value)
        {
            SetDataMorphingFlagsRaw(level, value.ToRaw(0, 99999));
        }

        private float GetDataAltitudeAdjustmentDuration(int level)
        {
            return _modifications.GetModification(862285125, level).ValueAsFloat;
        }

        private void SetDataAltitudeAdjustmentDuration(int level, float value)
        {
            _modifications[862285125, level] = new LevelObjectDataModification{Id = 862285125, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAltitudeAdjustmentDurationModified(int level)
        {
            return _modifications.ContainsKey(862285125, level);
        }

        private float GetDataLandingDelayTime(int level)
        {
            return _modifications.GetModification(879062341, level).ValueAsFloat;
        }

        private void SetDataLandingDelayTime(int level, float value)
        {
            _modifications[879062341, level] = new LevelObjectDataModification{Id = 879062341, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataLandingDelayTimeModified(int level)
        {
            return _modifications.ContainsKey(879062341, level);
        }

        private float GetDataAlternateFormHitPointBonus(int level)
        {
            return _modifications.GetModification(895839557, level).ValueAsFloat;
        }

        private void SetDataAlternateFormHitPointBonus(int level, float value)
        {
            _modifications[895839557, level] = new LevelObjectDataModification{Id = 895839557, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataAlternateFormHitPointBonusModified(int level)
        {
            return _modifications.ContainsKey(895839557, level);
        }

        private string GetDataAlternateFormUnitRaw(int level)
        {
            return _modifications.GetModification(1969581381, level).ValueAsString;
        }

        private void SetDataAlternateFormUnitRaw(int level, string value)
        {
            _modifications[1969581381, level] = new LevelObjectDataModification{Id = 1969581381, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataAlternateFormUnitModified(int level)
        {
            return _modifications.ContainsKey(1969581381, level);
        }

        private Unit GetDataAlternateFormUnit(int level)
        {
            return GetDataAlternateFormUnitRaw(level).ToUnit(this);
        }

        private void SetDataAlternateFormUnit(int level, Unit value)
        {
            SetDataAlternateFormUnitRaw(level, value.ToRaw(null, null));
        }
    }
}