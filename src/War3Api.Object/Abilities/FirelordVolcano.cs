using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FirelordVolcano : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataRockRingCount;
        private readonly Lazy<ObjectProperty<int>> _dataWaveCount;
        private readonly Lazy<ObjectProperty<float>> _dataWaveInterval;
        private readonly Lazy<ObjectProperty<float>> _dataBuildingDamageFactor;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataHalfDamageFactor;
        private readonly Lazy<ObjectProperty<string>> _dataDestructibleIDRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataDestructibleID;
        public FirelordVolcano(): base(1668697665)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(int newId): base(1668697665, newId)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(string newRawcode): base(1668697665, newRawcode)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(ObjectDatabase db): base(1668697665, db)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(int newId, ObjectDatabase db): base(1668697665, newId, db)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public FirelordVolcano(string newRawcode, ObjectDatabase db): base(1668697665, newRawcode, db)
        {
            _dataRockRingCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRockRingCount, SetDataRockRingCount));
            _dataWaveCount = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataWaveCount, SetDataWaveCount));
            _dataWaveInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataWaveInterval, SetDataWaveInterval));
            _dataBuildingDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBuildingDamageFactor, SetDataBuildingDamageFactor));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataHalfDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHalfDamageFactor, SetDataHalfDamageFactor));
            _dataDestructibleIDRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataDestructibleIDRaw, SetDataDestructibleIDRaw));
            _dataDestructibleID = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataDestructibleID, SetDataDestructibleID));
        }

        public ObjectProperty<int> DataRockRingCount => _dataRockRingCount.Value;
        public ObjectProperty<int> DataWaveCount => _dataWaveCount.Value;
        public ObjectProperty<float> DataWaveInterval => _dataWaveInterval.Value;
        public ObjectProperty<float> DataBuildingDamageFactor => _dataBuildingDamageFactor.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ObjectProperty<float> DataHalfDamageFactor => _dataHalfDamageFactor.Value;
        public ObjectProperty<string> DataDestructibleIDRaw => _dataDestructibleIDRaw.Value;
        public ObjectProperty<Unit> DataDestructibleID => _dataDestructibleID.Value;
        private int GetDataRockRingCount(int level)
        {
            return _modifications[828601934, level].ValueAsInt;
        }

        private void SetDataRockRingCount(int level, int value)
        {
            _modifications[828601934, level] = new LevelObjectDataModification{Id = 828601934, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataWaveCount(int level)
        {
            return _modifications[845379150, level].ValueAsInt;
        }

        private void SetDataWaveCount(int level, int value)
        {
            _modifications[845379150, level] = new LevelObjectDataModification{Id = 845379150, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataWaveInterval(int level)
        {
            return _modifications[862156366, level].ValueAsFloat;
        }

        private void SetDataWaveInterval(int level, float value)
        {
            _modifications[862156366, level] = new LevelObjectDataModification{Id = 862156366, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataBuildingDamageFactor(int level)
        {
            return _modifications[878933582, level].ValueAsFloat;
        }

        private void SetDataBuildingDamageFactor(int level, float value)
        {
            _modifications[878933582, level] = new LevelObjectDataModification{Id = 878933582, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataFullDamageAmount(int level)
        {
            return _modifications[895710798, level].ValueAsFloat;
        }

        private void SetDataFullDamageAmount(int level, float value)
        {
            _modifications[895710798, level] = new LevelObjectDataModification{Id = 895710798, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private float GetDataHalfDamageFactor(int level)
        {
            return _modifications[912488014, level].ValueAsFloat;
        }

        private void SetDataHalfDamageFactor(int level, float value)
        {
            _modifications[912488014, level] = new LevelObjectDataModification{Id = 912488014, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 6};
        }

        private string GetDataDestructibleIDRaw(int level)
        {
            return _modifications[1969452622, level].ValueAsString;
        }

        private void SetDataDestructibleIDRaw(int level, string value)
        {
            _modifications[1969452622, level] = new LevelObjectDataModification{Id = 1969452622, Type = ObjectDataType.String, Value = value, Level = level};
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