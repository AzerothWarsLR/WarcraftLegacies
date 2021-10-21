using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Exhume : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaximumNumberOfCorpses;
        private readonly Lazy<ObjectProperty<string>> _dataUnitTypeRaw;
        private readonly Lazy<ObjectProperty<Unit>> _dataUnitType;
        public Exhume(): base(1752720705)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public Exhume(int newId): base(1752720705, newId)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public Exhume(string newRawcode): base(1752720705, newRawcode)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public Exhume(ObjectDatabase db): base(1752720705, db)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public Exhume(int newId, ObjectDatabase db): base(1752720705, newId, db)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public Exhume(string newRawcode, ObjectDatabase db): base(1752720705, newRawcode, db)
        {
            _dataMaximumNumberOfCorpses = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumNumberOfCorpses, SetDataMaximumNumberOfCorpses));
            _dataUnitTypeRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataUnitTypeRaw, SetDataUnitTypeRaw));
            _dataUnitType = new Lazy<ObjectProperty<Unit>>(() => new ObjectProperty<Unit>(GetDataUnitType, SetDataUnitType));
        }

        public ObjectProperty<int> DataMaximumNumberOfCorpses => _dataMaximumNumberOfCorpses.Value;
        public ObjectProperty<string> DataUnitTypeRaw => _dataUnitTypeRaw.Value;
        public ObjectProperty<Unit> DataUnitType => _dataUnitType.Value;
        private int GetDataMaximumNumberOfCorpses(int level)
        {
            return _modifications[828930149, level].ValueAsInt;
        }

        private void SetDataMaximumNumberOfCorpses(int level, int value)
        {
            _modifications[828930149, level] = new LevelObjectDataModification{Id = 828930149, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private string GetDataUnitTypeRaw(int level)
        {
            return _modifications[1969780837, level].ValueAsString;
        }

        private void SetDataUnitTypeRaw(int level, string value)
        {
            _modifications[1969780837, level] = new LevelObjectDataModification{Id = 1969780837, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private Unit GetDataUnitType(int level)
        {
            return GetDataUnitTypeRaw(level).ToUnit(this);
        }

        private void SetDataUnitType(int level, Unit value)
        {
            SetDataUnitTypeRaw(level, value.ToRaw(null, null));
        }
    }
}