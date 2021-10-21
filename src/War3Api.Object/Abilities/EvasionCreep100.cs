using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class EvasionCreep100 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToEvade;
        public EvasionCreep100(): base(1936016193)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public EvasionCreep100(int newId): base(1936016193, newId)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public EvasionCreep100(string newRawcode): base(1936016193, newRawcode)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public EvasionCreep100(ObjectDatabase db): base(1936016193, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public EvasionCreep100(int newId, ObjectDatabase db): base(1936016193, newId, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public EvasionCreep100(string newRawcode, ObjectDatabase db): base(1936016193, newRawcode, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public ObjectProperty<float> DataChanceToEvade => _dataChanceToEvade.Value;
        private float GetDataChanceToEvade(int level)
        {
            return _modifications[829842757, level].ValueAsFloat;
        }

        private void SetDataChanceToEvade(int level, float value)
        {
            _modifications[829842757, level] = new LevelObjectDataModification{Id = 829842757, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}