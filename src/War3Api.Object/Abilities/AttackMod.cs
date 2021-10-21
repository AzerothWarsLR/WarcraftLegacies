using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AttackMod : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAttackModification;
        public AttackMod(): base(1633765697)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
        }

        public AttackMod(int newId): base(1633765697, newId)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
        }

        public AttackMod(string newRawcode): base(1633765697, newRawcode)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
        }

        public AttackMod(ObjectDatabase db): base(1633765697, db)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
        }

        public AttackMod(int newId, ObjectDatabase db): base(1633765697, newId, db)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
        }

        public AttackMod(string newRawcode, ObjectDatabase db): base(1633765697, newRawcode, db)
        {
            _dataAttackModification = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackModification, SetDataAttackModification));
        }

        public ObjectProperty<int> DataAttackModification => _dataAttackModification.Value;
        private int GetDataAttackModification(int level)
        {
            return _modifications[828465481, level].ValueAsInt;
        }

        private void SetDataAttackModification(int level, int value)
        {
            _modifications[828465481, level] = new LevelObjectDataModification{Id = 828465481, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}