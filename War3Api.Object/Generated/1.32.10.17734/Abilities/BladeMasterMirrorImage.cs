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
    public sealed class BladeMasterMirrorImage : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfImages;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataNumberOfImagesModified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Omi2;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Omi2Modified;
        private readonly Lazy<ObjectProperty<float>> _dataData_Omi3;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataData_Omi3Modified;
        private readonly Lazy<ObjectProperty<float>> _dataAnimationDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAnimationDelayModified;
        public BladeMasterMirrorImage(): base(1768771393)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _isDataNumberOfImagesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfImagesModified));
            _dataData_Omi2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi2, SetDataData_Omi2));
            _isDataData_Omi2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi2Modified));
            _dataData_Omi3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi3, SetDataData_Omi3));
            _isDataData_Omi3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi3Modified));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
            _isDataAnimationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAnimationDelayModified));
        }

        public BladeMasterMirrorImage(int newId): base(1768771393, newId)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _isDataNumberOfImagesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfImagesModified));
            _dataData_Omi2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi2, SetDataData_Omi2));
            _isDataData_Omi2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi2Modified));
            _dataData_Omi3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi3, SetDataData_Omi3));
            _isDataData_Omi3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi3Modified));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
            _isDataAnimationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAnimationDelayModified));
        }

        public BladeMasterMirrorImage(string newRawcode): base(1768771393, newRawcode)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _isDataNumberOfImagesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfImagesModified));
            _dataData_Omi2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi2, SetDataData_Omi2));
            _isDataData_Omi2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi2Modified));
            _dataData_Omi3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi3, SetDataData_Omi3));
            _isDataData_Omi3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi3Modified));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
            _isDataAnimationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAnimationDelayModified));
        }

        public BladeMasterMirrorImage(ObjectDatabaseBase db): base(1768771393, db)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _isDataNumberOfImagesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfImagesModified));
            _dataData_Omi2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi2, SetDataData_Omi2));
            _isDataData_Omi2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi2Modified));
            _dataData_Omi3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi3, SetDataData_Omi3));
            _isDataData_Omi3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi3Modified));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
            _isDataAnimationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAnimationDelayModified));
        }

        public BladeMasterMirrorImage(int newId, ObjectDatabaseBase db): base(1768771393, newId, db)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _isDataNumberOfImagesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfImagesModified));
            _dataData_Omi2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi2, SetDataData_Omi2));
            _isDataData_Omi2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi2Modified));
            _dataData_Omi3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi3, SetDataData_Omi3));
            _isDataData_Omi3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi3Modified));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
            _isDataAnimationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAnimationDelayModified));
        }

        public BladeMasterMirrorImage(string newRawcode, ObjectDatabaseBase db): base(1768771393, newRawcode, db)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _isDataNumberOfImagesModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataNumberOfImagesModified));
            _dataData_Omi2 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi2, SetDataData_Omi2));
            _isDataData_Omi2Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi2Modified));
            _dataData_Omi3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataData_Omi3, SetDataData_Omi3));
            _isDataData_Omi3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataData_Omi3Modified));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
            _isDataAnimationDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAnimationDelayModified));
        }

        public ObjectProperty<int> DataNumberOfImages => _dataNumberOfImages.Value;
        public ReadOnlyObjectProperty<bool> IsDataNumberOfImagesModified => _isDataNumberOfImagesModified.Value;
        public ObjectProperty<float> DataData_Omi2 => _dataData_Omi2.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Omi2Modified => _isDataData_Omi2Modified.Value;
        public ObjectProperty<float> DataData_Omi3 => _dataData_Omi3.Value;
        public ReadOnlyObjectProperty<bool> IsDataData_Omi3Modified => _isDataData_Omi3Modified.Value;
        public ObjectProperty<float> DataAnimationDelay => _dataAnimationDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataAnimationDelayModified => _isDataAnimationDelayModified.Value;
        private int GetDataNumberOfImages(int level)
        {
            return _modifications.GetModification(828992847, level).ValueAsInt;
        }

        private void SetDataNumberOfImages(int level, int value)
        {
            _modifications[828992847, level] = new LevelObjectDataModification{Id = 828992847, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataNumberOfImagesModified(int level)
        {
            return _modifications.ContainsKey(828992847, level);
        }

        private float GetDataData_Omi2(int level)
        {
            return _modifications.GetModification(845770063, level).ValueAsFloat;
        }

        private void SetDataData_Omi2(int level, float value)
        {
            _modifications[845770063, level] = new LevelObjectDataModification{Id = 845770063, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataData_Omi2Modified(int level)
        {
            return _modifications.ContainsKey(845770063, level);
        }

        private float GetDataData_Omi3(int level)
        {
            return _modifications.GetModification(862547279, level).ValueAsFloat;
        }

        private void SetDataData_Omi3(int level, float value)
        {
            _modifications[862547279, level] = new LevelObjectDataModification{Id = 862547279, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataData_Omi3Modified(int level)
        {
            return _modifications.ContainsKey(862547279, level);
        }

        private float GetDataAnimationDelay(int level)
        {
            return _modifications.GetModification(879324495, level).ValueAsFloat;
        }

        private void SetDataAnimationDelay(int level, float value)
        {
            _modifications[879324495, level] = new LevelObjectDataModification{Id = 879324495, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataAnimationDelayModified(int level)
        {
            return _modifications.ContainsKey(879324495, level);
        }
    }
}