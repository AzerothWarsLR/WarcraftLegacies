using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class LightningAttack : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDelay;
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDuration;
        public LightningAttack(): base(1953066049)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
        }

        public LightningAttack(int newId): base(1953066049, newId)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
        }

        public LightningAttack(string newRawcode): base(1953066049, newRawcode)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
        }

        public LightningAttack(ObjectDatabase db): base(1953066049, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
        }

        public LightningAttack(int newId, ObjectDatabase db): base(1953066049, newId, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
        }

        public LightningAttack(string newRawcode, ObjectDatabase db): base(1953066049, newRawcode, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
        }

        public ObjectProperty<float> DataGraphicDelay => _dataGraphicDelay.Value;
        public ObjectProperty<float> DataGraphicDuration => _dataGraphicDuration.Value;
        private float GetDataGraphicDelay(int level)
        {
            return _modifications[829712716, level].ValueAsFloat;
        }

        private void SetDataGraphicDelay(int level, float value)
        {
            _modifications[829712716, level] = new LevelObjectDataModification{Id = 829712716, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataGraphicDuration(int level)
        {
            return _modifications[846489932, level].ValueAsFloat;
        }

        private void SetDataGraphicDuration(int level, float value)
        {
            _modifications[846489932, level] = new LevelObjectDataModification{Id = 846489932, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}