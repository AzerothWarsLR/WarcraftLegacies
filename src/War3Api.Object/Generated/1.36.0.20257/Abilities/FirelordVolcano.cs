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
    public sealed class FirelordVolcano : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataRockRingCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRockRingCountModified;
        private readonly Lazy<ObjectProperty<int>> _dataWaveCount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWaveCountModified;
        private readonly Lazy<ObjectProperty<float>> _dataWaveInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataWaveIntervalModified;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBuildingDamageFactorModified;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataFullDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageFactor;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHalfDamageFactorModified;
        private readonly Lazy<ObjectProperty<string>> _dataDestructibleIDRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDestructibleIDModified;
        private readonly Lazy<ObjectProperty<Unit>> _dataDestructibleID;
        public FirelordVolcano(): base(1668697665)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _isDataRockRingCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRockRingCountModified));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _isDataWaveIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveIntervalModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _isDataHalfDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageFactorModified));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _isDataDestructibleIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDestructibleIDModified));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(int newId): base(1668697665, newId)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _isDataRockRingCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRockRingCountModified));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _isDataWaveIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveIntervalModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _isDataHalfDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageFactorModified));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _isDataDestructibleIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDestructibleIDModified));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(string newRawcode): base(1668697665, newRawcode)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _isDataRockRingCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRockRingCountModified));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _isDataWaveIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveIntervalModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _isDataHalfDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageFactorModified));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _isDataDestructibleIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDestructibleIDModified));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(ObjectDatabaseBase db): base(1668697665, db)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _isDataRockRingCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRockRingCountModified));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _isDataWaveIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveIntervalModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _isDataHalfDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageFactorModified));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _isDataDestructibleIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDestructibleIDModified));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(int newId, ObjectDatabaseBase db): base(1668697665, newId, db)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _isDataRockRingCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRockRingCountModified));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _isDataWaveIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveIntervalModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _isDataHalfDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageFactorModified));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _isDataDestructibleIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDestructibleIDModified));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(string newRawcode, ObjectDatabaseBase db): base(1668697665, newRawcode, db)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _isDataRockRingCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRockRingCountModified));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _isDataWaveCountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveCountModified));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _isDataWaveIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataWaveIntervalModified));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _isDataBuildingDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBuildingDamageFactorModified));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _isDataFullDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataFullDamageAmountModified));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _isDataHalfDamageFactorModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHalfDamageFactorModified));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _isDataDestructibleIDModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDestructibleIDModified));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public ObjectProperty<int> DataRockRingCount => _dataRockRingCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataRockRingCountModified => _isDataRockRingCountModified.Value;
        public ObjectProperty<int> DataWaveCount => _dataWaveCount.Value;
        public ReadOnlyObjectProperty<bool> IsDataWaveCountModified => _isDataWaveCountModified.Value;
        public ObjectProperty<float> DataWaveInterval => _dataWaveInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataWaveIntervalModified => _isDataWaveIntervalModified.Value;
        public ObjectProperty<float> DataBuildingDamageFactor => _dataBuildingDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataBuildingDamageFactorModified => _isDataBuildingDamageFactorModified.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataFullDamageAmountModified => _isDataFullDamageAmountModified.Value;
        public ObjectProperty<float> DataHalfDamageFactor => _dataHalfDamageFactor.Value;
        public ReadOnlyObjectProperty<bool> IsDataHalfDamageFactorModified => _isDataHalfDamageFactorModified.Value;
        public ObjectProperty<string> DataDestructibleIDRaw => _dataDestructibleIDRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDestructibleIDModified => _isDataDestructibleIDModified.Value;
        public ObjectProperty<Unit> DataDestructibleID => _dataDestructibleID.Value;
        private int GetDataRockRingCount(int level)
        {
            return _modifications.GetModification(828601934, level).ValueAsInt;
        }

        private void SetDataRockRingCount(int level, int value)
        {
            _modifications[828601934, level] = new LevelObjectDataModification{Id = 828601934, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataRockRingCountModified(int level)
        {
            return _modifications.ContainsKey(828601934, level);
        }

        private int GetDataWaveCount(int level)
        {
            return _modifications.GetModification(845379150, level).ValueAsInt;
        }

        private void SetDataWaveCount(int level, int value)
        {
            _modifications[845379150, level] = new LevelObjectDataModification{Id = 845379150, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataWaveCountModified(int level)
        {
            return _modifications.ContainsKey(845379150, level);
        }

        private float GetDataWaveInterval(int level)
        {
            return _modifications.GetModification(862156366, level).ValueAsFloat;
        }

        private void SetDataWaveInterval(int level, float value)
        {
            _modifications[862156366, level] = new LevelObjectDataModification{Id = 862156366, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataWaveIntervalModified(int level)
        {
            return _modifications.ContainsKey(862156366, level);
        }

        private float GetDataBuildingDamageFactor(int level)
        {
            return _modifications.GetModification(878933582, level).ValueAsFloat;
        }

        private void SetDataBuildingDamageFactor(int level, float value)
        {
            _modifications[878933582, level] = new LevelObjectDataModification{Id = 878933582, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataBuildingDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(878933582, level);
        }

        private float GetDataFullDamageAmount(int level)
        {
            return _modifications.GetModification(895710798, level).ValueAsFloat;
        }

        private void SetDataFullDamageAmount(int level, float value)
        {
            _modifications[895710798, level] = new LevelObjectDataModification{Id = 895710798, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataFullDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(895710798, level);
        }

        private float GetDataHalfDamageFactor(int level)
        {
            return _modifications.GetModification(912488014, level).ValueAsFloat;
        }

        private void SetDataHalfDamageFactor(int level, float value)
        {
            _modifications[912488014, level] = new LevelObjectDataModification{Id = 912488014, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataHalfDamageFactorModified(int level)
        {
            return _modifications.ContainsKey(912488014, level);
        }

        private string GetDataDestructibleIDRaw(int level)
        {
            return _modifications.GetModification(1969452622, level).ValueAsString;
        }

        private void SetDataDestructibleIDRaw(int level, string value)
        {
            _modifications[1969452622, level] = new LevelObjectDataModification{Id = 1969452622, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataDestructibleIDModified(int level)
        {
            return _modifications.ContainsKey(1969452622, level);
        }

        private Unit GetDataDestructibleID(int level)
        {
            return GetDataDestructibleIDRaw(level).ToUnit(this);
        }

        private void SetDataDestructibleID(int level, Unit value)
        {
            SetDataDestructibleIDRaw(level, value.ToRaw(null, null));
        }
    }
}