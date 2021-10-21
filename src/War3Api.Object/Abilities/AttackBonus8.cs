using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AttackBonus8 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAttackBonus;
        public AttackBonus8(): base(1819560257)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
        }

        public AttackBonus8(int newId): base(1819560257, newId)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
        }

        public AttackBonus8(string newRawcode): base(1819560257, newRawcode)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
        }

        public AttackBonus8(ObjectDatabase db): base(1819560257, db)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
        }

        public AttackBonus8(int newId, ObjectDatabase db): base(1819560257, newId, db)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
        }

        public AttackBonus8(string newRawcode, ObjectDatabase db): base(1819560257, newRawcode, db)
        {
            _dataAttackBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackBonus, SetDataAttackBonus));
        }

        public ObjectProperty<int> DataAttackBonus => _dataAttackBonus.Value;
        private int GetDataAttackBonus(int level)
        {
            return _modifications[1953784137, level].ValueAsInt;
        }

        private void SetDataAttackBonus(int level, int value)
        {
            _modifications[1953784137, level] = new LevelObjectDataModification{Id = 1953784137, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}