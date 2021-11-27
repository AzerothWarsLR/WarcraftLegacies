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
    public sealed class AttackTargetPriority : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAOEDamageRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAOEDamageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAOEDamage;
        public AttackTargetPriority(): base(1886675265)
        {
            _dataAOEDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAOEDamageRaw, SetDataAOEDamageRaw));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
        }

        public AttackTargetPriority(int newId): base(1886675265, newId)
        {
            _dataAOEDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAOEDamageRaw, SetDataAOEDamageRaw));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
        }

        public AttackTargetPriority(string newRawcode): base(1886675265, newRawcode)
        {
            _dataAOEDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAOEDamageRaw, SetDataAOEDamageRaw));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
        }

        public AttackTargetPriority(ObjectDatabaseBase db): base(1886675265, db)
        {
            _dataAOEDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAOEDamageRaw, SetDataAOEDamageRaw));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
        }

        public AttackTargetPriority(int newId, ObjectDatabaseBase db): base(1886675265, newId, db)
        {
            _dataAOEDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAOEDamageRaw, SetDataAOEDamageRaw));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
        }

        public AttackTargetPriority(string newRawcode, ObjectDatabaseBase db): base(1886675265, newRawcode, db)
        {
            _dataAOEDamageRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAOEDamageRaw, SetDataAOEDamageRaw));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
        }

        public ObjectProperty<int> DataAOEDamageRaw => _dataAOEDamageRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAOEDamageModified => _isDataAOEDamageModified.Value;
        public ObjectProperty<bool> DataAOEDamage => _dataAOEDamage.Value;
        private int GetDataAOEDamageRaw(int level)
        {
            return _modifications.GetModification(829710657, level).ValueAsInt;
        }

        private void SetDataAOEDamageRaw(int level, int value)
        {
            _modifications[829710657, level] = new LevelObjectDataModification{Id = 829710657, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAOEDamageModified(int level)
        {
            return _modifications.ContainsKey(829710657, level);
        }

        private bool GetDataAOEDamage(int level)
        {
            return GetDataAOEDamageRaw(level).ToBool(this);
        }

        private void SetDataAOEDamage(int level, bool value)
        {
            SetDataAOEDamageRaw(level, value.ToRaw(0, 1));
        }
    }
}