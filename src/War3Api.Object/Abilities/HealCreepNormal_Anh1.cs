using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class HealCreepNormal_Anh1 : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataHitPointsGained;
        public HealCreepNormal_Anh1(): base(828927553)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anh1(int newId): base(828927553, newId)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anh1(string newRawcode): base(828927553, newRawcode)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anh1(ObjectDatabase db): base(828927553, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anh1(int newId, ObjectDatabase db): base(828927553, newId, db)
        {
            _dataHitPointsGained = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataHitPointsGained, SetDataHitPointsGained));
        }

        public HealCreepNormal_Anh1(string newRawcode, ObjectDatabase db): base(828927553, newRawcode, db)
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