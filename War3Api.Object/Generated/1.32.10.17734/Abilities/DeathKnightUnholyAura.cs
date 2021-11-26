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
    public sealed class DeathKnightUnholyAura : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedIncreaseModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifeRegenerationIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeRegenerationIncreaseModified;
        private readonly Lazy<ObjectProperty<int>> _dataPercentBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        public DeathKnightUnholyAura(): base(1969313089)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public DeathKnightUnholyAura(int newId): base(1969313089, newId)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public DeathKnightUnholyAura(string newRawcode): base(1969313089, newRawcode)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public DeathKnightUnholyAura(ObjectDatabaseBase db): base(1969313089, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public DeathKnightUnholyAura(int newId, ObjectDatabaseBase db): base(1969313089, newId, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public DeathKnightUnholyAura(string newRawcode, ObjectDatabaseBase db): base(1969313089, newRawcode, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedIncreaseModified => _isDataMovementSpeedIncreaseModified.Value;
        public ObjectProperty<float> DataLifeRegenerationIncrease => _dataLifeRegenerationIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeRegenerationIncreaseModified => _isDataLifeRegenerationIncreaseModified.Value;
        public ObjectProperty<int> DataPercentBonusRaw => _dataPercentBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications.GetModification(829776213, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedIncrease(int level, float value)
        {
            _modifications[829776213, level] = new LevelObjectDataModification{Id = 829776213, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMovementSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(829776213, level);
        }

        private float GetDataLifeRegenerationIncrease(int level)
        {
            return _modifications.GetModification(846553429, level).ValueAsFloat;
        }

        private void SetDataLifeRegenerationIncrease(int level, float value)
        {
            _modifications[846553429, level] = new LevelObjectDataModification{Id = 846553429, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLifeRegenerationIncreaseModified(int level)
        {
            return _modifications.ContainsKey(846553429, level);
        }

        private int GetDataPercentBonusRaw(int level)
        {
            return _modifications.GetModification(863330645, level).ValueAsInt;
        }

        private void SetDataPercentBonusRaw(int level, int value)
        {
            _modifications[863330645, level] = new LevelObjectDataModification{Id = 863330645, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(863330645, level);
        }

        private bool GetDataPercentBonus(int level)
        {
            return GetDataPercentBonusRaw(level).ToBool(this);
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            SetDataPercentBonusRaw(level, value.ToRaw(0, 1));
        }
    }
}