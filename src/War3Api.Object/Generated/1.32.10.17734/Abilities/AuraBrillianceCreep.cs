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
    public sealed class AuraBrillianceCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaRegenerationIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaRegenerationIncreaseModified;
        private readonly Lazy<ObjectProperty<int>> _dataPercentBonusRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        public AuraBrillianceCreep(): base(1633829697)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public AuraBrillianceCreep(int newId): base(1633829697, newId)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public AuraBrillianceCreep(string newRawcode): base(1633829697, newRawcode)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public AuraBrillianceCreep(ObjectDatabaseBase db): base(1633829697, db)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public AuraBrillianceCreep(int newId, ObjectDatabaseBase db): base(1633829697, newId, db)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public AuraBrillianceCreep(string newRawcode, ObjectDatabaseBase db): base(1633829697, newRawcode, db)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonusRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataPercentBonusRaw, SetDataPercentBonusRaw));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
        }

        public ObjectProperty<float> DataManaRegenerationIncrease => _dataManaRegenerationIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaRegenerationIncreaseModified => _isDataManaRegenerationIncreaseModified.Value;
        public ObjectProperty<int> DataPercentBonusRaw => _dataPercentBonusRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        private float GetDataManaRegenerationIncrease(int level)
        {
            return _modifications.GetModification(828531016, level).ValueAsFloat;
        }

        private void SetDataManaRegenerationIncrease(int level, float value)
        {
            _modifications[828531016, level] = new LevelObjectDataModification{Id = 828531016, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaRegenerationIncreaseModified(int level)
        {
            return _modifications.ContainsKey(828531016, level);
        }

        private int GetDataPercentBonusRaw(int level)
        {
            return _modifications.GetModification(845308232, level).ValueAsInt;
        }

        private void SetDataPercentBonusRaw(int level, int value)
        {
            _modifications[845308232, level] = new LevelObjectDataModification{Id = 845308232, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(845308232, level);
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