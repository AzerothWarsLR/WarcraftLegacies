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
    public sealed class SleepCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataStunDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStunDurationModified;
        public SleepCreep(): base(1819493185)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
        }

        public SleepCreep(int newId): base(1819493185, newId)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
        }

        public SleepCreep(string newRawcode): base(1819493185, newRawcode)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
        }

        public SleepCreep(ObjectDatabaseBase db): base(1819493185, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
        }

        public SleepCreep(int newId, ObjectDatabaseBase db): base(1819493185, newId, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
        }

        public SleepCreep(string newRawcode, ObjectDatabaseBase db): base(1819493185, newRawcode, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
            _isDataStunDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStunDurationModified));
        }

        public ObjectProperty<float> DataStunDuration => _dataStunDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataStunDurationModified => _isDataStunDurationModified.Value;
        private float GetDataStunDuration(int level)
        {
            return _modifications.GetModification(829190997, level).ValueAsFloat;
        }

        private void SetDataStunDuration(int level, float value)
        {
            _modifications[829190997, level] = new LevelObjectDataModification{Id = 829190997, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataStunDurationModified(int level)
        {
            return _modifications.ContainsKey(829190997, level);
        }
    }
}