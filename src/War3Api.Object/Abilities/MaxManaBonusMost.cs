using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MaxManaBonusMost : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxManaGained;
        public MaxManaBonusMost(): base(1835157825)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusMost(int newId): base(1835157825, newId)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusMost(string newRawcode): base(1835157825, newRawcode)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusMost(ObjectDatabase db): base(1835157825, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusMost(int newId, ObjectDatabase db): base(1835157825, newId, db)
        {
            _dataMaxManaGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxManaGained, SetDataMaxManaGained));
        }

        public MaxManaBonusMost(string newRawcode, ObjectDatabase db): base(1835157825, newRawcode, db)
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