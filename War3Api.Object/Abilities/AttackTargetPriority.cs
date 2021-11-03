using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AttackTargetPriority : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataAOEDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAOEDamageModified;
        public AttackTargetPriority(): base(1886675265)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
        }

        public AttackTargetPriority(int newId): base(1886675265, newId)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
        }

        public AttackTargetPriority(string newRawcode): base(1886675265, newRawcode)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
        }

        public AttackTargetPriority(ObjectDatabase db): base(1886675265, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
        }

        public AttackTargetPriority(int newId, ObjectDatabase db): base(1886675265, newId, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
        }

        public AttackTargetPriority(string newRawcode, ObjectDatabase db): base(1886675265, newRawcode, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
        }

        public ObjectProperty<bool> DataAOEDamage => _dataAOEDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataAOEDamageModified => _isDataAOEDamageModified.Value;
        private bool GetDataAOEDamage(int level)
        {
            return _modifications[829710657, level].ValueAsBool;
        }

        private void SetDataAOEDamage(int level, bool value)
        {
            _modifications[829710657, level] = new LevelObjectDataModification{Id = 829710657, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAOEDamageModified(int level)
        {
            return _modifications.ContainsKey(829710657, level);
        }
    }
}