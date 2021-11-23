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
        private readonly Lazy<ObjectProperty<int>> _dataautoAcquireAttackTargetsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataautoAcquireAttackTargetsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataautoAcquireAttackTargets;
        private readonly Lazy<ObjectProperty<int>> _dataImmuneToMorphEffectsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataImmuneToMorphEffectsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataImmuneToMorphEffects;
        private readonly Lazy<ObjectProperty<int>> _dataDoesNotBlockBuildingsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDoesNotBlockBuildingsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDoesNotBlockBuildings;
        public Ghost(): base(1869113153)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(int newId): base(1869113153, newId)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(string newRawcode): base(1869113153, newRawcode)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(ObjectDatabaseBase db): base(1869113153, db)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(int newId, ObjectDatabaseBase db): base(1869113153, newId, db)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public Ghost(string newRawcode, ObjectDatabaseBase db): base(1869113153, newRawcode, db)
        {
            _dataautoAcquireAttackTargetsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataautoAcquireAttackTargetsRaw, SetDataautoAcquireAttackTargetsRaw));
            _isDataautoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataautoAcquireAttackTargetsModified));
            _dataautoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataautoAcquireAttackTargets, SetDataautoAcquireAttackTargets));
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public ObjectProperty<int> DataautoAcquireAttackTargetsRaw => _dataautoAcquireAttackTargetsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataautoAcquireAttackTargetsModified => _isDataautoAcquireAttackTargetsModified.Value;
        public ObjectProperty<bool> DataautoAcquireAttackTargets => _dataautoAcquireAttackTargets.Value;
        public ObjectProperty<int> DataImmuneToMorphEffectsRaw => _dataImmuneToMorphEffectsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataImmuneToMorphEffectsModified => _isDataImmuneToMorphEffectsModified.Value;
        public ObjectProperty<bool> DataImmuneToMorphEffects => _dataImmuneToMorphEffects.Value;
        public ObjectProperty<int> DataDoesNotBlockBuildingsRaw => _dataDoesNotBlockBuildingsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDoesNotBlockBuildingsModified => _isDataDoesNotBlockBuildingsModified.Value;
        public ObjectProperty<bool> DataDoesNotBlockBuildings => _dataDoesNotBlockBuildings.Value;
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