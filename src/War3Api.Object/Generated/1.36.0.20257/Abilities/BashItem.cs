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
    public sealed class BashItem : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNeverMissRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNeverMissModified;
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        public BashItem(): base(2019707201)
        {
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashItem(int newId): base(2019707201, newId)
        {
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashItem(string newRawcode): base(2019707201, newRawcode)
        {
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashItem(ObjectDatabaseBase db): base(2019707201, db)
        {
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashItem(int newId, ObjectDatabaseBase db): base(2019707201, newId, db)
        {
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public BashItem(string newRawcode, ObjectDatabaseBase db): base(2019707201, newRawcode, db)
        {
            _dataNeverMissRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNeverMissRaw, SetDataNeverMissRaw));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
        }

        public ObjectProperty<int> DataNeverMissRaw => _dataNeverMissRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataNeverMissModified => _isDataNeverMissModified.Value;
        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        private int GetDataNeverMissRaw(int level)
        {
            return _modifications.GetModification(896033352, level).ValueAsInt;
        }

        private void SetDataNeverMissRaw(int level, int value)
        {
            _modifications[896033352, level] = new LevelObjectDataModification{Id = 896033352, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataNeverMissModified(int level)
        {
            return _modifications.ContainsKey(896033352, level);
        }

        private bool GetDataNeverMiss(int level)
        {
            return GetDataNeverMissRaw(level).ToBool(this);
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            SetDataNeverMissRaw(level, value.ToRaw(0, 1));
        }
    }
}