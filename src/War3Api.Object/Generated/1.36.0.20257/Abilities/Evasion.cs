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
    public sealed class Evasion : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToEvade;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToEvadeModified;
        public Evasion(): base(1986349377)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public Evasion(int newId): base(1986349377, newId)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public Evasion(string newRawcode): base(1986349377, newRawcode)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public Evasion(ObjectDatabaseBase db): base(1986349377, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public Evasion(int newId, ObjectDatabaseBase db): base(1986349377, newId, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public Evasion(string newRawcode, ObjectDatabaseBase db): base(1986349377, newRawcode, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public ObjectProperty<float> DataChanceToEvade => _dataChanceToEvade.Value;
        public ReadOnlyObjectProperty<bool> IsDataChanceToEvadeModified => _isDataChanceToEvadeModified.Value;
        private float GetDataChanceToEvade(int level)
        {
            return _modifications.GetModification(829842757, level).ValueAsFloat;
        }

        private void SetDataChanceToEvade(int level, float value)
        {
            _modifications[829842757, level] = new LevelObjectDataModification{Id = 829842757, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataChanceToEvadeModified(int level)
        {
            return _modifications.ContainsKey(829842757, level);
        }
    }
}