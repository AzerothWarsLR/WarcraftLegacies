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
    public sealed class MechanicalCritter : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfUnitsCreated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfUnitsCreatedModified;
        public MechanicalCritter(): base(1667591489)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public MechanicalCritter(int newId): base(1667591489, newId)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public MechanicalCritter(string newRawcode): base(1667591489, newRawcode)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public MechanicalCritter(ObjectDatabaseBase db): base(1667591489, db)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public MechanicalCritter(int newId, ObjectDatabaseBase db): base(1667591489, newId, db)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public MechanicalCritter(string newRawcode, ObjectDatabaseBase db): base(1667591489, newRawcode, db)
        {
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public ObjectProperty<int> DataNumberOfUnitsCreated => _dataNumberOfUnitsCreated.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfUnitsCreatedModified => _isDataNumberOfUnitsCreatedModified.Value;
        private int GetDataNumberOfUnitsCreated(int level)
        {
            return _modifications.GetModification(828597613, level).ValueAsInt;
        }

        private void SetDataNumberOfUnitsCreated(int level, int value)
        {
            _modifications[828597613, level] = new LevelObjectDataModification{Id = 828597613, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfUnitsCreatedModified(int level)
        {
            return _modifications.ContainsKey(828597613, level);
        }
    }
}