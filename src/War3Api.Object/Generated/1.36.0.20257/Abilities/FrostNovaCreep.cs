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
    public sealed class FrostNovaCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAreaOfEffectDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAreaOfEffectDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataSpecificTargetDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSpecificTargetDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumDamageModified;
        public FrostNovaCreep(): base(1852195649)
        {
            _dataAreaOfEffectDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAreaOfEffectDamage, SetDataAreaOfEffectDamage));
            _isDataAreaOfEffectDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAreaOfEffectDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FrostNovaCreep(int newId): base(1852195649, newId)
        {
            _dataAreaOfEffectDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAreaOfEffectDamage, SetDataAreaOfEffectDamage));
            _isDataAreaOfEffectDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAreaOfEffectDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FrostNovaCreep(string newRawcode): base(1852195649, newRawcode)
        {
            _dataAreaOfEffectDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAreaOfEffectDamage, SetDataAreaOfEffectDamage));
            _isDataAreaOfEffectDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAreaOfEffectDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FrostNovaCreep(ObjectDatabaseBase db): base(1852195649, db)
        {
            _dataAreaOfEffectDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAreaOfEffectDamage, SetDataAreaOfEffectDamage));
            _isDataAreaOfEffectDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAreaOfEffectDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FrostNovaCreep(int newId, ObjectDatabaseBase db): base(1852195649, newId, db)
        {
            _dataAreaOfEffectDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAreaOfEffectDamage, SetDataAreaOfEffectDamage));
            _isDataAreaOfEffectDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAreaOfEffectDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public FrostNovaCreep(string newRawcode, ObjectDatabaseBase db): base(1852195649, newRawcode, db)
        {
            _dataAreaOfEffectDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAreaOfEffectDamage, SetDataAreaOfEffectDamage));
            _isDataAreaOfEffectDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAreaOfEffectDamageModified));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _isDataSpecificTargetDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSpecificTargetDamageModified));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
            _isDataMaximumDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumDamageModified));
        }

        public ObjectProperty<float> DataAreaOfEffectDamage => _dataAreaOfEffectDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataAreaOfEffectDamageModified => _isDataAreaOfEffectDamageModified.Value;
        public ObjectProperty<float> DataSpecificTargetDamage => _dataSpecificTargetDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSpecificTargetDamageModified => _isDataSpecificTargetDamageModified.Value;
        public ObjectProperty<float> DataMaximumDamage => _dataMaximumDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumDamageModified => _isDataMaximumDamageModified.Value;
        private float GetDataAreaOfEffectDamage(int level)
        {
            return _modifications.GetModification(829318741, level).ValueAsFloat;
        }

        private void SetDataAreaOfEffectDamage(int level, float value)
        {
            _modifications[829318741, level] = new LevelObjectDataModification{Id = 829318741, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAreaOfEffectDamageModified(int level)
        {
            return _modifications.ContainsKey(829318741, level);
        }

        private float GetDataSpecificTargetDamage(int level)
        {
            return _modifications.GetModification(846095957, level).ValueAsFloat;
        }

        private void SetDataSpecificTargetDamage(int level, float value)
        {
            _modifications[846095957, level] = new LevelObjectDataModification{Id = 846095957, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSpecificTargetDamageModified(int level)
        {
            return _modifications.ContainsKey(846095957, level);
        }

        private float GetDataMaximumDamage(int level)
        {
            return _modifications.GetModification(896427605, level).ValueAsFloat;
        }

        private void SetDataMaximumDamage(int level, float value)
        {
            _modifications[896427605, level] = new LevelObjectDataModification{Id = 896427605, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMaximumDamageModified(int level)
        {
            return _modifications.ContainsKey(896427605, level);
        }
    }
}