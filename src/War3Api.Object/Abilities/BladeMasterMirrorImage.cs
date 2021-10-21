using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BladeMasterMirrorImage : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataNumberOfImages;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDealt;
        private readonly Lazy<ObjectProperty<float>> _dataDamageTaken;
        private readonly Lazy<ObjectProperty<float>> _dataAnimationDelay;
        public BladeMasterMirrorImage(): base(1768771393)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
        }

        public BladeMasterMirrorImage(int newId): base(1768771393, newId)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
        }

        public BladeMasterMirrorImage(string newRawcode): base(1768771393, newRawcode)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
        }

        public BladeMasterMirrorImage(ObjectDatabase db): base(1768771393, db)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
        }

        public BladeMasterMirrorImage(int newId, ObjectDatabase db): base(1768771393, newId, db)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
        }

        public BladeMasterMirrorImage(string newRawcode, ObjectDatabase db): base(1768771393, newRawcode, db)
        {
            _dataNumberOfImages = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataNumberOfImages, SetDataNumberOfImages));
            _dataDamageDealt = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDealt, SetDataDamageDealt));
            _dataDamageTaken = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageTaken, SetDataDamageTaken));
            _dataAnimationDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAnimationDelay, SetDataAnimationDelay));
        }

        public ObjectProperty<int> DataNumberOfImages => _dataNumberOfImages.Value;
        public ObjectProperty<float> DataDamageDealt => _dataDamageDealt.Value;
        public ObjectProperty<float> DataDamageTaken => _dataDamageTaken.Value;
        public ObjectProperty<float> DataAnimationDelay => _dataAnimationDelay.Value;
        private int GetDataNumberOfImages(int level)
        {
            return _modifications[828992847, level].ValueAsInt;
        }

        private void SetDataNumberOfImages(int level, int value)
        {
            _modifications[828992847, level] = new LevelObjectDataModification{Id = 828992847, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamageDealt(int level)
        {
            return _modifications[845770063, level].ValueAsFloat;
        }

        private void SetDataDamageDealt(int level, float value)
        {
            _modifications[845770063, level] = new LevelObjectDataModification{Id = 845770063, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageTaken(int level)
        {
            return _modifications[862547279, level].ValueAsFloat;
        }

        private void SetDataDamageTaken(int level, float value)
        {
            _modifications[862547279, level] = new LevelObjectDataModification{Id = 862547279, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAnimationDelay(int level)
        {
            return _modifications[879324495, level].ValueAsFloat;
        }

        private void SetDataAnimationDelay(int level, float value)
        {
            _modifications[879324495, level] = new LevelObjectDataModification{Id = 879324495, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}