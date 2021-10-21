using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DarkPortal : Ability
    {
        private readonly Lazy<ObjectProperty<string>> _dataSpawnedUnitsRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Unit>>> _dataSpawnedUnits;
        private readonly Lazy<ObjectProperty<int>> _dataMinimumNumberOfUnits;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfUnits;
        public DarkPortal(): base(1885621825)
        {
            _dataSpawnedUnitsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnedUnitsRaw, SetDataSpawnedUnitsRaw));
            _dataSpawnedUnits = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSpawnedUnits, SetDataSpawnedUnits));
            _dataMinimumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumNumberOfUnits, SetDataMinimumNumberOfUnits));
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
        }

        public DarkPortal(int newId): base(1885621825, newId)
        {
            _dataSpawnedUnitsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnedUnitsRaw, SetDataSpawnedUnitsRaw));
            _dataSpawnedUnits = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSpawnedUnits, SetDataSpawnedUnits));
            _dataMinimumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumNumberOfUnits, SetDataMinimumNumberOfUnits));
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
        }

        public DarkPortal(string newRawcode): base(1885621825, newRawcode)
        {
            _dataSpawnedUnitsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnedUnitsRaw, SetDataSpawnedUnitsRaw));
            _dataSpawnedUnits = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSpawnedUnits, SetDataSpawnedUnits));
            _dataMinimumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumNumberOfUnits, SetDataMinimumNumberOfUnits));
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
        }

        public DarkPortal(ObjectDatabase db): base(1885621825, db)
        {
            _dataSpawnedUnitsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnedUnitsRaw, SetDataSpawnedUnitsRaw));
            _dataSpawnedUnits = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSpawnedUnits, SetDataSpawnedUnits));
            _dataMinimumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumNumberOfUnits, SetDataMinimumNumberOfUnits));
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
        }

        public DarkPortal(int newId, ObjectDatabase db): base(1885621825, newId, db)
        {
            _dataSpawnedUnitsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnedUnitsRaw, SetDataSpawnedUnitsRaw));
            _dataSpawnedUnits = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSpawnedUnits, SetDataSpawnedUnits));
            _dataMinimumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumNumberOfUnits, SetDataMinimumNumberOfUnits));
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
        }

        public DarkPortal(string newRawcode, ObjectDatabase db): base(1885621825, newRawcode, db)
        {
            _dataSpawnedUnitsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataSpawnedUnitsRaw, SetDataSpawnedUnitsRaw));
            _dataSpawnedUnits = new Lazy<ObjectProperty<IEnumerable<Unit>>>(() => new ObjectProperty<IEnumerable<Unit>>(GetDataSpawnedUnits, SetDataSpawnedUnits));
            _dataMinimumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMinimumNumberOfUnits, SetDataMinimumNumberOfUnits));
            _dataMaximumNumberOfUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfUnits, SetDataMaximumNumberOfUnits));
        }

        public ObjectProperty<string> DataSpawnedUnitsRaw => _dataSpawnedUnitsRaw.Value;
        public ObjectProperty<IEnumerable<Unit>> DataSpawnedUnits => _dataSpawnedUnits.Value;
        public ObjectProperty<int> DataMinimumNumberOfUnits => _dataMinimumNumberOfUnits.Value;
        public ObjectProperty<int> DataMaximumNumberOfUnits => _dataMaximumNumberOfUnits.Value;
        private string GetDataSpawnedUnitsRaw(int level)
        {
            return _modifications[829449294, level].ValueAsString;
        }

        private void SetDataSpawnedUnitsRaw(int level, string value)
        {
            _modifications[829449294, level] = new LevelObjectDataModification{Id = 829449294, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 1};
        }

        private IEnumerable<Unit> GetDataSpawnedUnits(int level)
        {
            return GetDataSpawnedUnitsRaw(level).ToIEnumerableUnit(this);
        }

        private void SetDataSpawnedUnits(int level, IEnumerable<Unit> value)
        {
            SetDataSpawnedUnitsRaw(level, value.ToRaw(null, null));
        }

        private int GetDataMinimumNumberOfUnits(int level)
        {
            return _modifications[846226510, level].ValueAsInt;
        }

        private void SetDataMinimumNumberOfUnits(int level, int value)
        {
            _modifications[846226510, level] = new LevelObjectDataModification{Id = 846226510, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataMaximumNumberOfUnits(int level)
        {
            return _modifications[863003726, level].ValueAsInt;
        }

        private void SetDataMaximumNumberOfUnits(int level, int value)
        {
            _modifications[863003726, level] = new LevelObjectDataModification{Id = 863003726, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}