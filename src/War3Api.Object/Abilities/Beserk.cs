using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Beserk : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedIncrease;
        private readonly Lazy<ObjectProperty<float>> _dataDamageTakenIncrease;
        public Beserk(): base(1802723905)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
        }

        public Beserk(int newId): base(1802723905, newId)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
        }

        public Beserk(string newRawcode): base(1802723905, newRawcode)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
        }

        public Beserk(ObjectDatabase db): base(1802723905, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
        }

        public Beserk(int newId, ObjectDatabase db): base(1802723905, newId, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
        }

        public Beserk(string newRawcode, ObjectDatabase db): base(1802723905, newRawcode, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
        }

        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ObjectProperty<float> DataAttackSpeedIncrease => _dataAttackSpeedIncrease.Value;
        public ObjectProperty<float> DataDamageTakenIncrease => _dataDamageTakenIncrease.Value;
        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications[829125474, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedIncrease(int level, float value)
        {
            _modifications[829125474, level] = new LevelObjectDataModification{Id = 829125474, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataAttackSpeedIncrease(int level)
        {
            return _modifications[845902690, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedIncrease(int level, float value)
        {
            _modifications[845902690, level] = new LevelObjectDataModification{Id = 845902690, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageTakenIncrease(int level)
        {
            return _modifications[862679906, level].ValueAsFloat;
        }

        private void SetDataDamageTakenIncrease(int level, float value)
        {
            _modifications[862679906, level] = new LevelObjectDataModification{Id = 862679906, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}