using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PitLordCleavingAttack : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataDistributedDamageFactor;
        public PitLordCleavingAttack(): base(1633898049)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
        }

        public PitLordCleavingAttack(int newId): base(1633898049, newId)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
        }

        public PitLordCleavingAttack(string newRawcode): base(1633898049, newRawcode)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
        }

        public PitLordCleavingAttack(ObjectDatabase db): base(1633898049, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
        }

        public PitLordCleavingAttack(int newId, ObjectDatabase db): base(1633898049, newId, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
        }

        public PitLordCleavingAttack(string newRawcode, ObjectDatabase db): base(1633898049, newRawcode, db)
        {
            _dataDistributedDamageFactor = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataDistributedDamageFactor, SetDataDistributedDamageFactor));
        }

        public ObjectProperty<float> DataDistributedDamageFactor => _dataDistributedDamageFactor.Value;
        private float GetDataDistributedDamageFactor(int level)
        {
            return _modifications[828466030, level].ValueAsFloat;
        }

        private void SetDataDistributedDamageFactor(int level, float value)
        {
            _modifications[828466030, level] = new LevelObjectDataModification{Id = 828466030, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}