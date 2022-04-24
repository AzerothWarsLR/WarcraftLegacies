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
    public sealed class SelfDestruct : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataPartialDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartialDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataPartialDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPartialDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingDamageFactorModified;
        private readonly Lazy<ObjectProperty<int>> _dataExplodesOnDeathRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExplodesOnDeathModified;
        private readonly Lazy<ObjectProperty<bool>> _dataExplodesOnDeath;
        public SelfDestruct(): base(1935962945)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestruct(int newId): base(1935962945, newId)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestruct(string newRawcode): base(1935962945, newRawcode)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestruct(ObjectDatabaseBase db): base(1935962945, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestruct(int newId, ObjectDatabaseBase db): base(1935962945, newId, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestruct(string newRawcode, ObjectDatabaseBase db): base(1935962945, newRawcode, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _isDataFullDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageRadiusModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _isDataPartialDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageRadiusModified));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
            _isDataPartialDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPartialDamageAmountModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataExplodesOnDeathRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExplodesOnDeathRaw, SetDataExplodesOnDeathRaw));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageRadiusModified => _isDataFullDamageRadiusModified.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageAmountModified => _isDataFullDamageAmountModified.Value;
        public ObjectProperty<float> DataPartialDamageRadius => _dataPartialDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartialDamageRadiusModified => _isDataPartialDamageRadiusModified.Value;
        public ObjectProperty<float> DataPartialDamageAmount => _dataPartialDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataPartialDamageAmountModified => _isDataPartialDamageAmountModified.Value;
        public ObjectProperty<float> DataBuildingDamageFactor => _dataBuildingDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingDamageFactorModified => _isDataBuildingDamageFactorModified.Value;
        public ObjectProperty<int> DataExplodesOnDeathRaw => _dataExplodesOnDeathRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataExplodesOnDeathModified => _isDataExplodesOnDeathModified.Value;
        public ObjectProperty<bool> DataExplodesOnDeath => _dataExplodesOnDeath.Value;
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

        private float GetDataBuildingDamageFactor(int level)
        {
            return _modifications.GetModification(829645907, level).ValueAsFloat;
        }

        private void SetDataBuildingDamageFactor(int level, float value)
        {
            _modifications[829645907, level] = new LevelObjectDataModification{Id = 829645907, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataBuildingDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(829645907, level);
        }

        private int GetDataExplodesOnDeathRaw(int level)
        {
            return _modifications.GetModification(913531987, level).ValueAsInt;
        }

        private void SetDataExplodesOnDeathRaw(int level, int value)
        {
            _modifications[913531987, level] = new LevelObjectDataModification{Id = 913531987, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataExplodesOnDeathModified(int level)
        {
            return _modifications.ContainsKey(913531987, level);
        }

        private bool GetDataExplodesOnDeath(int level)
        {
            return GetDataExplodesOnDeathRaw(level).ToBool(this);
        }

        private void SetDataExplodesOnDeath(int level, bool value)
        {
            SetDataExplodesOnDeathRaw(level, value.ToRaw(0, 1));
        }
    }
}