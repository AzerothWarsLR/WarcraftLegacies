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
    public sealed class ReplenishLife : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumLifeRequired;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMinimumLifeRequiredModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnitsChargedToCaster;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumUnitsChargedToCasterModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumUnitsAffected;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumUnitsAffectedModified;
        public ReplenishLife(): base(1819308609)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _isDataMinimumLifeRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumLifeRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishLife(int newId): base(1819308609, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _isDataMinimumLifeRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumLifeRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishLife(string newRawcode): base(1819308609, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _isDataMinimumLifeRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumLifeRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishLife(ObjectDatabaseBase db): base(1819308609, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _isDataMinimumLifeRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumLifeRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishLife(int newId, ObjectDatabaseBase db): base(1819308609, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _isDataMinimumLifeRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumLifeRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ReplenishLife(string newRawcode, ObjectDatabaseBase db): base(1819308609, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataMinimumLifeRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumLifeRequired, SetDataMinimumLifeRequired));
            _isDataMinimumLifeRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumLifeRequiredModified));
            _dataMaximumUnitsChargedToCaster = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsChargedToCaster, SetDataMaximumUnitsChargedToCaster));
            _isDataMaximumUnitsChargedToCasterModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsChargedToCasterModified));
            _dataMaximumUnitsAffected = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumUnitsAffected, SetDataMaximumUnitsAffected));
            _isDataMaximumUnitsAffectedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumUnitsAffectedModified));
        }

        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        public ObjectProperty<float> DataMinimumLifeRequired => _dataMinimumLifeRequired.Value;
        public ReadOnlyObjectProperty<bool> IsDataMinimumLifeRequiredModified => _isDataMinimumLifeRequiredModified.Value;
        public ObjectProperty<int> DataMaximumUnitsChargedToCaster => _dataMaximumUnitsChargedToCaster.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumUnitsChargedToCasterModified => _isDataMaximumUnitsChargedToCasterModified.Value;
        public ObjectProperty<int> DataMaximumUnitsAffected => _dataMaximumUnitsAffected.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumUnitsAffectedModified => _isDataMaximumUnitsAffectedModified.Value;
        private float GetDataHitPointsGained(int level)
        {
            return _modifications.GetModification(829056338, level).ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[829056338, level] = new LevelObjectDataModification{Id = 829056338, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(829056338, level);
        }

        private float GetDataMinimumLifeRequired(int level)
        {
            return _modifications.GetModification(862089298, level).ValueAsFloat;
        }

        private void SetDataMinimumLifeRequired(int level, float value)
        {
            _modifications[862089298, level] = new LevelObjectDataModification{Id = 862089298, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMinimumLifeRequiredModified(int level)
        {
            return _modifications.ContainsKey(862089298, level);
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