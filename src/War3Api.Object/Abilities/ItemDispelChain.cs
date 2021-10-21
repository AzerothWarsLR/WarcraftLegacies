using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemDispelChain : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaLossPerUnit;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumDispelledUnits;
        public ItemDispelChain(): base(1667516737)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
        }

        public ItemDispelChain(int newId): base(1667516737, newId)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
        }

        public ItemDispelChain(string newRawcode): base(1667516737, newRawcode)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
        }

        public ItemDispelChain(ObjectDatabase db): base(1667516737, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
        }

        public ItemDispelChain(int newId, ObjectDatabase db): base(1667516737, newId, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
        }

        public ItemDispelChain(string newRawcode, ObjectDatabase db): base(1667516737, newRawcode, db)
        {
            _dataManaLossPerUnit = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaLossPerUnit, SetDataManaLossPerUnit));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataMaximumDispelledUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumDispelledUnits, SetDataMaximumDispelledUnits));
        }

        public ObjectProperty<float> DataManaLossPerUnit => _dataManaLossPerUnit.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ObjectProperty<int> DataMaximumDispelledUnits => _dataMaximumDispelledUnits.Value;
        private float GetDataManaLossPerUnit(int level)
        {
            return _modifications[828597353, level].ValueAsFloat;
        }

        private void SetDataManaLossPerUnit(int level, float value)
        {
            _modifications[828597353, level] = new LevelObjectDataModification{Id = 828597353, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications[845374569, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[845374569, level] = new LevelObjectDataModification{Id = 845374569, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaximumDispelledUnits(int level)
        {
            return _modifications[862151785, level].ValueAsInt;
        }

        private void SetDataMaximumDispelledUnits(int level, int value)
        {
            _modifications[862151785, level] = new LevelObjectDataModification{Id = 862151785, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}