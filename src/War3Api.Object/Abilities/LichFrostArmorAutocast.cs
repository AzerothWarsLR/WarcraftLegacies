using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class LichFrostArmorAutocast : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataArmorDuration;
        private readonly Lazy<ObjectProperty<float>> _dataArmorBonus;
        public LichFrostArmorAutocast(): base(1969640769)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
        }

        public LichFrostArmorAutocast(int newId): base(1969640769, newId)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
        }

        public LichFrostArmorAutocast(string newRawcode): base(1969640769, newRawcode)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
        }

        public LichFrostArmorAutocast(ObjectDatabase db): base(1969640769, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
        }

        public LichFrostArmorAutocast(int newId, ObjectDatabase db): base(1969640769, newId, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
        }

        public LichFrostArmorAutocast(string newRawcode, ObjectDatabase db): base(1969640769, newRawcode, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
        }

        public ObjectProperty<float> DataArmorDuration => _dataArmorDuration.Value;
        public ObjectProperty<float> DataArmorBonus => _dataArmorBonus.Value;
        private float GetDataArmorDuration(int level)
        {
            return _modifications[828466773, level].ValueAsFloat;
        }

        private void SetDataArmorDuration(int level, float value)
        {
            _modifications[828466773, level] = new LevelObjectDataModification{Id = 828466773, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataArmorBonus(int level)
        {
            return _modifications[845243989, level].ValueAsFloat;
        }

        private void SetDataArmorBonus(int level, float value)
        {
            _modifications[845243989, level] = new LevelObjectDataModification{Id = 845243989, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }
    }
}