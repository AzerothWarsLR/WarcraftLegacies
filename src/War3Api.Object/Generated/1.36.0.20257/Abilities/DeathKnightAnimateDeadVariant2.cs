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
    public sealed class DeathKnightAnimateDeadVariant2 : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfCorpsesRaised;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfCorpsesRaisedModified;
        private readonly Lazy<ObjectProperty<int>> _dataInheritUpgradesRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInheritUpgradesModified;
        private readonly Lazy<ObjectProperty<bool>> _dataInheritUpgrades;
        private readonly Lazy<ObjectProperty<int>> _dataRaisedUnitsAreInvulnerableRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaisedUnitsAreInvulnerableModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRaisedUnitsAreInvulnerable;
        public DeathKnightAnimateDeadVariant2(): base(845239617)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public DeathKnightAnimateDeadVariant2(int newId): base(845239617, newId)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public DeathKnightAnimateDeadVariant2(string newRawcode): base(845239617, newRawcode)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public DeathKnightAnimateDeadVariant2(ObjectDatabaseBase db): base(845239617, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public DeathKnightAnimateDeadVariant2(int newId, ObjectDatabaseBase db): base(845239617, newId, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public DeathKnightAnimateDeadVariant2(string newRawcode, ObjectDatabaseBase db): base(845239617, newRawcode, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataInheritUpgradesRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataInheritUpgradesRaw, SetDataInheritUpgradesRaw));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public ObjectProperty<int> DataNumberOfCorpsesRaised => _dataNumberOfCorpsesRaised.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfCorpsesRaisedModified => _isDataNumberOfCorpsesRaisedModified.Value;
        public ObjectProperty<int> DataInheritUpgradesRaw => _dataInheritUpgradesRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataInheritUpgradesModified => _isDataInheritUpgradesModified.Value;
        public ObjectProperty<bool> DataInheritUpgrades => _dataInheritUpgrades.Value;
        public ObjectProperty<int> DataRaisedUnitsAreInvulnerableRaw => _dataRaisedUnitsAreInvulnerableRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaisedUnitsAreInvulnerableModified => _isDataRaisedUnitsAreInvulnerableModified.Value;
        public ObjectProperty<bool> DataRaisedUnitsAreInvulnerable => _dataRaisedUnitsAreInvulnerable.Value;
        private int GetDataNumberOfCorpsesRaised(int level)
        {
            return _modifications.GetModification(829317461, level).ValueAsInt;
        }

        private void SetDataNumberOfCorpsesRaised(int level, int value)
        {
            _modifications[829317461, level] = new LevelObjectDataModification{Id = 829317461, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfCorpsesRaisedModified(int level)
        {
            return _modifications.ContainsKey(829317461, level);
        }

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
    }
}