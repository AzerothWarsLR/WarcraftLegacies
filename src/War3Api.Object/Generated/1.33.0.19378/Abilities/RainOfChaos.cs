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
    public sealed class RainOfChaos : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataAbilityForUnitCreationRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAbilityForUnitCreationModified;
        private readonly Lazy<ObjectProperty<Ability>> _dataAbilityForUnitCreation;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfUnitsCreated;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfUnitsCreatedModified;
        public RainOfChaos(): base(1668435521)
        {
            _dataAbilityForUnitCreationRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityForUnitCreationRaw, SetDataAbilityForUnitCreationRaw));
            _isDataAbilityForUnitCreationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityForUnitCreationModified));
            _dataAbilityForUnitCreation = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataAbilityForUnitCreation, SetDataAbilityForUnitCreation));
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public RainOfChaos(int newId): base(1668435521, newId)
        {
            _dataAbilityForUnitCreationRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityForUnitCreationRaw, SetDataAbilityForUnitCreationRaw));
            _isDataAbilityForUnitCreationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityForUnitCreationModified));
            _dataAbilityForUnitCreation = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataAbilityForUnitCreation, SetDataAbilityForUnitCreation));
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public RainOfChaos(string newRawcode): base(1668435521, newRawcode)
        {
            _dataAbilityForUnitCreationRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityForUnitCreationRaw, SetDataAbilityForUnitCreationRaw));
            _isDataAbilityForUnitCreationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityForUnitCreationModified));
            _dataAbilityForUnitCreation = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataAbilityForUnitCreation, SetDataAbilityForUnitCreation));
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public RainOfChaos(ObjectDatabaseBase db): base(1668435521, db)
        {
            _dataAbilityForUnitCreationRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityForUnitCreationRaw, SetDataAbilityForUnitCreationRaw));
            _isDataAbilityForUnitCreationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityForUnitCreationModified));
            _dataAbilityForUnitCreation = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataAbilityForUnitCreation, SetDataAbilityForUnitCreation));
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public RainOfChaos(int newId, ObjectDatabaseBase db): base(1668435521, newId, db)
        {
            _dataAbilityForUnitCreationRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityForUnitCreationRaw, SetDataAbilityForUnitCreationRaw));
            _isDataAbilityForUnitCreationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityForUnitCreationModified));
            _dataAbilityForUnitCreation = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataAbilityForUnitCreation, SetDataAbilityForUnitCreation));
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public RainOfChaos(string newRawcode, ObjectDatabaseBase db): base(1668435521, newRawcode, db)
        {
            _dataAbilityForUnitCreationRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataAbilityForUnitCreationRaw, SetDataAbilityForUnitCreationRaw));
            _isDataAbilityForUnitCreationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAbilityForUnitCreationModified));
            _dataAbilityForUnitCreation = new Lazy<ObjectProperty<Ability>>(() => new ObjectProperty<Ability>(GetDataAbilityForUnitCreation, SetDataAbilityForUnitCreation));
            _dataNumberOfUnitsCreated = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfUnitsCreated, SetDataNumberOfUnitsCreated));
            _isDataNumberOfUnitsCreatedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfUnitsCreatedModified));
        }

        public ObjectProperty<string> DataAbilityForUnitCreationRaw => _dataAbilityForUnitCreationRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAbilityForUnitCreationModified => _isDataAbilityForUnitCreationModified.Value;
        public ObjectProperty<Ability> DataAbilityForUnitCreation => _dataAbilityForUnitCreation.Value;
        public ObjectProperty<int> DataNumberOfUnitsCreated => _dataNumberOfUnitsCreated.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfUnitsCreatedModified => _isDataNumberOfUnitsCreatedModified.Value;
        private string GetDataAbilityForUnitCreationRaw(int level)
        {
            return _modifications.GetModification(828600910, level).ValueAsString;
        }

        private void SetDataAbilityForUnitCreationRaw(int level, string value)
        {
            _modifications[828600910, level] = new LevelObjectDataModification{Id = 828600910, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAbilityForUnitCreationModified(int level)
        {
            return _modifications.ContainsKey(828600910, level);
        }

        private Ability GetDataAbilityForUnitCreation(int level)
        {
            return GetDataAbilityForUnitCreationRaw(level).ToAbility(this);
        }

        private void SetDataAbilityForUnitCreation(int level, Ability value)
        {
            SetDataAbilityForUnitCreationRaw(level, value.ToRaw(null, null));
        }

        private int GetDataNumberOfUnitsCreated(int level)
        {
            return _modifications.GetModification(845378126, level).ValueAsInt;
        }

        private void SetDataNumberOfUnitsCreated(int level, int value)
        {
            _modifications[845378126, level] = new LevelObjectDataModification{Id = 845378126, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataNumberOfUnitsCreatedModified(int level)
        {
            return _modifications.ContainsKey(845378126, level);
        }
    }
}