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
    public sealed class GrabTree : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAttachDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAttachDelayModified;
        private readonly Lazy<ObjectProperty<float>> _dataRemoveDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRemoveDelayModified;
        private readonly Lazy<ObjectProperty<int>> _dataDisabledAttackIndex;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDisabledAttackIndexModified;
        private readonly Lazy<ObjectProperty<int>> _dataEnabledAttackIndex;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataEnabledAttackIndexModified;
        private readonly Lazy<ObjectProperty<int>> _dataMaximumAttacks;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaximumAttacksModified;
        public GrabTree(): base(1634887489)
        {
            _dataAttachDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttachDelay, SetDataAttachDelay));
            _isDataAttachDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttachDelayModified));
            _dataRemoveDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRemoveDelay, SetDataRemoveDelay));
            _isDataRemoveDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRemoveDelayModified));
            _dataDisabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisabledAttackIndex, SetDataDisabledAttackIndex));
            _isDataDisabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisabledAttackIndexModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataMaximumAttacks = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumAttacks, SetDataMaximumAttacks));
            _isDataMaximumAttacksModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumAttacksModified));
        }

        public GrabTree(int newId): base(1634887489, newId)
        {
            _dataAttachDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttachDelay, SetDataAttachDelay));
            _isDataAttachDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttachDelayModified));
            _dataRemoveDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRemoveDelay, SetDataRemoveDelay));
            _isDataRemoveDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRemoveDelayModified));
            _dataDisabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisabledAttackIndex, SetDataDisabledAttackIndex));
            _isDataDisabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisabledAttackIndexModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataMaximumAttacks = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumAttacks, SetDataMaximumAttacks));
            _isDataMaximumAttacksModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumAttacksModified));
        }

        public GrabTree(string newRawcode): base(1634887489, newRawcode)
        {
            _dataAttachDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttachDelay, SetDataAttachDelay));
            _isDataAttachDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttachDelayModified));
            _dataRemoveDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRemoveDelay, SetDataRemoveDelay));
            _isDataRemoveDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRemoveDelayModified));
            _dataDisabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisabledAttackIndex, SetDataDisabledAttackIndex));
            _isDataDisabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisabledAttackIndexModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataMaximumAttacks = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumAttacks, SetDataMaximumAttacks));
            _isDataMaximumAttacksModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumAttacksModified));
        }

        public GrabTree(ObjectDatabaseBase db): base(1634887489, db)
        {
            _dataAttachDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttachDelay, SetDataAttachDelay));
            _isDataAttachDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttachDelayModified));
            _dataRemoveDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRemoveDelay, SetDataRemoveDelay));
            _isDataRemoveDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRemoveDelayModified));
            _dataDisabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisabledAttackIndex, SetDataDisabledAttackIndex));
            _isDataDisabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisabledAttackIndexModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataMaximumAttacks = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumAttacks, SetDataMaximumAttacks));
            _isDataMaximumAttacksModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumAttacksModified));
        }

        public GrabTree(int newId, ObjectDatabaseBase db): base(1634887489, newId, db)
        {
            _dataAttachDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttachDelay, SetDataAttachDelay));
            _isDataAttachDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttachDelayModified));
            _dataRemoveDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRemoveDelay, SetDataRemoveDelay));
            _isDataRemoveDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRemoveDelayModified));
            _dataDisabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisabledAttackIndex, SetDataDisabledAttackIndex));
            _isDataDisabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisabledAttackIndexModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataMaximumAttacks = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumAttacks, SetDataMaximumAttacks));
            _isDataMaximumAttacksModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumAttacksModified));
        }

        public GrabTree(string newRawcode, ObjectDatabaseBase db): base(1634887489, newRawcode, db)
        {
            _dataAttachDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttachDelay, SetDataAttachDelay));
            _isDataAttachDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAttachDelayModified));
            _dataRemoveDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataRemoveDelay, SetDataRemoveDelay));
            _isDataRemoveDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRemoveDelayModified));
            _dataDisabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDisabledAttackIndex, SetDataDisabledAttackIndex));
            _isDataDisabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDisabledAttackIndexModified));
            _dataEnabledAttackIndex = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataEnabledAttackIndex, SetDataEnabledAttackIndex));
            _isDataEnabledAttackIndexModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataEnabledAttackIndexModified));
            _dataMaximumAttacks = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaximumAttacks, SetDataMaximumAttacks));
            _isDataMaximumAttacksModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaximumAttacksModified));
        }

        public ObjectProperty<float> DataAttachDelay => _dataAttachDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataAttachDelayModified => _isDataAttachDelayModified.Value;
        public ObjectProperty<float> DataRemoveDelay => _dataRemoveDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataRemoveDelayModified => _isDataRemoveDelayModified.Value;
        public ObjectProperty<int> DataDisabledAttackIndex => _dataDisabledAttackIndex.Value;
        public ReadOnlyObjectProperty<bool> IsDataDisabledAttackIndexModified => _isDataDisabledAttackIndexModified.Value;
        public ObjectProperty<int> DataEnabledAttackIndex => _dataEnabledAttackIndex.Value;
        public ReadOnlyObjectProperty<bool> IsDataEnabledAttackIndexModified => _isDataEnabledAttackIndexModified.Value;
        public ObjectProperty<int> DataMaximumAttacks => _dataMaximumAttacks.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaximumAttacksModified => _isDataMaximumAttacksModified.Value;
        private float GetDataAttachDelay(int level)
        {
            return _modifications.GetModification(828469863, level).ValueAsFloat;
        }

        private void SetDataAttachDelay(int level, float value)
        {
            _modifications[828469863, level] = new LevelObjectDataModification{Id = 828469863, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAttachDelayModified(int level)
        {
            return _modifications.ContainsKey(828469863, level);
        }

        private float GetDataRemoveDelay(int level)
        {
            return _modifications.GetModification(845247079, level).ValueAsFloat;
        }

        private void SetDataRemoveDelay(int level, float value)
        {
            _modifications[845247079, level] = new LevelObjectDataModification{Id = 845247079, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataRemoveDelayModified(int level)
        {
            return _modifications.ContainsKey(845247079, level);
        }

        private int GetDataDisabledAttackIndex(int level)
        {
            return _modifications.GetModification(862024295, level).ValueAsInt;
        }

        private void SetDataDisabledAttackIndex(int level, int value)
        {
            _modifications[862024295, level] = new LevelObjectDataModification{Id = 862024295, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDisabledAttackIndexModified(int level)
        {
            return _modifications.ContainsKey(862024295, level);
        }

        private int GetDataEnabledAttackIndex(int level)
        {
            return _modifications.GetModification(878801511, level).ValueAsInt;
        }

        private void SetDataEnabledAttackIndex(int level, int value)
        {
            _modifications[878801511, level] = new LevelObjectDataModification{Id = 878801511, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataEnabledAttackIndexModified(int level)
        {
            return _modifications.ContainsKey(878801511, level);
        }

        private int GetDataMaximumAttacks(int level)
        {
            return _modifications.GetModification(895578727, level).ValueAsInt;
        }

        private void SetDataMaximumAttacks(int level, int value)
        {
            _modifications[895578727, level] = new LevelObjectDataModification{Id = 895578727, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataMaximumAttacksModified(int level)
        {
            return _modifications.ContainsKey(895578727, level);
        }
    }
}