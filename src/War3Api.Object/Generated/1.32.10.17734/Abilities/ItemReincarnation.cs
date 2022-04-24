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
        private readonly Lazy<ObjectProperty<int>> _dataDelayAfterDeathseconds;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDelayAfterDeathsecondsModified;
        private readonly Lazy<ObjectProperty<int>> _dataRestoredLife;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRestoredLifeModified;
        private readonly Lazy<ObjectProperty<int>> _dataRestoredMana1ForCurrent;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRestoredMana1ForCurrentModified;
        public ItemReincarnation(): base(1668434241)
        {
            _dataDelayAfterDeathseconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathseconds, SetDataDelayAfterDeathseconds));
            _isDataDelayAfterDeathsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathsecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
            _isDataRestoredMana1ForCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana1ForCurrentModified));
        }

        public ItemReincarnation(int newId): base(1668434241, newId)
        {
            _dataDelayAfterDeathseconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathseconds, SetDataDelayAfterDeathseconds));
            _isDataDelayAfterDeathsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathsecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
            _isDataRestoredMana1ForCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana1ForCurrentModified));
        }

        public ItemReincarnation(string newRawcode): base(1668434241, newRawcode)
        {
            _dataDelayAfterDeathseconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathseconds, SetDataDelayAfterDeathseconds));
            _isDataDelayAfterDeathsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathsecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
            _isDataRestoredMana1ForCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana1ForCurrentModified));
        }

        public ItemReincarnation(ObjectDatabaseBase db): base(1668434241, db)
        {
            _dataDelayAfterDeathseconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathseconds, SetDataDelayAfterDeathseconds));
            _isDataDelayAfterDeathsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathsecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
            _isDataRestoredMana1ForCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana1ForCurrentModified));
        }

        public ItemReincarnation(int newId, ObjectDatabaseBase db): base(1668434241, newId, db)
        {
            _dataDelayAfterDeathseconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathseconds, SetDataDelayAfterDeathseconds));
            _isDataDelayAfterDeathsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathsecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
            _isDataRestoredMana1ForCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana1ForCurrentModified));
        }

        public ItemReincarnation(string newRawcode, ObjectDatabaseBase db): base(1668434241, newRawcode, db)
        {
            _dataDelayAfterDeathseconds = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDelayAfterDeathseconds, SetDataDelayAfterDeathseconds));
            _isDataDelayAfterDeathsecondsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDelayAfterDeathsecondsModified));
            _dataRestoredLife = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredLife, SetDataRestoredLife));
            _isDataRestoredLifeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredLifeModified));
            _dataRestoredMana1ForCurrent = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRestoredMana1ForCurrent, SetDataRestoredMana1ForCurrent));
            _isDataRestoredMana1ForCurrentModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRestoredMana1ForCurrentModified));
        }

        public ObjectProperty<int> DataDelayAfterDeathseconds => _dataDelayAfterDeathseconds.Value;
        public ReadOnlyObjectProperty<bool> IsDataDelayAfterDeathsecondsModified => _isDataDelayAfterDeathsecondsModified.Value;
        public ObjectProperty<int> DataRestoredLife => _dataRestoredLife.Value;
        public ReadOnlyObjectProperty<bool> IsDataRestoredLifeModified => _isDataRestoredLifeModified.Value;
        public ObjectProperty<int> DataRestoredMana1ForCurrent => _dataRestoredMana1ForCurrent.Value;
        public ReadOnlyObjectProperty<bool> IsDataRestoredMana1ForCurrentModified => _isDataRestoredMana1ForCurrentModified.Value;
        private int GetDataDelayAfterDeathseconds(int level)
        {
            return _modifications.GetModification(1684238921, level).ValueAsInt;
        }

        private void SetDataDelayAfterDeathseconds(int level, int value)
        {
            _modifications[1684238921, level] = new LevelObjectDataModification{Id = 1684238921, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataDelayAfterDeathsecondsModified(int level)
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

        private int GetDataRestoredMana1ForCurrent(int level)
        {
            return _modifications.GetModification(862155369, level).ValueAsInt;
        }

        private void SetDataRestoredMana1ForCurrent(int level, int value)
        {
            _modifications[862155369, level] = new LevelObjectDataModification{Id = 862155369, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataRestoredMana1ForCurrentModified(int level)
        {
            return _modifications.ContainsKey(862155369, level);
        }
    }
}