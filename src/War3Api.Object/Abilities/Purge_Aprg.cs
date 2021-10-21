using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Purge_Aprg : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMovementUpdateFrequency;
        private readonly Lazy<ObjectProperty<int>> _dataAttackUpdateFrequency;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ObjectProperty<float>> _dataUnitPauseDuration;
        private readonly Lazy<ObjectProperty<float>> _dataHeroPauseDuration;
        private readonly Lazy<ObjectProperty<int>> _dataManaLoss;
        public Purge_Aprg(): base(1735553089)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public Purge_Aprg(int newId): base(1735553089, newId)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public Purge_Aprg(string newRawcode): base(1735553089, newRawcode)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public Purge_Aprg(ObjectDatabase db): base(1735553089, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public Purge_Aprg(int newId, ObjectDatabase db): base(1735553089, newId, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public Purge_Aprg(string newRawcode, ObjectDatabase db): base(1735553089, newRawcode, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
        }

        public ObjectProperty<int> DataMovementUpdateFrequency => _dataMovementUpdateFrequency.Value;
        public ObjectProperty<int> DataAttackUpdateFrequency => _dataAttackUpdateFrequency.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ObjectProperty<float> DataUnitPauseDuration => _dataUnitPauseDuration.Value;
        public ObjectProperty<float> DataHeroPauseDuration => _dataHeroPauseDuration.Value;
        public ObjectProperty<int> DataManaLoss => _dataManaLoss.Value;
        private int GetDataMovementUpdateFrequency(int level)
        {
            return _modifications[828863056, level].ValueAsInt;
        }

        private void SetDataMovementUpdateFrequency(int level, int value)
        {
            _modifications[828863056, level] = new LevelObjectDataModification{Id = 828863056, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataAttackUpdateFrequency(int level)
        {
            return _modifications[845640272, level].ValueAsInt;
        }

        private void SetDataAttackUpdateFrequency(int level, int value)
        {
            _modifications[845640272, level] = new LevelObjectDataModification{Id = 845640272, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications[862417488, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[862417488, level] = new LevelObjectDataModification{Id = 862417488, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataUnitPauseDuration(int level)
        {
            return _modifications[879194704, level].ValueAsFloat;
        }

        private void SetDataUnitPauseDuration(int level, float value)
        {
            _modifications[879194704, level] = new LevelObjectDataModification{Id = 879194704, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataHeroPauseDuration(int level)
        {
            return _modifications[895971920, level].ValueAsFloat;
        }

        private void SetDataHeroPauseDuration(int level, float value)
        {
            _modifications[895971920, level] = new LevelObjectDataModification{Id = 895971920, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private int GetDataManaLoss(int level)
        {
            return _modifications[912749136, level].ValueAsInt;
        }

        private void SetDataManaLoss(int level, int value)
        {
            _modifications[912749136, level] = new LevelObjectDataModification{Id = 912749136, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }
    }
}