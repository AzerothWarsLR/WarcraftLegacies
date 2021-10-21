using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MountainKingThunderClap : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAOEDamage;
        private readonly Lazy<ObjectProperty<float>> _dataSpecificTargetDamage;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedReduction;
        private readonly Lazy<ObjectProperty<float>> _dataMaximumDamage;
        public MountainKingThunderClap(): base(1668565057)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public MountainKingThunderClap(int newId): base(1668565057, newId)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public MountainKingThunderClap(string newRawcode): base(1668565057, newRawcode)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public MountainKingThunderClap(ObjectDatabase db): base(1668565057, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public MountainKingThunderClap(int newId, ObjectDatabase db): base(1668565057, newId, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public MountainKingThunderClap(string newRawcode, ObjectDatabase db): base(1668565057, newRawcode, db)
        {
            _dataAOEDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAOEDamage, SetDataAOEDamage));
            _dataSpecificTargetDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataSpecificTargetDamage, SetDataSpecificTargetDamage));
            _dataMovementSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedReduction, SetDataMovementSpeedReduction));
            _dataAttackSpeedReduction = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedReduction, SetDataAttackSpeedReduction));
            _dataMaximumDamage = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMaximumDamage, SetDataMaximumDamage));
        }

        public ObjectProperty<float> DataAOEDamage => _dataAOEDamage.Value;
        public ObjectProperty<float> DataSpecificTargetDamage => _dataSpecificTargetDamage.Value;
        public ObjectProperty<float> DataMovementSpeedReduction => _dataMovementSpeedReduction.Value;
        public ObjectProperty<float> DataAttackSpeedReduction => _dataAttackSpeedReduction.Value;
        public ObjectProperty<float> DataMaximumDamage => _dataMaximumDamage.Value;
        private float GetDataAOEDamage(int level)
        {
            return _modifications[828601416, level].ValueAsFloat;
        }

        private void SetDataAOEDamage(int level, float value)
        {
            _modifications[828601416, level] = new LevelObjectDataModification{Id = 828601416, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataSpecificTargetDamage(int level)
        {
            return _modifications[845378632, level].ValueAsFloat;
        }

        private void SetDataSpecificTargetDamage(int level, float value)
        {
            _modifications[845378632, level] = new LevelObjectDataModification{Id = 845378632, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataMovementSpeedReduction(int level)
        {
            return _modifications[862155848, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedReduction(int level, float value)
        {
            _modifications[862155848, level] = new LevelObjectDataModification{Id = 862155848, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataAttackSpeedReduction(int level)
        {
            return _modifications[878933064, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedReduction(int level, float value)
        {
            _modifications[878933064, level] = new LevelObjectDataModification{Id = 878933064, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }

        private float GetDataMaximumDamage(int level)
        {
            return _modifications[895710280, level].ValueAsFloat;
        }

        private void SetDataMaximumDamage(int level, float value)
        {
            _modifications[895710280, level] = new LevelObjectDataModification{Id = 895710280, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 5};
        }
    }
}