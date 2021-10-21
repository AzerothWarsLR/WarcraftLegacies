using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SleepAlways : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataSleepOnce;
        private readonly Lazy<ObjectProperty<bool>> _dataAllowOnAnyPlayerSlot;
        public SleepAlways(): base(1634497345)
        {
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(int newId): base(1634497345, newId)
        {
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(string newRawcode): base(1634497345, newRawcode)
        {
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(ObjectDatabase db): base(1634497345, db)
        {
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(int newId, ObjectDatabase db): base(1634497345, newId, db)
        {
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(string newRawcode, ObjectDatabase db): base(1634497345, newRawcode, db)
        {
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public ObjectProperty<bool> DataSleepOnce => _dataSleepOnce.Value;
        public ObjectProperty<bool> DataAllowOnAnyPlayerSlot => _dataAllowOnAnyPlayerSlot.Value;
        private bool GetDataSleepOnce(int level)
        {
            return _modifications[828468339, level].ValueAsBool;
        }

        private void SetDataSleepOnce(int level, bool value)
        {
            _modifications[828468339, level] = new LevelObjectDataModification{Id = 828468339, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataAllowOnAnyPlayerSlot(int level)
        {
            return _modifications[845245555, level].ValueAsBool;
        }

        private void SetDataAllowOnAnyPlayerSlot(int level, bool value)
        {
            _modifications[845245555, level] = new LevelObjectDataModification{Id = 845245555, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}