using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ExperienceModGreater : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataExperienceGained;
        public ExperienceModGreater(): base(845498689)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceModGreater(int newId): base(845498689, newId)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceModGreater(string newRawcode): base(845498689, newRawcode)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceModGreater(ObjectDatabase db): base(845498689, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceModGreater(int newId, ObjectDatabase db): base(845498689, newId, db)
        {
            _dataExperienceGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataExperienceGained, SetDataExperienceGained));
        }

        public ExperienceModGreater(string newRawcode, ObjectDatabase db): base(845498689, newRawcode, db)
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