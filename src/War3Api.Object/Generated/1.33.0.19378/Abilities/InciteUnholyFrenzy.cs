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
    public sealed class InciteUnholyFrenzy : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataRequiresUndeadTargetRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRequiresUndeadTargetModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRequiresUndeadTarget;
        private readonly Lazy<ObjectProperty<int>> _dataLeaveTargetAliveRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLeaveTargetAliveModified;
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        private readonly Lazy<ObjectProperty<string>> _dataTargetsAllowedForBuffRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetsAllowedForBuffModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Target>>> _dataTargetsAllowedForBuff;
        public InciteUnholyFrenzy(): base(1718973761)
        {
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _isDataTargetsAllowedForBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForBuffModified));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(int newId): base(1718973761, newId)
        {
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _isDataTargetsAllowedForBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForBuffModified));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(string newRawcode): base(1718973761, newRawcode)
        {
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _isDataTargetsAllowedForBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForBuffModified));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(ObjectDatabaseBase db): base(1718973761, db)
        {
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _isDataTargetsAllowedForBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForBuffModified));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(int newId, ObjectDatabaseBase db): base(1718973761, newId, db)
        {
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _isDataTargetsAllowedForBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForBuffModified));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public InciteUnholyFrenzy(string newRawcode, ObjectDatabaseBase db): base(1718973761, newRawcode, db)
        {
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataTargetsAllowedForBuffRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForBuffRaw, SetDataTargetsAllowedForBuffRaw));
            _isDataTargetsAllowedForBuffModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForBuffModified));
            _dataTargetsAllowedForBuff = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForBuff, SetDataTargetsAllowedForBuff));
        }

        public ObjectProperty<int> DataRequiresUndeadTargetRaw => _dataRequiresUndeadTargetRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRequiresUndeadTargetModified => _isDataRequiresUndeadTargetModified.Value;
        public ObjectProperty<bool> DataRequiresUndeadTarget => _dataRequiresUndeadTarget.Value;
        public ObjectProperty<int> DataLeaveTargetAliveRaw => _dataLeaveTargetAliveRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataLeaveTargetAliveModified => _isDataLeaveTargetAliveModified.Value;
        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        public ObjectProperty<string> DataTargetsAllowedForBuffRaw => _dataTargetsAllowedForBuffRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetsAllowedForBuffModified => _isDataTargetsAllowedForBuffModified.Value;
        public ObjectProperty<IEnumerable<Target>> DataTargetsAllowedForBuff => _dataTargetsAllowedForBuff.Value;
        private int GetDataRequiresUndeadTargetRaw(int level)
        {
            return _modifications.GetModification(828798293, level).ValueAsInt;
        }

        private void SetDataRequiresUndeadTargetRaw(int level, int value)
        {
            _modifications[828798293, level] = new LevelObjectDataModification{Id = 828798293, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataRequiresUndeadTargetModified(int level)
        {
            return _modifications.ContainsKey(828798293, level);
        }

        private bool GetDataRequiresUndeadTarget(int level)
        {
            return GetDataRequiresUndeadTargetRaw(level).ToBool(this);
        }

        private void SetDataRequiresUndeadTarget(int level, bool value)
        {
            SetDataRequiresUndeadTargetRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataLeaveTargetAliveRaw(int level)
        {
            return _modifications.GetModification(845575509, level).ValueAsInt;
        }

        private void SetDataLeaveTargetAliveRaw(int level, int value)
        {
            _modifications[845575509, level] = new LevelObjectDataModification{Id = 845575509, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 4};
        }

        private bool GetIsDataLeaveTargetAliveModified(int level)
        {
            return _modifications.ContainsKey(845575509, level);
        }

        private bool GetDataLeaveTargetAlive(int level)
        {
            return GetDataLeaveTargetAliveRaw(level).ToBool(this);
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            SetDataLeaveTargetAliveRaw(level, value.ToRaw(0, 1));
        }

        private string GetDataTargetsAllowedForBuffRaw(int level)
        {
            return _modifications.GetModification(862352725, level).ValueAsString;
        }

        private void SetDataTargetsAllowedForBuffRaw(int level, string value)
        {
            _modifications[862352725, level] = new LevelObjectDataModification{Id = 862352725, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 8};
        }

        private bool GetIsDataTargetsAllowedForBuffModified(int level)
        {
            return _modifications.ContainsKey(862352725, level);
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