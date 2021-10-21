using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class GhostVisible : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataImmuneToMorphEffects;
        private readonly Lazy<ObjectProperty<bool>> _dataDoesNotBlockBuildings;
        public GhostVisible(): base(1752458561)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(int newId): base(1752458561, newId)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(string newRawcode): base(1752458561, newRawcode)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(ObjectDatabase db): base(1752458561, db)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(int newId, ObjectDatabase db): base(1752458561, newId, db)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public GhostVisible(string newRawcode, ObjectDatabase db): base(1752458561, newRawcode, db)
        {
            _dataImmuneToMorphEffects = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataImmuneToMorphEffects, SetDataImmuneToMorphEffects));
            _dataDoesNotBlockBuildings = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataDoesNotBlockBuildings, SetDataDoesNotBlockBuildings));
        }

        public ObjectProperty<bool> DataImmuneToMorphEffects => _dataImmuneToMorphEffects.Value;
        public ObjectProperty<bool> DataDoesNotBlockBuildings => _dataDoesNotBlockBuildings.Value;
        private bool GetDataImmuneToMorphEffects(int level)
        {
            return _modifications[828929093, level].ValueAsBool;
        }

        private void SetDataImmuneToMorphEffects(int level, bool value)
        {
            _modifications[828929093, level] = new LevelObjectDataModification{Id = 828929093, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 1};
        }

        private bool GetDataDoesNotBlockBuildings(int level)
        {
            return _modifications[845706309, level].ValueAsBool;
        }

        private void SetDataDoesNotBlockBuildings(int level, bool value)
        {
            _modifications[845706309, level] = new LevelObjectDataModification{Id = 845706309, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 2};
        }
    }
}