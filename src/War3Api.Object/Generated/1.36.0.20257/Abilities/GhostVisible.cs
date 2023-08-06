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
    public sealed class GhostVisible : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataImmuneToMorphEffectsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataImmuneToMorphEffectsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataImmuneToMorphEffects;
        private readonly Lazy<ObjectProperty<int>> _dataDoesNotBlockBuildingsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataDoesNotBlockBuildingsModified;
        private readonly Lazy<ObjectProperty<bool>> _dataDoesNotBlockBuildings;
        public GhostVisible(): base(1752458561)
        {
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(int newId): base(1752458561, newId)
        {
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(string newRawcode): base(1752458561, newRawcode)
        {
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(ObjectDatabaseBase db): base(1752458561, db)
        {
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(int newId, ObjectDatabaseBase db): base(1752458561, newId, db)
        {
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(string newRawcode, ObjectDatabaseBase db): base(1752458561, newRawcode, db)
        {
            _dataImmuneToMorphEffectsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataImmuneToMorphEffectsRaw, SetDataImmuneToMorphEffectsRaw));
            _isDataImmuneToMorphEffectsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataImmuneToMorphEffectsModified));
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildingsRaw = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataDoesNotBlockBuildingsRaw, SetDataDoesNotBlockBuildingsRaw));
            _isDataDoesNotBlockBuildingsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataDoesNotBlockBuildingsModified));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public ObjectProperty<int> DataImmuneToMorphEffectsRaw => _dataImmuneToMorphEffectsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataImmuneToMorphEffectsModified => _isDataImmuneToMorphEffectsModified.Value;
        public ObjectProperty<bool> DataImmuneToMorphEffects => _dataImmuneToMorphEffects.Value;
        public ObjectProperty<int> DataDoesNotBlockBuildingsRaw => _dataDoesNotBlockBuildingsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsDataDoesNotBlockBuildingsModified => _isDataDoesNotBlockBuildingsModified.Value;
        public ObjectProperty<bool> DataDoesNotBlockBuildings => _dataDoesNotBlockBuildings.Value;
        private int GetDataImmuneToMorphEffectsRaw(int level)
        {
            return _modifications.GetModification(828929093, level).ValueAsInt;
        }

        private void SetDataImmuneToMorphEffectsRaw(int level, int value)
        {
            _modifications[828929093, level] = new LevelObjectDataModification{Id = 828929093, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataImmuneToMorphEffectsModified(int level)
        {
            return _modifications.ContainsKey(828929093, level);
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
            return _modifications.GetModification(845706309, level).ValueAsInt;
        }

        private void SetDataDoesNotBlockBuildingsRaw(int level, int value)
        {
            _modifications[845706309, level] = new LevelObjectDataModification{Id = 845706309, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataDoesNotBlockBuildingsModified(int level)
        {
            return _modifications.ContainsKey(845706309, level);
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