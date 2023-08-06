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
    public sealed class GoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxGold;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxGoldModified;
        private readonly Lazy<ObjectProperty<float>> _dataMiningDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMiningDurationModified;
        private readonly Lazy<ObjectProperty<int>> _dataMiningCapacity;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMiningCapacityModified;
        public GoldMine(): base(1684825921)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _isDataMaxGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxGoldModified));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _isDataMiningDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningDurationModified));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
            _isDataMiningCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningCapacityModified));
        }

        public GoldMine(int newId): base(1684825921, newId)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _isDataMaxGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxGoldModified));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _isDataMiningDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningDurationModified));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
            _isDataMiningCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningCapacityModified));
        }

        public GoldMine(string newRawcode): base(1684825921, newRawcode)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _isDataMaxGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxGoldModified));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _isDataMiningDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningDurationModified));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
            _isDataMiningCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningCapacityModified));
        }

        public GoldMine(ObjectDatabaseBase db): base(1684825921, db)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _isDataMaxGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxGoldModified));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _isDataMiningDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningDurationModified));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
            _isDataMiningCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningCapacityModified));
        }

        public GoldMine(int newId, ObjectDatabaseBase db): base(1684825921, newId, db)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _isDataMaxGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxGoldModified));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _isDataMiningDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningDurationModified));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
            _isDataMiningCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningCapacityModified));
        }

        public GoldMine(string newRawcode, ObjectDatabaseBase db): base(1684825921, newRawcode, db)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _isDataMaxGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxGoldModified));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _isDataMiningDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningDurationModified));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
            _isDataMiningCapacityModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMiningCapacityModified));
        }

        public ObjectProperty<int> DataMaxGold => _dataMaxGold.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxGoldModified => _isDataMaxGoldModified.Value;
        public ObjectProperty<float> DataMiningDuration => _dataMiningDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataMiningDurationModified => _isDataMiningDurationModified.Value;
        public ObjectProperty<int> DataMiningCapacity => _dataMiningCapacity.Value;
        public ReadOnlyObjectProperty<bool> IsDataMiningCapacityModified => _isDataMiningCapacityModified.Value;
        private int GetDataMaxGold(int level)
        {
            return _modifications.GetModification(828664903, level).ValueAsInt;
        }

        private void SetDataMaxGold(int level, int value)
        {
            _modifications[828664903, level] = new LevelObjectDataModification{Id = 828664903, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxGoldModified(int level)
        {
            return _modifications.ContainsKey(828664903, level);
        }

        private float GetDataMiningDuration(int level)
        {
            return _modifications.GetModification(845442119, level).ValueAsFloat;
        }

        private void SetDataMiningDuration(int level, float value)
        {
            _modifications[845442119, level] = new LevelObjectDataModification{Id = 845442119, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMiningDurationModified(int level)
        {
            return _modifications.ContainsKey(845442119, level);
        }

        private int GetDataMiningCapacity(int level)
        {
            return _modifications.GetModification(862219335, level).ValueAsInt;
        }

        private void SetDataMiningCapacity(int level, int value)
        {
            _modifications[862219335, level] = new LevelObjectDataModification{Id = 862219335, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMiningCapacityModified(int level)
        {
            return _modifications.ContainsKey(862219335, level);
        }
    }
}