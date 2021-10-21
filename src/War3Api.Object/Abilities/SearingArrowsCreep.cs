using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SearingArrowsCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamageBonus;
        public SearingArrowsCreep(): base(1634943809)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
        }

        public SearingArrowsCreep(int newId): base(1634943809, newId)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
        }

        public SearingArrowsCreep(string newRawcode): base(1634943809, newRawcode)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
        }

        public SearingArrowsCreep(ObjectDatabase db): base(1634943809, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
        }

        public SearingArrowsCreep(int newId, ObjectDatabase db): base(1634943809, newId, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
        }

        public SearingArrowsCreep(string newRawcode, ObjectDatabase db): base(1634943809, newRawcode, db)
        {
            _dataDamageBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageBonus, SetDataDamageBonus));
        }

        public ObjectProperty<float> DataDamageBonus => _dataDamageBonus.Value;
        private float GetDataDamageBonus(int level)
        {
            return _modifications[828466760, level].ValueAsFloat;
        }

        private void SetDataDamageBonus(int level, float value)
        {
            _modifications[828466760, level] = new LevelObjectDataModification{Id = 828466760, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}