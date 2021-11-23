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
    public sealed class ItemReincarnation : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataDelayAfterDeathSeconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDelayAfterDeathSecondsModified;
        private readonly Lazy<ObjectProperty<int>> _dataRestoredLife;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRestoredLifeModified;
        private readonly Lazy<ObjectProperty<int>> _dataRestoredMana(1ForCurrent;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRestoredMana(1ForCurrentModified;
        public ItemReincarnation(): base(1668434241)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _isDataDelayAfterDeathSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathSecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana(1F orCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana(1F orCurrent, SetDataRestoredMana(1F orCurrent));
            _isDataRestoredMana(1F orCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana(1F orCurrentModified));
        }

        public ItemReincarnation(int newId): base(1668434241, newId)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _isDataDelayAfterDeathSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathSecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana(1F orCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana(1F orCurrent, SetDataRestoredMana(1F orCurrent));
            _isDataRestoredMana(1F orCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana(1F orCurrentModified));
        }

        public ItemReincarnation(string newRawcode): base(1668434241, newRawcode)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _isDataDelayAfterDeathSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathSecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana(1F orCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana(1F orCurrent, SetDataRestoredMana(1F orCurrent));
            _isDataRestoredMana(1F orCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana(1F orCurrentModified));
        }

        public ItemReincarnation(ObjectDatabaseBase db): base(1668434241, db)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _isDataDelayAfterDeathSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathSecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana(1F orCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana(1F orCurrent, SetDataRestoredMana(1F orCurrent));
            _isDataRestoredMana(1F orCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana(1F orCurrentModified));
        }

        public ItemReincarnation(int newId, ObjectDatabaseBase db): base(1668434241, newId, db)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _isDataDelayAfterDeathSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathSecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana(1F orCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana(1F orCurrent, SetDataRestoredMana(1F orCurrent));
            _isDataRestoredMana(1F orCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana(1F orCurrentModified));
        }

        public ItemReincarnation(string newRawcode, ObjectDatabaseBase db): base(1668434241, newRawcode, db)
        {
            _dataDelayAfterDeathSeconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathSeconds, SetDataDelayAfterDeathSeconds));
            _isDataDelayAfterDeathSecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathSecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana(1F orCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana(1F orCurrent, SetDataRestoredMana(1F orCurrent));
            _isDataRestoredMana(1F orCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana(1F orCurrentModified));
        }

        public ObjectProperty<int> DataDelayAfterDeathSeconds => _dataDelayAfterDeathSeconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataDelayAfterDeathSecondsModified => _isDataDelayAfterDeathSecondsModified.Value;
        public ObjectProperty<int> DataRestoredLife => _dataRestoredLife.Value;
        public ReadOnlyObjectProperty<bool> IsDataRestoredLifeModified => _isDataRestoredLifeModified.Value;
        public ObjectProperty<int> DataRestoredMana(1ForCurrent => _dataRestoredMana(1F orCurrent.Value;
        public ReadOnlyObjectProperty<bool> IsDataRestoredMana(1ForCurrentModified => _isDataRestoredMana(1F orCurrentModified.Value;
        private int GetDataDelayAfterDeathSeconds(int level)
        {
            return _modifications.GetModification(1684238921, level).ValueAsInt;
        }

        private void SetDataDelayAfterDeathSeconds(int level, int value)
        {
            _modifications[1684238921, level] = new LevelObjectDataModification{Id = 1684238921, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDelayAfterDeathSecondsModified(int level)
        {
            return _modifications.ContainsKey(1684238921, level);
        }

        private int GetDataRestoredLife(int level)
        {
            return _modifications.GetModification(845378153, level).ValueAsInt;
        }

        private void SetDataRestoredLife(int level, int value)
        {
            _modifications[845378153, level] = new LevelObjectDataModification{Id = 845378153, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataRestoredLifeModified(int level)
        {
            return _modifications.ContainsKey(845378153, level);
        }

        private int GetDataRestoredMana(1ForCurrent(int level)
        {
            return _modifications.GetModification(862155369, level).ValueAsInt;
        }

        private void SetDataRestoredMana(1ForCurrent(int level, int value)
        {
            _modifications[862155369, level] = new LevelObjectDataModification{Id = 862155369, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataRestoredMana(1ForCurrentModified(int level)
        {
            return _modifications.ContainsKey(862155369, level);
        }
    }
}