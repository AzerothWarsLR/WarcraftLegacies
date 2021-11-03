using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class GhostVisible : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataImmuneToMorphEffects;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataImmuneToMorphEffectsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDoesNotBlockBuildings;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDoesNotBlockBuildingsModified;
        public GhostVisible(): base(1752458561)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public GhostVisible(int newId): base(1752458561, newId)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public GhostVisible(string newRawcode): base(1752458561, newRawcode)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public GhostVisible(ObjectDatabase db): base(1752458561, db)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public GhostVisible(int newId, ObjectDatabase db): base(1752458561, newId, db)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public GhostVisible(string newRawcode, ObjectDatabase db): base(1752458561, newRawcode, db)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
        }

        public ObjectProperty<bool> DataImmuneToMorphEffects => _dataImmuneToMorphEffects.Value;
        public ReadOnlyObjectProperty<bool> IsDataImmuneToMorphEffectsModified => _isDataImmuneToMorphEffectsModified.Value;
        public ObjectProperty<bool> DataDoesNotBlockBuildings => _dataDoesNotBlockBuildings.Value;
        public ReadOnlyObjectProperty<bool> IsDataDoesNotBlockBuildingsModified => _isDataDoesNotBlockBuildingsModified.Value;
        private bool GetDataImmuneToMorphEffects(int level)
        {
            return _modifications[828929093, level].ValueAsBool;
        }

        private void SetDataImmuneToMorphEffects(int level, bool value)
        {
            _modifications[828929093, level] = new LevelObjectDataModification{Id = 828929093, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataImmuneToMorphEffectsModified(int level)
        {
            return _modifications.ContainsKey(828929093, level);
        }

        private bool GetDataDoesNotBlockBuildings(int level)
        {
            return _modifications[845706309, level].ValueAsBool;
        }

        private void SetDataDoesNotBlockBuildings(int level, bool value)
        {
            _modifications[845706309, level] = new LevelObjectDataModification{Id = 845706309, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDoesNotBlockBuildingsModified(int level)
        {
            return _modifications.ContainsKey(845706309, level);
        }
    }
}