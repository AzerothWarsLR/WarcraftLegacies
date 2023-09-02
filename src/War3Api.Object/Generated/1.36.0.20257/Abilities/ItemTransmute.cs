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
    public sealed class ItemTransmute : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataGoldCostFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldCostFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataLumberCostFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberCostFactorModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaxCreepLevel;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxCreepLevelModified;
        private readonly Lazy<ObjectProperty<int>> _dataAllowBountyRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowBountyModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAllowBounty;
        public ItemTransmute(): base(1937000769)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _isDataGoldCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostFactorModified));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _isDataLumberCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostFactorModified));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
            _dataAllowBountyRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowBountyRaw, SetDataAllowBountyRaw));
            _isDataAllowBountyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowBountyModified));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(int newId): base(1937000769, newId)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _isDataGoldCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostFactorModified));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _isDataLumberCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostFactorModified));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
            _dataAllowBountyRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowBountyRaw, SetDataAllowBountyRaw));
            _isDataAllowBountyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowBountyModified));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(string newRawcode): base(1937000769, newRawcode)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _isDataGoldCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostFactorModified));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _isDataLumberCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostFactorModified));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
            _dataAllowBountyRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowBountyRaw, SetDataAllowBountyRaw));
            _isDataAllowBountyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowBountyModified));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(ObjectDatabaseBase db): base(1937000769, db)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _isDataGoldCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostFactorModified));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _isDataLumberCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostFactorModified));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
            _dataAllowBountyRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowBountyRaw, SetDataAllowBountyRaw));
            _isDataAllowBountyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowBountyModified));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(int newId, ObjectDatabaseBase db): base(1937000769, newId, db)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _isDataGoldCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostFactorModified));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _isDataLumberCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostFactorModified));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
            _dataAllowBountyRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowBountyRaw, SetDataAllowBountyRaw));
            _isDataAllowBountyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowBountyModified));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ItemTransmute(string newRawcode, ObjectDatabaseBase db): base(1937000769, newRawcode, db)
        {
            _dataGoldCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGoldCostFactor, SetDataGoldCostFactor));
            _isDataGoldCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostFactorModified));
            _dataLumberCostFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberCostFactor, SetDataLumberCostFactor));
            _isDataLumberCostFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostFactorModified));
            _dataMaxCreepLevel = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxCreepLevel, SetDataMaxCreepLevel));
            _isDataMaxCreepLevelModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxCreepLevelModified));
            _dataAllowBountyRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowBountyRaw, SetDataAllowBountyRaw));
            _isDataAllowBountyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowBountyModified));
            _dataAllowBounty = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowBounty, SetDataAllowBounty));
        }

        public ObjectProperty<float> DataGoldCostFactor => _dataGoldCostFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldCostFactorModified => _isDataGoldCostFactorModified.Value;
        public ObjectProperty<float> DataLumberCostFactor => _dataLumberCostFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberCostFactorModified => _isDataLumberCostFactorModified.Value;
        public ObjectProperty<int> DataMaxCreepLevel => _dataMaxCreepLevel.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxCreepLevelModified => _isDataMaxCreepLevelModified.Value;
        public ObjectProperty<int> DataAllowBountyRaw => _dataAllowBountyRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowBountyModified => _isDataAllowBountyModified.Value;
        public ObjectProperty<bool> DataAllowBounty => _dataAllowBounty.Value;
        private float GetDataGoldCostFactor(int level)
        {
            return _modifications.GetModification(829256782, level).ValueAsFloat;
        }

        private void SetDataGoldCostFactor(int level, float value)
        {
            _modifications[829256782, level] = new LevelObjectDataModification{Id = 829256782, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldCostFactorModified(int level)
        {
            return _modifications.ContainsKey(829256782, level);
        }

        private float GetDataLumberCostFactor(int level)
        {
            return _modifications.GetModification(846033998, level).ValueAsFloat;
        }

        private void SetDataLumberCostFactor(int level, float value)
        {
            _modifications[846033998, level] = new LevelObjectDataModification{Id = 846033998, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLumberCostFactorModified(int level)
        {
            return _modifications.ContainsKey(846033998, level);
        }

        private int GetDataMaxCreepLevel(int level)
        {
            return _modifications.GetModification(862811214, level).ValueAsInt;
        }

        private void SetDataMaxCreepLevel(int level, int value)
        {
            _modifications[862811214, level] = new LevelObjectDataModification{Id = 862811214, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaxCreepLevelModified(int level)
        {
            return _modifications.ContainsKey(862811214, level);
        }

        private int GetDataAllowBountyRaw(int level)
        {
            return _modifications.GetModification(879588430, level).ValueAsInt;
        }

        private void SetDataAllowBountyRaw(int level, int value)
        {
            _modifications[879588430, level] = new LevelObjectDataModification{Id = 879588430, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAllowBountyModified(int level)
        {
            return _modifications.ContainsKey(879588430, level);
        }

        private bool GetDataAllowBounty(int level)
        {
            return GetDataAllowBountyRaw(level).ToBool(this);
        }

        private void SetDataAllowBounty(int level, bool value)
        {
            SetDataAllowBountyRaw(level, value.ToRaw(0, 1));
        }
    }
}