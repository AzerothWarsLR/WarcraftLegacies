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
    public sealed class GiveGold : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldGiven;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataGoldGivenModified;
        public GiveGold(): base(1869039937)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
            _isDataGoldGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldGivenModified));
        }

        public GiveGold(int newId): base(1869039937, newId)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
            _isDataGoldGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldGivenModified));
        }

        public GiveGold(string newRawcode): base(1869039937, newRawcode)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
            _isDataGoldGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldGivenModified));
        }

        public GiveGold(ObjectDatabaseBase db): base(1869039937, db)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
            _isDataGoldGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldGivenModified));
        }

        public GiveGold(int newId, ObjectDatabaseBase db): base(1869039937, newId, db)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
            _isDataGoldGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldGivenModified));
        }

        public GiveGold(string newRawcode, ObjectDatabaseBase db): base(1869039937, newRawcode, db)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
            _isDataGoldGivenModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataGoldGivenModified));
        }

        public ObjectProperty<int> DataGoldGiven => _dataGoldGiven.Value;
        public ReadOnlyObjectProperty<bool> IsDataGoldGivenModified => _isDataGoldGivenModified.Value;
        private int GetDataGoldGiven(int level)
        {
            return _modifications.GetModification(1819240265, level).ValueAsInt;
        }

        private void SetDataGoldGiven(int level, int value)
        {
            _modifications[1819240265, level] = new LevelObjectDataModification{Id = 1819240265, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataGoldGivenModified(int level)
        {
            return _modifications.ContainsKey(1819240265, level);
        }
    }
}