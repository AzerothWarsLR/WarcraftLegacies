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
    public sealed class Frenzy : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDataModified;
        private readonly Lazy<ObjectProperty<float>> _dataScalingFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataScalingFactorModified;
        public Frenzy(): base(2038064705)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Frenzy(int newId): base(2038064705, newId)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Frenzy(string newRawcode): base(2038064705, newRawcode)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Frenzy(ObjectDatabaseBase db): base(2038064705, db)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Frenzy(int newId, ObjectDatabaseBase db): base(2038064705, newId, db)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Frenzy(string newRawcode, ObjectDatabaseBase db): base(2038064705, newRawcode, db)
        {
            _dataData = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData, SetDataData));
            _isDataDataModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDataModified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public ObjectProperty<float> DataData => _dataData.Value;
        public ReadOnlyObjectProperty<bool> IsDataDataModified => _isDataDataModified.Value;
        public ObjectProperty<float> DataScalingFactor => _dataScalingFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataScalingFactorModified => _isDataScalingFactorModified.Value;
        private float GetDataData(int level)
        {
            return _modifications.GetModification(829385794, level).ValueAsFloat;
        }

        private void SetDataData(int level, float value)
        {
            _modifications[829385794, level] = new LevelObjectDataModification{Id = 829385794, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDataModified(int level)
        {
            return _modifications.ContainsKey(829385794, level);
        }

        private float GetDataScalingFactor(int level)
        {
            return _modifications.GetModification(862940226, level).ValueAsFloat;
        }

        private void SetDataScalingFactor(int level, float value)
        {
            _modifications[862940226, level] = new LevelObjectDataModification{Id = 862940226, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataScalingFactorModified(int level)
        {
            return _modifications.ContainsKey(862940226, level);
        }
    }
}