using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ExperienceMod : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataExperienceGained;
        public ExperienceMod(): base(1835354433)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceMod(int newId): base(1835354433, newId)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceMod(string newRawcode): base(1835354433, newRawcode)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceMod(ObjectDatabase db): base(1835354433, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceMod(int newId, ObjectDatabase db): base(1835354433, newId, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceMod(string newRawcode, ObjectDatabase db): base(1835354433, newRawcode, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ObjectProperty<int> DataExperienceGained => _dataExperienceGained.Value;
        private int GetDataExperienceGained(int level)
        {
            return _modifications[1735424073, level].ValueAsInt;
        }

        private void SetDataExperienceGained(int level, int value)
        {
            _modifications[1735424073, level] = new LevelObjectDataModification{Id = 1735424073, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }
    }
}