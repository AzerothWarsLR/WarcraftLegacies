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
    public sealed class Bloodlust : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData_Blo1;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Blo1Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Blo2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Blo2Modified;
        private readonly Lazy<ObjectProperty<float>> _dataScalingFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataScalingFactorModified;
        public Bloodlust(): base(1869374017)
        {
            _dataData_Blo1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo1, SetDataData_Blo1));
            _isDataData_Blo1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo1Modified));
            _dataData_Blo2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo2, SetDataData_Blo2));
            _isDataData_Blo2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo2Modified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Bloodlust(int newId): base(1869374017, newId)
        {
            _dataData_Blo1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo1, SetDataData_Blo1));
            _isDataData_Blo1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo1Modified));
            _dataData_Blo2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo2, SetDataData_Blo2));
            _isDataData_Blo2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo2Modified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Bloodlust(string newRawcode): base(1869374017, newRawcode)
        {
            _dataData_Blo1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo1, SetDataData_Blo1));
            _isDataData_Blo1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo1Modified));
            _dataData_Blo2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo2, SetDataData_Blo2));
            _isDataData_Blo2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo2Modified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Bloodlust(ObjectDatabaseBase db): base(1869374017, db)
        {
            _dataData_Blo1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo1, SetDataData_Blo1));
            _isDataData_Blo1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo1Modified));
            _dataData_Blo2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo2, SetDataData_Blo2));
            _isDataData_Blo2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo2Modified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Bloodlust(int newId, ObjectDatabaseBase db): base(1869374017, newId, db)
        {
            _dataData_Blo1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo1, SetDataData_Blo1));
            _isDataData_Blo1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo1Modified));
            _dataData_Blo2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo2, SetDataData_Blo2));
            _isDataData_Blo2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo2Modified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public Bloodlust(string newRawcode, ObjectDatabaseBase db): base(1869374017, newRawcode, db)
        {
            _dataData_Blo1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo1, SetDataData_Blo1));
            _isDataData_Blo1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo1Modified));
            _dataData_Blo2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Blo2, SetDataData_Blo2));
            _isDataData_Blo2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Blo2Modified));
            _dataScalingFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataScalingFactor, SetDataScalingFactor));
            _isDataScalingFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataScalingFactorModified));
        }

        public ObjectProperty<float> DataData_Blo1 => _dataData_Blo1.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Blo1Modified => _isDataData_Blo1Modified.Value;
        public ObjectProperty<float> DataData_Blo2 => _dataData_Blo2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Blo2Modified => _isDataData_Blo2Modified.Value;
        public ObjectProperty<float> DataScalingFactor => _dataScalingFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataScalingFactorModified => _isDataScalingFactorModified.Value;
        private float GetDataData_Blo1(int level)
        {
            return _modifications.GetModification(829385794, level).ValueAsFloat;
        }

        private void SetDataData_Blo1(int level, float value)
        {
            _modifications[829385794, level] = new LevelObjectDataModification{Id = 829385794, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataData_Blo1Modified(int level)
        {
            return _modifications.ContainsKey(829385794, level);
        }

        private float GetDataData_Blo2(int level)
        {
            return _modifications.GetModification(846163010, level).ValueAsFloat;
        }

        private void SetDataData_Blo2(int level, float value)
        {
            _modifications[846163010, level] = new LevelObjectDataModification{Id = 846163010, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_Blo2Modified(int level)
        {
            return _modifications.ContainsKey(846163010, level);
        }

        private float GetDataScalingFactor(int level)
        {
            return _modifications.GetModification(862940226, level).ValueAsFloat;
        }

        private void SetDataScalingFactor(int level, float value)
        {
            _modifications[862940226, level] = new LevelObjectDataModification{Id = 862940226, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataScalingFactorModified(int level)
        {
            return _modifications.ContainsKey(862940226, level);
        }
    }
}