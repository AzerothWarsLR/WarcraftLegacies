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
        private readonly Lazy<ObjectProperty<float>> _dataData_fbk2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_fbk2Modified;
        private readonly Lazy<ObjectProperty<float>> _dataMaxManaDrainedHeros;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxManaDrainedHerosModified;
        private readonly Lazy<ObjectProperty<float>> _dataData_fbk4;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_fbk4Modified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedDamageModified;
        public Feedback(): base(1801610817)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataData_fbk2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk2, SetDataData_fbk2));
            _isDataData_fbk2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk2Modified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataData_fbk4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk4, SetDataData_fbk4));
            _isDataData_fbk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk4Modified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(int newId): base(1801610817, newId)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataData_fbk2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk2, SetDataData_fbk2));
            _isDataData_fbk2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk2Modified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataData_fbk4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk4, SetDataData_fbk4));
            _isDataData_fbk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk4Modified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(string newRawcode): base(1801610817, newRawcode)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataData_fbk2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk2, SetDataData_fbk2));
            _isDataData_fbk2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk2Modified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataData_fbk4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk4, SetDataData_fbk4));
            _isDataData_fbk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk4Modified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(ObjectDatabaseBase db): base(1801610817, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataData_fbk2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk2, SetDataData_fbk2));
            _isDataData_fbk2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk2Modified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataData_fbk4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk4, SetDataData_fbk4));
            _isDataData_fbk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk4Modified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(int newId, ObjectDatabaseBase db): base(1801610817, newId, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataData_fbk2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk2, SetDataData_fbk2));
            _isDataData_fbk2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk2Modified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataData_fbk4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk4, SetDataData_fbk4));
            _isDataData_fbk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk4Modified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public Feedback(string newRawcode, ObjectDatabaseBase db): base(1801610817, newRawcode, db)
        {
            _dataMaxManaDrainedUnits = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedUnits, SetDataMaxManaDrainedUnits));
            _isDataMaxManaDrainedUnitsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedUnitsModified));
            _dataData_fbk2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk2, SetDataData_fbk2));
            _isDataData_fbk2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk2Modified));
            _dataMaxManaDrainedHeros = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxManaDrainedHeros, SetDataMaxManaDrainedHeros));
            _isDataMaxManaDrainedHerosModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxManaDrainedHerosModified));
            _dataData_fbk4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_fbk4, SetDataData_fbk4));
            _isDataData_fbk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_fbk4Modified));
            _dataSummonedDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedDamage, SetDataSummonedDamage));
            _isDataSummonedDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedDamageModified));
        }

        public ObjectProperty<float> DataMaxManaDrainedUnits => _dataMaxManaDrainedUnits.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxManaDrainedUnitsModified => _isDataMaxManaDrainedUnitsModified.Value;
        public ObjectProperty<float> DataData_fbk2 => _dataData_fbk2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_fbk2Modified => _isDataData_fbk2Modified.Value;
        public ObjectProperty<float> DataMaxManaDrainedHeros => _dataMaxManaDrainedHeros.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxManaDrainedHerosModified => _isDataMaxManaDrainedHerosModified.Value;
        public ObjectProperty<float> DataData_fbk4 => _dataData_fbk4.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_fbk4Modified => _isDataData_fbk4Modified.Value;
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

        private float GetDataData_fbk2(int level)
        {
            return _modifications.GetModification(845898342, level).ValueAsFloat;
        }

        private void SetDataData_fbk2(int level, float value)
        {
            _modifications[845898342, level] = new LevelObjectDataModification{Id = 845898342, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_fbk2Modified(int level)
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

        private float GetDataData_fbk4(int level)
        {
            return _modifications.GetModification(879452774, level).ValueAsFloat;
        }

        private void SetDataData_fbk4(int level, float value)
        {
            _modifications[879452774, level] = new LevelObjectDataModification{Id = 879452774, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataData_fbk4Modified(int level)
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