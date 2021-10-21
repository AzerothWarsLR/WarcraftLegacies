using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ThunderClapCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDamage;
        private readonly Lazy<ObjectProperty<float>> _dataExtraDamageToTarget;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        public ThunderClapCreep(): base(1668563777)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ThunderClapCreep(int newId): base(1668563777, newId)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ThunderClapCreep(string newRawcode): base(1668563777, newRawcode)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ThunderClapCreep(ObjectDatabase db): base(1668563777, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ThunderClapCreep(int newId, ObjectDatabase db): base(1668563777, newId, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ThunderClapCreep(string newRawcode, ObjectDatabase db): base(1668563777, newRawcode, db)
        {
            _dataDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamage, SetDataDamage));
            _dataExtraDamageToTarget = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataExtraDamageToTarget, SetDataExtraDamageToTarget));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
        }

        public ObjectProperty<float> DataDamage => _dataDamage.Value;
        public ObjectProperty<float> DataExtraDamageToTarget => _dataExtraDamageToTarget.Value;
        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        private float GetDataDamage(int level)
        {
            return _modifications[828601411, level].ValueAsFloat;
        }

        private void SetDataDamage(int level, float value)
        {
            _modifications[828601411, level] = new LevelObjectDataModification{Id = 828601411, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataExtraDamageToTarget(int level)
        {
            return _modifications[845378627, level].ValueAsFloat;
        }

        private void SetDataExtraDamageToTarget(int level, float value)
        {
            _modifications[845378627, level] = new LevelObjectDataModification{Id = 845378627, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications[862155843, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[862155843, level] = new LevelObjectDataModification{Id = 862155843, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications[878933059, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[878933059, level] = new LevelObjectDataModification{Id = 878933059, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}