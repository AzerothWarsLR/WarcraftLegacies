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
    public sealed class AnimateDeadCreep : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataInheritUpgradesRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInheritUpgradesModified;
        private readonly Lazy<ObjectProperty<bool>> _dataInheritUpgrades;
        private readonly Lazy<ObjectProperty<int>> _dataRaisedUnitsAreInvulnerableRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaisedUnitsAreInvulnerableModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRaisedUnitsAreInvulnerable;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfCorpsesRaised;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfCorpsesRaisedModified;
        public AnimateDeadCreep(): base(1684095809)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDeadCreep(int newId): base(1684095809, newId)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDeadCreep(string newRawcode): base(1684095809, newRawcode)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDeadCreep(ObjectDatabaseBase db): base(1684095809, db)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDeadCreep(int newId, ObjectDatabaseBase db): base(1684095809, newId, db)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDeadCreep(string newRawcode, ObjectDatabaseBase db): base(1684095809, newRawcode, db)
        {
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public ObjectProperty<int> DataInheritUpgradesRaw => _dataInheritUpgradesRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataInheritUpgradesModified => _isDataInheritUpgradesModified.Value;
        public ObjectProperty<bool> DataInheritUpgrades => _dataInheritUpgrades.Value;
        public ObjectProperty<int> DataRaisedUnitsAreInvulnerableRaw => _dataRaisedUnitsAreInvulnerableRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaisedUnitsAreInvulnerableModified => _isDataRaisedUnitsAreInvulnerableModified.Value;
        public ObjectProperty<bool> DataRaisedUnitsAreInvulnerable => _dataRaisedUnitsAreInvulnerable.Value;
        public ObjectProperty<int> DataNumberOfCorpsesRaised => _dataNumberOfCorpsesRaised.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfCorpsesRaisedModified => _isDataNumberOfCorpsesRaisedModified.Value;
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

        private int GetDataRaisedUnitsAreInvulnerableRaw(int level)
        {
            return _modifications.GetModification(845509192, level).ValueAsInt;
        }

        private void SetDataRaisedUnitsAreInvulnerableRaw(int level, int value)
        {
            _modifications[845509192, level] = new LevelObjectDataModification{Id = 845509192, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataRaisedUnitsAreInvulnerableModified(int level)
        {
            return _modifications.ContainsKey(845509192, level);
        }

        private bool GetDataRaisedUnitsAreInvulnerable(int level)
        {
            return GetDataRaisedUnitsAreInvulnerableRaw(level).ToBool(this);
        }

        private void SetDataRaisedUnitsAreInvulnerable(int level, bool value)
        {
            SetDataRaisedUnitsAreInvulnerableRaw(level, value.ToRaw(null, null));
        }

        private int GetDataNumberOfCorpsesRaised(int level)
        {
            return _modifications.GetModification(828662083, level).ValueAsInt;
        }

        private void SetDataNumberOfCorpsesRaised(int level, int value)
        {
            _modifications[828662083, level] = new LevelObjectDataModification{Id = 828662083, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfCorpsesRaisedModified(int level)
        {
            return _modifications.ContainsKey(828662083, level);
        }
    }
}