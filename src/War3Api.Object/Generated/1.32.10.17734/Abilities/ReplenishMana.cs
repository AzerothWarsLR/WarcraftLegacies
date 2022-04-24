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
    public sealed class ReplenishMana : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaPointsGainedModified;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumManaRequired;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMinimumManaRequiredModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnitsChargedToCaster;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumUnitsChargedToCasterModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnitsAffected;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumUnitsAffectedModified;
        public ReplenishMana(): base(1836085825)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataMinimumManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumManaRequired, SetDataMinimumManaRequired));
            _isDataMinimumManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumManaRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishMana(int newId): base(1836085825, newId)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataMinimumManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumManaRequired, SetDataMinimumManaRequired));
            _isDataMinimumManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumManaRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishMana(string newRawcode): base(1836085825, newRawcode)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataMinimumManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumManaRequired, SetDataMinimumManaRequired));
            _isDataMinimumManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumManaRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishMana(ObjectDatabaseBase db): base(1836085825, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataMinimumManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumManaRequired, SetDataMinimumManaRequired));
            _isDataMinimumManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumManaRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishMana(int newId, ObjectDatabaseBase db): base(1836085825, newId, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataMinimumManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumManaRequired, SetDataMinimumManaRequired));
            _isDataMinimumManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumManaRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishMana(string newRawcode, ObjectDatabaseBase db): base(1836085825, newRawcode, db)
        {
            _dataManaPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaPointsGained, SetDataManaPointsGained));
            _isDataManaPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaPointsGainedModified));
            _dataMinimumManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumManaRequired, SetDataMinimumManaRequired));
            _isDataMinimumManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumManaRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ObjectProperty<float> DataManaPointsGained => _dataManaPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaPointsGainedModified => _isDataManaPointsGainedModified.Value;
        public ObjectProperty<float> DataMinimumManaRequired => _dataMinimumManaRequired.Value;
        public ReadOnlyObjectProperty<bool> IsDataMinimumManaRequiredModified => _isDataMinimumManaRequiredModified.Value;
        public ObjectProperty<int> DataMaximumUnitsChargedToCaster => _dataMaximumUnitsChargedToCaster.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumUnitsChargedToCasterModified => _isDataMaximumUnitsChargedToCasterModified.Value;
        public ObjectProperty<int> DataMaximumUnitsAffected => _dataMaximumUnitsAffected.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumUnitsAffectedModified => _isDataMaximumUnitsAffectedModified.Value;
        private float GetDataManaPointsGained(int level)
        {
            return _modifications.GetModification(845833554, level).ValueAsFloat;
        }

        private void SetDataManaPointsGained(int level, float value)
        {
            _modifications[845833554, level] = new LevelObjectDataModification{Id = 845833554, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(845833554, level);
        }

        private float GetDataMinimumManaRequired(int level)
        {
            return _modifications.GetModification(878866514, level).ValueAsFloat;
        }

        private void SetDataMinimumManaRequired(int level, float value)
        {
            _modifications[878866514, level] = new LevelObjectDataModification{Id = 878866514, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMinimumManaRequiredModified(int level)
        {
            return _modifications.ContainsKey(878866514, level);
        }

        private int GetDataMaximumUnitsChargedToCaster(int level)
        {
            return _modifications.GetModification(895643730, level).ValueAsInt;
        }

        private void SetDataMaximumUnitsChargedToCaster(int level, int value)
        {
            _modifications[895643730, level] = new LevelObjectDataModification{Id = 895643730, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMaximumUnitsChargedToCasterModified(int level)
        {
            return _modifications.ContainsKey(895643730, level);
        }

        private int GetDataMaximumUnitsAffected(int level)
        {
            return _modifications.GetModification(912420946, level).ValueAsInt;
        }

        private void SetDataMaximumUnitsAffected(int level, int value)
        {
            _modifications[912420946, level] = new LevelObjectDataModification{Id = 912420946, Type = ObjectDataType.Int, Value = value, Level = level};
        }

        private bool GetIsDataMaximumUnitsAffectedModified(int level)
        {
            return _modifications.ContainsKey(912420946, level);
        }
    }
}