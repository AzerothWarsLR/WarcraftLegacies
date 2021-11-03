using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class UnholyAuraCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedIncreaseModified;
        private readonly Lazy<ObjectProperty<float>> _dataLifeRegenerationIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLifeRegenerationIncreaseModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        public UnholyAuraCreep(): base(1635074881)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public UnholyAuraCreep(int newId): base(1635074881, newId)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public UnholyAuraCreep(string newRawcode): base(1635074881, newRawcode)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public UnholyAuraCreep(ObjectDatabase db): base(1635074881, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public UnholyAuraCreep(int newId, ObjectDatabase db): base(1635074881, newId, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public UnholyAuraCreep(string newRawcode, ObjectDatabase db): base(1635074881, newRawcode, db)
        {
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataLifeRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLifeRegenerationIncrease, SetDataLifeRegenerationIncrease));
            _isDataLifeRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLifeRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedIncreaseModified => _isDataMovementSpeedIncreaseModified.Value;
        public ObjectProperty<float> DataLifeRegenerationIncrease => _dataLifeRegenerationIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataLifeRegenerationIncreaseModified => _isDataLifeRegenerationIncreaseModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications[829776213, level].ValueAsFloat;
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
            return _modifications[846553429, level].ValueAsFloat;
        }

        private void SetDataLifeRegenerationIncrease(int level, float value)
        {
            _modifications[846553429, level] = new LevelObjectDataModification{Id = 846553429, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataLifeRegenerationIncreaseModified(int level)
        {
            return _modifications.ContainsKey(846553429, level);
        }

        private bool GetDataPercentBonus(int level)
        {
            return _modifications[863330645, level].ValueAsBool;
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            _modifications[863330645, level] = new LevelObjectDataModification{Id = 863330645, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(863330645, level);
        }
    }
}