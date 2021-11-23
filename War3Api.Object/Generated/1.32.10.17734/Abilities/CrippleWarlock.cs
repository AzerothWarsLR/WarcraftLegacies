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
    public sealed class CrippleWarlock : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataData_Cri1;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Cri1Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Cri2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Cri2Modified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageReduction;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageReductionModified;
        public CrippleWarlock(): base(1769104211)
        {
            _dataData_Cri1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri1, SetDataData_Cri1));
            _isDataData_Cri1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri1Modified));
            _dataData_Cri2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri2, SetDataData_Cri2));
            _isDataData_Cri2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri2Modified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleWarlock(int newId): base(1769104211, newId)
        {
            _dataData_Cri1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri1, SetDataData_Cri1));
            _isDataData_Cri1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri1Modified));
            _dataData_Cri2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri2, SetDataData_Cri2));
            _isDataData_Cri2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri2Modified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleWarlock(string newRawcode): base(1769104211, newRawcode)
        {
            _dataData_Cri1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri1, SetDataData_Cri1));
            _isDataData_Cri1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri1Modified));
            _dataData_Cri2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri2, SetDataData_Cri2));
            _isDataData_Cri2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri2Modified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleWarlock(ObjectDatabaseBase db): base(1769104211, db)
        {
            _dataData_Cri1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri1, SetDataData_Cri1));
            _isDataData_Cri1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri1Modified));
            _dataData_Cri2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri2, SetDataData_Cri2));
            _isDataData_Cri2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri2Modified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleWarlock(int newId, ObjectDatabaseBase db): base(1769104211, newId, db)
        {
            _dataData_Cri1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri1, SetDataData_Cri1));
            _isDataData_Cri1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri1Modified));
            _dataData_Cri2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri2, SetDataData_Cri2));
            _isDataData_Cri2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri2Modified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public CrippleWarlock(string newRawcode, ObjectDatabaseBase db): base(1769104211, newRawcode, db)
        {
            _dataData_Cri1 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri1, SetDataData_Cri1));
            _isDataData_Cri1Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri1Modified));
            _dataData_Cri2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Cri2, SetDataData_Cri2));
            _isDataData_Cri2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Cri2Modified));
            _dataDamageReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageReduction, SetDataDamageReduction));
            _isDataDamageReductionModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageReductionModified));
        }

        public ObjectProperty<float> DataData_Cri1 => _dataData_Cri1.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Cri1Modified => _isDataData_Cri1Modified.Value;
        public ObjectProperty<float> DataData_Cri2 => _dataData_Cri2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Cri2Modified => _isDataData_Cri2Modified.Value;
        public ObjectProperty<float> DataDamageReduction => _dataDamageReduction.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageReductionModified => _isDataDamageReductionModified.Value;
        private float GetDataData_Cri1(int level)
        {
            return _modifications.GetModification(828994115, level).ValueAsFloat;
        }

        private void SetDataData_Cri1(int level, float value)
        {
            _modifications[828994115, level] = new LevelObjectDataModification{Id = 828994115, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataData_Cri1Modified(int level)
        {
            return _modifications.ContainsKey(828994115, level);
        }

        private float GetDataData_Cri2(int level)
        {
            return _modifications.GetModification(845771331, level).ValueAsFloat;
        }

        private void SetDataData_Cri2(int level, float value)
        {
            _modifications[845771331, level] = new LevelObjectDataModification{Id = 845771331, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_Cri2Modified(int level)
        {
            return _modifications.ContainsKey(845771331, level);
        }

        private float GetDataDamageReduction(int level)
        {
            return _modifications.GetModification(862548547, level).ValueAsFloat;
        }

        private void SetDataDamageReduction(int level, float value)
        {
            _modifications[862548547, level] = new LevelObjectDataModification{Id = 862548547, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageReductionModified(int level)
        {
            return _modifications.ContainsKey(862548547, level);
        }
    }
}