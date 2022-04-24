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
    public sealed class Ghost : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataAutoAcquireAttackTargetsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAutoAcquireAttackTargetsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataAutoAcquireAttackTargets;
        private readonly Lazy<ObjectProperty<int>> _dataImmuneToMorphEffectsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataImmuneToMorphEffectsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataImmuneToMorphEffects;
        private readonly Lazy<ObjectProperty<int>> _dataDoesNotBlockBuildingsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDoesNotBlockBuildingsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDoesNotBlockBuildings;
        public Ghost(): base(1869113153)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(int newId): base(1869113153, newId)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(string newRawcode): base(1869113153, newRawcode)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(ObjectDatabaseBase db): base(1869113153, db)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(int newId, ObjectDatabaseBase db): base(1869113153, newId, db)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(string newRawcode, ObjectDatabaseBase db): base(1869113153, newRawcode, db)
        {
            _dataAutoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataAutoAcquireAttackTargetsRaw, SetDataAutoAcquireAttackTargetsRaw));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public ObjectProperty<int> DataAutoAcquireAttackTargetsRaw => _dataAutoAcquireAttackTargetsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataAutoAcquireAttackTargetsModified => _isDataAutoAcquireAttackTargetsModified.Value;
        public ObjectProperty<bool> DataAutoAcquireAttackTargets => _dataAutoAcquireAttackTargets.Value;
        public ObjectProperty<int> DataImmuneToMorphEffectsRaw => _dataImmuneToMorphEffectsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataImmuneToMorphEffectsModified => _isDataImmuneToMorphEffectsModified.Value;
        public ObjectProperty<bool> DataImmuneToMorphEffects => _dataImmuneToMorphEffects.Value;
        public ObjectProperty<int> DataDoesNotBlockBuildingsRaw => _dataDoesNotBlockBuildingsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDoesNotBlockBuildingsModified => _isDataDoesNotBlockBuildingsModified.Value;
        public ObjectProperty<bool> DataDoesNotBlockBuildings => _dataDoesNotBlockBuildings.Value;
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

        private int GetDataImmuneToMorphEffectsRaw(int level)
        {
            return _modifications.GetModification(846161991, level).ValueAsInt;
        }

        private void SetDataImmuneToMorphEffectsRaw(int level, int value)
        {
            _modifications[846161991, level] = new LevelObjectDataModification{Id = 846161991, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataImmuneToMorphEffectsModified(int level)
        {
            return _modifications.ContainsKey(846161991, level);
        }

        private bool GetDataImmuneToMorphEffects(int level)
        {
            return GetDataImmuneToMorphEffectsRaw(level).ToBool(this);
        }

        private void SetDataImmuneToMorphEffects(int level, bool value)
        {
            SetDataImmuneToMorphEffectsRaw(level, value.ToRaw(null, null));
        }

        private int GetDataDoesNotBlockBuildingsRaw(int level)
        {
            return _modifications.GetModification(862939207, level).ValueAsInt;
        }

        private void SetDataDoesNotBlockBuildingsRaw(int level, int value)
        {
            _modifications[862939207, level] = new LevelObjectDataModification{Id = 862939207, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDoesNotBlockBuildingsModified(int level)
        {
            return _modifications.ContainsKey(862939207, level);
        }

        private bool GetDataDoesNotBlockBuildings(int level)
        {
            return GetDataDoesNotBlockBuildingsRaw(level).ToBool(this);
        }

        private void SetDataDoesNotBlockBuildings(int level, bool value)
        {
            SetDataDoesNotBlockBuildingsRaw(level, value.ToRaw(null, null));
        }
    }
}