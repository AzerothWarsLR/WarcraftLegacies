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
    public sealed class AttackSpeedIncrease : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttackSpeedIncreaseModified;
        public AttackSpeedIncrease(): base(2020821313)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
        }

        public AttackSpeedIncrease(int newId): base(2020821313, newId)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
        }

        public AttackSpeedIncrease(string newRawcode): base(2020821313, newRawcode)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
        }

        public AttackSpeedIncrease(ObjectDatabaseBase db): base(2020821313, db)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
        }

        public AttackSpeedIncrease(int newId, ObjectDatabaseBase db): base(2020821313, newId, db)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
        }

        public AttackSpeedIncrease(string newRawcode, ObjectDatabaseBase db): base(2020821313, newRawcode, db)
        {
            _dataAttackSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedIncrease, SetDataAttackSpeedIncrease));
            _isDataAttackSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttackSpeedIncreaseModified));
        }

        public ObjectProperty<float> DataAttackSpeedIncrease => _dataAttackSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttackSpeedIncreaseModified => _isDataAttackSpeedIncreaseModified.Value;
        private float GetDataAttackSpeedIncrease(int level)
        {
            return _modifications.GetModification(829977417, level).ValueAsFloat;
        }

        private void SetDataAttackSpeedIncrease(int level, float value)
        {
            _modifications[829977417, level] = new LevelObjectDataModification{Id = 829977417, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttackSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(829977417, level);
        }
    }
}