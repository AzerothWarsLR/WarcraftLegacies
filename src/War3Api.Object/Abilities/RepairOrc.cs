using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RepairOrc : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataRepairCostRatio;
        private readonly Lazy<ObjectProperty<float>> _dataRepairTimeRatio;
        private readonly Lazy<ObjectProperty<float>> _dataPowerbuildCost;
        private readonly Lazy<ObjectProperty<float>> _dataPowerbuildRate;
        private readonly Lazy<ObjectProperty<float>> _dataNavalRangeBonus;
        public RepairOrc(): base(1885696577)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
        }

        public RepairOrc(int newId): base(1885696577, newId)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
        }

        public RepairOrc(string newRawcode): base(1885696577, newRawcode)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
        }

        public RepairOrc(ObjectDatabase db): base(1885696577, db)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
        }

        public RepairOrc(int newId, ObjectDatabase db): base(1885696577, newId, db)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
        }

        public RepairOrc(string newRawcode, ObjectDatabase db): base(1885696577, newRawcode, db)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
        }

        public ObjectProperty<float> DataRepairCostRatio => _dataRepairCostRatio.Value;
        public ObjectProperty<float> DataRepairTimeRatio => _dataRepairTimeRatio.Value;
        public ObjectProperty<float> DataPowerbuildCost => _dataPowerbuildCost.Value;
        public ObjectProperty<float> DataPowerbuildRate => _dataPowerbuildRate.Value;
        public ObjectProperty<float> DataNavalRangeBonus => _dataNavalRangeBonus.Value;
        private float GetDataRepairCostRatio(int level)
        {
            return _modifications[829449554, level].ValueAsFloat;
        }

        private void SetDataRepairCostRatio(int level, float value)
        {
            _modifications[829449554, level] = new LevelObjectDataModification{Id = 829449554, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataRepairTimeRatio(int level)
        {
            return _modifications[846226770, level].ValueAsFloat;
        }

        private void SetDataRepairTimeRatio(int level, float value)
        {
            _modifications[846226770, level] = new LevelObjectDataModification{Id = 846226770, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataPowerbuildCost(int level)
        {
            return _modifications[863003986, level].ValueAsFloat;
        }

        private void SetDataPowerbuildCost(int level, float value)
        {
            _modifications[863003986, level] = new LevelObjectDataModification{Id = 863003986, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataPowerbuildRate(int level)
        {
            return _modifications[879781202, level].ValueAsFloat;
        }

        private void SetDataPowerbuildRate(int level, float value)
        {
            _modifications[879781202, level] = new LevelObjectDataModification{Id = 879781202, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataNavalRangeBonus(int level)
        {
            return _modifications[896558418, level].ValueAsFloat;
        }

        private void SetDataNavalRangeBonus(int level, float value)
        {
            _modifications[896558418, level] = new LevelObjectDataModification{Id = 896558418, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}