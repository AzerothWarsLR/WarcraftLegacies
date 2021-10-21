using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MaxManaBonusLeast : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxManaGained;
        public MaxManaBonusLeast(): base(1651329345)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusLeast(int newId): base(1651329345, newId)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusLeast(string newRawcode): base(1651329345, newRawcode)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusLeast(ObjectDatabase db): base(1651329345, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusLeast(int newId, ObjectDatabase db): base(1651329345, newId, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusLeast(string newRawcode, ObjectDatabase db): base(1651329345, newRawcode, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public ObjectProperty<int> DataMaxManaGained => _dataMaxManaGained.Value;
        private int GetDataMaxManaGained(int level)
        {
            return _modifications[1851878729, level].ValueAsInt;
        }

        private void SetDataMaxManaGained(int level, int value)
        {
            _modifications[1851878729, level] = new LevelObjectDataModification{Id = 1851878729, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}