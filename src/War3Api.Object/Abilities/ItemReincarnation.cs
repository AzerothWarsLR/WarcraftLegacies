using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemReincarnation : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDelayAfterDeathSeconds;
        private readonly Lazy<ObjectProperty<int>> _dataRestoredLife;
        private readonly Lazy<ObjectProperty<int>> _dataRestoredMana1ForCurrent;
        public ItemReincarnation(): base(1668434241)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
        }

        public ItemReincarnation(int newId): base(1668434241, newId)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
        }

        public ItemReincarnation(string newRawcode): base(1668434241, newRawcode)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
        }

        public ItemReincarnation(ObjectDatabase db): base(1668434241, db)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
        }

        public ItemReincarnation(int newId, ObjectDatabase db): base(1668434241, newId, db)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
        }

        public ItemReincarnation(string newRawcode, ObjectDatabase db): base(1668434241, newRawcode, db)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
        }

        public ObjectProperty<int> DataDelayAfterDeathSeconds => _dataDelayAfterDeathSeconds.Value;
        public ObjectProperty<int> DataRestoredLife => _dataRestoredLife.Value;
        public ObjectProperty<int> DataRestoredMana1ForCurrent => _dataRestoredMana1ForCurrent.Value;
        private int GetDataDelayAfterDeathSeconds(int level)
        {
            return _modifications[1684238921, level].ValueAsInt;
        }

        private void SetDataDelayAfterDeathSeconds(int level, int value)
        {
            _modifications[1684238921, level] = new LevelObjectDataModification{Id = 1684238921, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataRestoredLife(int level)
        {
            return _modifications[845378153, level].ValueAsInt;
        }

        private void SetDataRestoredLife(int level, int value)
        {
            _modifications[845378153, level] = new LevelObjectDataModification{Id = 845378153, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private int GetDataRestoredMana1ForCurrent(int level)
        {
            return _modifications[862155369, level].ValueAsInt;
        }

        private void SetDataRestoredMana1ForCurrent(int level, int value)
        {
            _modifications[862155369, level] = new LevelObjectDataModification{Id = 862155369, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }
    }
}