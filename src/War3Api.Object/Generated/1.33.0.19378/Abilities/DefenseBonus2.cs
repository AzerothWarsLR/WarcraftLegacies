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
    public sealed class DefenseBonus2 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDefenseBonusModified;
        public DefenseBonus2(): base(845433153)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public DefenseBonus2(int newId): base(845433153, newId)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public DefenseBonus2(string newRawcode): base(845433153, newRawcode)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public DefenseBonus2(ObjectDatabaseBase db): base(845433153, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public DefenseBonus2(int newId, ObjectDatabaseBase db): base(845433153, newId, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public DefenseBonus2(string newRawcode, ObjectDatabaseBase db): base(845433153, newRawcode, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
            _isDataDefenseBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDefenseBonusModified));
        }

        public ObjectProperty<int> DataDefenseBonus => _dataDefenseBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataDefenseBonusModified => _isDataDefenseBonusModified.Value;
        private int GetDataDefenseBonus(int level)
        {
            return _modifications.GetModification(1717920841, level).ValueAsInt;
        }

        private void SetDataDefenseBonus(int level, int value)
        {
            _modifications[1717920841, level] = new LevelObjectDataModification{Id = 1717920841, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDefenseBonusModified(int level)
        {
            return _modifications.ContainsKey(1717920841, level);
        }
    }
}