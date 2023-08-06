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
    public sealed class ItemDispelAoe : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataManaLossPerUnit;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaLossPerUnitModified;
        private readonly Lazy<ObjectProperty<int>> _dataDamageToSummonedUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageToSummonedUnitsModified;
        public ItemDispelAoe(): base(1768180033)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _isDataDamageToSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToSummonedUnitsModified));
        }

        public ItemDispelAoe(int newId): base(1768180033, newId)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _isDataDamageToSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToSummonedUnitsModified));
        }

        public ItemDispelAoe(string newRawcode): base(1768180033, newRawcode)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _isDataDamageToSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToSummonedUnitsModified));
        }

        public ItemDispelAoe(ObjectDatabaseBase db): base(1768180033, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _isDataDamageToSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToSummonedUnitsModified));
        }

        public ItemDispelAoe(int newId, ObjectDatabaseBase db): base(1768180033, newId, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _isDataDamageToSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToSummonedUnitsModified));
        }

        public ItemDispelAoe(string newRawcode, ObjectDatabaseBase db): base(1768180033, newRawcode, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataDamageToSummonedUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDamageToSummonedUnits, SetDataDamageToSummonedUnits));
            _isDataDamageToSummonedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageToSummonedUnitsModified));
        }

        public ObjectProperty<int> DataManaLossPerUnit => _dataManaLossPerUnit.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaLossPerUnitModified => _isDataManaLossPerUnitModified.Value;
        public ObjectProperty<int> DataDamageToSummonedUnits => _dataDamageToSummonedUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageToSummonedUnitsModified => _isDataDamageToSummonedUnitsModified.Value;
        private int GetDataManaLossPerUnit(int level)
        {
            return _modifications.GetModification(1835623497, level).ValueAsInt;
        }

        private void SetDataManaLossPerUnit(int level, int value)
        {
            _modifications[1835623497, level] = new LevelObjectDataModification{Id = 1835623497, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaLossPerUnitModified(int level)
        {
            return _modifications.ContainsKey(1835623497, level);
        }

        private int GetDataDamageToSummonedUnits(int level)
        {
            return _modifications.GetModification(1684628553, level).ValueAsInt;
        }

        private void SetDataDamageToSummonedUnits(int level, int value)
        {
            _modifications[1684628553, level] = new LevelObjectDataModification{Id = 1684628553, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageToSummonedUnitsModified(int level)
        {
            return _modifications.ContainsKey(1684628553, level);
        }
    }
}