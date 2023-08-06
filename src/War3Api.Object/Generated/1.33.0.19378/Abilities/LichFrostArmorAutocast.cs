using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class LichFrostArmorAutocast : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataArmorDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataArmorBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorBonusModified;
        public LichFrostArmorAutocast(): base(1969640769)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmorAutocast(int newId): base(1969640769, newId)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmorAutocast(string newRawcode): base(1969640769, newRawcode)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmorAutocast(ObjectDatabaseBase db): base(1969640769, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmorAutocast(int newId, ObjectDatabaseBase db): base(1969640769, newId, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmorAutocast(string newRawcode, ObjectDatabaseBase db): base(1969640769, newRawcode, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public ObjectProperty<float> DataArmorDuration => _dataArmorDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataArmorDurationModified => _isDataArmorDurationModified.Value;
        public ObjectProperty<float> DataArmorBonus => _dataArmorBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataArmorBonusModified => _isDataArmorBonusModified.Value;
        private float GetDataArmorDuration(int level)
        {
            return _modifications.GetModification(828466773, level).ValueAsFloat;
        }

        private void SetDataArmorDuration(int level, float value)
        {
            _modifications[828466773, level] = new LevelObjectDataModification{Id = 828466773, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataArmorDurationModified(int level)
        {
            return _modifications.ContainsKey(828466773, level);
        }

        private float GetDataArmorBonus(int level)
        {
            return _modifications.GetModification(845243989, level).ValueAsFloat;
        }

        private void SetDataArmorBonus(int level, float value)
        {
            _modifications[845243989, level] = new LevelObjectDataModification{Id = 845243989, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataArmorBonusModified(int level)
        {
            return _modifications.ContainsKey(845243989, level);
        }
    }
}