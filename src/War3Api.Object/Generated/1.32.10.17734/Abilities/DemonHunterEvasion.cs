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
    public sealed class DemonHunterEvasion : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToEvade;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataChanceToEvadeModified;
        public DemonHunterEvasion(): base(1986348353)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public DemonHunterEvasion(int newId): base(1986348353, newId)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public DemonHunterEvasion(string newRawcode): base(1986348353, newRawcode)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public DemonHunterEvasion(ObjectDatabaseBase db): base(1986348353, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public DemonHunterEvasion(int newId, ObjectDatabaseBase db): base(1986348353, newId, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
            _isDataChanceToEvadeModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataChanceToEvadeModified));
        }

        public DemonHunterEvasion(string newRawcode, ObjectDatabaseBase db): base(1986348353, newRawcode, db)
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