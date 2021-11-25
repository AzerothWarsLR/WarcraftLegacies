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
        private readonly Lazy<ObjectProperty<int>> _dataAutoAcquireAttackTargetsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAutoAcquireAttackTargetsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAutoAcquireAttackTargets;
        public PermanentInvisibility(): base(1986621505)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
        }

        public PermanentInvisibility(int newId): base(1986621505, newId)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
        }

        public PermanentInvisibility(string newRawcode): base(1986621505, newRawcode)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
        }

        public PermanentInvisibility(ObjectDatabaseBase db): base(1986621505, db)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
        }

        public PermanentInvisibility(int newId, ObjectDatabaseBase db): base(1986621505, newId, db)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
        }

        public PermanentInvisibility(string newRawcode, ObjectDatabaseBase db): base(1986621505, newRawcode, db)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
        }

        public ObjectProperty<int> DataAutoAcquireAttackTargetsRaw => _dataAutoAcquireAttackTargetsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAutoAcquireAttackTargetsModified => _isDataAutoAcquireAttackTargetsModified.Value;
        public ObjectProperty<bool> DataAutoAcquireAttackTargets => _dataAutoAcquireAttackTargets.Value;
        private int GetDataAutoAcquireAttackTargetsRaw(int level)
        {
            return _modifications.GetModification(829384775, level).ValueAsInt;
        }

        private void SetDataAutoAcquireAttackTargetsRaw(int level, int value)
        {
            _modifications[829384775, level] = new LevelObjectDataModification{Id = 829384775, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAutoAcquireAttackTargetsModified(int level)
        {
            return _modifications.ContainsKey(829384775, level);
        }

        private bool GetDataAutoAcquireAttackTargets(int level)
        {
            return GetDataAutoAcquireAttackTargetsRaw(level).ToBool(this);
        }

        private void SetDataAutoAcquireAttackTargets(int level, bool value)
        {
            SetDataAutoAcquireAttackTargetsRaw(level, value.ToRaw(null, null));
        }
    }
}