using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class EntanglingRootsCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        public EntanglingRootsCreep(): base(1919837505)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public EntanglingRootsCreep(int newId): base(1919837505, newId)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public EntanglingRootsCreep(string newRawcode): base(1919837505, newRawcode)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public EntanglingRootsCreep(ObjectDatabase db): base(1919837505, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public EntanglingRootsCreep(int newId, ObjectDatabase db): base(1919837505, newId, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public EntanglingRootsCreep(string newRawcode, ObjectDatabase db): base(1919837505, newRawcode, db)
        {
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
        }

        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[829580613, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[829580613, level] = new LevelObjectDataModification{Id = 829580613, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}