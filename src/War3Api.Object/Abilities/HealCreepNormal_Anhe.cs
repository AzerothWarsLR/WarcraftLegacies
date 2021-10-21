using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class HealCreepNormal_Anhe : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        public HealCreepNormal_Anhe(): base(1701342785)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anhe(int newId): base(1701342785, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anhe(string newRawcode): base(1701342785, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anhe(ObjectDatabase db): base(1701342785, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anhe(int newId, ObjectDatabase db): base(1701342785, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anhe(string newRawcode, ObjectDatabase db): base(1701342785, newRawcode, db)
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