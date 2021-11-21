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
    public sealed class BuildTinyScoutTower : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataUnitCreatedPerPlayerRaceRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitCreatedPerPlayerRaceModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataUnitCreatedPerPlayerRace;
        public BuildTinyScoutTower(): base(1952598337)
        {
            _dataUnitCreatedPerPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedPerPlayerRaceRaw, SetDataUnitCreatedPerPlayerRaceRaw));
            _isDataUnitCreatedPerPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedPerPlayerRaceModified));
            _dataUnitCreatedPerPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedPerPlayerRace, SetDataUnitCreatedPerPlayerRace));
        }

        public BuildTinyScoutTower(int newId): base(1952598337, newId)
        {
            _dataUnitCreatedPerPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedPerPlayerRaceRaw, SetDataUnitCreatedPerPlayerRaceRaw));
            _isDataUnitCreatedPerPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedPerPlayerRaceModified));
            _dataUnitCreatedPerPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedPerPlayerRace, SetDataUnitCreatedPerPlayerRace));
        }

        public BuildTinyScoutTower(string newRawcode): base(1952598337, newRawcode)
        {
            _dataUnitCreatedPerPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedPerPlayerRaceRaw, SetDataUnitCreatedPerPlayerRaceRaw));
            _isDataUnitCreatedPerPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedPerPlayerRaceModified));
            _dataUnitCreatedPerPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedPerPlayerRace, SetDataUnitCreatedPerPlayerRace));
        }

        public BuildTinyScoutTower(ObjectDatabaseBase db): base(1952598337, db)
        {
            _dataUnitCreatedPerPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedPerPlayerRaceRaw, SetDataUnitCreatedPerPlayerRaceRaw));
            _isDataUnitCreatedPerPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedPerPlayerRaceModified));
            _dataUnitCreatedPerPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedPerPlayerRace, SetDataUnitCreatedPerPlayerRace));
        }

        public BuildTinyScoutTower(int newId, ObjectDatabaseBase db): base(1952598337, newId, db)
        {
            _dataUnitCreatedPerPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedPerPlayerRaceRaw, SetDataUnitCreatedPerPlayerRaceRaw));
            _isDataUnitCreatedPerPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedPerPlayerRaceModified));
            _dataUnitCreatedPerPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedPerPlayerRace, SetDataUnitCreatedPerPlayerRace));
        }

        public BuildTinyScoutTower(string newRawcode, ObjectDatabaseBase db): base(1952598337, newRawcode, db)
        {
            _dataUnitCreatedPerPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedPerPlayerRaceRaw, SetDataUnitCreatedPerPlayerRaceRaw));
            _isDataUnitCreatedPerPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedPerPlayerRaceModified));
            _dataUnitCreatedPerPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedPerPlayerRace, SetDataUnitCreatedPerPlayerRace));
        }

        public ObjectProperty<string> DataUnitCreatedPerPlayerRaceRaw => _dataUnitCreatedPerPlayerRaceRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitCreatedPerPlayerRaceModified => _isDataUnitCreatedPerPlayerRaceModified.Value;
        public ObjectProperty<IEnumerable<Unit>> DataUnitCreatedPerPlayerRace => _dataUnitCreatedPerPlayerRace.Value;
        private string GetDataUnitCreatedPerPlayerRaceRaw(int level)
        {
            return _modifications.GetModification(829186633, level).ValueAsString;
        }

        private void SetDataUnitCreatedPerPlayerRaceRaw(int level, string value)
        {
            _modifications[829186633, level] = new LevelObjectDataModification{Id = 829186633, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataUnitCreatedPerPlayerRaceModified(int level)
        {
            return _modifications.ContainsKey(829186633, level);
        }

        private IEnumerable<Unit> GetDataUnitCreatedPerPlayerRace(int level)
        {
            return GetDataUnitCreatedPerPlayerRaceRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataUnitCreatedPerPlayerRace(int level, IEnumerable<Unit> value)
        {
            SetDataUnitCreatedPerPlayerRaceRaw(level, value.ToRaw(4, 4));
        }
    }
}