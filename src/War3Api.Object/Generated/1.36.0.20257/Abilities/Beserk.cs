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
    public sealed class Beserk : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedIncreaseModified;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedIncreaseModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageTakenIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageTakenIncreaseModified;
        public Beserk(): base(1802723905)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
            _isDataDamageTakenIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenIncreaseModified));
        }

        public Beserk(int newId): base(1802723905, newId)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
            _isDataDamageTakenIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenIncreaseModified));
        }

        public Beserk(string newRawcode): base(1802723905, newRawcode)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
            _isDataDamageTakenIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenIncreaseModified));
        }

        public Beserk(ObjectDatabaseBase db): base(1802723905, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
            _isDataDamageTakenIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenIncreaseModified));
        }

        public Beserk(int newId, ObjectDatabaseBase db): base(1802723905, newId, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
            _isDataDamageTakenIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenIncreaseModified));
        }

        public Beserk(string newRawcode, ObjectDatabaseBase db): base(1802723905, newRawcode, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
            _dataDamageTakenIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTakenIncrease, SetDataDamageTakenIncrease));
            _isDataDamageTakenIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageTakenIncreaseModified));
        }

        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedIncreaseModified => _isDataMovementSpeedIncreaseModified.Value;
        public ObjectProperty<float> DataAttackSpeedIncrease => _dataAttackSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedIncreaseModified => _isDataAttackSpeedIncreaseModified.Value;
        public ObjectProperty<float> DataDamageTakenIncrease => _dataDamageTakenIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageTakenIncreaseModified => _isDataDamageTakenIncreaseModified.Value;
        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications.GetModification(829125474, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedIncrease(int level, float value)
        {
            _modifications[829125474, level] = new LevelObjectDataModification{Id = 829125474, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(829125474, level);
        }

        private float GetDataAttackSpeedIncrease(int level)
        {
            return _modifications.GetModification(845902690, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedIncrease(int level, float value)
        {
            _modifications[845902690, level] = new LevelObjectDataModification{Id = 845902690, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAttackSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(845902690, level);
        }

        private float GetDataDamageTakenIncrease(int level)
        {
            return _modifications.GetModification(862679906, level).ValueAsFloat;
        }

        private void SetDataDamageTakenIncrease(int level, float value)
        {
            _modifications[862679906, level] = new LevelObjectDataModification{Id = 862679906, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageTakenIncreaseModified(int level)
        {
            return _modifications.ContainsKey(862679906, level);
        }
    }
}