using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FingerOfDeath_ANfd : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDelay;
        private readonly Lazy<ObjectProperty<float>> _dataGraphicDuration;
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        public FingerOfDeath_ANfd(): base(1684426305)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FingerOfDeath_ANfd(int newId): base(1684426305, newId)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FingerOfDeath_ANfd(string newRawcode): base(1684426305, newRawcode)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FingerOfDeath_ANfd(ObjectDatabase db): base(1684426305, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FingerOfDeath_ANfd(int newId, ObjectDatabase db): base(1684426305, newId, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FingerOfDeath_ANfd(string newRawcode, ObjectDatabase db): base(1684426305, newRawcode, db)
        {
            _dataGraphicDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDelay, SetDataGraphicDelay));
            _dataGraphicDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataGraphicDuration, SetDataGraphicDuration));
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ObjectProperty<float> DataGraphicDelay => _dataGraphicDelay.Value;
        public ObjectProperty<float> DataGraphicDuration => _dataGraphicDuration.Value;
        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        private float GetDataGraphicDelay(int level)
        {
            return _modifications[828663374, level].ValueAsFloat;
        }

        private void SetDataGraphicDelay(int level, float value)
        {
            _modifications[828663374, level] = new LevelObjectDataModification{Id = 828663374, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataGraphicDuration(int level)
        {
            return _modifications[845440590, level].ValueAsFloat;
        }

        private void SetDataGraphicDuration(int level, float value)
        {
            _modifications[845440590, level] = new LevelObjectDataModification{Id = 845440590, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamage(int level)
        {
            return _modifications[862217806, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[862217806, level] = new LevelObjectDataModification{Id = 862217806, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}