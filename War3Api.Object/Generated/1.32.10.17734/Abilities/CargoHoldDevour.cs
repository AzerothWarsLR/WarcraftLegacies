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
    public sealed class CargoHoldDevour : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataCargoCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataCargoCapacityModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumCreepLevelModified;
        public CargoHoldDevour(): base(1668703297)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public CargoHoldDevour(int newId): base(1668703297, newId)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public CargoHoldDevour(string newRawcode): base(1668703297, newRawcode)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public CargoHoldDevour(ObjectDatabaseBase db): base(1668703297, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public CargoHoldDevour(int newId, ObjectDatabaseBase db): base(1668703297, newId, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public CargoHoldDevour(string newRawcode, ObjectDatabaseBase db): base(1668703297, newRawcode, db)
        {
            _dataCargoCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataCargoCapacity, SetDataCargoCapacity));
            _isDataCargoCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataCargoCapacityModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
            _dataMaximumCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumCreepLevel, SetDataMaximumCreepLevel));
            _isDataMaximumCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumCreepLevelModified));
        }

        public ObjectProperty<int> DataCargoCapacity => _dataCargoCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataCargoCapacityModified => _isDataCargoCapacityModified.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        public ObjectProperty<int> DataMaximumCreepLevel => _dataMaximumCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumCreepLevelModified => _isDataMaximumCreepLevelModified.Value;
        private int GetDataCargoCapacity(int level)
        {
            return _modifications.GetModification(829579587, level).ValueAsInt;
        }

        private void SetDataCargoCapacity(int level, int value)
        {
            _modifications[829579587, level] = new LevelObjectDataModification{Id = 829579587, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataCargoCapacityModified(int level)
        {
            return _modifications.ContainsKey(829579587, level);
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(846619972, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[846619972, level] = new LevelObjectDataModification{Id = 846619972, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(846619972, level);
        }

        private int GetDataMaximumCreepLevel(int level)
        {
            return _modifications.GetModification(863397188, level).ValueAsInt;
        }

        private void SetDataMaximumCreepLevel(int level, int value)
        {
            _modifications[863397188, level] = new LevelObjectDataModification{Id = 863397188, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaximumCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(863397188, level);
        }
    }
}