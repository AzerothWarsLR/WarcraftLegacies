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
    public sealed class AttackBonus_AItc : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAttackBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackBonusModified;
        public AttackBonus_AItc(): base(1668565313)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
            _isDataAttackBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackBonusModified));
        }

        public AttackBonus_AItc(int newId): base(1668565313, newId)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
            _isDataAttackBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackBonusModified));
        }

        public AttackBonus_AItc(string newRawcode): base(1668565313, newRawcode)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
            _isDataAttackBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackBonusModified));
        }

        public AttackBonus_AItc(ObjectDatabaseBase db): base(1668565313, db)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
            _isDataAttackBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackBonusModified));
        }

        public AttackBonus_AItc(int newId, ObjectDatabaseBase db): base(1668565313, newId, db)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
            _isDataAttackBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackBonusModified));
        }

        public AttackBonus_AItc(string newRawcode, ObjectDatabaseBase db): base(1668565313, newRawcode, db)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
            _isDataAttackBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackBonusModified));
        }

        public ObjectProperty<int> DataAttackBonus => _dataAttackBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackBonusModified => _isDataAttackBonusModified.Value;
        private int GetDataAttackBonus(int level)
        {
            return _modifications.GetModification(1953784137, level).ValueAsInt;
        }

        private void SetDataAttackBonus(int level, int value)
        {
            _modifications[1953784137, level] = new LevelObjectDataModification{Id = 1953784137, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackBonusModified(int level)
        {
            return _modifications.ContainsKey(1953784137, level);
        }
    }
}