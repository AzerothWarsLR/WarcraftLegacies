using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SelfDestructClockwerkGoblins : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataExplodesOnDeath;
        public SelfDestructClockwerkGoblins(): base(1734636353)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(int newId): base(1734636353, newId)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(string newRawcode): base(1734636353, newRawcode)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(ObjectDatabase db): base(1734636353, db)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(int newId, ObjectDatabase db): base(1734636353, newId, db)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public SelfDestructClockwerkGoblins(string newRawcode, ObjectDatabase db): base(1734636353, newRawcode, db)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
        }

        public ObjectProperty<bool> DataExplodesOnDeath => _dataExplodesOnDeath.Value;
        private bool GetDataExplodesOnDeath(int level)
        {
            return _modifications[913531987, level].ValueAsBool;
        }

        private void SetDataExplodesOnDeath(int level, bool value)
        {
            _modifications[913531987, level] = new LevelObjectDataModification{Id = 913531987, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }
    }
}