using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MindRot : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaDrainedPerSecond;
        public MindRot(): base(1919766081)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
        }

        public MindRot(int newId): base(1919766081, newId)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
        }

        public MindRot(string newRawcode): base(1919766081, newRawcode)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
        }

        public MindRot(ObjectDatabase db): base(1919766081, db)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
        }

        public MindRot(int newId, ObjectDatabase db): base(1919766081, newId, db)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
        }

        public MindRot(string newRawcode, ObjectDatabase db): base(1919766081, newRawcode, db)
        {
            _dataManaDrainedPerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaDrainedPerSecond, SetDataManaDrainedPerSecond));
        }

        public ObjectProperty<float> DataManaDrainedPerSecond => _dataManaDrainedPerSecond.Value;
        private float GetDataManaDrainedPerSecond(int level)
        {
            return _modifications[829582670, level].ValueAsFloat;
        }

        private void SetDataManaDrainedPerSecond(int level, float value)
        {
            _modifications[829582670, level] = new LevelObjectDataModification{Id = 829582670, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}