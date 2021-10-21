using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MoveSpeedBonus : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMovementSpeedBonus;
        public MoveSpeedBonus(): base(1936542017)
        {
            _dataMovementSpeedBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementSpeedBonus, SetDataMovementSpeedBonus));
        }

        public MoveSpeedBonus(int newId): base(1936542017, newId)
        {
            _dataMovementSpeedBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementSpeedBonus, SetDataMovementSpeedBonus));
        }

        public MoveSpeedBonus(string newRawcode): base(1936542017, newRawcode)
        {
            _dataMovementSpeedBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementSpeedBonus, SetDataMovementSpeedBonus));
        }

        public MoveSpeedBonus(ObjectDatabase db): base(1936542017, db)
        {
            _dataMovementSpeedBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementSpeedBonus, SetDataMovementSpeedBonus));
        }

        public MoveSpeedBonus(int newId, ObjectDatabase db): base(1936542017, newId, db)
        {
            _dataMovementSpeedBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementSpeedBonus, SetDataMovementSpeedBonus));
        }

        public MoveSpeedBonus(string newRawcode, ObjectDatabase db): base(1936542017, newRawcode, db)
        {
            _dataMovementSpeedBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementSpeedBonus, SetDataMovementSpeedBonus));
        }

        public ObjectProperty<int> DataMovementSpeedBonus => _dataMovementSpeedBonus.Value;
        private int GetDataMovementSpeedBonus(int level)
        {
            return _modifications[1651928393, level].ValueAsInt;
        }

        private void SetDataMovementSpeedBonus(int level, int value)
        {
            _modifications[1651928393, level] = new LevelObjectDataModification{Id = 1651928393, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}