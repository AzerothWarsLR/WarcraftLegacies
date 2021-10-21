using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WindWalk : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataBackstabDamage;
        private readonly Lazy<ObjectProperty<bool>> _dataStartCooldownWhenDecloak;
        public WindWalk(): base(1802980929)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(int newId): base(1802980929, newId)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(string newRawcode): base(1802980929, newRawcode)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(ObjectDatabase db): base(1802980929, db)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(int newId, ObjectDatabase db): base(1802980929, newId, db)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public WindWalk(string newRawcode, ObjectDatabase db): base(1802980929, newRawcode, db)
        {
            _dataBackstabDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage, SetDataBackstabDamage));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public ObjectProperty<bool> DataBackstabDamage => _dataBackstabDamage.Value;
        public ObjectProperty<bool> DataStartCooldownWhenDecloak => _dataStartCooldownWhenDecloak.Value;
        private bool GetDataBackstabDamage(int level)
        {
            return _modifications[879458127, level].ValueAsBool;
        }

        private void SetDataBackstabDamage(int level, bool value)
        {
            _modifications[879458127, level] = new LevelObjectDataModification{Id = 879458127, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataStartCooldownWhenDecloak(int level)
        {
            return _modifications[896235343, level].ValueAsBool;
        }

        private void SetDataStartCooldownWhenDecloak(int level, bool value)
        {
            _modifications[896235343, level] = new LevelObjectDataModification{Id = 896235343, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}