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
    public sealed class ItemDispelChain : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaLossPerUnit;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaLossPerUnitModified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitDamageModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumDispelledUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumDispelledUnitsModified;
        public ItemDispelChain(): base(1667516737)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
            _isDataMaximumDispelledUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDispelledUnitsModified));
        }

        public ItemDispelChain(int newId): base(1667516737, newId)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
            _isDataMaximumDispelledUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDispelledUnitsModified));
        }

        public ItemDispelChain(string newRawcode): base(1667516737, newRawcode)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
            _isDataMaximumDispelledUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDispelledUnitsModified));
        }

        public ItemDispelChain(ObjectDatabaseBase db): base(1667516737, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
            _isDataMaximumDispelledUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDispelledUnitsModified));
        }

        public ItemDispelChain(int newId, ObjectDatabaseBase db): base(1667516737, newId, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
            _isDataMaximumDispelledUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDispelledUnitsModified));
        }

        public ItemDispelChain(string newRawcode, ObjectDatabaseBase db): base(1667516737, newRawcode, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _isDataManaLossPerUnitModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossPerUnitModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
            _isDataMaximumDispelledUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDispelledUnitsModified));
        }

        public ObjectProperty<float> DataManaLossPerUnit => _dataManaLossPerUnit.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaLossPerUnitModified => _isDataManaLossPerUnitModified.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitDamageModified => _isDataSummonedUnitDamageModified.Value;
        public ObjectProperty<int> DataMaximumDispelledUnits => _dataMaximumDispelledUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumDispelledUnitsModified => _isDataMaximumDispelledUnitsModified.Value;
        private float GetDataManaLossPerUnit(int level)
        {
            return _modifications.GetModification(828597353, level).ValueAsFloat;
        }

        private void SetDataManaLossPerUnit(int level, float value)
        {
            _modifications[828597353, level] = new LevelObjectDataModification{Id = 828597353, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaLossPerUnitModified(int level)
        {
            return _modifications.ContainsKey(828597353, level);
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications.GetModification(845374569, level).ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[845374569, level] = new LevelObjectDataModification{Id = 845374569, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSummonedUnitDamageModified(int level)
        {
            return _modifications.ContainsKey(845374569, level);
        }

        private int GetDataMaximumDispelledUnits(int level)
        {
            return _modifications.GetModification(862151785, level).ValueAsInt;
        }

        private void SetDataMaximumDispelledUnits(int level, int value)
        {
            _modifications[862151785, level] = new LevelObjectDataModification{Id = 862151785, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaximumDispelledUnitsModified(int level)
        {
            return _modifications.ContainsKey(862151785, level);
        }
    }
}