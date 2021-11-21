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
    public sealed class PurgeOrb : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMovementUpdateFrequency;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementUpdateFrequencyModified;
        private readonly Lazy<ObjectProperty<int>> _dataAttackUpdateFrequency;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackUpdateFrequencyModified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitDamageModified;
        private readonly Lazy<ObjectProperty<float>> _dataUnitPauseDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitPauseDurationModified;
        private readonly Lazy<ObjectProperty<float>> _dataHeroPauseDuration;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHeroPauseDurationModified;
        private readonly Lazy<ObjectProperty<int>> _dataManaLoss;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaLossModified;
        public PurgeOrb(): base(1735412033)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _isDataUnitPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitPauseDurationModified));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _isDataHeroPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroPauseDurationModified));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public PurgeOrb(int newId): base(1735412033, newId)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _isDataUnitPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitPauseDurationModified));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _isDataHeroPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroPauseDurationModified));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public PurgeOrb(string newRawcode): base(1735412033, newRawcode)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _isDataUnitPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitPauseDurationModified));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _isDataHeroPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroPauseDurationModified));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public PurgeOrb(ObjectDatabaseBase db): base(1735412033, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _isDataUnitPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitPauseDurationModified));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _isDataHeroPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroPauseDurationModified));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public PurgeOrb(int newId, ObjectDatabaseBase db): base(1735412033, newId, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _isDataUnitPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitPauseDurationModified));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _isDataHeroPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroPauseDurationModified));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public PurgeOrb(string newRawcode, ObjectDatabaseBase db): base(1735412033, newRawcode, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
            _dataUnitPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataUnitPauseDuration, SetDataUnitPauseDuration));
            _isDataUnitPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitPauseDurationModified));
            _dataHeroPauseDuration = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHeroPauseDuration, SetDataHeroPauseDuration));
            _isDataHeroPauseDurationModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHeroPauseDurationModified));
            _dataManaLoss = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataManaLoss, SetDataManaLoss));
            _isDataManaLossModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaLossModified));
        }

        public ObjectProperty<int> DataMovementUpdateFrequency => _dataMovementUpdateFrequency.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementUpdateFrequencyModified => _isDataMovementUpdateFrequencyModified.Value;
        public ObjectProperty<int> DataAttackUpdateFrequency => _dataAttackUpdateFrequency.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackUpdateFrequencyModified => _isDataAttackUpdateFrequencyModified.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitDamageModified => _isDataSummonedUnitDamageModified.Value;
        public ObjectProperty<float> DataUnitPauseDuration => _dataUnitPauseDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitPauseDurationModified => _isDataUnitPauseDurationModified.Value;
        public ObjectProperty<float> DataHeroPauseDuration => _dataHeroPauseDuration.Value;
        public ReadOnlyObjectProperty<bool> IsDataHeroPauseDurationModified => _isDataHeroPauseDurationModified.Value;
        public ObjectProperty<int> DataManaLoss => _dataManaLoss.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaLossModified => _isDataManaLossModified.Value;
        private int GetDataMovementUpdateFrequency(int level)
        {
            return _modifications.GetModification(828863056, level).ValueAsInt;
        }

        private void SetDataMovementUpdateFrequency(int level, int value)
        {
            _modifications[828863056, level] = new LevelObjectDataModification{Id = 828863056, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementUpdateFrequencyModified(int level)
        {
            return _modifications.ContainsKey(828863056, level);
        }

        private int GetDataAttackUpdateFrequency(int level)
        {
            return _modifications.GetModification(845640272, level).ValueAsInt;
        }

        private void SetDataAttackUpdateFrequency(int level, int value)
        {
            _modifications[845640272, level] = new LevelObjectDataModification{Id = 845640272, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAttackUpdateFrequencyModified(int level)
        {
            return _modifications.ContainsKey(845640272, level);
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications.GetModification(862417488, level).ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[862417488, level] = new LevelObjectDataModification{Id = 862417488, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSummonedUnitDamageModified(int level)
        {
            return _modifications.ContainsKey(862417488, level);
        }

        private float GetDataUnitPauseDuration(int level)
        {
            return _modifications.GetModification(879194704, level).ValueAsFloat;
        }

        private void SetDataUnitPauseDuration(int level, float value)
        {
            _modifications[879194704, level] = new LevelObjectDataModification{Id = 879194704, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataUnitPauseDurationModified(int level)
        {
            return _modifications.ContainsKey(879194704, level);
        }

        private float GetDataHeroPauseDuration(int level)
        {
            return _modifications.GetModification(895971920, level).ValueAsFloat;
        }

        private void SetDataHeroPauseDuration(int level, float value)
        {
            _modifications[895971920, level] = new LevelObjectDataModification{Id = 895971920, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataHeroPauseDurationModified(int level)
        {
            return _modifications.ContainsKey(895971920, level);
        }

        private int GetDataManaLoss(int level)
        {
            return _modifications.GetModification(912749136, level).ValueAsInt;
        }

        private void SetDataManaLoss(int level, int value)
        {
            _modifications[912749136, level] = new LevelObjectDataModification{Id = 912749136, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataManaLossModified(int level)
        {
            return _modifications.ContainsKey(912749136, level);
        }
    }
}