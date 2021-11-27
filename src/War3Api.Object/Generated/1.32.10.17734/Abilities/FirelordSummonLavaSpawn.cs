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
    public sealed class FirelordSummonLavaSpawn : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataSummonedUnitTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitTypeModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataSummonedUnitType;
        private readonly Lazy<ObjectProperty<int>> _dataSummonedUnitCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitCountModified;
        private readonly Lazy<ObjectProperty<float>> _dataSplitDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSplitDelayModified;
        private readonly Lazy<ObjectProperty<int>> _dataSplitAttackCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSplitAttackCountModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaxHitpointFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxHitpointFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifeDurationSplitBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeDurationSplitBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataGenerationCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGenerationCountModified;
        public FirelordSummonLavaSpawn(): base(1835814465)
        {
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _isDataSummonedUnitCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitCountModified));
            _dataSplitDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSplitDelay, SetDataSplitDelay));
            _isDataSplitDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitDelayModified));
            _dataSplitAttackCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSplitAttackCount, SetDataSplitAttackCount));
            _isDataSplitAttackCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitAttackCountModified));
            _dataMaxHitpointFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitpointFactor, SetDataMaxHitpointFactor));
            _isDataMaxHitpointFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxHitpointFactorModified));
            _dataLifeDurationSplitBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeDurationSplitBonus, SetDataLifeDurationSplitBonus));
            _isDataLifeDurationSplitBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeDurationSplitBonusModified));
            _dataGenerationCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGenerationCount, SetDataGenerationCount));
            _isDataGenerationCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGenerationCountModified));
        }

        public FirelordSummonLavaSpawn(int newId): base(1835814465, newId)
        {
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _isDataSummonedUnitCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitCountModified));
            _dataSplitDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSplitDelay, SetDataSplitDelay));
            _isDataSplitDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitDelayModified));
            _dataSplitAttackCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSplitAttackCount, SetDataSplitAttackCount));
            _isDataSplitAttackCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitAttackCountModified));
            _dataMaxHitpointFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitpointFactor, SetDataMaxHitpointFactor));
            _isDataMaxHitpointFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxHitpointFactorModified));
            _dataLifeDurationSplitBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeDurationSplitBonus, SetDataLifeDurationSplitBonus));
            _isDataLifeDurationSplitBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeDurationSplitBonusModified));
            _dataGenerationCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGenerationCount, SetDataGenerationCount));
            _isDataGenerationCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGenerationCountModified));
        }

        public FirelordSummonLavaSpawn(string newRawcode): base(1835814465, newRawcode)
        {
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _isDataSummonedUnitCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitCountModified));
            _dataSplitDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSplitDelay, SetDataSplitDelay));
            _isDataSplitDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitDelayModified));
            _dataSplitAttackCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSplitAttackCount, SetDataSplitAttackCount));
            _isDataSplitAttackCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitAttackCountModified));
            _dataMaxHitpointFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitpointFactor, SetDataMaxHitpointFactor));
            _isDataMaxHitpointFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxHitpointFactorModified));
            _dataLifeDurationSplitBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeDurationSplitBonus, SetDataLifeDurationSplitBonus));
            _isDataLifeDurationSplitBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeDurationSplitBonusModified));
            _dataGenerationCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGenerationCount, SetDataGenerationCount));
            _isDataGenerationCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGenerationCountModified));
        }

        public FirelordSummonLavaSpawn(ObjectDatabaseBase db): base(1835814465, db)
        {
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _isDataSummonedUnitCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitCountModified));
            _dataSplitDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSplitDelay, SetDataSplitDelay));
            _isDataSplitDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitDelayModified));
            _dataSplitAttackCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSplitAttackCount, SetDataSplitAttackCount));
            _isDataSplitAttackCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitAttackCountModified));
            _dataMaxHitpointFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitpointFactor, SetDataMaxHitpointFactor));
            _isDataMaxHitpointFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxHitpointFactorModified));
            _dataLifeDurationSplitBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeDurationSplitBonus, SetDataLifeDurationSplitBonus));
            _isDataLifeDurationSplitBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeDurationSplitBonusModified));
            _dataGenerationCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGenerationCount, SetDataGenerationCount));
            _isDataGenerationCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGenerationCountModified));
        }

        public FirelordSummonLavaSpawn(int newId, ObjectDatabaseBase db): base(1835814465, newId, db)
        {
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _isDataSummonedUnitCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitCountModified));
            _dataSplitDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSplitDelay, SetDataSplitDelay));
            _isDataSplitDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitDelayModified));
            _dataSplitAttackCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSplitAttackCount, SetDataSplitAttackCount));
            _isDataSplitAttackCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitAttackCountModified));
            _dataMaxHitpointFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitpointFactor, SetDataMaxHitpointFactor));
            _isDataMaxHitpointFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxHitpointFactorModified));
            _dataLifeDurationSplitBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeDurationSplitBonus, SetDataLifeDurationSplitBonus));
            _isDataLifeDurationSplitBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeDurationSplitBonusModified));
            _dataGenerationCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGenerationCount, SetDataGenerationCount));
            _isDataGenerationCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGenerationCountModified));
        }

        public FirelordSummonLavaSpawn(string newRawcode, ObjectDatabaseBase db): base(1835814465, newRawcode, db)
        {
            _dataSummonedUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSummonedUnitTypeRaw, SetDataSummonedUnitTypeRaw));
            _isDataSummonedUnitTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitTypeModified));
            _dataSummonedUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataSummonedUnitType, SetDataSummonedUnitType));
            _dataSummonedUnitCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSummonedUnitCount, SetDataSummonedUnitCount));
            _isDataSummonedUnitCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitCountModified));
            _dataSplitDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSplitDelay, SetDataSplitDelay));
            _isDataSplitDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitDelayModified));
            _dataSplitAttackCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSplitAttackCount, SetDataSplitAttackCount));
            _isDataSplitAttackCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSplitAttackCountModified));
            _dataMaxHitpointFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxHitpointFactor, SetDataMaxHitpointFactor));
            _isDataMaxHitpointFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxHitpointFactorModified));
            _dataLifeDurationSplitBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeDurationSplitBonus, SetDataLifeDurationSplitBonus));
            _isDataLifeDurationSplitBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeDurationSplitBonusModified));
            _dataGenerationCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGenerationCount, SetDataGenerationCount));
            _isDataGenerationCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGenerationCountModified));
        }

        public ObjectProperty<string> DataSummonedUnitTypeRaw => _dataSummonedUnitTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitTypeModified => _isDataSummonedUnitTypeModified.Value;
        public ObjectProperty<Unit> DataSummonedUnitType => _dataSummonedUnitType.Value;
        public ObjectProperty<int> DataSummonedUnitCount => _dataSummonedUnitCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitCountModified => _isDataSummonedUnitCountModified.Value;
        public ObjectProperty<float> DataSplitDelay => _dataSplitDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataSplitDelayModified => _isDataSplitDelayModified.Value;
        public ObjectProperty<int> DataSplitAttackCount => _dataSplitAttackCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataSplitAttackCountModified => _isDataSplitAttackCountModified.Value;
        public ObjectProperty<float> DataMaxHitpointFactor => _dataMaxHitpointFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxHitpointFactorModified => _isDataMaxHitpointFactorModified.Value;
        public ObjectProperty<float> DataLifeDurationSplitBonus => _dataLifeDurationSplitBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeDurationSplitBonusModified => _isDataLifeDurationSplitBonusModified.Value;
        public ObjectProperty<int> DataGenerationCount => _dataGenerationCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataGenerationCountModified => _isDataGenerationCountModified.Value;
        private string GetDataSummonedUnitTypeRaw(int level)
        {
            return _modifications.GetModification(828733256, level).ValueAsString;
        }

        private void SetDataSummonedUnitTypeRaw(int level, string value)
        {
            _modifications[828733256, level] = new LevelObjectDataModification{Id = 828733256, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataSummonedUnitTypeModified(int level)
        {
            return _modifications.ContainsKey(828733256, level);
        }

        private Unit GetDataSummonedUnitType(int level)
        {
            return GetDataSummonedUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataSummonedUnitType(int level, Unit value)
        {
            SetDataSummonedUnitTypeRaw(level, value.ToRaw(null, null));
        }

        private int GetDataSummonedUnitCount(int level)
        {
            return _modifications.GetModification(845510472, level).ValueAsInt;
        }

        private void SetDataSummonedUnitCount(int level, int value)
        {
            _modifications[845510472, level] = new LevelObjectDataModification{Id = 845510472, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSummonedUnitCountModified(int level)
        {
            return _modifications.ContainsKey(845510472, level);
        }

        private float GetDataSplitDelay(int level)
        {
            return _modifications.GetModification(846031950, level).ValueAsFloat;
        }

        private void SetDataSplitDelay(int level, float value)
        {
            _modifications[846031950, level] = new LevelObjectDataModification{Id = 846031950, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSplitDelayModified(int level)
        {
            return _modifications.ContainsKey(846031950, level);
        }

        private int GetDataSplitAttackCount(int level)
        {
            return _modifications.GetModification(862809166, level).ValueAsInt;
        }

        private void SetDataSplitAttackCount(int level, int value)
        {
            _modifications[862809166, level] = new LevelObjectDataModification{Id = 862809166, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSplitAttackCountModified(int level)
        {
            return _modifications.ContainsKey(862809166, level);
        }

        private float GetDataMaxHitpointFactor(int level)
        {
            return _modifications.GetModification(879586382, level).ValueAsFloat;
        }

        private void SetDataMaxHitpointFactor(int level, float value)
        {
            _modifications[879586382, level] = new LevelObjectDataModification{Id = 879586382, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMaxHitpointFactorModified(int level)
        {
            return _modifications.ContainsKey(879586382, level);
        }

        private float GetDataLifeDurationSplitBonus(int level)
        {
            return _modifications.GetModification(896363598, level).ValueAsFloat;
        }

        private void SetDataLifeDurationSplitBonus(int level, float value)
        {
            _modifications[896363598, level] = new LevelObjectDataModification{Id = 896363598, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataLifeDurationSplitBonusModified(int level)
        {
            return _modifications.ContainsKey(896363598, level);
        }

        private int GetDataGenerationCount(int level)
        {
            return _modifications.GetModification(913140814, level).ValueAsInt;
        }

        private void SetDataGenerationCount(int level, int value)
        {
            _modifications[913140814, level] = new LevelObjectDataModification{Id = 913140814, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataGenerationCountModified(int level)
        {
            return _modifications.ContainsKey(913140814, level);
        }
    }
}