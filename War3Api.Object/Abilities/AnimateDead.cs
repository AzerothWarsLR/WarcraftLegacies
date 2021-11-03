using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class AnimateDead : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataInheritUpgrades;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataInheritUpgradesModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRaisedUnitsAreInvulnerable;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaisedUnitsAreInvulnerableModified;
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfCorpsesRaised;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfCorpsesRaisedModified;
        public AnimateDead(): base(1851869505)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDead(int newId): base(1851869505, newId)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDead(string newRawcode): base(1851869505, newRawcode)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDead(ObjectDatabase db): base(1851869505, db)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDead(int newId, ObjectDatabase db): base(1851869505, newId, db)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public AnimateDead(string newRawcode, ObjectDatabase db): base(1851869505, newRawcode, db)
        {
            _dataInheritUpgrades = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataInheritUpgrades, SetDataInheritUpgrades));
            _isDataInheritUpgradesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataInheritUpgradesModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
        }

        public ObjectProperty<bool> DataInheritUpgrades => _dataInheritUpgrades.Value;
        public ReadOnlyObjectProperty<bool> IsDataInheritUpgradesModified => _isDataInheritUpgradesModified.Value;
        public ObjectProperty<bool> DataRaisedUnitsAreInvulnerable => _dataRaisedUnitsAreInvulnerable.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaisedUnitsAreInvulnerableModified => _isDataRaisedUnitsAreInvulnerableModified.Value;
        public ObjectProperty<int> DataNumberOfCorpsesRaised => _dataNumberOfCorpsesRaised.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfCorpsesRaisedModified => _isDataNumberOfCorpsesRaisedModified.Value;
        private bool GetDataInheritUpgrades(int level)
        {
            return _modifications[862871893, level].ValueAsBool;
        }

        private void SetDataInheritUpgrades(int level, bool value)
        {
            _modifications[862871893, level] = new LevelObjectDataModification{Id = 862871893, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataInheritUpgradesModified(int level)
        {
            return _modifications.ContainsKey(862871893, level);
        }

        private bool GetDataRaisedUnitsAreInvulnerable(int level)
        {
            return _modifications[845509192, level].ValueAsBool;
        }

        private void SetDataRaisedUnitsAreInvulnerable(int level, bool value)
        {
            _modifications[845509192, level] = new LevelObjectDataModification{Id = 845509192, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataRaisedUnitsAreInvulnerableModified(int level)
        {
            return _modifications.ContainsKey(845509192, level);
        }

        private int GetDataNumberOfCorpsesRaised(int level)
        {
            return _modifications[828662083, level].ValueAsInt;
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