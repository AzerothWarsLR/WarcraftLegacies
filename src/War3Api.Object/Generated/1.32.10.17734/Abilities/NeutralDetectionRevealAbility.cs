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
    public sealed class NeutralDetectionRevealAbility : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldCost;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldCostModified;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCost;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberCostModified;
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionTypeModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        public NeutralDetectionRevealAbility(): base(1952738881)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(int newId): base(1952738881, newId)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(string newRawcode): base(1952738881, newRawcode)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(ObjectDatabaseBase db): base(1952738881, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(int newId, ObjectDatabaseBase db): base(1952738881, newId, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralDetectionRevealAbility(string newRawcode, ObjectDatabaseBase db): base(1952738881, newRawcode, db)
        {
            _dataGoldCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCost, SetDataGoldCost));
            _isDataGoldCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostModified));
            _dataLumberCost = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCost, SetDataLumberCost));
            _isDataLumberCostModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ObjectProperty<int> DataGoldCost => _dataGoldCost.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldCostModified => _isDataGoldCostModified.Value;
        public ObjectProperty<int> DataLumberCost => _dataLumberCost.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberCostModified => _isDataLumberCostModified.Value;
        public ObjectProperty<int> DataDetectionTypeRaw => _dataDetectionTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionTypeModified => _isDataDetectionTypeModified.Value;
        public ObjectProperty<DetectionType> DataDetectionType => _dataDetectionType.Value;
        private int GetDataGoldCost(int level)
        {
            return _modifications.GetModification(829711438, level).ValueAsInt;
        }

        private void SetDataGoldCost(int level, int value)
        {
            _modifications[829711438, level] = new LevelObjectDataModification{Id = 829711438, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldCostModified(int level)
        {
            return _modifications.ContainsKey(829711438, level);
        }

        private int GetDataLumberCost(int level)
        {
            return _modifications.GetModification(846488654, level).ValueAsInt;
        }

        private void SetDataLumberCost(int level, int value)
        {
            _modifications[846488654, level] = new LevelObjectDataModification{Id = 846488654, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLumberCostModified(int level)
        {
            return _modifications.ContainsKey(846488654, level);
        }

        private int GetDataDetectionTypeRaw(int level)
        {
            return _modifications.GetModification(863265870, level).ValueAsInt;
        }

        private void SetDataDetectionTypeRaw(int level, int value)
        {
            _modifications[863265870, level] = new LevelObjectDataModification{Id = 863265870, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDetectionTypeModified(int level)
        {
            return _modifications.ContainsKey(863265870, level);
        }

        private DetectionType GetDataDetectionType(int level)
        {
            return GetDataDetectionTypeRaw(level).ToDetectionType(this);
        }

        private void SetDataDetectionType(int level, DetectionType value)
        {
            SetDataDetectionTypeRaw(level, value.ToRaw(null, null));
        }
    }
}