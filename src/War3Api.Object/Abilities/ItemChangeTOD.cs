using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemChangeTOD : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNewTimeOfDayHour;
        private readonly Lazy<ObjectProperty<int>> _dataNewTimeOfDayMinute;
        public ItemChangeTOD(): base(1952663873)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
        }

        public ItemChangeTOD(int newId): base(1952663873, newId)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
        }

        public ItemChangeTOD(string newRawcode): base(1952663873, newRawcode)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
        }

        public ItemChangeTOD(ObjectDatabase db): base(1952663873, db)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
        }

        public ItemChangeTOD(int newId, ObjectDatabase db): base(1952663873, newId, db)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
        }

        public ItemChangeTOD(string newRawcode, ObjectDatabase db): base(1952663873, newRawcode, db)
        {
            _dataNewTimeOfDayHour = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayHour, SetDataNewTimeOfDayHour));
            _dataNewTimeOfDayMinute = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNewTimeOfDayMinute, SetDataNewTimeOfDayMinute));
        }

        public ObjectProperty<int> DataNewTimeOfDayHour => _dataNewTimeOfDayHour.Value;
        public ObjectProperty<int> DataNewTimeOfDayMinute => _dataNewTimeOfDayMinute.Value;
        private int GetDataNewTimeOfDayHour(int level)
        {
            return _modifications[829711209, level].ValueAsInt;
        }

        private void SetDataNewTimeOfDayHour(int level, int value)
        {
            _modifications[829711209, level] = new LevelObjectDataModification{Id = 829711209, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataNewTimeOfDayMinute(int level)
        {
            return _modifications[846488425, level].ValueAsInt;
        }

        private void SetDataNewTimeOfDayMinute(int level, int value)
        {
            _modifications[846488425, level] = new LevelObjectDataModification{Id = 846488425, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }
    }
}