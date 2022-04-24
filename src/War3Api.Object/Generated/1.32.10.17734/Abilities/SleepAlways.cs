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
    public sealed class SleepAlways : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataSleepOnceRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataSleepOnceModified;
        private readonly Lazy<ObjectProperty<bool>> _dataSleepOnce;
        private readonly Lazy<ObjectProperty<int>> _dataAllowOnAnyPlayerSlotRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAllowOnAnyPlayerSlotModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAllowOnAnyPlayerSlot;
        public SleepAlways(): base(1634497345)
        {
            _dataSleepOnceRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSleepOnceRaw, SetDataSleepOnceRaw));
            _isDataSleepOnceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSleepOnceModified));
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlotRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowOnAnyPlayerSlotRaw, SetDataAllowOnAnyPlayerSlotRaw));
            _isDataAllowOnAnyPlayerSlotModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowOnAnyPlayerSlotModified));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(int newId): base(1634497345, newId)
        {
            _dataSleepOnceRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSleepOnceRaw, SetDataSleepOnceRaw));
            _isDataSleepOnceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSleepOnceModified));
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlotRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowOnAnyPlayerSlotRaw, SetDataAllowOnAnyPlayerSlotRaw));
            _isDataAllowOnAnyPlayerSlotModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowOnAnyPlayerSlotModified));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(string newRawcode): base(1634497345, newRawcode)
        {
            _dataSleepOnceRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSleepOnceRaw, SetDataSleepOnceRaw));
            _isDataSleepOnceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSleepOnceModified));
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlotRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowOnAnyPlayerSlotRaw, SetDataAllowOnAnyPlayerSlotRaw));
            _isDataAllowOnAnyPlayerSlotModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowOnAnyPlayerSlotModified));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(ObjectDatabaseBase db): base(1634497345, db)
        {
            _dataSleepOnceRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSleepOnceRaw, SetDataSleepOnceRaw));
            _isDataSleepOnceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSleepOnceModified));
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlotRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowOnAnyPlayerSlotRaw, SetDataAllowOnAnyPlayerSlotRaw));
            _isDataAllowOnAnyPlayerSlotModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowOnAnyPlayerSlotModified));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(int newId, ObjectDatabaseBase db): base(1634497345, newId, db)
        {
            _dataSleepOnceRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSleepOnceRaw, SetDataSleepOnceRaw));
            _isDataSleepOnceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSleepOnceModified));
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlotRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowOnAnyPlayerSlotRaw, SetDataAllowOnAnyPlayerSlotRaw));
            _isDataAllowOnAnyPlayerSlotModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowOnAnyPlayerSlotModified));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public SleepAlways(string newRawcode, ObjectDatabaseBase db): base(1634497345, newRawcode, db)
        {
            _dataSleepOnceRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataSleepOnceRaw, SetDataSleepOnceRaw));
            _isDataSleepOnceModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataSleepOnceModified));
            _dataSleepOnce = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataSleepOnce, SetDataSleepOnce));
            _dataAllowOnAnyPlayerSlotRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAllowOnAnyPlayerSlotRaw, SetDataAllowOnAnyPlayerSlotRaw));
            _isDataAllowOnAnyPlayerSlotModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAllowOnAnyPlayerSlotModified));
            _dataAllowOnAnyPlayerSlot = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAllowOnAnyPlayerSlot, SetDataAllowOnAnyPlayerSlot));
        }

        public ObjectProperty<int> DataSleepOnceRaw => _dataSleepOnceRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataSleepOnceModified => _isDataSleepOnceModified.Value;
        public ObjectProperty<bool> DataSleepOnce => _dataSleepOnce.Value;
        public ObjectProperty<int> DataAllowOnAnyPlayerSlotRaw => _dataAllowOnAnyPlayerSlotRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAllowOnAnyPlayerSlotModified => _isDataAllowOnAnyPlayerSlotModified.Value;
        public ObjectProperty<bool> DataAllowOnAnyPlayerSlot => _dataAllowOnAnyPlayerSlot.Value;
        private int GetDataSleepOnceRaw(int level)
        {
            return _modifications.GetModification(828468339, level).ValueAsInt;
        }

        private void SetDataSleepOnceRaw(int level, int value)
        {
            _modifications[828468339, level] = new LevelObjectDataModification{Id = 828468339, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataSleepOnceModified(int level)
        {
            return _modifications.ContainsKey(828468339, level);
        }

        private bool GetDataSleepOnce(int level)
        {
            return GetDataSleepOnceRaw(level).ToBool(this);
        }

        private void SetDataSleepOnce(int level, bool value)
        {
            SetDataSleepOnceRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataAllowOnAnyPlayerSlotRaw(int level)
        {
            return _modifications.GetModification(845245555, level).ValueAsInt;
        }

        private void SetDataAllowOnAnyPlayerSlotRaw(int level, int value)
        {
            _modifications[845245555, level] = new LevelObjectDataModification{Id = 845245555, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataAllowOnAnyPlayerSlotModified(int level)
        {
            return _modifications.ContainsKey(845245555, level);
        }

        private bool GetDataAllowOnAnyPlayerSlot(int level)
        {
            return GetDataAllowOnAnyPlayerSlotRaw(level).ToBool(this);
        }

        private void SetDataAllowOnAnyPlayerSlot(int level, bool value)
        {
            SetDataAllowOnAnyPlayerSlotRaw(level, value.ToRaw(0, 1));
        }
    }
}