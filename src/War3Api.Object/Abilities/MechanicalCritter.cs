using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MechanicalCritter : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfUnitsCreated;
        public MechanicalCritter(): base(1667591489)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
        }

        public MechanicalCritter(int newId): base(1667591489, newId)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
        }

        public MechanicalCritter(string newRawcode): base(1667591489, newRawcode)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
        }

        public MechanicalCritter(ObjectDatabase db): base(1667591489, db)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
        }

        public MechanicalCritter(int newId, ObjectDatabase db): base(1667591489, newId, db)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
        }

        public MechanicalCritter(string newRawcode, ObjectDatabase db): base(1667591489, newRawcode, db)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
        }

        public ObjectProperty<int> DataNumberOfUnitsCreated => _dataNumberOfUnitsCreated.Value;
        private int GetDataNumberOfUnitsCreated(int level)
        {
            return _modifications[828597613, level].ValueAsInt;
        }

        private void SetDataNumberOfUnitsCreated(int level, int value)
        {
            _modifications[828597613, level] = new LevelObjectDataModification{Id = 828597613, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}