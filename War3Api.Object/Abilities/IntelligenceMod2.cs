using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class IntelligenceMod2 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAgilityBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAgilityBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataIntelligenceBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIntelligenceBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataStrengthBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStrengthBonusModified;
        private readonly Lazy<ObjectProperty<bool>> _dataHideButton;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHideButtonModified;
        public IntelligenceMod2(): base(1836337473)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
        }

        public IntelligenceMod2(int newId): base(1836337473, newId)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
        }

        public IntelligenceMod2(string newRawcode): base(1836337473, newRawcode)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
        }

        public IntelligenceMod2(ObjectDatabase db): base(1836337473, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
        }

        public IntelligenceMod2(int newId, ObjectDatabase db): base(1836337473, newId, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
        }

        public IntelligenceMod2(string newRawcode, ObjectDatabase db): base(1836337473, newRawcode, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
        }

        public ObjectProperty<int> DataAgilityBonus => _dataAgilityBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataAgilityBonusModified => _isDataAgilityBonusModified.Value;
        public ObjectProperty<int> DataIntelligenceBonus => _dataIntelligenceBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataIntelligenceBonusModified => _isDataIntelligenceBonusModified.Value;
        public ObjectProperty<int> DataStrengthBonus => _dataStrengthBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataStrengthBonusModified => _isDataStrengthBonusModified.Value;
        public ObjectProperty<bool> DataHideButton => _dataHideButton.Value;
        public ReadOnlyObjectProperty<bool> IsDataHideButtonModified => _isDataHideButtonModified.Value;
        private int GetDataAgilityBonus(int level)
        {
            return _modifications[1768382793, level].ValueAsInt;
        }

        private void SetDataAgilityBonus(int level, int value)
        {
            _modifications[1768382793, level] = new LevelObjectDataModification{Id = 1768382793, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAgilityBonusModified(int level)
        {
            return _modifications.ContainsKey(1768382793, level);
        }

        private int GetDataIntelligenceBonus(int level)
        {
            return _modifications[1953392969, level].ValueAsInt;
        }

        private void SetDataIntelligenceBonus(int level, int value)
        {
            _modifications[1953392969, level] = new LevelObjectDataModification{Id = 1953392969, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataIntelligenceBonusModified(int level)
        {
            return _modifications.ContainsKey(1953392969, level);
        }

        private int GetDataStrengthBonus(int level)
        {
            return _modifications[1920234313, level].ValueAsInt;
        }

        private void SetDataStrengthBonus(int level, int value)
        {
            _modifications[1920234313, level] = new LevelObjectDataModification{Id = 1920234313, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataStrengthBonusModified(int level)
        {
            return _modifications.ContainsKey(1920234313, level);
        }

        private bool GetDataHideButton(int level)
        {
            return _modifications[1684629577, level].ValueAsBool;
        }

        private void SetDataHideButton(int level, bool value)
        {
            _modifications[1684629577, level] = new LevelObjectDataModification{Id = 1684629577, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataHideButtonModified(int level)
        {
            return _modifications.ContainsKey(1684629577, level);
        }
    }
}