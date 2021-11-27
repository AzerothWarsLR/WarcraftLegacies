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
    public sealed class ItemChangeTOD : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNewTimeOfDayHour;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNewTimeOfDayHourModified;
        private readonly Lazy<ObjectProperty<int>> _dataNewTimeOfDayMinute;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNewTimeOfDayMinuteModified;
        public ItemChangeTOD(): base(1952663873)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _isDataNewTimeOfDayHourModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayHourModified));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
            _isDataNewTimeOfDayMinuteModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayMinuteModified));
        }

        public ItemChangeTOD(int newId): base(1952663873, newId)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _isDataNewTimeOfDayHourModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayHourModified));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
            _isDataNewTimeOfDayMinuteModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayMinuteModified));
        }

        public ItemChangeTOD(string newRawcode): base(1952663873, newRawcode)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _isDataNewTimeOfDayHourModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayHourModified));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
            _isDataNewTimeOfDayMinuteModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayMinuteModified));
        }

        public ItemChangeTOD(ObjectDatabaseBase db): base(1952663873, db)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _isDataNewTimeOfDayHourModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayHourModified));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
            _isDataNewTimeOfDayMinuteModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayMinuteModified));
        }

        public ItemChangeTOD(int newId, ObjectDatabaseBase db): base(1952663873, newId, db)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _isDataNewTimeOfDayHourModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayHourModified));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
            _isDataNewTimeOfDayMinuteModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayMinuteModified));
        }

        public ItemChangeTOD(string newRawcode, ObjectDatabaseBase db): base(1952663873, newRawcode, db)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _isDataNewTimeOfDayHourModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayHourModified));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
            _isDataNewTimeOfDayMinuteModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNewTimeOfDayMinuteModified));
        }

        public ObjectProperty<int> DataNewTimeOfDayHour => _dataNewTimeOfDayHour.Value;
        public ReadOnlyObjectProperty<bool> IsDataNewTimeOfDayHourModified => _isDataNewTimeOfDayHourModified.Value;
        public ObjectProperty<int> DataNewTimeOfDayMinute => _dataNewTimeOfDayMinute.Value;
        public ReadOnlyObjectProperty<bool> IsDataNewTimeOfDayMinuteModified => _isDataNewTimeOfDayMinuteModified.Value;
        private int GetDataNewTimeOfDayHour(int level)
        {
            return _modifications.GetModification(829711209, level).ValueAsInt;
        }

        private void SetDataNewTimeOfDayHour(int level, int value)
        {
            _modifications[829711209, level] = new LevelObjectDataModification{Id = 829711209, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNewTimeOfDayHourModified(int level)
        {
            return _modifications.ContainsKey(829711209, level);
        }

        private int GetDataNewTimeOfDayMinute(int level)
        {
            return _modifications.GetModification(846488425, level).ValueAsInt;
        }

        private void SetDataNewTimeOfDayMinute(int level, int value)
        {
            _modifications[846488425, level] = new LevelObjectDataModification{Id = 846488425, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataNewTimeOfDayMinuteModified(int level)
        {
            return _modifications.ContainsKey(846488425, level);
        }
    }
}