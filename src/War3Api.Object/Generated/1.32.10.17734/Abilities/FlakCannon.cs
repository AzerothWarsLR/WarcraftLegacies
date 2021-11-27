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
    public sealed class FlakCannon : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMediumDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSmallDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataMediumDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMediumDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataSmallDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSmallDamageAmountModified;
        public FlakCannon(): base(1802266177)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _isDataMediumDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageAmountModified));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
            _isDataSmallDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageAmountModified));
        }

        public FlakCannon(int newId): base(1802266177, newId)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _isDataMediumDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageAmountModified));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
            _isDataSmallDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageAmountModified));
        }

        public FlakCannon(string newRawcode): base(1802266177, newRawcode)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _isDataMediumDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageAmountModified));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
            _isDataSmallDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageAmountModified));
        }

        public FlakCannon(ObjectDatabaseBase db): base(1802266177, db)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _isDataMediumDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageAmountModified));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
            _isDataSmallDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageAmountModified));
        }

        public FlakCannon(int newId, ObjectDatabaseBase db): base(1802266177, newId, db)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _isDataMediumDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageAmountModified));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
            _isDataSmallDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageAmountModified));
        }

        public FlakCannon(string newRawcode, ObjectDatabaseBase db): base(1802266177, newRawcode, db)
        {
            _dataMediumDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageRadius, SetDataMediumDamageRadius));
            _isDataMediumDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageRadiusModified));
            _dataSmallDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageRadius, SetDataSmallDamageRadius));
            _isDataSmallDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataMediumDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMediumDamageAmount, SetDataMediumDamageAmount));
            _isDataMediumDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMediumDamageAmountModified));
            _dataSmallDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSmallDamageAmount, SetDataSmallDamageAmount));
            _isDataSmallDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSmallDamageAmountModified));
        }

        public ObjectProperty<float> DataMediumDamageRadius => _dataMediumDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataMediumDamageRadiusModified => _isDataMediumDamageRadiusModified.Value;
        public ObjectProperty<float> DataSmallDamageRadius => _dataSmallDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataSmallDamageRadiusModified => _isDataSmallDamageRadiusModified.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageAmountModified => _isDataFullDamageAmountModified.Value;
        public ObjectProperty<float> DataMediumDamageAmount => _dataMediumDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataMediumDamageAmountModified => _isDataMediumDamageAmountModified.Value;
        public ObjectProperty<float> DataSmallDamageAmount => _dataSmallDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataSmallDamageAmountModified => _isDataSmallDamageAmountModified.Value;
        private float GetDataMediumDamageRadius(int level)
        {
            return _modifications.GetModification(829123686, level).ValueAsFloat;
        }

        private void SetDataMediumDamageRadius(int level, float value)
        {
            _modifications[829123686, level] = new LevelObjectDataModification{Id = 829123686, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMediumDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(829123686, level);
        }

        private float GetDataSmallDamageRadius(int level)
        {
            return _modifications.GetModification(845900902, level).ValueAsFloat;
        }

        private void SetDataSmallDamageRadius(int level, float value)
        {
            _modifications[845900902, level] = new LevelObjectDataModification{Id = 845900902, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataSmallDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(845900902, level);
        }

        private float GetDataFullDamageAmount(int level)
        {
            return _modifications.GetModification(862678118, level).ValueAsFloat;
        }

        private void SetDataFullDamageAmount(int level, float value)
        {
            _modifications[862678118, level] = new LevelObjectDataModification{Id = 862678118, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataFullDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(862678118, level);
        }

        private float GetDataMediumDamageAmount(int level)
        {
            return _modifications.GetModification(879455334, level).ValueAsFloat;
        }

        private void SetDataMediumDamageAmount(int level, float value)
        {
            _modifications[879455334, level] = new LevelObjectDataModification{Id = 879455334, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataMediumDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(879455334, level);
        }

        private float GetDataSmallDamageAmount(int level)
        {
            return _modifications.GetModification(896232550, level).ValueAsFloat;
        }

        private void SetDataSmallDamageAmount(int level, float value)
        {
            _modifications[896232550, level] = new LevelObjectDataModification{Id = 896232550, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataSmallDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(896232550, level);
        }
    }
}