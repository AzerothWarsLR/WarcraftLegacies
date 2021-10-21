using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SleepCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataStunDuration;
        public SleepCreep(): base(1819493185)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public SleepCreep(int newId): base(1819493185, newId)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public SleepCreep(string newRawcode): base(1819493185, newRawcode)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public SleepCreep(ObjectDatabase db): base(1819493185, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public SleepCreep(int newId, ObjectDatabase db): base(1819493185, newId, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public SleepCreep(string newRawcode, ObjectDatabase db): base(1819493185, newRawcode, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public ObjectProperty<float> DataStunDuration => _dataStunDuration.Value;
        private float GetDataStunDuration(int level)
        {
            return _modifications[829190997, level].ValueAsFloat;
        }

        private void SetDataStunDuration(int level, float value)
        {
            _modifications[829190997, level] = new LevelObjectDataModification{Id = 829190997, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}