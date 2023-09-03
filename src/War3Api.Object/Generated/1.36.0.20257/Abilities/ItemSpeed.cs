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
    public sealed class ItemSpeed : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedIncreaseModified;
        public ItemSpeed(): base(1886603585)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
        }

        public ItemSpeed(int newId): base(1886603585, newId)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
        }

        public ItemSpeed(string newRawcode): base(1886603585, newRawcode)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
        }

        public ItemSpeed(ObjectDatabaseBase db): base(1886603585, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
        }

        public ItemSpeed(int newId, ObjectDatabaseBase db): base(1886603585, newId, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
        }

        public ItemSpeed(string newRawcode, ObjectDatabaseBase db): base(1886603585, newRawcode, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
        }

        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedIncreaseModified => _isDataMovementSpeedIncreaseModified.Value;
        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications.GetModification(1768977225, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedIncrease(int level, float value)
        {
            _modifications[1768977225, level] = new LevelObjectDataModification{Id = 1768977225, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(1768977225, level);
        }
    }
}