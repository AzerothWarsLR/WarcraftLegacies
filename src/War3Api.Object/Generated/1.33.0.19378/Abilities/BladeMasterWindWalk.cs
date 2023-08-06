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
    public sealed class BladeMasterWindWalk : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataTransitionTime;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTransitionTimeModified;
        private readonly Lazy<ObjectProperty<float>> _dataMovementSpeedIncrease;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMovementSpeedIncreaseModified;
        private readonly Lazy<ObjectProperty<float>> _dataBackstabDamage_Owk3;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBackstabDamage_Owk3Modified;
        private readonly Lazy<ObjectProperty<int>> _dataBackstabDamage_Owk4Raw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataBackstabDamage_Owk4Modified;
        private readonly Lazy<ObjectProperty<bool>> _dataBackstabDamage_Owk4;
        private readonly Lazy<ObjectProperty<int>> _dataStartCooldownWhenDecloakRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataStartCooldownWhenDecloakModified;
        private readonly Lazy<ObjectProperty<bool>> _dataStartCooldownWhenDecloak;
        public BladeMasterWindWalk(): base(1802981185)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _isDataTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeModified));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _isDataBackstabDamage_Owk3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk3Modified));
            _dataBackstabDamage_Owk4Raw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamage_Owk4Raw, SetDataBackstabDamage_Owk4Raw));
            _isDataBackstabDamage_Owk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk4Modified));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(int newId): base(1802981185, newId)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _isDataTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeModified));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _isDataBackstabDamage_Owk3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk3Modified));
            _dataBackstabDamage_Owk4Raw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamage_Owk4Raw, SetDataBackstabDamage_Owk4Raw));
            _isDataBackstabDamage_Owk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk4Modified));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(string newRawcode): base(1802981185, newRawcode)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _isDataTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeModified));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _isDataBackstabDamage_Owk3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk3Modified));
            _dataBackstabDamage_Owk4Raw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamage_Owk4Raw, SetDataBackstabDamage_Owk4Raw));
            _isDataBackstabDamage_Owk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk4Modified));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(ObjectDatabaseBase db): base(1802981185, db)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _isDataTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeModified));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _isDataBackstabDamage_Owk3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk3Modified));
            _dataBackstabDamage_Owk4Raw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamage_Owk4Raw, SetDataBackstabDamage_Owk4Raw));
            _isDataBackstabDamage_Owk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk4Modified));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(int newId, ObjectDatabaseBase db): base(1802981185, newId, db)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _isDataTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeModified));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _isDataBackstabDamage_Owk3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk3Modified));
            _dataBackstabDamage_Owk4Raw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamage_Owk4Raw, SetDataBackstabDamage_Owk4Raw));
            _isDataBackstabDamage_Owk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk4Modified));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public BladeMasterWindWalk(string newRawcode, ObjectDatabaseBase db): base(1802981185, newRawcode, db)
        {
            _dataTransitionTime = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTransitionTime, SetDataTransitionTime));
            _isDataTransitionTimeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTransitionTimeModified));
            _dataMovementSpeedIncrease = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataMovementSpeedIncrease, SetDataMovementSpeedIncrease));
            _isDataMovementSpeedIncreaseModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMovementSpeedIncreaseModified));
            _dataBackstabDamage_Owk3 = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataBackstabDamage_Owk3, SetDataBackstabDamage_Owk3));
            _isDataBackstabDamage_Owk3Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk3Modified));
            _dataBackstabDamage_Owk4Raw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataBackstabDamage_Owk4Raw, SetDataBackstabDamage_Owk4Raw));
            _isDataBackstabDamage_Owk4Modified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataBackstabDamage_Owk4Modified));
            _dataBackstabDamage_Owk4 = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataBackstabDamage_Owk4, SetDataBackstabDamage_Owk4));
            _dataStartCooldownWhenDecloakRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataStartCooldownWhenDecloakRaw, SetDataStartCooldownWhenDecloakRaw));
            _isDataStartCooldownWhenDecloakModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataStartCooldownWhenDecloakModified));
            _dataStartCooldownWhenDecloak = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataStartCooldownWhenDecloak, SetDataStartCooldownWhenDecloak));
        }

        public ObjectProperty<float> DataTransitionTime => _dataTransitionTime.Value;
        public ReadOnlyObjectProperty<bool> IsDataTransitionTimeModified => _isDataTransitionTimeModified.Value;
        public ObjectProperty<float> DataMovementSpeedIncrease => _dataMovementSpeedIncrease.Value;
        public ReadOnlyObjectProperty<bool> IsDataMovementSpeedIncreaseModified => _isDataMovementSpeedIncreaseModified.Value;
        public ObjectProperty<float> DataBackstabDamage_Owk3 => _dataBackstabDamage_Owk3.Value;
        public ReadOnlyObjectProperty<bool> IsDataBackstabDamage_Owk3Modified => _isDataBackstabDamage_Owk3Modified.Value;
        public ObjectProperty<int> DataBackstabDamage_Owk4Raw => _dataBackstabDamage_Owk4Raw.Value;
        public ReadOnlyObjectProperty<bool> IsDataBackstabDamage_Owk4Modified => _isDataBackstabDamage_Owk4Modified.Value;
        public ObjectProperty<bool> DataBackstabDamage_Owk4 => _dataBackstabDamage_Owk4.Value;
        public ObjectProperty<int> DataStartCooldownWhenDecloakRaw => _dataStartCooldownWhenDecloakRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataStartCooldownWhenDecloakModified => _isDataStartCooldownWhenDecloakModified.Value;
        public ObjectProperty<bool> DataStartCooldownWhenDecloak => _dataStartCooldownWhenDecloak.Value;
        private float GetDataTransitionTime(int level)
        {
            return _modifications.GetModification(829126479, level).ValueAsFloat;
        }

        private void SetDataTransitionTime(int level, float value)
        {
            _modifications[829126479, level] = new LevelObjectDataModification{Id = 829126479, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataTransitionTimeModified(int level)
        {
            return _modifications.ContainsKey(829126479, level);
        }

        private float GetDataMovementSpeedIncrease(int level)
        {
            return _modifications.GetModification(845903695, level).ValueAsFloat;
        }

        private void SetDataMovementSpeedIncrease(int level, float value)
        {
            _modifications[845903695, level] = new LevelObjectDataModification{Id = 845903695, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataMovementSpeedIncreaseModified(int level)
        {
            return _modifications.ContainsKey(845903695, level);
        }

        private float GetDataBackstabDamage_Owk3(int level)
        {
            return _modifications.GetModification(862680911, level).ValueAsFloat;
        }

        private void SetDataBackstabDamage_Owk3(int level, float value)
        {
            _modifications[862680911, level] = new LevelObjectDataModification{Id = 862680911, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataBackstabDamage_Owk3Modified(int level)
        {
            return _modifications.ContainsKey(862680911, level);
        }

        private int GetDataBackstabDamage_Owk4Raw(int level)
        {
            return _modifications.GetModification(879458127, level).ValueAsInt;
        }

        private void SetDataBackstabDamage_Owk4Raw(int level, int value)
        {
            _modifications[879458127, level] = new LevelObjectDataModification{Id = 879458127, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataBackstabDamage_Owk4Modified(int level)
        {
            return _modifications.ContainsKey(879458127, level);
        }

        private bool GetDataBackstabDamage_Owk4(int level)
        {
            return GetDataBackstabDamage_Owk4Raw(level).ToBool(this);
        }

        private void SetDataBackstabDamage_Owk4(int level, bool value)
        {
            SetDataBackstabDamage_Owk4Raw(level, value.ToRaw(0, 1));
        }

        private int GetDataStartCooldownWhenDecloakRaw(int level)
        {
            return _modifications.GetModification(896235343, level).ValueAsInt;
        }

        private void SetDataStartCooldownWhenDecloakRaw(int level, int value)
        {
            _modifications[896235343, level] = new LevelObjectDataModification{Id = 896235343, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataStartCooldownWhenDecloakModified(int level)
        {
            return _modifications.ContainsKey(896235343, level);
        }

        private bool GetDataStartCooldownWhenDecloak(int level)
        {
            return GetDataStartCooldownWhenDecloakRaw(level).ToBool(this);
        }

        private void SetDataStartCooldownWhenDecloak(int level, bool value)
        {
            SetDataStartCooldownWhenDecloakRaw(level, value.ToRaw(0, 1));
        }
    }
}