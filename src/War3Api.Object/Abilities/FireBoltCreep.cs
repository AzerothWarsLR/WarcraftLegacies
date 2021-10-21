using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FireBoltCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        public FireBoltCreep(): base(1650869057)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FireBoltCreep(int newId): base(1650869057, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FireBoltCreep(string newRawcode): base(1650869057, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FireBoltCreep(ObjectDatabase db): base(1650869057, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FireBoltCreep(int newId, ObjectDatabase db): base(1650869057, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public FireBoltCreep(string newRawcode, ObjectDatabase db): base(1650869057, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        private float GetDataDamage(int level)
        {
            return _modifications[828535880, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[828535880, level] = new LevelObjectDataModification{Id = 828535880, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}