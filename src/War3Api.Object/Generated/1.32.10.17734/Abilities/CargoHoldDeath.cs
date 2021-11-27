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
    public sealed class CargoHoldDeath : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementUpdateFrequency;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementUpdateFrequencyModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackUpdateFrequency;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackUpdateFrequencyModified;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSummonedUnitDamageModified;
        public CargoHoldDeath(): base(1684562753)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
        }

        public CargoHoldDeath(int newId): base(1684562753, newId)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
        }

        public CargoHoldDeath(string newRawcode): base(1684562753, newRawcode)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
        }

        public CargoHoldDeath(ObjectDatabaseBase db): base(1684562753, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
        }

        public CargoHoldDeath(int newId, ObjectDatabaseBase db): base(1684562753, newId, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
        }

        public CargoHoldDeath(string newRawcode, ObjectDatabaseBase db): base(1684562753, newRawcode, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _isDataMovementUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementUpdateFrequencyModified));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _isDataAttackUpdateFrequencyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackUpdateFrequencyModified));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
            _isDataSummonedUnitDamageModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSummonedUnitDamageModified));
        }

        public ObjectProperty<float> DataMovementUpdateFrequency => _dataMovementUpdateFrequency.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementUpdateFrequencyModified => _isDataMovementUpdateFrequencyModified.Value;
        public ObjectProperty<float> DataAttackUpdateFrequency => _dataAttackUpdateFrequency.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackUpdateFrequencyModified => _isDataAttackUpdateFrequencyModified.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        public ReadOnlyObjectProperty<bool> IsDataSummonedUnitDamageModified => _isDataSummonedUnitDamageModified.Value;
        private float GetDataMovementUpdateFrequency(int level)
        {
            return _modifications.GetModification(828663875, level).ValueAsFloat;
        }

        private void SetDataMovementUpdateFrequency(int level, float value)
        {
            _modifications[828663875, level] = new LevelObjectDataModification{Id = 828663875, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementUpdateFrequencyModified(int level)
        {
            return _modifications.ContainsKey(828663875, level);
        }

        private float GetDataAttackUpdateFrequency(int level)
        {
            return _modifications.GetModification(845441091, level).ValueAsFloat;
        }

        private void SetDataAttackUpdateFrequency(int level, float value)
        {
            _modifications[845441091, level] = new LevelObjectDataModification{Id = 845441091, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAttackUpdateFrequencyModified(int level)
        {
            return _modifications.ContainsKey(845441091, level);
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications.GetModification(862218307, level).ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[862218307, level] = new LevelObjectDataModification{Id = 862218307, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataSummonedUnitDamageModified(int level)
        {
            return _modifications.ContainsKey(862218307, level);
        }
    }
}