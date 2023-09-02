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
    public sealed class Feedback : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrainedUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxManaDrainedUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageRatioUnits;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageRatioUnitsModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrainedHeros;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxManaDrainedHerosModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageRatioHeros;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageRatioHerosModified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedDamageModified;
        public Feedback(): base(1801610817)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _isDataDamageRatioUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioUnitsModified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _isDataDamageRatioHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioHerosModified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(int newId): base(1801610817, newId)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _isDataDamageRatioUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioUnitsModified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _isDataDamageRatioHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioHerosModified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(string newRawcode): base(1801610817, newRawcode)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _isDataDamageRatioUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioUnitsModified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _isDataDamageRatioHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioHerosModified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(ObjectDatabaseBase db): base(1801610817, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _isDataDamageRatioUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioUnitsModified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _isDataDamageRatioHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioHerosModified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(int newId, ObjectDatabaseBase db): base(1801610817, newId, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _isDataDamageRatioUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioUnitsModified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _isDataDamageRatioHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioHerosModified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(string newRawcode, ObjectDatabaseBase db): base(1801610817, newRawcode, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataDamageRatioUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioUnits, SetDataDamageRatioUnits));
            _isDataDamageRatioUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioUnitsModified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataDamageRatioHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRatioHeros, SetDataDamageRatioHeros));
            _isDataDamageRatioHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRatioHerosModified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public ObjectProperty<float> DataMaxManaDrainedUnits => _dataMaxManaDrainedUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxManaDrainedUnitsModified => _isDataMaxManaDrainedUnitsModified.Value;
        public ObjectProperty<float> DataDamageRatioUnits => _dataDamageRatioUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageRatioUnitsModified => _isDataDamageRatioUnitsModified.Value;
        public ObjectProperty<float> DataMaxManaDrainedHeros => _dataMaxManaDrainedHeros.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxManaDrainedHerosModified => _isDataMaxManaDrainedHerosModified.Value;
        public ObjectProperty<float> DataDamageRatioHeros => _dataDamageRatioHeros.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageRatioHerosModified => _isDataDamageRatioHerosModified.Value;
        public ObjectProperty<float> DataSummonedDamage => _dataSummonedDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedDamageModified => _isDataSummonedDamageModified.Value;
        private float GetDataMaxManaDrainedUnits(int level)
        {
            return _modifications.GetModification(829121126, level).ValueAsFloat;
        }

        private void SetDataMaxManaDrainedUnits(int level, float value)
        {
            _modifications[829121126, level] = new LevelObjectDataModification{Id = 829121126, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxManaDrainedUnitsModified(int level)
        {
            return _modifications.ContainsKey(829121126, level);
        }

        private float GetDataDamageRatioUnits(int level)
        {
            return _modifications.GetModification(845898342, level).ValueAsFloat;
        }

        private void SetDataDamageRatioUnits(int level, float value)
        {
            _modifications[845898342, level] = new LevelObjectDataModification{Id = 845898342, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDamageRatioUnitsModified(int level)
        {
            return _modifications.ContainsKey(845898342, level);
        }

        private float GetDataMaxManaDrainedHeros(int level)
        {
            return _modifications.GetModification(862675558, level).ValueAsFloat;
        }

        private void SetDataMaxManaDrainedHeros(int level, float value)
        {
            _modifications[862675558, level] = new LevelObjectDataModification{Id = 862675558, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataMaxManaDrainedHerosModified(int level)
        {
            return _modifications.ContainsKey(862675558, level);
        }

        private float GetDataDamageRatioHeros(int level)
        {
            return _modifications.GetModification(879452774, level).ValueAsFloat;
        }

        private void SetDataDamageRatioHeros(int level, float value)
        {
            _modifications[879452774, level] = new LevelObjectDataModification{Id = 879452774, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataDamageRatioHerosModified(int level)
        {
            return _modifications.ContainsKey(879452774, level);
        }

        private float GetDataSummonedDamage(int level)
        {
            return _modifications.GetModification(896229990, level).ValueAsFloat;
        }

        private void SetDataSummonedDamage(int level, float value)
        {
            _modifications[896229990, level] = new LevelObjectDataModification{Id = 896229990, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataSummonedDamageModified(int level)
        {
            return _modifications.ContainsKey(896229990, level);
        }
    }
}