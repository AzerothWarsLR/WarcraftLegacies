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
    public sealed class GiveLumber : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataLumberGiven;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberGivenModified;
        public GiveLumber(): base(1970030913)
        {
            _dataLumberGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberGiven, SetDataLumberGiven));
            _isDataLumberGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberGivenModified));
        }

        public GiveLumber(int newId): base(1970030913, newId)
        {
            _dataLumberGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberGiven, SetDataLumberGiven));
            _isDataLumberGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberGivenModified));
        }

        public GiveLumber(string newRawcode): base(1970030913, newRawcode)
        {
            _dataLumberGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberGiven, SetDataLumberGiven));
            _isDataLumberGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberGivenModified));
        }

        public GiveLumber(ObjectDatabaseBase db): base(1970030913, db)
        {
            _dataLumberGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberGiven, SetDataLumberGiven));
            _isDataLumberGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberGivenModified));
        }

        public GiveLumber(int newId, ObjectDatabaseBase db): base(1970030913, newId, db)
        {
            _dataLumberGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberGiven, SetDataLumberGiven));
            _isDataLumberGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberGivenModified));
        }

        public GiveLumber(string newRawcode, ObjectDatabaseBase db): base(1970030913, newRawcode, db)
        {
            _dataLumberGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLumberGiven, SetDataLumberGiven));
            _isDataLumberGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberGivenModified));
        }

        public ObjectProperty<int> DataLumberGiven => _dataLumberGiven.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberGivenModified => _isDataLumberGivenModified.Value;
        private int GetDataLumberGiven(int level)
        {
            return _modifications.GetModification(1836411977, level).ValueAsInt;
        }

        private void SetDataLumberGiven(int level, int value)
        {
            _modifications[1836411977, level] = new LevelObjectDataModification{Id = 1836411977, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLumberGivenModified(int level)
        {
            return _modifications.ContainsKey(1836411977, level);
        }
    }
}