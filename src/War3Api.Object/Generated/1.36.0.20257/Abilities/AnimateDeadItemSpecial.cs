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
    public sealed class AnimateDeadItemSpecial : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataInheritUpgradesRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInheritUpgradesModified;
        private readonly Lazy<ObjectProperty<bool>> _dataInheritUpgrades;
        public AnimateDeadItemSpecial(): base(1684949313)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(int newId): base(1684949313, newId)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(string newRawcode): base(1684949313, newRawcode)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(ObjectDatabaseBase db): base(1684949313, db)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(int newId, ObjectDatabaseBase db): base(1684949313, newId, db)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public AnimateDeadItemSpecial(string newRawcode, ObjectDatabaseBase db): base(1684949313, newRawcode, db)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
        }

        public ObjectProperty<int> DataInheritUpgradesRaw => _dataInheritUpgradesRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataInheritUpgradesModified => _isDataInheritUpgradesModified.Value;
        public ObjectProperty<bool> DataInheritUpgrades => _dataInheritUpgrades.Value;
        private int GetDataInheritUpgradesRaw(int level)
        {
            return _modifications.GetModification(862871893, level).ValueAsInt;
        }

        private void SetDataInheritUpgradesRaw(int level, int value)
        {
            _modifications[862871893, level] = new LevelObjectDataModification{Id = 862871893, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataInheritUpgradesModified(int level)
        {
            return _modifications.ContainsKey(862871893, level);
        }

        private bool GetDataInheritUpgrades(int level)
        {
            return GetDataInheritUpgradesRaw(level).ToBool(this);
        }

        private void SetDataInheritUpgrades(int level, bool value)
        {
            SetDataInheritUpgradesRaw(level, value.ToRaw(1, 1));
        }
    }
}