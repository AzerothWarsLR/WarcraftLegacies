using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WindWalk : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataBackstabDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBackstabDamageModified;
        private readonly Lazy<ObjectProperty<bool>> _dataStartCooldownWhenDecloak;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStartCooldownWhenDecloakModified;
        public WindWalk(): base(1802980929)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
        }

        public WindWalk(int newId): base(1802980929, newId)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
        }

        public WindWalk(string newRawcode): base(1802980929, newRawcode)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
        }

        public WindWalk(ObjectDatabase db): base(1802980929, db)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
        }

        public WindWalk(int newId, ObjectDatabase db): base(1802980929, newId, db)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
        }

        public WindWalk(string newRawcode, ObjectDatabase db): base(1802980929, newRawcode, db)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _isDataBackstabDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamageModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
        }

        public ObjectProperty<bool> DataBackstabDamage => _dataBackstabDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataBackstabDamageModified => _isDataBackstabDamageModified.Value;
        public ObjectProperty<bool> DataStartCooldownWhenDecloak => _dataStartCooldownWhenDecloak.Value;
        public ReadOnlyObjectProperty<bool> IsDataStartCooldownWhenDecloakModified => _isDataStartCooldownWhenDecloakModified.Value;
        private bool GetDataBackstabDamage(int level)
        {
            return _modifications[879458127, level].ValueAsBool;
        }

        private void SetDataBackstabDamage(int level, bool value)
        {
            _modifications[879458127, level] = new LevelObjectDataModification{Id = 879458127, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataBackstabDamageModified(int level)
        {
            return _modifications.ContainsKey(879458127, level);
        }

        private bool GetDataStartCooldownWhenDecloak(int level)
        {
            return _modifications[896235343, level].ValueAsBool;
        }

        private void SetDataStartCooldownWhenDecloak(int level, bool value)
        {
            _modifications[896235343, level] = new LevelObjectDataModification{Id = 896235343, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataStartCooldownWhenDecloakModified(int level)
        {
            return _modifications.ContainsKey(896235343, level);
        }
    }
}