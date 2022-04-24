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
    public sealed class WispHarvest : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLumberPerInterval;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLumberPerIntervalModified;
        private readonly Lazy<ObjectProperty<int>> _dataIntervalsBeforeChangingTrees;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataIntervalsBeforeChangingTreesModified;
        private readonly Lazy<ObjectProperty<float>> _dataArtAttachmentHeight;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataArtAttachmentHeightModified;
        public WispHarvest(): base(1634236225)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _isDataLumberPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberPerIntervalModified));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _isDataIntervalsBeforeChangingTreesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalsBeforeChangingTreesModified));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
            _isDataArtAttachmentHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtAttachmentHeightModified));
        }

        public WispHarvest(int newId): base(1634236225, newId)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _isDataLumberPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberPerIntervalModified));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _isDataIntervalsBeforeChangingTreesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalsBeforeChangingTreesModified));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
            _isDataArtAttachmentHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtAttachmentHeightModified));
        }

        public WispHarvest(string newRawcode): base(1634236225, newRawcode)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _isDataLumberPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberPerIntervalModified));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _isDataIntervalsBeforeChangingTreesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalsBeforeChangingTreesModified));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
            _isDataArtAttachmentHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtAttachmentHeightModified));
        }

        public WispHarvest(ObjectDatabaseBase db): base(1634236225, db)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _isDataLumberPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberPerIntervalModified));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _isDataIntervalsBeforeChangingTreesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalsBeforeChangingTreesModified));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
            _isDataArtAttachmentHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtAttachmentHeightModified));
        }

        public WispHarvest(int newId, ObjectDatabaseBase db): base(1634236225, newId, db)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _isDataLumberPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberPerIntervalModified));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _isDataIntervalsBeforeChangingTreesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalsBeforeChangingTreesModified));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
            _isDataArtAttachmentHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtAttachmentHeightModified));
        }

        public WispHarvest(string newRawcode, ObjectDatabaseBase db): base(1634236225, newRawcode, db)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _isDataLumberPerIntervalModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLumberPerIntervalModified));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _isDataIntervalsBeforeChangingTreesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataIntervalsBeforeChangingTreesModified));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
            _isDataArtAttachmentHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataArtAttachmentHeightModified));
        }

        public ObjectProperty<float> DataLumberPerInterval => _dataLumberPerInterval.Value;
        public ReadOnlyObjectProperty<bool> IsDataLumberPerIntervalModified => _isDataLumberPerIntervalModified.Value;
        public ObjectProperty<int> DataIntervalsBeforeChangingTrees => _dataIntervalsBeforeChangingTrees.Value;
        public ReadOnlyObjectProperty<bool> IsDataIntervalsBeforeChangingTreesModified => _isDataIntervalsBeforeChangingTreesModified.Value;
        public ObjectProperty<float> DataArtAttachmentHeight => _dataArtAttachmentHeight.Value;
        public ReadOnlyObjectProperty<bool> IsDataArtAttachmentHeightModified => _isDataArtAttachmentHeightModified.Value;
        private float GetDataLumberPerInterval(int level)
        {
            return _modifications.GetModification(828467287, level).ValueAsFloat;
        }

        private void SetDataLumberPerInterval(int level, float value)
        {
            _modifications[828467287, level] = new LevelObjectDataModification{Id = 828467287, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataLumberPerIntervalModified(int level)
        {
            return _modifications.ContainsKey(828467287, level);
        }

        private int GetDataIntervalsBeforeChangingTrees(int level)
        {
            return _modifications.GetModification(845244503, level).ValueAsInt;
        }

        private void SetDataIntervalsBeforeChangingTrees(int level, int value)
        {
            _modifications[845244503, level] = new LevelObjectDataModification{Id = 845244503, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataIntervalsBeforeChangingTreesModified(int level)
        {
            return _modifications.ContainsKey(845244503, level);
        }

        private float GetDataArtAttachmentHeight(int level)
        {
            return _modifications.GetModification(862021719, level).ValueAsFloat;
        }

        private void SetDataArtAttachmentHeight(int level, float value)
        {
            _modifications[862021719, level] = new LevelObjectDataModification{Id = 862021719, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataArtAttachmentHeightModified(int level)
        {
            return _modifications.ContainsKey(862021719, level);
        }
    }
}