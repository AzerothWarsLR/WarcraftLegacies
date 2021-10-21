using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Heal : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        public Heal(): base(1634035777)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public Heal(int newId): base(1634035777, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public Heal(string newRawcode): base(1634035777, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public Heal(ObjectDatabase db): base(1634035777, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public Heal(int newId, ObjectDatabase db): base(1634035777, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public Heal(string newRawcode, ObjectDatabase db): base(1634035777, newRawcode, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public ObjectProperty<float> DataHitPointsGained => _dataHitPointsGained.Value;
        private float GetDataHitPointsGained(int level)
        {
            return _modifications[828466504, level].ValueAsFloat;
        }

        private void SetDataHitPointsGained(int level, float value)
        {
            _modifications[828466504, level] = new LevelObjectDataModification{Id = 828466504, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}