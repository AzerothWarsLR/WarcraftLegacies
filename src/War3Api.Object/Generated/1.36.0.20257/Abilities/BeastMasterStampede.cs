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
    public sealed class BeastMasterStampede : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataBeastsPerSecond;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBeastsPerSecondModified;
        private readonly Lazy<ObjectProperty<float>> _dataBeastCollisionRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBeastCollisionRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageAmount;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageAmountModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageRadius;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageRadiusModified;
        private readonly Lazy<ObjectProperty<float>> _dataDamageDelay;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDamageDelayModified;
        public BeastMasterStampede(): base(1953713729)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _isDataBeastsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastsPerSecondModified));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _isDataBeastCollisionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastCollisionRadiusModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _isDataDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRadiusModified));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
            _isDataDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDelayModified));
        }

        public BeastMasterStampede(int newId): base(1953713729, newId)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _isDataBeastsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastsPerSecondModified));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _isDataBeastCollisionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastCollisionRadiusModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _isDataDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRadiusModified));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
            _isDataDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDelayModified));
        }

        public BeastMasterStampede(string newRawcode): base(1953713729, newRawcode)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _isDataBeastsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastsPerSecondModified));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _isDataBeastCollisionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastCollisionRadiusModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _isDataDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRadiusModified));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
            _isDataDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDelayModified));
        }

        public BeastMasterStampede(ObjectDatabaseBase db): base(1953713729, db)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _isDataBeastsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastsPerSecondModified));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _isDataBeastCollisionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastCollisionRadiusModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _isDataDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRadiusModified));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
            _isDataDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDelayModified));
        }

        public BeastMasterStampede(int newId, ObjectDatabaseBase db): base(1953713729, newId, db)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _isDataBeastsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastsPerSecondModified));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _isDataBeastCollisionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastCollisionRadiusModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _isDataDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRadiusModified));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
            _isDataDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDelayModified));
        }

        public BeastMasterStampede(string newRawcode, ObjectDatabaseBase db): base(1953713729, newRawcode, db)
        {
            _dataBeastsPerSecond = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBeastsPerSecond, SetDataBeastsPerSecond));
            _isDataBeastsPerSecondModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastsPerSecondModified));
            _dataBeastCollisionRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBeastCollisionRadius, SetDataBeastCollisionRadius));
            _isDataBeastCollisionRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBeastCollisionRadiusModified));
            _dataDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageAmount, SetDataDamageAmount));
            _isDataDamageAmountModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageAmountModified));
            _dataDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageRadius, SetDataDamageRadius));
            _isDataDamageRadiusModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageRadiusModified));
            _dataDamageDelay = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamageDelay, SetDataDamageDelay));
            _isDataDamageDelayModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDamageDelayModified));
        }

        public ObjectProperty<int> DataBeastsPerSecond => _dataBeastsPerSecond.Value;
        public ReadOnlyObjectProperty<bool> IsDataBeastsPerSecondModified => _isDataBeastsPerSecondModified.Value;
        public ObjectProperty<float> DataBeastCollisionRadius => _dataBeastCollisionRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataBeastCollisionRadiusModified => _isDataBeastCollisionRadiusModified.Value;
        public ObjectProperty<float> DataDamageAmount => _dataDamageAmount.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageAmountModified => _isDataDamageAmountModified.Value;
        public ObjectProperty<float> DataDamageRadius => _dataDamageRadius.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageRadiusModified => _isDataDamageRadiusModified.Value;
        public ObjectProperty<float> DataDamageDelay => _dataDamageDelay.Value;
        public ReadOnlyObjectProperty<bool> IsDataDamageDelayModified => _isDataDamageDelayModified.Value;
        private int GetDataBeastsPerSecond(int level)
        {
            return _modifications.GetModification(829715278, level).ValueAsInt;
        }

        private void SetDataBeastsPerSecond(int level, int value)
        {
            _modifications[829715278, level] = new LevelObjectDataModification{Id = 829715278, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataBeastsPerSecondModified(int level)
        {
            return _modifications.ContainsKey(829715278, level);
        }

        private float GetDataBeastCollisionRadius(int level)
        {
            return _modifications.GetModification(846492494, level).ValueAsFloat;
        }

        private void SetDataBeastCollisionRadius(int level, float value)
        {
            _modifications[846492494, level] = new LevelObjectDataModification{Id = 846492494, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataBeastCollisionRadiusModified(int level)
        {
            return _modifications.ContainsKey(846492494, level);
        }

        private float GetDataDamageAmount(int level)
        {
            return _modifications.GetModification(863269710, level).ValueAsFloat;
        }

        private void SetDataDamageAmount(int level, float value)
        {
            _modifications[863269710, level] = new LevelObjectDataModification{Id = 863269710, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDamageAmountModified(int level)
        {
            return _modifications.ContainsKey(863269710, level);
        }

        private float GetDataDamageRadius(int level)
        {
            return _modifications.GetModification(880046926, level).ValueAsFloat;
        }

        private void SetDataDamageRadius(int level, float value)
        {
            _modifications[880046926, level] = new LevelObjectDataModification{Id = 880046926, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataDamageRadiusModified(int level)
        {
            return _modifications.ContainsKey(880046926, level);
        }

        private float GetDataDamageDelay(int level)
        {
            return _modifications.GetModification(896824142, level).ValueAsFloat;
        }

        private void SetDataDamageDelay(int level, float value)
        {
            _modifications[896824142, level] = new LevelObjectDataModification{Id = 896824142, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataDamageDelayModified(int level)
        {
            return _modifications.ContainsKey(896824142, level);
        }
    }
}