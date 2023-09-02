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
    public sealed class AttackMod : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAttackModification;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackModificationModified;
        public AttackMod(): base(1633765697)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
            _isDataAttackModificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackModificationModified));
        }

        public AttackMod(int newId): base(1633765697, newId)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
            _isDataAttackModificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackModificationModified));
        }

        public AttackMod(string newRawcode): base(1633765697, newRawcode)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
            _isDataAttackModificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackModificationModified));
        }

        public AttackMod(ObjectDatabaseBase db): base(1633765697, db)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
            _isDataAttackModificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackModificationModified));
        }

        public AttackMod(int newId, ObjectDatabaseBase db): base(1633765697, newId, db)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
            _isDataAttackModificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackModificationModified));
        }

        public AttackMod(string newRawcode, ObjectDatabaseBase db): base(1633765697, newRawcode, db)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
            _isDataAttackModificationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackModificationModified));
        }

        public ObjectProperty<int> DataAttackModification => _dataAttackModification.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackModificationModified => _isDataAttackModificationModified.Value;
        private int GetDataAttackModification(int level)
        {
            return _modifications.GetModification(828465481, level).ValueAsInt;
        }

        private void SetDataAttackModification(int level, int value)
        {
            _modifications[828465481, level] = new LevelObjectDataModification{Id = 828465481, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackModificationModified(int level)
        {
            return _modifications.ContainsKey(828465481, level);
        }
    }
}