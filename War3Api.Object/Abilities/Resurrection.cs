using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Resurrection : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfCorpsesRaised;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfCorpsesRaisedModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRaisedUnitsAreInvulnerable;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaisedUnitsAreInvulnerableModified;
        public Resurrection(): base(1936869697)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public Resurrection(int newId): base(1936869697, newId)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public Resurrection(string newRawcode): base(1936869697, newRawcode)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public Resurrection(ObjectDatabase db): base(1936869697, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public Resurrection(int newId, ObjectDatabase db): base(1936869697, newId, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public Resurrection(string newRawcode, ObjectDatabase db): base(1936869697, newRawcode, db)
        {
            _dataNumberOfCorpsesRaised = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfCorpsesRaised, SetDataNumberOfCorpsesRaised));
            _isDataNumberOfCorpsesRaisedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfCorpsesRaisedModified));
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public ObjectProperty<int> DataNumberOfCorpsesRaised => _dataNumberOfCorpsesRaised.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfCorpsesRaisedModified => _isDataNumberOfCorpsesRaisedModified.Value;
        public ObjectProperty<bool> DataRaisedUnitsAreInvulnerable => _dataRaisedUnitsAreInvulnerable.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaisedUnitsAreInvulnerableModified => _isDataRaisedUnitsAreInvulnerableModified.Value;
        private int GetDataNumberOfCorpsesRaised(int level)
        {
            return _modifications[828731976, level].ValueAsInt;
        }

        private void SetDataNumberOfCorpsesRaised(int level, int value)
        {
            _modifications[828731976, level] = new LevelObjectDataModification{Id = 828731976, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfCorpsesRaisedModified(int level)
        {
            return _modifications.ContainsKey(828731976, level);
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
    }
}