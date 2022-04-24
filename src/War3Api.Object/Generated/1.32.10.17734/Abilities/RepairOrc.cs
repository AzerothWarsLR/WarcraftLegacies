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
    public sealed class RepairOrc : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataRepairCostRatio;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRepairCostRatioModified;
        private readonly Lazy<ObjectProperty<float>> _dataRepairTimeRatio;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRepairTimeRatioModified;
        private readonly Lazy<ObjectProperty<float>> _dataPowerbuildCost;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPowerbuildCostModified;
        private readonly Lazy<ObjectProperty<float>> _dataPowerbuildRate;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPowerbuildRateModified;
        private readonly Lazy<ObjectProperty<float>> _dataNavalRangeBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNavalRangeBonusModified;
        public RepairOrc(): base(1885696577)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _isDataRepairCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairCostRatioModified));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _isDataRepairTimeRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairTimeRatioModified));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _isDataPowerbuildCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildCostModified));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _isDataPowerbuildRateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildRateModified));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
            _isDataNavalRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNavalRangeBonusModified));
        }

        public RepairOrc(int newId): base(1885696577, newId)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _isDataRepairCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairCostRatioModified));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _isDataRepairTimeRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairTimeRatioModified));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _isDataPowerbuildCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildCostModified));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _isDataPowerbuildRateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildRateModified));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
            _isDataNavalRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNavalRangeBonusModified));
        }

        public RepairOrc(string newRawcode): base(1885696577, newRawcode)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _isDataRepairCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairCostRatioModified));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _isDataRepairTimeRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairTimeRatioModified));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _isDataPowerbuildCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildCostModified));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _isDataPowerbuildRateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildRateModified));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
            _isDataNavalRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNavalRangeBonusModified));
        }

        public RepairOrc(ObjectDatabaseBase db): base(1885696577, db)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _isDataRepairCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairCostRatioModified));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _isDataRepairTimeRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairTimeRatioModified));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _isDataPowerbuildCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildCostModified));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _isDataPowerbuildRateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildRateModified));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
            _isDataNavalRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNavalRangeBonusModified));
        }

        public RepairOrc(int newId, ObjectDatabaseBase db): base(1885696577, newId, db)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _isDataRepairCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairCostRatioModified));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _isDataRepairTimeRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairTimeRatioModified));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _isDataPowerbuildCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildCostModified));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _isDataPowerbuildRateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildRateModified));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
            _isDataNavalRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNavalRangeBonusModified));
        }

        public RepairOrc(string newRawcode, ObjectDatabaseBase db): base(1885696577, newRawcode, db)
        {
            _dataRepairCostRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairCostRatio, SetDataRepairCostRatio));
            _isDataRepairCostRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairCostRatioModified));
            _dataRepairTimeRatio = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRepairTimeRatio, SetDataRepairTimeRatio));
            _isDataRepairTimeRatioModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRepairTimeRatioModified));
            _dataPowerbuildCost = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildCost, SetDataPowerbuildCost));
            _isDataPowerbuildCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildCostModified));
            _dataPowerbuildRate = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPowerbuildRate, SetDataPowerbuildRate));
            _isDataPowerbuildRateModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPowerbuildRateModified));
            _dataNavalRangeBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataNavalRangeBonus, SetDataNavalRangeBonus));
            _isDataNavalRangeBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNavalRangeBonusModified));
        }

        public ObjectProperty<float> DataRepairCostRatio => _dataRepairCostRatio.Value;
        public ReadOnlyObjectProperty<bool> IsDataRepairCostRatioModified => _isDataRepairCostRatioModified.Value;
        public ObjectProperty<float> DataRepairTimeRatio => _dataRepairTimeRatio.Value;
        public ReadOnlyObjectProperty<bool> IsDataRepairTimeRatioModified => _isDataRepairTimeRatioModified.Value;
        public ObjectProperty<float> DataPowerbuildCost => _dataPowerbuildCost.Value;
        public ReadOnlyObjectProperty<bool> IsDataPowerbuildCostModified => _isDataPowerbuildCostModified.Value;
        public ObjectProperty<float> DataPowerbuildRate => _dataPowerbuildRate.Value;
        public ReadOnlyObjectProperty<bool> IsDataPowerbuildRateModified => _isDataPowerbuildRateModified.Value;
        public ObjectProperty<float> DataNavalRangeBonus => _dataNavalRangeBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataNavalRangeBonusModified => _isDataNavalRangeBonusModified.Value;
        private float GetDataRepairCostRatio(int level)
        {
            return _modifications.GetModification(829449554, level).ValueAsFloat;
        }

        private void SetDataRepairCostRatio(int level, float value)
        {
            _modifications[829449554, level] = new LevelObjectDataModification{Id = 829449554, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataRepairCostRatioModified(int level)
        {
            return _modifications.ContainsKey(829449554, level);
        }

        private float GetDataRepairTimeRatio(int level)
        {
            return _modifications.GetModification(846226770, level).ValueAsFloat;
        }

        private void SetDataRepairTimeRatio(int level, float value)
        {
            _modifications[846226770, level] = new LevelObjectDataModification{Id = 846226770, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataRepairTimeRatioModified(int level)
        {
            return _modifications.ContainsKey(846226770, level);
        }

        private float GetDataPowerbuildCost(int level)
        {
            return _modifications.GetModification(863003986, level).ValueAsFloat;
        }

        private void SetDataPowerbuildCost(int level, float value)
        {
            _modifications[863003986, level] = new LevelObjectDataModification{Id = 863003986, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataPowerbuildCostModified(int level)
        {
            return _modifications.ContainsKey(863003986, level);
        }

        private float GetDataPowerbuildRate(int level)
        {
            return _modifications.GetModification(879781202, level).ValueAsFloat;
        }

        private void SetDataPowerbuildRate(int level, float value)
        {
            _modifications[879781202, level] = new LevelObjectDataModification{Id = 879781202, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataPowerbuildRateModified(int level)
        {
            return _modifications.ContainsKey(879781202, level);
        }

        private float GetDataNavalRangeBonus(int level)
        {
            return _modifications.GetModification(896558418, level).ValueAsFloat;
        }

        private void SetDataNavalRangeBonus(int level, float value)
        {
            _modifications[896558418, level] = new LevelObjectDataModification{Id = 896558418, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataNavalRangeBonusModified(int level)
        {
            return _modifications.ContainsKey(896558418, level);
        }
    }
}