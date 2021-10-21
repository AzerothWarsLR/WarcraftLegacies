using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class HardenedSkin : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToReduceDamage;
        private readonly Lazy<ObjectProperty<float>> _dataMinimumDamage;
        private readonly Lazy<ObjectProperty<float>> _dataIgnoredDamage;
        private readonly Lazy<ObjectProperty<bool>> _dataIncludeRangedDamage;
        private readonly Lazy<ObjectProperty<bool>> _dataIncludeMeleeDamage;
        public HardenedSkin(): base(1802728257)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(int newId): base(1802728257, newId)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(string newRawcode): base(1802728257, newRawcode)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(ObjectDatabase db): base(1802728257, db)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(int newId, ObjectDatabase db): base(1802728257, newId, db)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public HardenedSkin(string newRawcode, ObjectDatabase db): base(1802728257, newRawcode, db)
        {
            _dataChanceToReduceDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToReduceDamage, SetDataChanceToReduceDamage));
            _dataMinimumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMinimumDamage, SetDataMinimumDamage));
            _dataIgnoredDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataIgnoredDamage, SetDataIgnoredDamage));
            _dataIncludeRangedDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeRangedDamage, SetDataIncludeRangedDamage));
            _dataIncludeMeleeDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataIncludeMeleeDamage, SetDataIncludeMeleeDamage));
        }

        public ObjectProperty<float> DataChanceToReduceDamage => _dataChanceToReduceDamage.Value;
        public ObjectProperty<float> DataMinimumDamage => _dataMinimumDamage.Value;
        public ObjectProperty<float> DataIgnoredDamage => _dataIgnoredDamage.Value;
        public ObjectProperty<bool> DataIncludeRangedDamage => _dataIncludeRangedDamage.Value;
        public ObjectProperty<bool> DataIncludeMeleeDamage => _dataIncludeMeleeDamage.Value;
        private float GetDataChanceToReduceDamage(int level)
        {
            return _modifications[829125459, level].ValueAsFloat;
        }

        private void SetDataChanceToReduceDamage(int level, float value)
        {
            _modifications[829125459, level] = new LevelObjectDataModification{Id = 829125459, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMinimumDamage(int level)
        {
            return _modifications[845902675, level].ValueAsFloat;
        }

        private void SetDataMinimumDamage(int level, float value)
        {
            _modifications[845902675, level] = new LevelObjectDataModification{Id = 845902675, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataIgnoredDamage(int level)
        {
            return _modifications[862679891, level].ValueAsFloat;
        }

        private void SetDataIgnoredDamage(int level, float value)
        {
            _modifications[862679891, level] = new LevelObjectDataModification{Id = 862679891, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataIncludeRangedDamage(int level)
        {
            return _modifications[879457107, level].ValueAsBool;
        }

        private void SetDataIncludeRangedDamage(int level, bool value)
        {
            _modifications[879457107, level] = new LevelObjectDataModification{Id = 879457107, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataIncludeMeleeDamage(int level)
        {
            return _modifications[896234323, level].ValueAsBool;
        }

        private void SetDataIncludeMeleeDamage(int level, bool value)
        {
            _modifications[896234323, level] = new LevelObjectDataModification{Id = 896234323, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}