using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BeastMasterStampede : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataBeastsPerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataBeastCollisionRadius;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDelay;
        public BeastMasterStampede(): base(1953713729)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
        }

        public BeastMasterStampede(int newId): base(1953713729, newId)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
        }

        public BeastMasterStampede(string newRawcode): base(1953713729, newRawcode)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
        }

        public BeastMasterStampede(ObjectDatabase db): base(1953713729, db)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
        }

        public BeastMasterStampede(int newId, ObjectDatabase db): base(1953713729, newId, db)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
        }

        public BeastMasterStampede(string newRawcode, ObjectDatabase db): base(1953713729, newRawcode, db)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
        }

        public ObjectProperty<int> DataBeastsPerSecond => _dataBeastsPerSecond.Value;
        public ObjectProperty<float> DataBeastCollisionRadius => _dataBeastCollisionRadius.Value;
        public ObjectProperty<float> DataDamageAmount => _dataDamageAmount.Value;
        public ObjectProperty<float> DataDamageRadius => _dataDamageRadius.Value;
        public ObjectProperty<float> DataDamageDelay => _dataDamageDelay.Value;
        private int GetDataBeastsPerSecond(int level)
        {
            return _modifications[829715278, level].ValueAsInt;
        }

        private void SetDataBeastsPerSecond(int level, int value)
        {
            _modifications[829715278, level] = new LevelObjectDataModification{Id = 829715278, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataBeastCollisionRadius(int level)
        {
            return _modifications[846492494, level].ValueAsFloat;
        }

        private void SetDataBeastCollisionRadius(int level, float value)
        {
            _modifications[846492494, level] = new LevelObjectDataModification{Id = 846492494, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataDamageAmount(int level)
        {
            return _modifications[863269710, level].ValueAsFloat;
        }

        private void SetDataDamageAmount(int level, float value)
        {
            _modifications[863269710, level] = new LevelObjectDataModification{Id = 863269710, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataDamageRadius(int level)
        {
            return _modifications[880046926, level].ValueAsFloat;
        }

        private void SetDataDamageRadius(int level, float value)
        {
            _modifications[880046926, level] = new LevelObjectDataModification{Id = 880046926, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataDamageDelay(int level)
        {
            return _modifications[896824142, level].ValueAsFloat;
        }

        private void SetDataDamageDelay(int level, float value)
        {
            _modifications[896824142, level] = new LevelObjectDataModification{Id = 896824142, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}