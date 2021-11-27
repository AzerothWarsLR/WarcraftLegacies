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
    public sealed class LichFrostArmor : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataArmorDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataArmorBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArmorBonusModified;
        public LichFrostArmor(): base(1634096449)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmor(int newId): base(1634096449, newId)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmor(string newRawcode): base(1634096449, newRawcode)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmor(ObjectDatabaseBase db): base(1634096449, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmor(int newId, ObjectDatabaseBase db): base(1634096449, newId, db)
        {
            _dataArmorDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorDuration, SetDataArmorDuration));
            _isDataArmorDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorDurationModified));
            _dataArmorBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArmorBonus, SetDataArmorBonus));
            _isDataArmorBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArmorBonusModified));
        }

        public LichFrostArmor(string newRawcode, ObjectDatabaseBase db): base(1634096449, newRawcode, db)
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