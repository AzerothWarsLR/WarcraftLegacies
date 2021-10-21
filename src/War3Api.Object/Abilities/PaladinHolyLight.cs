using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PaladinHolyLight : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataAmountHealedDamaged;
        public PaladinHolyLight(): base(1651001409)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
        }

        public PaladinHolyLight(int newId): base(1651001409, newId)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
        }

        public PaladinHolyLight(string newRawcode): base(1651001409, newRawcode)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
        }

        public PaladinHolyLight(ObjectDatabase db): base(1651001409, db)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
        }

        public PaladinHolyLight(int newId, ObjectDatabase db): base(1651001409, newId, db)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
        }

        public PaladinHolyLight(string newRawcode, ObjectDatabase db): base(1651001409, newRawcode, db)
        {
            _dataAmountHealedDamaged = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataAmountHealedDamaged, SetDataAmountHealedDamaged));
        }

        public ObjectProperty<float> DataAmountHealedDamaged => _dataAmountHealedDamaged.Value;
        private float GetDataAmountHealedDamaged(int level)
        {
            return _modifications[828532808, level].ValueAsFloat;
        }

        private void SetDataAmountHealedDamaged(int level, float value)
        {
            _modifications[828532808, level] = new LevelObjectDataModification{Id = 828532808, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }
    }
}