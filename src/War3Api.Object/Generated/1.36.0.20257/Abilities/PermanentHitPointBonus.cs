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
    public sealed class PermanentHitPointBonus : Ability
    {
        private readonly Lazy<ObjectProperty<int>> _dataMaxLifeGained;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataMaxLifeGainedModified;
        public PermanentHitPointBonus(): base(1751992641)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public PermanentHitPointBonus(int newId): base(1751992641, newId)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public PermanentHitPointBonus(string newRawcode): base(1751992641, newRawcode)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public PermanentHitPointBonus(ObjectDatabaseBase db): base(1751992641, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public PermanentHitPointBonus(int newId, ObjectDatabaseBase db): base(1751992641, newId, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public PermanentHitPointBonus(string newRawcode, ObjectDatabaseBase db): base(1751992641, newRawcode, db)
        {
            _dataMaxLifeGained = new Lazy<ObjectProperty<int>>(() => new ObjectProperty<int>(GetDataMaxLifeGained, SetDataMaxLifeGained));
            _isDataMaxLifeGainedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataMaxLifeGainedModified));
        }

        public ObjectProperty<int> DataMaxLifeGained => _dataMaxLifeGained.Value;
        public ReadOnlyObjectProperty<bool> IsDataMaxLifeGainedModified => _isDataMaxLifeGainedModified.Value;
        private int GetDataMaxLifeGained(int level)
        {
            return _modifications.GetModification(1718185033, level).ValueAsInt;
        }

        private void SetDataMaxLifeGained(int level, int value)
        {
            _modifications[1718185033, level] = new LevelObjectDataModification{Id = 1718185033, Type = ObjectDataType.Int, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataMaxLifeGainedModified(int level)
        {
            return _modifications.ContainsKey(1718185033, level);
        }
    }
}