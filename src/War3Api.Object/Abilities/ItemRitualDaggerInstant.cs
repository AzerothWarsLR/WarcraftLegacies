using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemRitualDaggerInstant : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataLeaveTargetAlive;
        private readonly Lazy<ObjectProperty<int>> _dataHitPointsGained;
        private readonly Lazy<ObjectProperty<bool>> _dataRequiresUndeadTarget;
        private readonly Lazy<ObjectProperty<bool>> _dataAffectsInitialTarget;
        private readonly Lazy<ObjectProperty<string>> _dataTargetsAllowedForHealRaw;
        private readonly Lazy<ObjectProperty<IEnumerable<Target>>> _dataTargetsAllowedForHeal;
        public ItemRitualDaggerInstant(): base(1734625601)
        {
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerInstant(int newId): base(1734625601, newId)
        {
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerInstant(string newRawcode): base(1734625601, newRawcode)
        {
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerInstant(ObjectDatabase db): base(1734625601, db)
        {
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerInstant(int newId, ObjectDatabase db): base(1734625601, newId, db)
        {
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ItemRitualDaggerInstant(string newRawcode, ObjectDatabase db): base(1734625601, newRawcode, db)
        {
            _dataLeaveTargetAlive = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataLeaveTargetAlive, SetDataLeaveTargetAlive));
            _dataHitPointsGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataHitPointsGained, SetDataHitPointsGained));
            _dataRequiresUndeadTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataRequiresUndeadTarget, SetDataRequiresUndeadTarget));
            _dataAffectsInitialTarget = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAffectsInitialTarget, SetDataAffectsInitialTarget));
            _dataTargetsAllowedForHealRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetDataTargetsAllowedForHealRaw, SetDataTargetsAllowedForHealRaw));
            _dataTargetsAllowedForHeal = new Lazy<ObjectProperty<IEnumerable<Target>>>(() => new ObjectProperty<IEnumerable<Target>>(GetDataTargetsAllowedForHeal, SetDataTargetsAllowedForHeal));
        }

        public ObjectProperty<bool> DataLeaveTargetAlive => _dataLeaveTargetAlive.Value;
        public ObjectProperty<int> DataHitPointsGained => _dataHitPointsGained.Value;
        public ObjectProperty<bool> DataRequiresUndeadTarget => _dataRequiresUndeadTarget.Value;
        public ObjectProperty<bool> DataAffectsInitialTarget => _dataAffectsInitialTarget.Value;
        public ObjectProperty<string> DataTargetsAllowedForHealRaw => _dataTargetsAllowedForHealRaw.Value;
        public ObjectProperty<IEnumerable<Target>> DataTargetsAllowedForHeal => _dataTargetsAllowedForHeal.Value;
        private bool GetDataLeaveTargetAlive(int level)
        {
            return _modifications[896558165, level].ValueAsBool;
        }

        private void SetDataLeaveTargetAlive(int level, bool value)
        {
            _modifications[896558165, level] = new LevelObjectDataModification{Id = 896558165, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 5};
        }

        private int GetDataHitPointsGained(int level)
        {
            return _modifications[1735419977, level].ValueAsInt;
        }

        private void SetDataHitPointsGained(int level, int value)
        {
            _modifications[1735419977, level] = new LevelObjectDataModification{Id = 1735419977, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataRequiresUndeadTarget(int level)
        {
            return _modifications[828859465, level].ValueAsBool;
        }

        private void SetDataRequiresUndeadTarget(int level, bool value)
        {
            _modifications[828859465, level] = new LevelObjectDataModification{Id = 828859465, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetDataAffectsInitialTarget(int level)
        {
            return _modifications[845636681, level].ValueAsBool;
        }

        private void SetDataAffectsInitialTarget(int level, bool value)
        {
            _modifications[845636681, level] = new LevelObjectDataModification{Id = 845636681, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private string GetDataTargetsAllowedForHealRaw(int level)
        {
            return _modifications[862413897, level].ValueAsString;
        }

        private void SetDataTargetsAllowedForHealRaw(int level, string value)
        {
            _modifications[862413897, level] = new LevelObjectDataModification{Id = 862413897, Type = ObjectDataType.String, Value = value, Level = level, Pointer = 8};
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