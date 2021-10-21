using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class LevelMod : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataLevelsGained;
        public LevelMod(): base(1835813185)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
        }

        public LevelMod(int newId): base(1835813185, newId)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
        }

        public LevelMod(string newRawcode): base(1835813185, newRawcode)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
        }

        public LevelMod(ObjectDatabase db): base(1835813185, db)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
        }

        public LevelMod(int newId, ObjectDatabase db): base(1835813185, newId, db)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
        }

        public LevelMod(string newRawcode, ObjectDatabase db): base(1835813185, newRawcode, db)
        {
            _dataLevelsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLevelsGained, SetDataLevelsGained));
        }

        public ObjectProperty<int> DataLevelsGained => _dataLevelsGained.Value;
        private int GetDataLevelsGained(int level)
        {
            return _modifications[1986358345, level].ValueAsInt;
        }

        private void SetDataLevelsGained(int level, int value)
        {
            _modifications[1986358345, level] = new LevelObjectDataModification{Id = 1986358345, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}