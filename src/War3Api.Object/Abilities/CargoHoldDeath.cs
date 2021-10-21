using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CargoHoldDeath : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementUpdateFrequency;
        private readonly Lazy<ObjectProperty<float>> _dataAttackUpdateFrequency;
        private readonly Lazy<ObjectProperty<float>> _dataSummonedUnitDamage;
        public CargoHoldDeath(): base(1684562753)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public CargoHoldDeath(int newId): base(1684562753, newId)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public CargoHoldDeath(string newRawcode): base(1684562753, newRawcode)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public CargoHoldDeath(ObjectDatabase db): base(1684562753, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public CargoHoldDeath(int newId, ObjectDatabase db): base(1684562753, newId, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public CargoHoldDeath(string newRawcode, ObjectDatabase db): base(1684562753, newRawcode, db)
        {
            _dataMovementUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementUpdateFrequency, SetDataMovementUpdateFrequency));
            _dataAttackUpdateFrequency = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackUpdateFrequency, SetDataAttackUpdateFrequency));
            _dataSummonedUnitDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSummonedUnitDamage, SetDataSummonedUnitDamage));
        }

        public ObjectProperty<float> DataMovementUpdateFrequency => _dataMovementUpdateFrequency.Value;
        public ObjectProperty<float> DataAttackUpdateFrequency => _dataAttackUpdateFrequency.Value;
        public ObjectProperty<float> DataSummonedUnitDamage => _dataSummonedUnitDamage.Value;
        private float GetDataMovementUpdateFrequency(int level)
        {
            return _modifications[828663875, level].ValueAsFloat;
        }

        private void SetDataMovementUpdateFrequency(int level, float value)
        {
            _modifications[828663875, level] = new LevelObjectDataModification{Id = 828663875, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataAttackUpdateFrequency(int level)
        {
            return _modifications[845441091, level].ValueAsFloat;
        }

        private void SetDataAttackUpdateFrequency(int level, float value)
        {
            _modifications[845441091, level] = new LevelObjectDataModification{Id = 845441091, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataSummonedUnitDamage(int level)
        {
            return _modifications[862218307, level].ValueAsFloat;
        }

        private void SetDataSummonedUnitDamage(int level, float value)
        {
            _modifications[862218307, level] = new LevelObjectDataModification{Id = 862218307, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}