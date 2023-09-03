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
    public sealed class FlameStrikeCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageDealt;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageDealtModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageDealt;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHalfDamageDealtModified;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHalfDamageIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingReductionModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumDamageModified;
        public FlameStrikeCreep(): base(1936081729)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _isDataFullDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageDealtModified));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _isDataFullDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageIntervalModified));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _isDataHalfDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageDealtModified));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _isDataHalfDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FlameStrikeCreep(int newId): base(1936081729, newId)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _isDataFullDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageDealtModified));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _isDataFullDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageIntervalModified));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _isDataHalfDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageDealtModified));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _isDataHalfDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FlameStrikeCreep(string newRawcode): base(1936081729, newRawcode)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _isDataFullDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageDealtModified));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _isDataFullDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageIntervalModified));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _isDataHalfDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageDealtModified));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _isDataHalfDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FlameStrikeCreep(ObjectDatabaseBase db): base(1936081729, db)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _isDataFullDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageDealtModified));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _isDataFullDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageIntervalModified));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _isDataHalfDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageDealtModified));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _isDataHalfDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FlameStrikeCreep(int newId, ObjectDatabaseBase db): base(1936081729, newId, db)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _isDataFullDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageDealtModified));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _isDataFullDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageIntervalModified));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _isDataHalfDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageDealtModified));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _isDataHalfDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FlameStrikeCreep(string newRawcode, ObjectDatabaseBase db): base(1936081729, newRawcode, db)
        {
            _dataFullDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageDealt, SetDataFullDamageDealt));
            _isDataFullDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageDealtModified));
            _dataFullDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageInterval, SetDataFullDamageInterval));
            _isDataFullDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageIntervalModified));
            _dataHalfDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageDealt, SetDataHalfDamageDealt));
            _isDataHalfDamageDealtModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageDealtModified));
            _dataHalfDamageInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageInterval, SetDataHalfDamageInterval));
            _isDataHalfDamageIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageIntervalModified));
            _dataBuildingReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingReduction, SetDataBuildingReduction));
            _isDataBuildingReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingReductionModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public ObjectProperty<float> DataFullDamageDealt => _dataFullDamageDealt.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageDealtModified => _isDataFullDamageDealtModified.Value;
        public ObjectProperty<float> DataFullDamageInterval => _dataFullDamageInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageIntervalModified => _isDataFullDamageIntervalModified.Value;
        public ObjectProperty<float> DataHalfDamageDealt => _dataHalfDamageDealt.Value;
        public ReadOnlyObjectProperty<bool> IsDataHalfDamageDealtModified => _isDataHalfDamageDealtModified.Value;
        public ObjectProperty<float> DataHalfDamageInterval => _dataHalfDamageInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataHalfDamageIntervalModified => _isDataHalfDamageIntervalModified.Value;
        public ObjectProperty<float> DataBuildingReduction => _dataBuildingReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingReductionModified => _isDataBuildingReductionModified.Value;
        public ObjectProperty<float> DataMaximumDamage => _dataMaximumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumDamageModified => _isDataMaximumDamageModified.Value;
        private float GetDataFullDamageDealt(int level)
        {
            return _modifications.GetModification(829646408, level).ValueAsFloat;
        }

        private void SetDataFullDamageDealt(int level, float value)
        {
            _modifications[829646408, level] = new LevelObjectDataModification{Id = 829646408, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataFullDamageDealtModified(int level)
        {
            return _modifications.ContainsKey(829646408, level);
        }

        private float GetDataFullDamageInterval(int level)
        {
            return _modifications.GetModification(846423624, level).ValueAsFloat;
        }

        private void SetDataFullDamageInterval(int level, float value)
        {
            _modifications[846423624, level] = new LevelObjectDataModification{Id = 846423624, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataFullDamageIntervalModified(int level)
        {
            return _modifications.ContainsKey(846423624, level);
        }

        private float GetDataHalfDamageDealt(int level)
        {
            return _modifications.GetModification(863200840, level).ValueAsFloat;
        }

        private void SetDataHalfDamageDealt(int level, float value)
        {
            _modifications[863200840, level] = new LevelObjectDataModification{Id = 863200840, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataHalfDamageDealtModified(int level)
        {
            return _modifications.ContainsKey(863200840, level);
        }

        private float GetDataHalfDamageInterval(int level)
        {
            return _modifications.GetModification(879978056, level).ValueAsFloat;
        }

        private void SetDataHalfDamageInterval(int level, float value)
        {
            _modifications[879978056, level] = new LevelObjectDataModification{Id = 879978056, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataHalfDamageIntervalModified(int level)
        {
            return _modifications.ContainsKey(879978056, level);
        }

        private float GetDataBuildingReduction(int level)
        {
            return _modifications.GetModification(896755272, level).ValueAsFloat;
        }

        private void SetDataBuildingReduction(int level, float value)
        {
            _modifications[896755272, level] = new LevelObjectDataModification{Id = 896755272, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataBuildingReductionModified(int level)
        {
            return _modifications.ContainsKey(896755272, level);
        }

        private float GetDataMaximumDamage(int level)
        {
            return _modifications.GetModification(913532488, level).ValueAsFloat;
        }

        private void SetDataMaximumDamage(int level, float value)
        {
            _modifications[913532488, level] = new LevelObjectDataModification{Id = 913532488, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataMaximumDamageModified(int level)
        {
            return _modifications.ContainsKey(913532488, level);
        }
    }
}