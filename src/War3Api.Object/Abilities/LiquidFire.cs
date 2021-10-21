using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class LiquidFire : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataExtraDamagePerSecond;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ObjectProperty<bool>> _dataRepairsAllowed;
        public LiquidFire(): base(1902734401)
        {
            _dataExtraDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamagePerSecond, SetDataExtraDamagePerSecond));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataRepairsAllowed = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRepairsAllowed, SetDataRepairsAllowed));
        }

        public LiquidFire(int newId): base(1902734401, newId)
        {
            _dataExtraDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamagePerSecond, SetDataExtraDamagePerSecond));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataRepairsAllowed = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRepairsAllowed, SetDataRepairsAllowed));
        }

        public LiquidFire(string newRawcode): base(1902734401, newRawcode)
        {
            _dataExtraDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamagePerSecond, SetDataExtraDamagePerSecond));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataRepairsAllowed = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRepairsAllowed, SetDataRepairsAllowed));
        }

        public LiquidFire(ObjectDatabase db): base(1902734401, db)
        {
            _dataExtraDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamagePerSecond, SetDataExtraDamagePerSecond));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataRepairsAllowed = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRepairsAllowed, SetDataRepairsAllowed));
        }

        public LiquidFire(int newId, ObjectDatabase db): base(1902734401, newId, db)
        {
            _dataExtraDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamagePerSecond, SetDataExtraDamagePerSecond));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataRepairsAllowed = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRepairsAllowed, SetDataRepairsAllowed));
        }

        public LiquidFire(string newRawcode, ObjectDatabase db): base(1902734401, newRawcode, db)
        {
            _dataExtraDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamagePerSecond, SetDataExtraDamagePerSecond));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataRepairsAllowed = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRepairsAllowed, SetDataRepairsAllowed));
        }

        public ObjectProperty<float> DataExtraDamagePerSecond => _dataExtraDamagePerSecond.Value;
        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ObjectProperty<bool> DataRepairsAllowed => _dataRepairsAllowed.Value;
        private float GetDataExtraDamagePerSecond(int level)
        {
            return _modifications[829516140, level].ValueAsFloat;
        }

        private void SetDataExtraDamagePerSecond(int level, float value)
        {
            _modifications[829516140, level] = new LevelObjectDataModification{Id = 829516140, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications[846293356, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[846293356, level] = new LevelObjectDataModification{Id = 846293356, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications[863070572, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[863070572, level] = new LevelObjectDataModification{Id = 863070572, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataRepairsAllowed(int level)
        {
            return _modifications[879847788, level].ValueAsBool;
        }

        private void SetDataRepairsAllowed(int level, bool value)
        {
            _modifications[879847788, level] = new LevelObjectDataModification{Id = 879847788, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }
    }
}