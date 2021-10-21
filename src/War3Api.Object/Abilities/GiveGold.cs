using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class GiveGold : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataGoldGiven;
        public GiveGold(): base(1869039937)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
        }

        public GiveGold(int newId): base(1869039937, newId)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
        }

        public GiveGold(string newRawcode): base(1869039937, newRawcode)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
        }

        public GiveGold(ObjectDatabase db): base(1869039937, db)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
        }

        public GiveGold(int newId, ObjectDatabase db): base(1869039937, newId, db)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
        }

        public GiveGold(string newRawcode, ObjectDatabase db): base(1869039937, newRawcode, db)
        {
            _dataGoldGiven = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataGoldGiven, SetDataGoldGiven));
        }

        public ObjectProperty<int> DataGoldGiven => _dataGoldGiven.Value;
        private int GetDataGoldGiven(int level)
        {
            return _modifications[1819240265, level].ValueAsInt;
        }

        private void SetDataGoldGiven(int level, int value)
        {
            _modifications[1819240265, level] = new LevelObjectDataModification{Id = 1819240265, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}