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
    public sealed class UnstableConcoction : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataPartialDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartialDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataPartialDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartialDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataMaxDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataMoveSpeedBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMoveSpeedBonusModified;
        public UnstableConcoction(): base(1868789057)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
        }

        public UnstableConcoction(int newId): base(1868789057, newId)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
        }

        public UnstableConcoction(string newRawcode): base(1868789057, newRawcode)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
        }

        public UnstableConcoction(ObjectDatabaseBase db): base(1868789057, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
        }

        public UnstableConcoction(int newId, ObjectDatabaseBase db): base(1868789057, newId, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
        }

        public UnstableConcoction(string newRawcode, ObjectDatabaseBase db): base(1868789057, newRawcode, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataMaxDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaxDamage, SetDataMaxDamage));
            _isDataMaxDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxDamageModified));
            _dataMoveSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMoveSpeedBonus, SetDataMoveSpeedBonus));
            _isDataMoveSpeedBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMoveSpeedBonusModified));
        }

        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageRadiusModified => _isDataFullDamageRadiusModified.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageAmountModified => _isDataFullDamageAmountModified.Value;
        public ObjectProperty<float> DataPartialDamageRadius => _dataPartialDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartialDamageRadiusModified => _isDataPartialDamageRadiusModified.Value;
        public ObjectProperty<float> DataPartialDamageAmount => _dataPartialDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartialDamageAmountModified => _isDataPartialDamageAmountModified.Value;
        public ObjectProperty<float> DataMaxDamage => _dataMaxDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxDamageModified => _isDataMaxDamageModified.Value;
        public ObjectProperty<float> DataMoveSpeedBonus => _dataMoveSpeedBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataMoveSpeedBonusModified => _isDataMoveSpeedBonusModified.Value;
        private float GetDataFullDamageRadius(int level)
        {
            return _modifications.GetModification(828466244, level).ValueAsFloat;
        }

        private void SetDataFullDamageRadius(int level, float value)
        {
            _modifications[828466244, level] = new LevelObjectDataModification{Id = 828466244, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataFullDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(828466244, level);
        }

        private float GetDataFullDamageAmount(int level)
        {
            return _modifications.GetModification(845243460, level).ValueAsFloat;
        }

        private void SetDataFullDamageAmount(int level, float value)
        {
            _modifications[845243460, level] = new LevelObjectDataModification{Id = 845243460, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataFullDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(845243460, level);
        }

        private float GetDataPartialDamageRadius(int level)
        {
            return _modifications.GetModification(862020676, level).ValueAsFloat;
        }

        private void SetDataPartialDamageRadius(int level, float value)
        {
            _modifications[862020676, level] = new LevelObjectDataModification{Id = 862020676, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataPartialDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(862020676, level);
        }

        private float GetDataPartialDamageAmount(int level)
        {
            return _modifications.GetModification(878797892, level).ValueAsFloat;
        }

        private void SetDataPartialDamageAmount(int level, float value)
        {
            _modifications[878797892, level] = new LevelObjectDataModification{Id = 878797892, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataPartialDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(878797892, level);
        }

        private float GetDataMaxDamage(int level)
        {
            return _modifications.GetModification(896492373, level).ValueAsFloat;
        }

        private void SetDataMaxDamage(int level, float value)
        {
            _modifications[896492373, level] = new LevelObjectDataModification{Id = 896492373, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMaxDamageModified(int level)
        {
            return _modifications.ContainsKey(896492373, level);
        }

        private float GetDataMoveSpeedBonus(int level)
        {
            return _modifications.GetModification(913269589, level).ValueAsFloat;
        }

        private void SetDataMoveSpeedBonus(int level, float value)
        {
            _modifications[913269589, level] = new LevelObjectDataModification{Id = 913269589, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataMoveSpeedBonusModified(int level)
        {
            return _modifications.ContainsKey(913269589, level);
        }
    }
}