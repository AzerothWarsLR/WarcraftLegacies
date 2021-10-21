using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DreadlordSleep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataStunDuration;
        public DreadlordSleep(): base(1819497793)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public DreadlordSleep(int newId): base(1819497793, newId)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public DreadlordSleep(string newRawcode): base(1819497793, newRawcode)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public DreadlordSleep(ObjectDatabase db): base(1819497793, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public DreadlordSleep(int newId, ObjectDatabase db): base(1819497793, newId, db)
        {
            _dataStunDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataStunDuration, SetDataStunDuration));
        }

        public DreadlordSleep(string newRawcode, ObjectDatabase db): base(1819497793, newRawcode, db)
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