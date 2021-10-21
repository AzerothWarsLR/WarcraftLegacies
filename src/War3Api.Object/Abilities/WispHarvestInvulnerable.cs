using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WispHarvestInvulnerable : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataLumberPerInterval;
        private readonly Lazy<ObjectProperty<int>> _dataIntervalsBeforeChangingTrees;
        private readonly Lazy<ObjectProperty<float>> _dataArtAttachmentHeight;
        public WispHarvestInvulnerable(): base(845707073)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
        }

        public WispHarvestInvulnerable(int newId): base(845707073, newId)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
        }

        public WispHarvestInvulnerable(string newRawcode): base(845707073, newRawcode)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
        }

        public WispHarvestInvulnerable(ObjectDatabase db): base(845707073, db)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
        }

        public WispHarvestInvulnerable(int newId, ObjectDatabase db): base(845707073, newId, db)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
        }

        public WispHarvestInvulnerable(string newRawcode, ObjectDatabase db): base(845707073, newRawcode, db)
        {
            _dataLumberPerInterval = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataLumberPerInterval, SetDataLumberPerInterval));
            _dataIntervalsBeforeChangingTrees = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataIntervalsBeforeChangingTrees, SetDataIntervalsBeforeChangingTrees));
            _dataArtAttachmentHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataArtAttachmentHeight, SetDataArtAttachmentHeight));
        }

        public ObjectProperty<float> DataLumberPerInterval => _dataLumberPerInterval.Value;
        public ObjectProperty<int> DataIntervalsBeforeChangingTrees => _dataIntervalsBeforeChangingTrees.Value;
        public ObjectProperty<float> DataArtAttachmentHeight => _dataArtAttachmentHeight.Value;
        private float GetDataLumberPerInterval(int level)
        {
            return _modifications[828467287, level].ValueAsFloat;
        }

        private void SetDataLumberPerInterval(int level, float value)
        {
            _modifications[828467287, level] = new LevelObjectDataModification{Id = 828467287, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private int GetDataIntervalsBeforeChangingTrees(int level)
        {
            return _modifications[845244503, level].ValueAsInt;
        }

        private void SetDataIntervalsBeforeChangingTrees(int level, int value)
        {
            _modifications[845244503, level] = new LevelObjectDataModification{Id = 845244503, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataArtAttachmentHeight(int level)
        {
            return _modifications[862021719, level].ValueAsFloat;
        }

        private void SetDataArtAttachmentHeight(int level, float value)
        {
            _modifications[862021719, level] = new LevelObjectDataModification{Id = 862021719, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }
    }
}