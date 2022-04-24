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
    public sealed class SubmergeMyrmidon : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataNormalFormUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNormalFormUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataNormalFormUnit;
        private readonly Lazy<ObjectProperty<int>> _dataMorphingFlagsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMorphingFlagsModified;
        private readonly Lazy<ObjectProperty<MorphFlags>> _dataMorphingFlags;
        private readonly Lazy<ObjectProperty<float>> _dataAltitudeAdjustmentDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAltitudeAdjustmentDurationModified;
        private readonly Lazy<ObjectProperty<string>> _dataAlternateFormUnitRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAlternateFormUnitModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataAlternateFormUnit;
        public SubmergeMyrmidon(): base(828535617)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public SubmergeMyrmidon(int newId): base(828535617, newId)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public SubmergeMyrmidon(string newRawcode): base(828535617, newRawcode)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public SubmergeMyrmidon(ObjectDatabaseBase db): base(828535617, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public SubmergeMyrmidon(int newId, ObjectDatabaseBase db): base(828535617, newId, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
            _dataAlternateFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAlternateFormUnitRaw, SetDataAlternateFormUnitRaw));
            _isDataAlternateFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAlternateFormUnitModified));
            _dataAlternateFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataAlternateFormUnit, SetDataAlternateFormUnit));
        }

        public SubmergeMyrmidon(string newRawcode, ObjectDatabaseBase db): base(828535617, newRawcode, db)
        {
            _dataNormalFormUnitRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataNormalFormUnitRaw, SetDataNormalFormUnitRaw));
            _isDataNormalFormUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNormalFormUnitModified));
            _dataNormalFormUnit = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataNormalFormUnit, SetDataNormalFormUnit));
            _dataMorphingFlagsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMorphingFlagsRaw, SetDataMorphingFlagsRaw));
            _isDataMorphingFlagsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMorphingFlagsModified));
            _dataMorphingFlags = new Lazy<ObjectProperty<MorphFlags>>(() => new ObjectProperty<MorphFlags>(GetDataMorphingFlags, SetDataMorphingFlags));
            _dataAltitudeAdjustmentDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAltitudeAdjustmentDuration, SetDataAltitudeAdjustmentDuration));
            _isDataAltitudeAdjustmentDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAltitudeAdjustmentDurationModified));
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