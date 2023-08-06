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
    public sealed class PhoenixFire : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataInitialDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInitialDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamagePerSecondModified;
        public PhoenixFire(): base(1719169089)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public PhoenixFire(int newId): base(1719169089, newId)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public PhoenixFire(string newRawcode): base(1719169089, newRawcode)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public PhoenixFire(ObjectDatabaseBase db): base(1719169089, db)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public PhoenixFire(int newId, ObjectDatabaseBase db): base(1719169089, newId, db)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public PhoenixFire(string newRawcode, ObjectDatabaseBase db): base(1719169089, newRawcode, db)
        {
            _dataInitialDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataInitialDamage, SetDataInitialDamage));
            _isDataInitialDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInitialDamageModified));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _isDataDamagePerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamagePerSecondModified));
        }

        public ObjectProperty<float> DataInitialDamage => _dataInitialDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataInitialDamageModified => _isDataInitialDamageModified.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamagePerSecondModified => _isDataDamagePerSecondModified.Value;
        private float GetDataInitialDamage(int level)
        {
            return _modifications.GetModification(828799088, level).ValueAsFloat;
        }

        private void SetDataInitialDamage(int level, float value)
        {
            _modifications[828799088, level] = new LevelObjectDataModification{Id = 828799088, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataInitialDamageModified(int level)
        {
            return _modifications.ContainsKey(828799088, level);
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications.GetModification(845576304, level).ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845576304, level] = new LevelObjectDataModification{Id = 845576304, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamagePerSecondModified(int level)
        {
            return _modifications.ContainsKey(845576304, level);
        }
    }
}