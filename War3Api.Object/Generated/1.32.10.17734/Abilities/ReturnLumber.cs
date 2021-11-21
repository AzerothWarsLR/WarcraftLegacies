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
    public sealed class ReturnLumber : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAcceptsGoldRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAcceptsGoldModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAcceptsGold;
        private readonly Lazy<ObjectProperty<int>> _dataAcceptsLumberRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAcceptsLumberModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAcceptsLumber;
        public ReturnLumber(): base(1835823681)
        {
            _dataAcceptsGoldRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsGoldRaw, SetDataAcceptsGoldRaw));
            _isDataAcceptsGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsGoldModified));
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumberRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsLumberRaw, SetDataAcceptsLumberRaw));
            _isDataAcceptsLumberModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsLumberModified));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnLumber(int newId): base(1835823681, newId)
        {
            _dataAcceptsGoldRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsGoldRaw, SetDataAcceptsGoldRaw));
            _isDataAcceptsGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsGoldModified));
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumberRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsLumberRaw, SetDataAcceptsLumberRaw));
            _isDataAcceptsLumberModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsLumberModified));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnLumber(string newRawcode): base(1835823681, newRawcode)
        {
            _dataAcceptsGoldRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsGoldRaw, SetDataAcceptsGoldRaw));
            _isDataAcceptsGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsGoldModified));
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumberRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsLumberRaw, SetDataAcceptsLumberRaw));
            _isDataAcceptsLumberModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsLumberModified));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnLumber(ObjectDatabaseBase db): base(1835823681, db)
        {
            _dataAcceptsGoldRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsGoldRaw, SetDataAcceptsGoldRaw));
            _isDataAcceptsGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsGoldModified));
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumberRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsLumberRaw, SetDataAcceptsLumberRaw));
            _isDataAcceptsLumberModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsLumberModified));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnLumber(int newId, ObjectDatabaseBase db): base(1835823681, newId, db)
        {
            _dataAcceptsGoldRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsGoldRaw, SetDataAcceptsGoldRaw));
            _isDataAcceptsGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsGoldModified));
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumberRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsLumberRaw, SetDataAcceptsLumberRaw));
            _isDataAcceptsLumberModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsLumberModified));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ReturnLumber(string newRawcode, ObjectDatabaseBase db): base(1835823681, newRawcode, db)
        {
            _dataAcceptsGoldRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsGoldRaw, SetDataAcceptsGoldRaw));
            _isDataAcceptsGoldModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsGoldModified));
            _dataAcceptsGold = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsGold, SetDataAcceptsGold));
            _dataAcceptsLumberRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAcceptsLumberRaw, SetDataAcceptsLumberRaw));
            _isDataAcceptsLumberModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAcceptsLumberModified));
            _dataAcceptsLumber = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAcceptsLumber, SetDataAcceptsLumber));
        }

        public ObjectProperty<int> DataAcceptsGoldRaw => _dataAcceptsGoldRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAcceptsGoldModified => _isDataAcceptsGoldModified.Value;
        public ObjectProperty<bool> DataAcceptsGold => _dataAcceptsGold.Value;
        public ObjectProperty<int> DataAcceptsLumberRaw => _dataAcceptsLumberRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAcceptsLumberModified => _isDataAcceptsLumberModified.Value;
        public ObjectProperty<bool> DataAcceptsLumber => _dataAcceptsLumber.Value;
        private int GetDataAcceptsGoldRaw(int level)
        {
            return _modifications.GetModification(829322322, level).ValueAsInt;
        }

        private void SetDataAcceptsGoldRaw(int level, int value)
        {
            _modifications[829322322, level] = new LevelObjectDataModification{Id = 829322322, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAcceptsGoldModified(int level)
        {
            return _modifications.ContainsKey(829322322, level);
        }

        private bool GetDataAcceptsGold(int level)
        {
            return GetDataAcceptsGoldRaw(level).ToBool(this);
        }

        private void SetDataAcceptsGold(int level, bool value)
        {
            SetDataAcceptsGoldRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataAcceptsLumberRaw(int level)
        {
            return _modifications.GetModification(846099538, level).ValueAsInt;
        }

        private void SetDataAcceptsLumberRaw(int level, int value)
        {
            _modifications[846099538, level] = new LevelObjectDataModification{Id = 846099538, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAcceptsLumberModified(int level)
        {
            return _modifications.ContainsKey(846099538, level);
        }

        private bool GetDataAcceptsLumber(int level)
        {
            return GetDataAcceptsLumberRaw(level).ToBool(this);
        }

        private void SetDataAcceptsLumber(int level, bool value)
        {
            SetDataAcceptsLumberRaw(level, value.ToRaw(0, 1));
        }
    }
}