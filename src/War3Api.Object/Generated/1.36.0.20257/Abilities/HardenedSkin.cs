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
    public sealed class HardenedSkin : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToReduceDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToReduceDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMinimumDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataIgnoredDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIgnoredDamageModified;
        private readonly Lazy<ObjectProperty<int>> _dataIncludeRangedDamageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIncludeRangedDamageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataIncludeRangedDamage;
        private readonly Lazy<ObjectProperty<int>> _dataIncludeMeleeDamageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIncludeMeleeDamageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataIncludeMeleeDamage;
        public HardenedSkin(): base(1802728257)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _isDataChanceToReduceDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToReduceDamageModified));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _isDataMinimumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumDamageModified));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _isDataIgnoredDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoredDamageModified));
            _dataIncludeRangedDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeRangedDamageRaw, SetDataIncludeRangedDamageRaw));
            _isDataIncludeRangedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeRangedDamageModified));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeMeleeDamageRaw, SetDataIncludeMeleeDamageRaw));
            _isDataIncludeMeleeDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeMeleeDamageModified));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(int newId): base(1802728257, newId)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _isDataChanceToReduceDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToReduceDamageModified));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _isDataMinimumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumDamageModified));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _isDataIgnoredDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoredDamageModified));
            _dataIncludeRangedDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeRangedDamageRaw, SetDataIncludeRangedDamageRaw));
            _isDataIncludeRangedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeRangedDamageModified));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeMeleeDamageRaw, SetDataIncludeMeleeDamageRaw));
            _isDataIncludeMeleeDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeMeleeDamageModified));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(string newRawcode): base(1802728257, newRawcode)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _isDataChanceToReduceDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToReduceDamageModified));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _isDataMinimumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumDamageModified));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _isDataIgnoredDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoredDamageModified));
            _dataIncludeRangedDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeRangedDamageRaw, SetDataIncludeRangedDamageRaw));
            _isDataIncludeRangedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeRangedDamageModified));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeMeleeDamageRaw, SetDataIncludeMeleeDamageRaw));
            _isDataIncludeMeleeDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeMeleeDamageModified));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(ObjectDatabaseBase db): base(1802728257, db)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _isDataChanceToReduceDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToReduceDamageModified));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _isDataMinimumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumDamageModified));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _isDataIgnoredDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoredDamageModified));
            _dataIncludeRangedDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeRangedDamageRaw, SetDataIncludeRangedDamageRaw));
            _isDataIncludeRangedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeRangedDamageModified));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeMeleeDamageRaw, SetDataIncludeMeleeDamageRaw));
            _isDataIncludeMeleeDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeMeleeDamageModified));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(int newId, ObjectDatabaseBase db): base(1802728257, newId, db)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _isDataChanceToReduceDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToReduceDamageModified));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _isDataMinimumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumDamageModified));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _isDataIgnoredDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoredDamageModified));
            _dataIncludeRangedDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeRangedDamageRaw, SetDataIncludeRangedDamageRaw));
            _isDataIncludeRangedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeRangedDamageModified));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeMeleeDamageRaw, SetDataIncludeMeleeDamageRaw));
            _isDataIncludeMeleeDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeMeleeDamageModified));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(string newRawcode, ObjectDatabaseBase db): base(1802728257, newRawcode, db)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _isDataChanceToReduceDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToReduceDamageModified));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _isDataMinimumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMinimumDamageModified));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _isDataIgnoredDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIgnoredDamageModified));
            _dataIncludeRangedDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeRangedDamageRaw, SetDataIncludeRangedDamageRaw));
            _isDataIncludeRangedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeRangedDamageModified));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIncludeMeleeDamageRaw, SetDataIncludeMeleeDamageRaw));
            _isDataIncludeMeleeDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIncludeMeleeDamageModified));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public ObjectProperty<float> DataChanceToReduceDamage => _dataChanceToReduceDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToReduceDamageModified => _isDataChanceToReduceDamageModified.Value;
        public ObjectProperty<float> DataMinimumDamage => _dataMinimumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMinimumDamageModified => _isDataMinimumDamageModified.Value;
        public ObjectProperty<float> DataIgnoredDamage => _dataIgnoredDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataIgnoredDamageModified => _isDataIgnoredDamageModified.Value;
        public ObjectProperty<int> DataIncludeRangedDamageRaw => _dataIncludeRangedDamageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataIncludeRangedDamageModified => _isDataIncludeRangedDamageModified.Value;
        public ObjectProperty<bool> DataIncludeRangedDamage => _dataIncludeRangedDamage.Value;
        public ObjectProperty<int> DataIncludeMeleeDamageRaw => _dataIncludeMeleeDamageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataIncludeMeleeDamageModified => _isDataIncludeMeleeDamageModified.Value;
        public ObjectProperty<bool> DataIncludeMeleeDamage => _dataIncludeMeleeDamage.Value;
        private float GetDataChanceToReduceDamage(int level)
        {
            return _modifications.GetModification(829125459, level).ValueAsFloat;
        }

        private void SetDataChanceToReduceDamage(int level, float value)
        {
            _modifications[829125459, level] = new LevelObjectDataModification{Id = 829125459, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToReduceDamageModified(int level)
        {
            return _modifications.ContainsKey(829125459, level);
        }

        private float GetDataMinimumDamage(int level)
        {
            return _modifications.GetModification(845902675, level).ValueAsFloat;
        }

        private void SetDataMinimumDamage(int level, float value)
        {
            _modifications[845902675, level] = new LevelObjectDataModification{Id = 845902675, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMinimumDamageModified(int level)
        {
            return _modifications.ContainsKey(845902675, level);
        }

        private float GetDataIgnoredDamage(int level)
        {
            return _modifications.GetModification(862679891, level).ValueAsFloat;
        }

        private void SetDataIgnoredDamage(int level, float value)
        {
            _modifications[862679891, level] = new LevelObjectDataModification{Id = 862679891, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataIgnoredDamageModified(int level)
        {
            return _modifications.ContainsKey(862679891, level);
        }

        private int GetDataIncludeRangedDamageRaw(int level)
        {
            return _modifications.GetModification(879457107, level).ValueAsInt;
        }

        private void SetDataIncludeRangedDamageRaw(int level, int value)
        {
            _modifications[879457107, level] = new LevelObjectDataModification{Id = 879457107, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataIncludeRangedDamageModified(int level)
        {
            return _modifications.ContainsKey(879457107, level);
        }

        private bool GetDataIncludeRangedDamage(int level)
        {
            return GetDataIncludeRangedDamageRaw(level).ToBool(this);
        }

        private void SetDataIncludeRangedDamage(int level, bool value)
        {
            SetDataIncludeRangedDamageRaw(level, value.ToRaw(null, null));
        }

        private int GetDataIncludeMeleeDamageRaw(int level)
        {
            return _modifications.GetModification(896234323, level).ValueAsInt;
        }

        private void SetDataIncludeMeleeDamageRaw(int level, int value)
        {
            _modifications[896234323, level] = new LevelObjectDataModification{Id = 896234323, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataIncludeMeleeDamageModified(int level)
        {
            return _modifications.ContainsKey(896234323, level);
        }

        private bool GetDataIncludeMeleeDamage(int level)
        {
            return GetDataIncludeMeleeDamageRaw(level).ToBool(this);
        }

        private void SetDataIncludeMeleeDamage(int level, bool value)
        {
            SetDataIncludeMeleeDamageRaw(level, value.ToRaw(null, null));
        }
    }
}