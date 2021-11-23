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
    public sealed class MountainKingThunderClap : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAOEDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAOEDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataSpecificTargetDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpecificTargetDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Htc3;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Htc3Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Htc4;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Htc4Modified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumDamageModified;
        public MountainKingThunderClap(): base(1668565057)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataData_Htc3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc3, SetDataData_Htc3));
            _isDataData_Htc3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc3Modified));
            _dataData_Htc4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc4, SetDataData_Htc4));
            _isDataData_Htc4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc4Modified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public MountainKingThunderClap(int newId): base(1668565057, newId)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataData_Htc3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc3, SetDataData_Htc3));
            _isDataData_Htc3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc3Modified));
            _dataData_Htc4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc4, SetDataData_Htc4));
            _isDataData_Htc4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc4Modified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public MountainKingThunderClap(string newRawcode): base(1668565057, newRawcode)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataData_Htc3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc3, SetDataData_Htc3));
            _isDataData_Htc3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc3Modified));
            _dataData_Htc4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc4, SetDataData_Htc4));
            _isDataData_Htc4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc4Modified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public MountainKingThunderClap(ObjectDatabaseBase db): base(1668565057, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataData_Htc3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc3, SetDataData_Htc3));
            _isDataData_Htc3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc3Modified));
            _dataData_Htc4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc4, SetDataData_Htc4));
            _isDataData_Htc4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc4Modified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public MountainKingThunderClap(int newId, ObjectDatabaseBase db): base(1668565057, newId, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataData_Htc3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc3, SetDataData_Htc3));
            _isDataData_Htc3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc3Modified));
            _dataData_Htc4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc4, SetDataData_Htc4));
            _isDataData_Htc4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc4Modified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public MountainKingThunderClap(string newRawcode, ObjectDatabaseBase db): base(1668565057, newRawcode, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _isDataAOEDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAOEDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataData_Htc3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc3, SetDataData_Htc3));
            _isDataData_Htc3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc3Modified));
            _dataData_Htc4 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Htc4, SetDataData_Htc4));
            _isDataData_Htc4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Htc4Modified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public ObjectProperty<float> DataAOEDamage => _dataAOEDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataAOEDamageModified => _isDataAOEDamageModified.Value;
        public ObjectProperty<float> DataSpecificTargetDamage => _dataSpecificTargetDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpecificTargetDamageModified => _isDataSpecificTargetDamageModified.Value;
        public ObjectProperty<float> DataData_Htc3 => _dataData_Htc3.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Htc3Modified => _isDataData_Htc3Modified.Value;
        public ObjectProperty<float> DataData_Htc4 => _dataData_Htc4.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Htc4Modified => _isDataData_Htc4Modified.Value;
        public ObjectProperty<float> DataMaximumDamage => _dataMaximumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumDamageModified => _isDataMaximumDamageModified.Value;
        private float GetDataAOEDamage(int level)
        {
            return _modifications.GetModification(828601416, level).ValueAsFloat;
        }

        private void SetDataAOEDamage(int level, float value)
        {
            _modifications[828601416, level] = new LevelObjectDataModification{Id = 828601416, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAOEDamageModified(int level)
        {
            return _modifications.ContainsKey(828601416, level);
        }

        private float GetDataSpecificTargetDamage(int level)
        {
            return _modifications.GetModification(845378632, level).ValueAsFloat;
        }

        private void SetDataSpecificTargetDamage(int level, float value)
        {
            _modifications[845378632, level] = new LevelObjectDataModification{Id = 845378632, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSpecificTargetDamageModified(int level)
        {
            return _modifications.ContainsKey(845378632, level);
        }

        private float GetDataData_Htc3(int level)
        {
            return _modifications.GetModification(862155848, level).ValueAsFloat;
        }

        private void SetDataData_Htc3(int level, float value)
        {
            _modifications[862155848, level] = new LevelObjectDataModification{Id = 862155848, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataData_Htc3Modified(int level)
        {
            return _modifications.ContainsKey(862155848, level);
        }

        private float GetDataData_Htc4(int level)
        {
            return _modifications.GetModification(878933064, level).ValueAsFloat;
        }

        private void SetDataData_Htc4(int level, float value)
        {
            _modifications[878933064, level] = new LevelObjectDataModification{Id = 878933064, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataData_Htc4Modified(int level)
        {
            return _modifications.ContainsKey(878933064, level);
        }

        private float GetDataMaximumDamage(int level)
        {
            return _modifications.GetModification(895710280, level).ValueAsFloat;
        }

        private void SetDataMaximumDamage(int level, float value)
        {
            _modifications[895710280, level] = new LevelObjectDataModification{Id = 895710280, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMaximumDamageModified(int level)
        {
            return _modifications.ContainsKey(895710280, level);
        }
    }
}