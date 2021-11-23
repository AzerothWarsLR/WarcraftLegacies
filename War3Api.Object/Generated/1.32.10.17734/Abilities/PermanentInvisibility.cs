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
    public sealed class PermanentInvisibility : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataautoAcquireAttackTargetsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataautoAcquireAttackTargetsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataautoAcquireAttackTargets;
        public PermanentInvisibility(): base(1986621505)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
        }

        public PermanentInvisibility(int newId): base(1986621505, newId)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
        }

        public PermanentInvisibility(string newRawcode): base(1986621505, newRawcode)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
        }

        public PermanentInvisibility(ObjectDatabaseBase db): base(1986621505, db)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
        }

        public PermanentInvisibility(int newId, ObjectDatabaseBase db): base(1986621505, newId, db)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
        }

        public PermanentInvisibility(string newRawcode, ObjectDatabaseBase db): base(1986621505, newRawcode, db)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
        }

        public ObjectProperty<int> DataautoAcquireAttackTargetsRaw => _dataautoAcquireAttackTargetsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataautoAcquireAttackTargetsModified => _isDataautoAcquireAttackTargetsModified.Value;
        public ObjectProperty<bool> DataautoAcquireAttackTargets => _dataautoAcquireAttackTargets.Value;
        private int GetDataautoAcquireAttackTargetsRaw(int level)
        {
            return _modifications.GetModification(829384775, level).ValueAsInt;
        }

        private void SetDataautoAcquireAttackTargetsRaw(int level, int value)
        {
            _modifications[829384775, level] = new LevelObjectDataModification{Id = 829384775, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataautoAcquireAttackTargetsModified(int level)
        {
            return _modifications.ContainsKey(829384775, level);
        }

        private bool GetDataautoAcquireAttackTargets(int level)
        {
            return GetDataautoAcquireAttackTargetsRaw(level).ToBool(this);
        }

        private void SetDataautoAcquireAttackTargets(int level, bool value)
        {
            SetDataautoAcquireAttackTargetsRaw(level, value.ToRaw(null, null));
        }
    }
}