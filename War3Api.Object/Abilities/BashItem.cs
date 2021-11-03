using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BashItem : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataNeverMiss;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNeverMissModified;
        public BashItem(): base(2019707201)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
        }

        public BashItem(int newId): base(2019707201, newId)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
        }

        public BashItem(string newRawcode): base(2019707201, newRawcode)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
        }

        public BashItem(ObjectDatabase db): base(2019707201, db)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
        }

        public BashItem(int newId, ObjectDatabase db): base(2019707201, newId, db)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
        }

        public BashItem(string newRawcode, ObjectDatabase db): base(2019707201, newRawcode, db)
        {
            _dataNeverMiss = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataNeverMiss, SetDataNeverMiss));
            _isDataNeverMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNeverMissModified));
        }

        public ObjectProperty<bool> DataNeverMiss => _dataNeverMiss.Value;
        public ReadOnlyObjectProperty<bool> IsDataNeverMissModified => _isDataNeverMissModified.Value;
        private bool GetDataNeverMiss(int level)
        {
            return _modifications[896033352, level].ValueAsBool;
        }

        private void SetDataNeverMiss(int level, bool value)
        {
            _modifications[896033352, level] = new LevelObjectDataModification{Id = 896033352, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataNeverMissModified(int level)
        {
            return _modifications.ContainsKey(896033352, level);
        }
    }
}