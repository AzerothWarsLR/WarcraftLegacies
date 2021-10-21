using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class All4 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAgilityBonus;
        private readonly Lazy<ObjectProperty<int>> _dataIntelligenceBonus;
        private readonly Lazy<ObjectProperty<int>> _dataStrengthBonus;
        private readonly Lazy<ObjectProperty<bool>> _dataHideButton;
        public All4(): base(880298305)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(int newId): base(880298305, newId)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(string newRawcode): base(880298305, newRawcode)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(ObjectDatabase db): base(880298305, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(int newId, ObjectDatabase db): base(880298305, newId, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public All4(string newRawcode, ObjectDatabase db): base(880298305, newRawcode, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public ObjectProperty<int> DataAgilityBonus => _dataAgilityBonus.Value;
        public ObjectProperty<int> DataIntelligenceBonus => _dataIntelligenceBonus.Value;
        public ObjectProperty<int> DataStrengthBonus => _dataStrengthBonus.Value;
        public ObjectProperty<bool> DataHideButton => _dataHideButton.Value;
        private int GetDataAgilityBonus(int level)
        {
            return _modifications[1768382793, level].ValueAsInt;
        }

        private void SetDataAgilityBonus(int level, int value)
        {
            _modifications[1768382793, level] = new LevelObjectDataModification{Id = 1768382793, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataIntelligenceBonus(int level)
        {
            return _modifications[1953392969, level].ValueAsInt;
        }

        private void SetDataIntelligenceBonus(int level, int value)
        {
            _modifications[1953392969, level] = new LevelObjectDataModification{Id = 1953392969, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataStrengthBonus(int level)
        {
            return _modifications[1920234313, level].ValueAsInt;
        }

        private void SetDataStrengthBonus(int level, int value)
        {
            _modifications[1920234313, level] = new LevelObjectDataModification{Id = 1920234313, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataHideButton(int level)
        {
            return _modifications[1684629577, level].ValueAsBool;
        }

        private void SetDataHideButton(int level, bool value)
        {
            _modifications[1684629577, level] = new LevelObjectDataModification{Id = 1684629577, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}