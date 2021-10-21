using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BladeMasterWindWalk : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataTransitionTime;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ObjectProperty<float>> _dataBackstabDamage_Owk3;
        private readonly Lazy<ObjectProperty<bool>> _dataBackstabDamage_Owk4;
        private readonly Lazy<ObjectProperty<bool>> _dataStartCooldownWhenDecloak;
        public BladeMasterWindWalk(): base(1802981185)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(int newId): base(1802981185, newId)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(string newRawcode): base(1802981185, newRawcode)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(ObjectDatabase db): base(1802981185, db)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(int newId, ObjectDatabase db): base(1802981185, newId, db)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(string newRawcode, ObjectDatabase db): base(1802981185, newRawcode, db)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public ObjectProperty<float> DataTransitionTime => _dataTransitionTime.Value;
        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ObjectProperty<float> DataBackstabDamage_Owk3 => _dataBackstabDamage_Owk3.Value;
        public ObjectProperty<bool> DataBackstabDamage_Owk4 => _dataBackstabDamage_Owk4.Value;
        public ObjectProperty<bool> DataStartCooldownWhenDecloak => _dataStartCooldownWhenDecloak.Value;
        private float GetDataTransitionTime(int level)
        {
            return _modifications[829126479, level].ValueAsFloat;
        }

        private void SetDataTransitionTime(int level, float value)
        {
            _modifications[829126479, level] = new LevelObjectDataModification{Id = 829126479, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications[845903695, level].ValueAsFloat;
        }

        private void SetDataMovementSpeedIncrease(int level, float value)
        {
            _modifications[845903695, level] = new LevelObjectDataModification{Id = 845903695, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataBackstabDamage_Owk3(int level)
        {
            return _modifications[862680911, level].ValueAsFloat;
        }

        private void SetDataBackstabDamage_Owk3(int level, float value)
        {
            _modifications[862680911, level] = new LevelObjectDataModification{Id = 862680911, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataBackstabDamage_Owk4(int level)
        {
            return _modifications[879458127, level].ValueAsBool;
        }

        private void SetDataBackstabDamage_Owk4(int level, bool value)
        {
            _modifications[879458127, level] = new LevelObjectDataModification{Id = 879458127, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private bool GetDataStartCooldownWhenDecloak(int level)
        {
            return _modifications[896235343, level].ValueAsBool;
        }

        private void SetDataStartCooldownWhenDecloak(int level, bool value)
        {
            _modifications[896235343, level] = new LevelObjectDataModification{Id = 896235343, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }
    }
}