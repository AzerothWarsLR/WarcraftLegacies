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
    public sealed class SunderingBlades : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataBonusDamageFlat;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusDamageFlatModified;
        private readonly Lazy<ObjectProperty<float>> _dataBonusDamagePercent;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBonusDamagePercentModified;
        private readonly Lazy<ObjectProperty<int>> _dataDefenseTypeAffectedRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDefenseTypeAffectedModified;
        private readonly Lazy<ObjectProperty<DefenseTypeInt>> _dataDefenseTypeAffected;
        public SunderingBlades(): base(1651730497)
        {
            _dataBonusDamageFlat = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageFlat, SetDataBonusDamageFlat));
            _isDataBonusDamageFlatModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageFlatModified));
            _dataBonusDamagePercent = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamagePercent, SetDataBonusDamagePercent));
            _isDataBonusDamagePercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamagePercentModified));
            _dataDefenseTypeAffectedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseTypeAffectedRaw, SetDataDefenseTypeAffectedRaw));
            _isDataDefenseTypeAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseTypeAffectedModified));
            _dataDefenseTypeAffected = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataDefenseTypeAffected, SetDataDefenseTypeAffected));
        }

        public SunderingBlades(int newId): base(1651730497, newId)
        {
            _dataBonusDamageFlat = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageFlat, SetDataBonusDamageFlat));
            _isDataBonusDamageFlatModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageFlatModified));
            _dataBonusDamagePercent = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamagePercent, SetDataBonusDamagePercent));
            _isDataBonusDamagePercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamagePercentModified));
            _dataDefenseTypeAffectedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseTypeAffectedRaw, SetDataDefenseTypeAffectedRaw));
            _isDataDefenseTypeAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseTypeAffectedModified));
            _dataDefenseTypeAffected = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataDefenseTypeAffected, SetDataDefenseTypeAffected));
        }

        public SunderingBlades(string newRawcode): base(1651730497, newRawcode)
        {
            _dataBonusDamageFlat = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageFlat, SetDataBonusDamageFlat));
            _isDataBonusDamageFlatModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageFlatModified));
            _dataBonusDamagePercent = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamagePercent, SetDataBonusDamagePercent));
            _isDataBonusDamagePercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamagePercentModified));
            _dataDefenseTypeAffectedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseTypeAffectedRaw, SetDataDefenseTypeAffectedRaw));
            _isDataDefenseTypeAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseTypeAffectedModified));
            _dataDefenseTypeAffected = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataDefenseTypeAffected, SetDataDefenseTypeAffected));
        }

        public SunderingBlades(ObjectDatabaseBase db): base(1651730497, db)
        {
            _dataBonusDamageFlat = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageFlat, SetDataBonusDamageFlat));
            _isDataBonusDamageFlatModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageFlatModified));
            _dataBonusDamagePercent = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamagePercent, SetDataBonusDamagePercent));
            _isDataBonusDamagePercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamagePercentModified));
            _dataDefenseTypeAffectedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseTypeAffectedRaw, SetDataDefenseTypeAffectedRaw));
            _isDataDefenseTypeAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseTypeAffectedModified));
            _dataDefenseTypeAffected = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataDefenseTypeAffected, SetDataDefenseTypeAffected));
        }

        public SunderingBlades(int newId, ObjectDatabaseBase db): base(1651730497, newId, db)
        {
            _dataBonusDamageFlat = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageFlat, SetDataBonusDamageFlat));
            _isDataBonusDamageFlatModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageFlatModified));
            _dataBonusDamagePercent = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamagePercent, SetDataBonusDamagePercent));
            _isDataBonusDamagePercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamagePercentModified));
            _dataDefenseTypeAffectedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseTypeAffectedRaw, SetDataDefenseTypeAffectedRaw));
            _isDataDefenseTypeAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseTypeAffectedModified));
            _dataDefenseTypeAffected = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataDefenseTypeAffected, SetDataDefenseTypeAffected));
        }

        public SunderingBlades(string newRawcode, ObjectDatabaseBase db): base(1651730497, newRawcode, db)
        {
            _dataBonusDamageFlat = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamageFlat, SetDataBonusDamageFlat));
            _isDataBonusDamageFlatModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamageFlatModified));
            _dataBonusDamagePercent = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBonusDamagePercent, SetDataBonusDamagePercent));
            _isDataBonusDamagePercentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBonusDamagePercentModified));
            _dataDefenseTypeAffectedRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseTypeAffectedRaw, SetDataDefenseTypeAffectedRaw));
            _isDataDefenseTypeAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseTypeAffectedModified));
            _dataDefenseTypeAffected = new Lazy<ObjectProperty<DefenseTypeInt>>(() => new ObjectProperty<DefenseTypeInt>(GetDataDefenseTypeAffected, SetDataDefenseTypeAffected));
        }

        public ObjectProperty<float> DataBonusDamageFlat => _dataBonusDamageFlat.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusDamageFlatModified => _isDataBonusDamageFlatModified.Value;
        public ObjectProperty<float> DataBonusDamagePercent => _dataBonusDamagePercent.Value;
        public ReadOnlyObjectProperty<bool> IsDataBonusDamagePercentModified => _isDataBonusDamagePercentModified.Value;
        public ObjectProperty<int> DataDefenseTypeAffectedRaw => _dataDefenseTypeAffectedRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDefenseTypeAffectedModified => _isDataDefenseTypeAffectedModified.Value;
        public ObjectProperty<DefenseTypeInt> DataDefenseTypeAffected => _dataDefenseTypeAffected.Value;
        private float GetDataBonusDamageFlat(int level)
        {
            return _modifications.GetModification(828535624, level).ValueAsFloat;
        }

        private void SetDataBonusDamageFlat(int level, float value)
        {
            _modifications[828535624, level] = new LevelObjectDataModification{Id = 828535624, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataBonusDamageFlatModified(int level)
        {
            return _modifications.ContainsKey(828535624, level);
        }

        private float GetDataBonusDamagePercent(int level)
        {
            return _modifications.GetModification(845312840, level).ValueAsFloat;
        }

        private void SetDataBonusDamagePercent(int level, float value)
        {
            _modifications[845312840, level] = new LevelObjectDataModification{Id = 845312840, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataBonusDamagePercentModified(int level)
        {
            return _modifications.ContainsKey(845312840, level);
        }

        private int GetDataDefenseTypeAffectedRaw(int level)
        {
            return _modifications.GetModification(862090056, level).ValueAsInt;
        }

        private void SetDataDefenseTypeAffectedRaw(int level, int value)
        {
            _modifications[862090056, level] = new LevelObjectDataModification{Id = 862090056, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDefenseTypeAffectedModified(int level)
        {
            return _modifications.ContainsKey(862090056, level);
        }

        private DefenseTypeInt GetDataDefenseTypeAffected(int level)
        {
            return GetDataDefenseTypeAffectedRaw(level).ToDefenseTypeInt(this);
        }

        private void SetDataDefenseTypeAffected(int level, DefenseTypeInt value)
        {
            SetDataDefenseTypeAffectedRaw(level, value.ToRaw(null, null));
        }
    }
}