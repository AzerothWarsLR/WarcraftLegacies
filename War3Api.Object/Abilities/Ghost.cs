using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Ghost : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataAutoAcquireAttackTargets;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataAutoAcquireAttackTargetsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataImmuneToMorphEffects;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataImmuneToMorphEffectsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDoesNotBlockBuildings;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDoesNotBlockBuildingsModified;
        public Ghost(): base(1869113153)
        {
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public Ghost(int newId): base(1869113153, newId)
        {
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public Ghost(string newRawcode): base(1869113153, newRawcode)
        {
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public Ghost(ObjectDatabase db): base(1869113153, db)
        {
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public Ghost(int newId, ObjectDatabase db): base(1869113153, newId, db)
        {
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public Ghost(string newRawcode, ObjectDatabase db): base(1869113153, newRawcode, db)
        {
            _dataAutoAcquireAttackTargets = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataAutoAcquireAttackTargets, SetDataAutoAcquireAttackTargets));
            _isDataAutoAcquireAttackTargetsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataAutoAcquireAttackTargetsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public ObjectProperty<bool> DataAutoAcquireAttackTargets => _dataAutoAcquireAttackTargets.Value;
        public ReadOnlyObjectProperty<bool> IsDataAutoAcquireAttackTargetsModified => _isDataAutoAcquireAttackTargetsModified.Value;
        public ObjectProperty<bool> DataImmuneToMorphEffects => _dataImmuneToMorphEffects.Value;
        public ReadOnlyObjectProperty<bool> IsDataImmuneToMorphEffectsModified => _isDataImmuneToMorphEffectsModified.Value;
        public ObjectProperty<bool> DataDoesNotBlockBuildings => _dataDoesNotBlockBuildings.Value;
        public ReadOnlyObjectProperty<bool> IsDataDoesNotBlockBuildingsModified => _isDataDoesNotBlockBuildingsModified.Value;
        private bool GetDataAutoAcquireAttackTargets(int level)
        {
            return _modifications[829384775, level].ValueAsBool;
        }

        private void SetDataAutoAcquireAttackTargets(int level, bool value)
        {
            _modifications[829384775, level] = new LevelObjectDataModification{Id = 829384775, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataAutoAcquireAttackTargetsModified(int level)
        {
            return _modifications.ContainsKey(829384775, level);
        }

        private bool GetDataImmuneToMorphEffects(int level)
        {
            return _modifications[846161991, level].ValueAsBool;
        }

        private void SetDataImmuneToMorphEffects(int level, bool value)
        {
            _modifications[846161991, level] = new LevelObjectDataModification{Id = 846161991, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataImmuneToMorphEffectsModified(int level)
        {
            return _modifications.ContainsKey(846161991, level);
        }

        private bool GetDataDoesNotBlockBuildings(int level)
        {
            return _modifications[862939207, level].ValueAsBool;
        }

        private void SetDataDoesNotBlockBuildings(int level, bool value)
        {
            _modifications[862939207, level] = new LevelObjectDataModification{Id = 862939207, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 3};
        }

        private bool GetIsDataDoesNotBlockBuildingsModified(int level)
        {
            return _modifications.ContainsKey(862939207, level);
        }
    }
}