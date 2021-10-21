using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AgilityBonus3 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAgilityBonus;
        private readonly Lazy<ObjectProperty<int>> _dataIntelligenceBonus;
        private readonly Lazy<ObjectProperty<int>> _dataStrengthBonus;
        private readonly Lazy<ObjectProperty<bool>> _dataHideButton;
        public AgilityBonus3(): base(862013761)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public AgilityBonus3(int newId): base(862013761, newId)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public AgilityBonus3(string newRawcode): base(862013761, newRawcode)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public AgilityBonus3(ObjectDatabase db): base(862013761, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public AgilityBonus3(int newId, ObjectDatabase db): base(862013761, newId, db)
        {
            _dataAgilityBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAgilityBonus, SetDataAgilityBonus));
            _dataIntelligenceBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntelligenceBonus, SetDataIntelligenceBonus));
            _dataStrengthBonus = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStrengthBonus, SetDataStrengthBonus));
            _dataHideButton = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataHideButton, SetDataHideButton));
        }

        public AgilityBonus3(string newRawcode, ObjectDatabase db): base(862013761, newRawcode, db)
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