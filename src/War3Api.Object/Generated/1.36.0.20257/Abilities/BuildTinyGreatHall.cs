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
    public sealed class BuildTinyGreatHall : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataUnitCreatedperPlayerRaceRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataUnitCreatedperPlayerRaceModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataUnitCreatedperPlayerRace;
        public BuildTinyGreatHall(): base(1734494529)
        {
            _dataUnitCreatedperPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedperPlayerRaceRaw, SetDataUnitCreatedperPlayerRaceRaw));
            _isDataUnitCreatedperPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedperPlayerRaceModified));
            _dataUnitCreatedperPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedperPlayerRace, SetDataUnitCreatedperPlayerRace));
        }

        public BuildTinyGreatHall(int newId): base(1734494529, newId)
        {
            _dataUnitCreatedperPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedperPlayerRaceRaw, SetDataUnitCreatedperPlayerRaceRaw));
            _isDataUnitCreatedperPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedperPlayerRaceModified));
            _dataUnitCreatedperPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedperPlayerRace, SetDataUnitCreatedperPlayerRace));
        }

        public BuildTinyGreatHall(string newRawcode): base(1734494529, newRawcode)
        {
            _dataUnitCreatedperPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedperPlayerRaceRaw, SetDataUnitCreatedperPlayerRaceRaw));
            _isDataUnitCreatedperPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedperPlayerRaceModified));
            _dataUnitCreatedperPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedperPlayerRace, SetDataUnitCreatedperPlayerRace));
        }

        public BuildTinyGreatHall(ObjectDatabaseBase db): base(1734494529, db)
        {
            _dataUnitCreatedperPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedperPlayerRaceRaw, SetDataUnitCreatedperPlayerRaceRaw));
            _isDataUnitCreatedperPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedperPlayerRaceModified));
            _dataUnitCreatedperPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedperPlayerRace, SetDataUnitCreatedperPlayerRace));
        }

        public BuildTinyGreatHall(int newId, ObjectDatabaseBase db): base(1734494529, newId, db)
        {
            _dataUnitCreatedperPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedperPlayerRaceRaw, SetDataUnitCreatedperPlayerRaceRaw));
            _isDataUnitCreatedperPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedperPlayerRaceModified));
            _dataUnitCreatedperPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedperPlayerRace, SetDataUnitCreatedperPlayerRace));
        }

        public BuildTinyGreatHall(string newRawcode, ObjectDatabaseBase db): base(1734494529, newRawcode, db)
        {
            _dataUnitCreatedperPlayerRaceRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitCreatedperPlayerRaceRaw, SetDataUnitCreatedperPlayerRaceRaw));
            _isDataUnitCreatedperPlayerRaceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataUnitCreatedperPlayerRaceModified));
            _dataUnitCreatedperPlayerRace = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataUnitCreatedperPlayerRace, SetDataUnitCreatedperPlayerRace));
        }

        public ObjectProperty<string> DataUnitCreatedperPlayerRaceRaw => _dataUnitCreatedperPlayerRaceRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataUnitCreatedperPlayerRaceModified => _isDataUnitCreatedperPlayerRaceModified.Value;
        public ObjectProperty<IEnumerable<Unit>> DataUnitCreatedperPlayerRace => _dataUnitCreatedperPlayerRace.Value;
        private string GetDataUnitCreatedperPlayerRaceRaw(int level)
        {
            return _modifications.GetModification(829186633, level).ValueAsString;
        }

        private void SetDataUnitCreatedperPlayerRaceRaw(int level, string value)
        {
            _modifications[829186633, level] = new LevelObjectDataModification{Id = 829186633, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsDataUnitCreatedperPlayerRaceModified(int level)
        {
            return _modifications.ContainsKey(829186633, level);
        }

        private IEnumerable<Unit> GetDataUnitCreatedperPlayerRace(int level)
        {
            return GetDataUnitCreatedperPlayerRaceRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataUnitCreatedperPlayerRace(int level, IEnumerable<Unit> value)
        {
            SetDataUnitCreatedperPlayerRaceRaw(level, value.ToRaw(4, 4));
        }
    }
}