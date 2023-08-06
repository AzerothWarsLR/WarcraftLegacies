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
    public sealed class All4 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAgilityBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAgilityBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataIntelligenceBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIntelligenceBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataStrengthBonus;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStrengthBonusModified;
        private readonly Lazy<ObjectProperty<int>> _dataHideButtonRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHideButtonModified;
        private readonly Lazy<ObjectProperty<bool>> _dataHideButton;
        public All4(): base(880298305)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHideButtonRaw, SetDataHideButtonRaw));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(int newId): base(880298305, newId)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHideButtonRaw, SetDataHideButtonRaw));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(string newRawcode): base(880298305, newRawcode)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHideButtonRaw, SetDataHideButtonRaw));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(ObjectDatabaseBase db): base(880298305, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHideButtonRaw, SetDataHideButtonRaw));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(int newId, ObjectDatabaseBase db): base(880298305, newId, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHideButtonRaw, SetDataHideButtonRaw));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(string newRawcode, ObjectDatabaseBase db): base(880298305, newRawcode, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _isDataAgilityBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAgilityBonusModified));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _isDataIntelligenceBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntelligenceBonusModified));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _isDataStrengthBonusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStrengthBonusModified));
            _dataHideButtonRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHideButtonRaw, SetDataHideButtonRaw));
            _isDataHideButtonModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHideButtonModified));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public ObjectProperty<int> DataAgilityBonus => _dataAgilityBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataAgilityBonusModified => _isDataAgilityBonusModified.Value;
        public ObjectProperty<int> DataIntelligenceBonus => _dataIntelligenceBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataIntelligenceBonusModified => _isDataIntelligenceBonusModified.Value;
        public ObjectProperty<int> DataStrengthBonus => _dataStrengthBonus.Value;
        public ReadOnlyObjectProperty<bool> IsDataStrengthBonusModified => _isDataStrengthBonusModified.Value;
        public ObjectProperty<int> DataHideButtonRaw => _dataHideButtonRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataHideButtonModified => _isDataHideButtonModified.Value;
        public ObjectProperty<bool> DataHideButton => _dataHideButton.Value;
        private int GetDataAgilityBonus(int level)
        {
            return _modifications.GetModification(1768382793, level).ValueAsInt;
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
            return _modifications.GetModification(1953392969, level).ValueAsInt;
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
            return _modifications.GetModification(1920234313, level).ValueAsInt;
        }

        private void SetDataStrengthBonus(int level, int value)
        {
            _modifications[1920234313, level] = new LevelObjectDataModification{Id = 1920234313, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataStrengthBonusModified(int level)
        {
            return _modifications.ContainsKey(1920234313, level);
        }

        private int GetDataHideButtonRaw(int level)
        {
            return _modifications.GetModification(1684629577, level).ValueAsInt;
        }

        private void SetDataHideButtonRaw(int level, int value)
        {
            _modifications[1684629577, level] = new LevelObjectDataModification{Id = 1684629577, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataHideButtonModified(int level)
        {
            return _modifications.ContainsKey(1684629577, level);
        }

        private bool GetDataHideButton(int level)
        {
            return GetDataHideButtonRaw(level).ToBool(this);
        }

        private void SetDataHideButton(int level, bool value)
        {
            SetDataHideButtonRaw(level, value.ToRaw(0, 1));
        }
    }
}