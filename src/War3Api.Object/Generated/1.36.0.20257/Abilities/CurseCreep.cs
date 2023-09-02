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
    public sealed class CurseCreep : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToMiss;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToMissModified;
        public CurseCreep(): base(1935885121)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
        }

        public CurseCreep(int newId): base(1935885121, newId)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
        }

        public CurseCreep(string newRawcode): base(1935885121, newRawcode)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
        }

        public CurseCreep(ObjectDatabaseBase db): base(1935885121, db)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
        }

        public CurseCreep(int newId, ObjectDatabaseBase db): base(1935885121, newId, db)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
        }

        public CurseCreep(string newRawcode, ObjectDatabaseBase db): base(1935885121, newRawcode, db)
        {
            _dataChanceToMiss = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToMiss, SetDataChanceToMiss));
            _isDataChanceToMissModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToMissModified));
        }

        public ObjectProperty<float> DataChanceToMiss => _dataChanceToMiss.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToMissModified => _isDataChanceToMissModified.Value;
        private float GetDataChanceToMiss(int level)
        {
            return _modifications.GetModification(0, level).ValueAsFloat;
        }

        private void SetDataChanceToMiss(int level, float value)
        {
            _modifications[0, level] = new LevelObjectDataModification{Id = 0, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToMissModified(int level)
        {
            return _modifications.ContainsKey(0, level);
        }
    }
}