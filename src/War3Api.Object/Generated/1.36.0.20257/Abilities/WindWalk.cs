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
    public sealed class WindWalk : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataBackstabDamageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBackstabDamageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataBackstabDamage;
        private readonly Lazy<ObjectProperty<int>> _dataStartCooldownWhenDecloakRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStartCooldownWhenDecloakModified;
        private readonly Lazy<ObjectProperty<bool>> _dataStartCooldownWhenDecloak;
        public WindWalk(): base(1802980929)
        {
            _dataBackstabDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamageRaw, SetDataBackstabDamageRaw));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(int newId): base(1802980929, newId)
        {
            _dataBackstabDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamageRaw, SetDataBackstabDamageRaw));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(string newRawcode): base(1802980929, newRawcode)
        {
            _dataBackstabDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamageRaw, SetDataBackstabDamageRaw));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(ObjectDatabaseBase db): base(1802980929, db)
        {
            _dataBackstabDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamageRaw, SetDataBackstabDamageRaw));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(int newId, ObjectDatabaseBase db): base(1802980929, newId, db)
        {
            _dataBackstabDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamageRaw, SetDataBackstabDamageRaw));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(string newRawcode, ObjectDatabaseBase db): base(1802980929, newRawcode, db)
        {
            _dataBackstabDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamageRaw, SetDataBackstabDamageRaw));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public ObjectProperty<int> DataBackstabDamageRaw => _dataBackstabDamageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataBackstabDamageModified => _isDataBackstabDamageModified.Value;
        public ObjectProperty<bool> DataBackstabDamage => _dataBackstabDamage.Value;
        public ObjectProperty<int> DataStartCooldownWhenDecloakRaw => _dataStartCooldownWhenDecloakRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataStartCooldownWhenDecloakModified => _isDataStartCooldownWhenDecloakModified.Value;
        public ObjectProperty<bool> DataStartCooldownWhenDecloak => _dataStartCooldownWhenDecloak.Value;
        private int GetDataBackstabDamageRaw(int level)
        {
            return _modifications.GetModification(879458127, level).ValueAsInt;
        }

        private void SetDataBackstabDamageRaw(int level, int value)
        {
            _modifications[879458127, level] = new LevelObjectDataModification{Id = 879458127, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataBackstabDamageModified(int level)
        {
            return _modifications.ContainsKey(879458127, level);
        }

        private bool GetDataBackstabDamage(int level)
        {
            return GetDataBackstabDamageRaw(level).ToBool(this);
        }

        private void SetDataBackstabDamage(int level, bool value)
        {
            SetDataBackstabDamageRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataStartCooldownWhenDecloakRaw(int level)
        {
            return _modifications.GetModification(896235343, level).ValueAsInt;
        }

        private void SetDataStartCooldownWhenDecloakRaw(int level, int value)
        {
            _modifications[896235343, level] = new LevelObjectDataModification{Id = 896235343, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataStartCooldownWhenDecloakModified(int level)
        {
            return _modifications.ContainsKey(896235343, level);
        }

        private bool GetDataStartCooldownWhenDecloak(int level)
        {
            return GetDataStartCooldownWhenDecloakRaw(level).ToBool(this);
        }

        private void SetDataStartCooldownWhenDecloak(int level, bool value)
        {
            SetDataStartCooldownWhenDecloakRaw(level, value.ToRaw(0, 1));
        }
    }
}