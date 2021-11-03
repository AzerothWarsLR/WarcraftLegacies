using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AuraBrillianceCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataManaRegenerationIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataManaRegenerationIncreaseModified;
        private readonly Lazy<ObjectProperty<bool>> _dataPercentBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataPercentBonusModified;
        public AuraBrillianceCreep(): base(1633829697)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public AuraBrillianceCreep(int newId): base(1633829697, newId)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public AuraBrillianceCreep(string newRawcode): base(1633829697, newRawcode)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public AuraBrillianceCreep(ObjectDatabase db): base(1633829697, db)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public AuraBrillianceCreep(int newId, ObjectDatabase db): base(1633829697, newId, db)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public AuraBrillianceCreep(string newRawcode, ObjectDatabase db): base(1633829697, newRawcode, db)
        {
            _dataManaRegenerationIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataManaRegenerationIncrease, SetDataManaRegenerationIncrease));
            _isDataManaRegenerationIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataManaRegenerationIncreaseModified));
            _dataPercentBonus = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPercentBonus, SetDataPercentBonus));
            _isDataPercentBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataPercentBonusModified));
        }

        public ObjectProperty<float> DataManaRegenerationIncrease => _dataManaRegenerationIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataManaRegenerationIncreaseModified => _isDataManaRegenerationIncreaseModified.Value;
        public ObjectProperty<bool> DataPercentBonus => _dataPercentBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataPercentBonusModified => _isDataPercentBonusModified.Value;
        private float GetDataManaRegenerationIncrease(int level)
        {
            return _modifications[828531016, level].ValueAsFloat;
        }

        private void SetDataManaRegenerationIncrease(int level, float value)
        {
            _modifications[828531016, level] = new LevelObjectDataModification{Id = 828531016, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataManaRegenerationIncreaseModified(int level)
        {
            return _modifications.ContainsKey(828531016, level);
        }

        private bool GetDataPercentBonus(int level)
        {
            return _modifications[845308232, level].ValueAsBool;
        }

        private void SetDataPercentBonus(int level, bool value)
        {
            _modifications[845308232, level] = new LevelObjectDataModification{Id = 845308232, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataPercentBonusModified(int level)
        {
            return _modifications.ContainsKey(845308232, level);
        }
    }
}