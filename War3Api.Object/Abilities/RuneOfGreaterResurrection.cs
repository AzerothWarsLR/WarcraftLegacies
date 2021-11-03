using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RuneOfGreaterResurrection : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataRaisedUnitsAreInvulnerable;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRaisedUnitsAreInvulnerableModified;
        public RuneOfGreaterResurrection(): base(1920094273)
        {
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public RuneOfGreaterResurrection(int newId): base(1920094273, newId)
        {
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public RuneOfGreaterResurrection(string newRawcode): base(1920094273, newRawcode)
        {
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public RuneOfGreaterResurrection(ObjectDatabase db): base(1920094273, db)
        {
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public RuneOfGreaterResurrection(int newId, ObjectDatabase db): base(1920094273, newId, db)
        {
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public RuneOfGreaterResurrection(string newRawcode, ObjectDatabase db): base(1920094273, newRawcode, db)
        {
            _dataRaisedUnitsAreInvulnerable = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRaisedUnitsAreInvulnerable, SetDataRaisedUnitsAreInvulnerable));
            _isDataRaisedUnitsAreInvulnerableModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRaisedUnitsAreInvulnerableModified));
        }

        public ObjectProperty<bool> DataRaisedUnitsAreInvulnerable => _dataRaisedUnitsAreInvulnerable.Value;
        public ReadOnlyObjectProperty<bool> IsDataRaisedUnitsAreInvulnerableModified => _isDataRaisedUnitsAreInvulnerableModified.Value;
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