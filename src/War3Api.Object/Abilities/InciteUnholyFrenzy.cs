using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class InciteUnholyFrenzy : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataPreferHostiles;
        private readonly Lazy<ObjectProperty<bool>> _dataPreferFriendlies;
        private readonly Lazy<ObjectProperty<int>> _dataMaxUnits;
        private readonly Lazy<ObjectProperty<float>> _dataAttackSpeedBonus;
        private readonly Lazy<ObjectProperty<float>> _dataDamagePerSecond;
        private readonly Lazy<ObjectProperty<bool>> _dataRequiresUndeadTarget;
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        private readonly Lazy<ObjectProperty<string>> _dataTargetsAllowedForBuffRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Target>>> _dataTargetsAllowedForBuff;
        public InciteUnholyFrenzy(): base(1718973761)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(int newId): base(1718973761, newId)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(string newRawcode): base(1718973761, newRawcode)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(ObjectDatabase db): base(1718973761, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(int newId, ObjectDatabase db): base(1718973761, newId, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(string newRawcode, ObjectDatabase db): base(1718973761, newRawcode, db)
        {
            _dataPreferHostiles = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferHostiles, SetDataPreferHostiles));
            _dataPreferFriendlies = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataPreferFriendlies, SetDataPreferFriendlies));
            _dataMaxUnits = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxUnits, SetDataMaxUnits));
            _dataAttackSpeedBonus = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAttackSpeedBonus, SetDataAttackSpeedBonus));
            _dataDamagePerSecond = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDamagePerSecond, SetDataDamagePerSecond));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public ObjectProperty<bool> DataPreferHostiles => _dataPreferHostiles.Value;
        public ObjectProperty<bool> DataPreferFriendlies => _dataPreferFriendlies.Value;
        public ObjectProperty<int> DataMaxUnits => _dataMaxUnits.Value;
        public ObjectProperty<float> DataAttackSpeedBonus => _dataAttackSpeedBonus.Value;
        public ObjectProperty<float> DataDamagePerSecond => _dataDamagePerSecond.Value;
        public ObjectProperty<bool> DataRequiresUndeadTarget => _dataRequiresUndeadTarget.Value;
        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        public ObjectProperty<string> DataTargetsAllowedForBuffRaw => _dataTargetsAllowedForBuffRaw.Value;
        public ObjectProperty<IEnumerable<Target>> DataTargetsAllowedForBuff => _dataTargetsAllowedForBuff.Value;
        private bool GetDataPreferHostiles(int level)
        {
            return _modifications[895577938, level].ValueAsBool;
        }

        private void SetDataPreferHostiles(int level, bool value)
        {
            _modifications[895577938, level] = new LevelObjectDataModification{Id = 895577938, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private bool GetDataPreferFriendlies(int level)
        {
            return _modifications[912355154, level].ValueAsBool;
        }

        private void SetDataPreferFriendlies(int level, bool value)
        {
            _modifications[912355154, level] = new LevelObjectDataModification{Id = 912355154, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }

        private int GetDataMaxUnits(int level)
        {
            return _modifications[929132370, level].ValueAsInt;
        }

        private void SetDataMaxUnits(int level, int value)
        {
            _modifications[929132370, level] = new LevelObjectDataModification{Id = 929132370, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 7};
        }

        private float GetDataAttackSpeedBonus(int level)
        {
            return _modifications[828794965, level].ValueAsFloat;
        }

        private void SetDataAttackSpeedBonus(int level, float value)
        {
            _modifications[828794965, level] = new LevelObjectDataModification{Id = 828794965, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataDamagePerSecond(int level)
        {
            return _modifications[845572181, level].ValueAsFloat;
        }

        private void SetDataDamagePerSecond(int level, float value)
        {
            _modifications[845572181, level] = new LevelObjectDataModification{Id = 845572181, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataRequiresUndeadTarget(int level)
        {
            return _modifications[828798293, level].ValueAsBool;
        }

        private void SetDataRequiresUndeadTarget(int level, bool value)
        {
            _modifications[828798293, level] = new LevelObjectDataModification{Id = 828798293, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetDataLeaveTargetAlive(int level)
        {
            return _modifications[845575509, level].ValueAsBool;
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            _modifications[845575509, level] = new LevelObjectDataModification{Id = 845575509, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 4};
        }

        private string GetDataTargetsAllowedForBuffRaw(int level)
        {
            return _modifications[862352725, level].ValueAsString;
        }

        private void SetDataTargetsAllowedForBuffRaw(int level, string value)
        {
            _modifications[862352725, level] = new LevelObjectDataModification{Id = 862352725, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 8};
        }

        private IEnumerable<Target> GetDataTargetsAllowedForBuff(int level)
        {
            return GetDataTargetsAllowedForBuffRaw(level).ToIEnumerableTarget(this);
        }

        private void SetDataTargetsAllowedForBuff(int level, IEnumerable<Target> value)
        {
            SetDataTargetsAllowedForBuffRaw(level, value.ToRaw(null, null));
        }
    }
}