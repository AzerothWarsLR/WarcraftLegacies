using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MalganisSoulPreservation : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataUnitToPreserveRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitToPreserve;
        public MalganisSoulPreservation(): base(1819496001)
        {
            _dataUnitToPreserveRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitToPreserveRaw, SetDataUnitToPreserveRaw));
            _dataUnitToPreserve = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitToPreserve, SetDataUnitToPreserve));
        }

        public MalganisSoulPreservation(int newId): base(1819496001, newId)
        {
            _dataUnitToPreserveRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitToPreserveRaw, SetDataUnitToPreserveRaw));
            _dataUnitToPreserve = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitToPreserve, SetDataUnitToPreserve));
        }

        public MalganisSoulPreservation(string newRawcode): base(1819496001, newRawcode)
        {
            _dataUnitToPreserveRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitToPreserveRaw, SetDataUnitToPreserveRaw));
            _dataUnitToPreserve = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitToPreserve, SetDataUnitToPreserve));
        }

        public MalganisSoulPreservation(ObjectDatabase db): base(1819496001, db)
        {
            _dataUnitToPreserveRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitToPreserveRaw, SetDataUnitToPreserveRaw));
            _dataUnitToPreserve = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitToPreserve, SetDataUnitToPreserve));
        }

        public MalganisSoulPreservation(int newId, ObjectDatabase db): base(1819496001, newId, db)
        {
            _dataUnitToPreserveRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitToPreserveRaw, SetDataUnitToPreserveRaw));
            _dataUnitToPreserve = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitToPreserve, SetDataUnitToPreserve));
        }

        public MalganisSoulPreservation(string newRawcode, ObjectDatabase db): base(1819496001, newRawcode, db)
        {
            _dataUnitToPreserveRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitToPreserveRaw, SetDataUnitToPreserveRaw));
            _dataUnitToPreserve = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitToPreserve, SetDataUnitToPreserve));
        }

        public ObjectProperty<string> DataUnitToPreserveRaw => _dataUnitToPreserveRaw.Value;
        public ObjectProperty<Unit> DataUnitToPreserve => _dataUnitToPreserve.Value;
        private string GetDataUnitToPreserveRaw(int level)
        {
            return _modifications[829190990, level].ValueAsString;
        }

        private void SetDataUnitToPreserveRaw(int level, string value)
        {
            _modifications[829190990, level] = new LevelObjectDataModification{Id = 829190990, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataUnitToPreserve(int level)
        {
            return GetDataUnitToPreserveRaw(level).ToUnit(this);
        }

        private void SetDataUnitToPreserve(int level, Unit value)
        {
            SetDataUnitToPreserveRaw(level, value.ToRaw(null, null));
        }
    }
}