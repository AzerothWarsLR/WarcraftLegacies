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
    public sealed class ItemRitualDaggerRegen : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataLeaveTargetAliveRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataLeaveTargetAliveModified;
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataHitPointsGainedModified;
        private readonly Lazy<ObjectProperty<int>> _dataRequiresUndeadTargetRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataRequiresUndeadTargetModified;
        private readonly Lazy<ObjectProperty<bool>> _dataRequiresUndeadTarget;
        private readonly Lazy<ObjectProperty<int>> _dataAffectsInitialTargetRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAffectsInitialTargetModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAffectsInitialTarget;
        private readonly Lazy<ObjectProperty<string>> _dataTargetsAllowedForHealRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTargetsAllowedForHealModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Target>>> _dataTargetsAllowedForHeal;
        public ItemRitualDaggerRegen(): base(845629761)
        {
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAffectsInitialTargetRaw, SetDataAffectsInitialTargetRaw));
            _isDataAffectsInitialTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAffectsInitialTargetModified));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _isDataTargetsAllowedForHealModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForHealModified));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerRegen(int newId): base(845629761, newId)
        {
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAffectsInitialTargetRaw, SetDataAffectsInitialTargetRaw));
            _isDataAffectsInitialTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAffectsInitialTargetModified));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _isDataTargetsAllowedForHealModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForHealModified));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerRegen(string newRawcode): base(845629761, newRawcode)
        {
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAffectsInitialTargetRaw, SetDataAffectsInitialTargetRaw));
            _isDataAffectsInitialTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAffectsInitialTargetModified));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _isDataTargetsAllowedForHealModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForHealModified));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerRegen(ObjectDatabaseBase db): base(845629761, db)
        {
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAffectsInitialTargetRaw, SetDataAffectsInitialTargetRaw));
            _isDataAffectsInitialTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAffectsInitialTargetModified));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _isDataTargetsAllowedForHealModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForHealModified));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerRegen(int newId, ObjectDatabaseBase db): base(845629761, newId, db)
        {
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAffectsInitialTargetRaw, SetDataAffectsInitialTargetRaw));
            _isDataAffectsInitialTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAffectsInitialTargetModified));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _isDataTargetsAllowedForHealModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForHealModified));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerRegen(string newRawcode, ObjectDatabaseBase db): base(845629761, newRawcode, db)
        {
            _dataLeaveTargetAliveRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataLeaveTargetAliveRaw, SetDataLeaveTargetAliveRaw));
            _isDataLeaveTargetAliveModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataLeaveTargetAliveModified));
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _isDataHitPointsGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataHitPointsGainedModified));
            _dataRequiresUndeadTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataRequiresUndeadTargetRaw, SetDataRequiresUndeadTargetRaw));
            _isDataRequiresUndeadTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataRequiresUndeadTargetModified));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTargetRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAffectsInitialTargetRaw, SetDataAffectsInitialTargetRaw));
            _isDataAffectsInitialTargetModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAffectsInitialTargetModified));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _isDataTargetsAllowedForHealModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTargetsAllowedForHealModified));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ObjectProperty<int> DataLeaveTargetAliveRaw => _dataLeaveTargetAliveRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataLeaveTargetAliveModified => _isDataLeaveTargetAliveModified.Value;
        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        public ObjectProperty<int> DataHitPointsGained => _dataHitPointsGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataHitPointsGainedModified => _isDataHitPointsGainedModified.Value;
        public ObjectProperty<int> DataRequiresUndeadTargetRaw => _dataRequiresUndeadTargetRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataRequiresUndeadTargetModified => _isDataRequiresUndeadTargetModified.Value;
        public ObjectProperty<bool> DataRequiresUndeadTarget => _dataRequiresUndeadTarget.Value;
        public ObjectProperty<int> DataAffectsInitialTargetRaw => _dataAffectsInitialTargetRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAffectsInitialTargetModified => _isDataAffectsInitialTargetModified.Value;
        public ObjectProperty<bool> DataAffectsInitialTarget => _dataAffectsInitialTarget.Value;
        public ObjectProperty<string> DataTargetsAllowedForHealRaw => _dataTargetsAllowedForHealRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataTargetsAllowedForHealModified => _isDataTargetsAllowedForHealModified.Value;
        public ObjectProperty<IEnumerable<Target>> DataTargetsAllowedForHeal => _dataTargetsAllowedForHeal.Value;
        private int GetDataLeaveTargetAliveRaw(int level)
        {
            return _modifications.GetModification(896558165, level).ValueAsInt;
        }

        private void SetDataLeaveTargetAliveRaw(int level, int value)
        {
            _modifications[896558165, level] = new LevelObjectDataModification{Id = 896558165, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 5};
        }

        private bool GetIsDataLeaveTargetAliveModified(int level)
        {
            return _modifications.ContainsKey(896558165, level);
        }

        private bool GetDataLeaveTargetAlive(int level)
        {
            return GetDataLeaveTargetAliveRaw(level).ToBool(this);
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            SetDataLeaveTargetAliveRaw(level, value.ToRaw(null, null));
        }

        private int GetDataHitPointsGained(int level)
        {
            return _modifications.GetModification(1735419977, level).ValueAsInt;
        }

        private void SetDataHitPointsGained(int level, int value)
        {
            _modifications[1735419977, level] = new LevelObjectDataModification{Id = 1735419977, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataHitPointsGainedModified(int level)
        {
            return _modifications.ContainsKey(1735419977, level);
        }

        private int GetDataRequiresUndeadTargetRaw(int level)
        {
            return _modifications.GetModification(828859465, level).ValueAsInt;
        }

        private void SetDataRequiresUndeadTargetRaw(int level, int value)
        {
            _modifications[828859465, level] = new LevelObjectDataModification{Id = 828859465, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataRequiresUndeadTargetModified(int level)
        {
            return _modifications.ContainsKey(828859465, level);
        }

        private bool GetDataRequiresUndeadTarget(int level)
        {
            return GetDataRequiresUndeadTargetRaw(level).ToBool(this);
        }

        private void SetDataRequiresUndeadTarget(int level, bool value)
        {
            SetDataRequiresUndeadTargetRaw(level, value.ToRaw(0, 1));
        }

        private int GetDataAffectsInitialTargetRaw(int level)
        {
            return _modifications.GetModification(845636681, level).ValueAsInt;
        }

        private void SetDataAffectsInitialTargetRaw(int level, int value)
        {
            _modifications[845636681, level] = new LevelObjectDataModification{Id = 845636681, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataAffectsInitialTargetModified(int level)
        {
            return _modifications.ContainsKey(845636681, level);
        }

        private bool GetDataAffectsInitialTarget(int level)
        {
            return GetDataAffectsInitialTargetRaw(level).ToBool(this);
        }

        private void SetDataAffectsInitialTarget(int level, bool value)
        {
            SetDataAffectsInitialTargetRaw(level, value.ToRaw(0, 1));
        }

        private string GetDataTargetsAllowedForHealRaw(int level)
        {
            return _modifications.GetModification(862413897, level).ValueAsString;
        }

        private void SetDataTargetsAllowedForHealRaw(int level, string value)
        {
            _modifications[862413897, level] = new LevelObjectDataModification{Id = 862413897, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 8};
        }

        private bool GetIsDataTargetsAllowedForHealModified(int level)
        {
            return _modifications.ContainsKey(862413897, level);
        }

        private IEnumerable<Target> GetDataTargetsAllowedForHeal(int level)
        {
            return GetDataTargetsAllowedForHealRaw(level).ToIEnumerableTarget(this);
        }

        private void SetDataTargetsAllowedForHeal(int level, IEnumerable<Target> value)
        {
            SetDataTargetsAllowedForHealRaw(level, value.ToRaw(null, null));
        }
    }
}