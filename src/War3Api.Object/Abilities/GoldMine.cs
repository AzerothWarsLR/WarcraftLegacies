using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class GoldMine : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxGold;
        private readonly Lazy<ObjectProperty<float>> _dataMiningDuration;
        private readonly Lazy<ObjectProperty<int>> _dataMiningCapacity;
        public GoldMine(): base(1684825921)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
        }

        public GoldMine(int newId): base(1684825921, newId)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
        }

        public GoldMine(string newRawcode): base(1684825921, newRawcode)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
        }

        public GoldMine(ObjectDatabase db): base(1684825921, db)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
        }

        public GoldMine(int newId, ObjectDatabase db): base(1684825921, newId, db)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
        }

        public GoldMine(string newRawcode, ObjectDatabase db): base(1684825921, newRawcode, db)
        {
            _dataMaxGold = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxGold, SetDataMaxGold));
            _dataMiningDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMiningDuration, SetDataMiningDuration));
            _dataMiningCapacity = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMiningCapacity, SetDataMiningCapacity));
        }

        public ObjectProperty<int> DataMaxGold => _dataMaxGold.Value;
        public ObjectProperty<float> DataMiningDuration => _dataMiningDuration.Value;
        public ObjectProperty<int> DataMiningCapacity => _dataMiningCapacity.Value;
        private int GetDataMaxGold(int level)
        {
            return _modifications[828664903, level].ValueAsInt;
        }

        private void SetDataMaxGold(int level, int value)
        {
            _modifications[828664903, level] = new LevelObjectDataModification{Id = 828664903, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMiningDuration(int level)
        {
            return _modifications[845442119, level].ValueAsFloat;
        }

        private void SetDataMiningDuration(int level, float value)
        {
            _modifications[845442119, level] = new LevelObjectDataModification{Id = 845442119, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMiningCapacity(int level)
        {
            return _modifications[862219335, level].ValueAsInt;
        }

        private void SetDataMiningCapacity(int level, int value)
        {
            _modifications[862219335, level] = new LevelObjectDataModification{Id = 862219335, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}