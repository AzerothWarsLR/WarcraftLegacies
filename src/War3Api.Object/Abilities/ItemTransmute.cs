using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemTransmute : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataGoldCostFactor;
        private readonly Lazy<ObjectProperty<float>> _dataLumberCostFactor;
        private readonly Lazy<ObjectProperty<int>> _dataMaxCreepLevel;
        private readonly Lazy<ObjectProperty<bool>> _dataAllowBounty;
        public ItemTransmute(): base(1937000769)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(int newId): base(1937000769, newId)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(string newRawcode): base(1937000769, newRawcode)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(ObjectDatabase db): base(1937000769, db)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(int newId, ObjectDatabase db): base(1937000769, newId, db)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(string newRawcode, ObjectDatabase db): base(1937000769, newRawcode, db)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ObjectProperty<float> DataGoldCostFactor => _dataGoldCostFactor.Value;
        public ObjectProperty<float> DataLumberCostFactor => _dataLumberCostFactor.Value;
        public ObjectProperty<int> DataMaxCreepLevel => _dataMaxCreepLevel.Value;
        public ObjectProperty<bool> DataAllowBounty => _dataAllowBounty.Value;
        private float GetDataGoldCostFactor(int level)
        {
            return _modifications[829256782, level].ValueAsFloat;
        }

        private void SetDataGoldCostFactor(int level, float value)
        {
            _modifications[829256782, level] = new LevelObjectDataModification{Id = 829256782, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataLumberCostFactor(int level)
        {
            return _modifications[846033998, level].ValueAsFloat;
        }

        private void SetDataLumberCostFactor(int level, float value)
        {
            _modifications[846033998, level] = new LevelObjectDataModification{Id = 846033998, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaxCreepLevel(int level)
        {
            return _modifications[862811214, level].ValueAsInt;
        }

        private void SetDataMaxCreepLevel(int level, int value)
        {
            _modifications[862811214, level] = new LevelObjectDataModification{Id = 862811214, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataAllowBounty(int level)
        {
            return _modifications[879588430, level].ValueAsBool;
        }

        private void SetDataAllowBounty(int level, bool value)
        {
            _modifications[879588430, level] = new LevelObjectDataModification{Id = 879588430, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}