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
    public sealed class PermanentImmolationGraphic : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataManaDrainedPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaDrainedPerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataBufferManaRequired;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBufferManaRequiredModified;
        public PermanentImmolationGraphic(): base(1734963265)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _isDataDamagePerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerIntervalModified));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
            _isDataBufferManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBufferManaRequiredModified));
        }

        public PermanentImmolationGraphic(int newId): base(1734963265, newId)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _isDataDamagePerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerIntervalModified));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
            _isDataBufferManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBufferManaRequiredModified));
        }

        public PermanentImmolationGraphic(string newRawcode): base(1734963265, newRawcode)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _isDataDamagePerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerIntervalModified));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
            _isDataBufferManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBufferManaRequiredModified));
        }

        public PermanentImmolationGraphic(ObjectDatabaseBase db): base(1734963265, db)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _isDataDamagePerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerIntervalModified));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
            _isDataBufferManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBufferManaRequiredModified));
        }

        public PermanentImmolationGraphic(int newId, ObjectDatabaseBase db): base(1734963265, newId, db)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _isDataDamagePerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerIntervalModified));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
            _isDataBufferManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBufferManaRequiredModified));
        }

        public PermanentImmolationGraphic(string newRawcode, ObjectDatabaseBase db): base(1734963265, newRawcode, db)
        {
            _dataDamagePerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerInterval, SetDataDamagePerInterval));
            _isDataDamagePerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerIntervalModified));
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
            _isDataManaDrainedPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaDrainedPerSecondModified));
            _dataBufferManaRequired = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBufferManaRequired, SetDataBufferManaRequired));
            _isDataBufferManaRequiredModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBufferManaRequiredModified));
        }

        public ObjectProperty<float> DataDamagePerInterval => _dataDamagePerInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerIntervalModified => _isDataDamagePerIntervalModified.Value;
        public ObjectProperty<float> DataManaDrainedPerSecond => _dataManaDrainedPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaDrainedPerSecondModified => _isDataManaDrainedPerSecondModified.Value;
        public ObjectProperty<float> DataBufferManaRequired => _dataBufferManaRequired.Value;
        public ReadOnlyObjectProperty<bool> IsDataBufferManaRequiredModified => _isDataBufferManaRequiredModified.Value;
        private float GetDataDamagePerInterval(int level)
        {
            return _modifications.GetModification(829253957, level).ValueAsFloat;
        }

        private void SetDataDamagePerInterval(int level, float value)
        {
            _modifications[829253957, level] = new LevelObjectDataModification{Id = 829253957, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDamagePerIntervalModified(int level)
        {
            return _modifications.ContainsKey(829253957, level);
        }

        private float GetDataManaDrainedPerSecond(int level)
        {
            return _modifications.GetModification(846031173, level).ValueAsFloat;
        }

        private void SetDataManaDrainedPerSecond(int level, float value)
        {
            _modifications[846031173, level] = new LevelObjectDataModification{Id = 846031173, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataManaDrainedPerSecondModified(int level)
        {
            return _modifications.ContainsKey(846031173, level);
        }

        private float GetDataBufferManaRequired(int level)
        {
            return _modifications.GetModification(862808389, level).ValueAsFloat;
        }

        private void SetDataBufferManaRequired(int level, float value)
        {
            _modifications[862808389, level] = new LevelObjectDataModification{Id = 862808389, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataBufferManaRequiredModified(int level)
        {
            return _modifications.ContainsKey(862808389, level);
        }
    }
}