using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SelfDestruct2ClockwerkGoblins : Ability
    {
        private readonly Lazy<ObjectProperty<bool>> _dataExplodesOnDeath;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataExplodesOnDeathModified;
        public SelfDestruct2ClockwerkGoblins(): base(845443905)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
        }

        public SelfDestruct2ClockwerkGoblins(int newId): base(845443905, newId)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
        }

        public SelfDestruct2ClockwerkGoblins(string newRawcode): base(845443905, newRawcode)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
        }

        public SelfDestruct2ClockwerkGoblins(ObjectDatabase db): base(845443905, db)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
        }

        public SelfDestruct2ClockwerkGoblins(int newId, ObjectDatabase db): base(845443905, newId, db)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
        }

        public SelfDestruct2ClockwerkGoblins(string newRawcode, ObjectDatabase db): base(845443905, newRawcode, db)
        {
            _dataExplodesOnDeath = new Lazy<ObjectProperty<bool>>(() => new ObjectProperty<bool>(GetDataExplodesOnDeath, SetDataExplodesOnDeath));
            _isDataExplodesOnDeathModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataExplodesOnDeathModified));
        }

        public ObjectProperty<bool> DataExplodesOnDeath => _dataExplodesOnDeath.Value;
        public ReadOnlyObjectProperty<bool> IsDataExplodesOnDeathModified => _isDataExplodesOnDeathModified.Value;
        private bool GetDataExplodesOnDeath(int level)
        {
            return _modifications[913531987, level].ValueAsBool;
        }

        private void SetDataExplodesOnDeath(int level, bool value)
        {
            _modifications[913531987, level] = new LevelObjectDataModification{Id = 913531987, Type = ObjectDataType.Bool, Value = value, Level = level, Pointer = 6};
        }

        private bool GetIsDataExplodesOnDeathModified(int level)
        {
            return _modifications.ContainsKey(913531987, level);
        }
    }
}