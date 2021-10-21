using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DefenseBonus4 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDefenseBonus;
        public DefenseBonus4(): base(878987585)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
        }

        public DefenseBonus4(int newId): base(878987585, newId)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
        }

        public DefenseBonus4(string newRawcode): base(878987585, newRawcode)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
        }

        public DefenseBonus4(ObjectDatabase db): base(878987585, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
        }

        public DefenseBonus4(int newId, ObjectDatabase db): base(878987585, newId, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
        }

        public DefenseBonus4(string newRawcode, ObjectDatabase db): base(878987585, newRawcode, db)
        {
            _dataDefenseBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDefenseBonus, SetDataDefenseBonus));
        }

        public ObjectProperty<int> DataDefenseBonus => _dataDefenseBonus.Value;
        private int GetDataDefenseBonus(int level)
        {
            return _modifications[1717920841, level].ValueAsInt;
        }

        private void SetDataDefenseBonus(int level, int value)
        {
            _modifications[1717920841, level] = new LevelObjectDataModification{Id = 1717920841, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}