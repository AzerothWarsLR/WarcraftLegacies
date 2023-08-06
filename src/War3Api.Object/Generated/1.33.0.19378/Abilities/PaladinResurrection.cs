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
    public sealed class PaladinResurrection : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfCorpsesRaised;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfCorpsesRaisedModified;
        private readonly Lazy<ObjectProperty<int>> _dataRaisedUnitsAreInvulnerableRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaisedUnitsAreInvulnerableModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRaisedUnitsAreInvulnerable;
        public PaladinResurrection(): base(1701988417)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public PaladinResurrection(int newId): base(1701988417, newId)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public PaladinResurrection(string newRawcode): base(1701988417, newRawcode)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public PaladinResurrection(ObjectDatabaseBase db): base(1701988417, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public PaladinResurrection(int newId, ObjectDatabaseBase db): base(1701988417, newId, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public PaladinResurrection(string newRawcode, ObjectDatabaseBase db): base(1701988417, newRawcode, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerableRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRaisedUnitsAreInvulnerableRaw, SetDataRaisedUnitsAreInvulnerableRaw));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
        }

        public ObjectProperty<int> DataNumberOfCorpsesRaised => _dataNumberOfCorpsesRaised.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfCorpsesRaisedModified => _isDataNumberOfCorpsesRaisedModified.Value;
        public ObjectProperty<int> DataRaisedUnitsAreInvulnerableRaw => _dataRaisedUnitsAreInvulnerableRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaisedUnitsAreInvulnerableModified => _isDataRaisedUnitsAreInvulnerableModified.Value;
        public ObjectProperty<bool> DataRaisedUnitsAreInvulnerable => _dataRaisedUnitsAreInvulnerable.Value;
        private int GetDataNumberOfCorpsesRaised(int level)
        {
            return _modifications.GetModification(828731976, level).ValueAsInt;
        }

        private void SetDataNumberOfCorpsesRaised(int level, int value)
        {
            _modifications[828731976, level] = new LevelObjectDataModification{Id = 828731976, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfCorpsesRaisedModified(int level)
        {
            return _modifications.ContainsKey(828731976, level);
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