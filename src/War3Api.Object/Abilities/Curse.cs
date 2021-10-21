using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Curse : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToMiss;
        public Curse(): base(1936876353)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
        }

        public Curse(int newId): base(1936876353, newId)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
        }

        public Curse(string newRawcode): base(1936876353, newRawcode)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
        }

        public Curse(ObjectDatabase db): base(1936876353, db)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
        }

        public Curse(int newId, ObjectDatabase db): base(1936876353, newId, db)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
        }

        public Curse(string newRawcode, ObjectDatabase db): base(1936876353, newRawcode, db)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
        }

        public ObjectProperty<float> DataChanceToMiss => _dataChanceToMiss.Value;
        private float GetDataChanceToMiss(int level)
        {
            return _modifications[0, level].ValueAsFloat;
        }

        private void SetDataChanceToMiss(int level, float value)
        {
            _modifications[0, level] = new LevelObjectDataModification{Id = 0, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}