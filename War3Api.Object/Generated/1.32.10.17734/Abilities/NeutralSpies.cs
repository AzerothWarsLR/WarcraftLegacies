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
    public sealed class NeutralSpies : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldCostPerStructure;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldCostPerStructureModified;
        private readonly Lazy<ObjectProperty<int>> _dataLumberCostPerUse;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberCostPerUseModified;
        private readonly Lazy<ObjectProperty<int>> _dataDetectionTypeRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDetectionTypeModified;
        private readonly Lazy<ObjectProperty<DetectionType>> _dataDetectionType;
        public NeutralSpies(): base(1886613057)
        {
            _dataGoldCostPerStructure = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCostPerStructure, SetDataGoldCostPerStructure));
            _isDataGoldCostPerStructureModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostPerStructureModified));
            _dataLumberCostPerUse = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCostPerUse, SetDataLumberCostPerUse));
            _isDataLumberCostPerUseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostPerUseModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralSpies(int newId): base(1886613057, newId)
        {
            _dataGoldCostPerStructure = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCostPerStructure, SetDataGoldCostPerStructure));
            _isDataGoldCostPerStructureModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostPerStructureModified));
            _dataLumberCostPerUse = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCostPerUse, SetDataLumberCostPerUse));
            _isDataLumberCostPerUseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostPerUseModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralSpies(string newRawcode): base(1886613057, newRawcode)
        {
            _dataGoldCostPerStructure = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCostPerStructure, SetDataGoldCostPerStructure));
            _isDataGoldCostPerStructureModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostPerStructureModified));
            _dataLumberCostPerUse = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCostPerUse, SetDataLumberCostPerUse));
            _isDataLumberCostPerUseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostPerUseModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralSpies(ObjectDatabaseBase db): base(1886613057, db)
        {
            _dataGoldCostPerStructure = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCostPerStructure, SetDataGoldCostPerStructure));
            _isDataGoldCostPerStructureModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostPerStructureModified));
            _dataLumberCostPerUse = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCostPerUse, SetDataLumberCostPerUse));
            _isDataLumberCostPerUseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostPerUseModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralSpies(int newId, ObjectDatabaseBase db): base(1886613057, newId, db)
        {
            _dataGoldCostPerStructure = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCostPerStructure, SetDataGoldCostPerStructure));
            _isDataGoldCostPerStructureModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostPerStructureModified));
            _dataLumberCostPerUse = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCostPerUse, SetDataLumberCostPerUse));
            _isDataLumberCostPerUseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostPerUseModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public NeutralSpies(string newRawcode, ObjectDatabaseBase db): base(1886613057, newRawcode, db)
        {
            _dataGoldCostPerStructure = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldCostPerStructure, SetDataGoldCostPerStructure));
            _isDataGoldCostPerStructureModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldCostPerStructureModified));
            _dataLumberCostPerUse = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberCostPerUse, SetDataLumberCostPerUse));
            _isDataLumberCostPerUseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberCostPerUseModified));
            _dataDetectionTypeRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDetectionTypeRaw, SetDataDetectionTypeRaw));
            _isDataDetectionTypeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDetectionTypeModified));
            _dataDetectionType = new Lazy<ObjectProperty<DetectionType>>(() => new ObjectProperty<DetectionType>(GetDataDetectionType, SetDataDetectionType));
        }

        public ObjectProperty<int> DataGoldCostPerStructure => _dataGoldCostPerStructure.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldCostPerStructureModified => _isDataGoldCostPerStructureModified.Value;
        public ObjectProperty<int> DataLumberCostPerUse => _dataLumberCostPerUse.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberCostPerUseModified => _isDataLumberCostPerUseModified.Value;
        public ObjectProperty<int> DataDetectionTypeRaw => _dataDetectionTypeRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDetectionTypeModified => _isDataDetectionTypeModified.Value;
        public ObjectProperty<DetectionType> DataDetectionType => _dataDetectionType.Value;
        private int GetDataGoldCostPerStructure(int level)
        {
            return _modifications.GetModification(829453134, level).ValueAsInt;
        }

        private void SetDataGoldCostPerStructure(int level, int value)
        {
            _modifications[829453134, level] = new LevelObjectDataModification{Id = 829453134, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldCostPerStructureModified(int level)
        {
            return _modifications.ContainsKey(829453134, level);
        }

        private int GetDataLumberCostPerUse(int level)
        {
            return _modifications.GetModification(846230350, level).ValueAsInt;
        }

        private void SetDataLumberCostPerUse(int level, int value)
        {
            _modifications[846230350, level] = new LevelObjectDataModification{Id = 846230350, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLumberCostPerUseModified(int level)
        {
            return _modifications.ContainsKey(846230350, level);
        }

        private int GetDataDetectionTypeRaw(int level)
        {
            return _modifications.GetModification(863007566, level).ValueAsInt;
        }

        private void SetDataDetectionTypeRaw(int level, int value)
        {
            _modifications[863007566, level] = new LevelObjectDataModification{Id = 863007566, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDetectionTypeModified(int level)
        {
            return _modifications.ContainsKey(863007566, level);
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