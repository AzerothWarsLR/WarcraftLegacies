using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Invisibility : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataTransitionTimeSeconds;
        public Invisibility(): base(1937140033)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
        }

        public Invisibility(int newId): base(1937140033, newId)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
        }

        public Invisibility(string newRawcode): base(1937140033, newRawcode)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
        }

        public Invisibility(ObjectDatabase db): base(1937140033, db)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
        }

        public Invisibility(int newId, ObjectDatabase db): base(1937140033, newId, db)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
        }

        public Invisibility(string newRawcode, ObjectDatabase db): base(1937140033, newRawcode, db)
        {
            _dataTransitionTimeSeconds = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTimeSeconds, SetDataTransitionTimeSeconds));
        }

        public ObjectProperty<float> DataTransitionTimeSeconds => _dataTransitionTimeSeconds.Value;
        private float GetDataTransitionTimeSeconds(int level)
        {
            return _modifications[829650505, level].ValueAsFloat;
        }

        private void SetDataTransitionTimeSeconds(int level, float value)
        {
            _modifications[829650505, level] = new LevelObjectDataModification{Id = 829650505, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}