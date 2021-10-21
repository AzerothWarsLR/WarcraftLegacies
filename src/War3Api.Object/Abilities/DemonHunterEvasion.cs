using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DemonHunterEvasion : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataChanceToEvade;
        public DemonHunterEvasion(): base(1986348353)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public DemonHunterEvasion(int newId): base(1986348353, newId)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public DemonHunterEvasion(string newRawcode): base(1986348353, newRawcode)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public DemonHunterEvasion(ObjectDatabase db): base(1986348353, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public DemonHunterEvasion(int newId, ObjectDatabase db): base(1986348353, newId, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public DemonHunterEvasion(string newRawcode, ObjectDatabase db): base(1986348353, newRawcode, db)
        {
            _dataChanceToEvade = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataChanceToEvade, SetDataChanceToEvade));
        }

        public ObjectProperty<float> DataChanceToEvade => _dataChanceToEvade.Value;
        private float GetDataChanceToEvade(int level)
        {
            return _modifications[829842757, level].ValueAsFloat;
        }

        private void SetDataChanceToEvade(int level, float value)
        {
            _modifications[829842757, level] = new LevelObjectDataModification{Id = 829842757, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}