using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DeathDamageSapper : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataFullDamageAmount;
        private readonly Lazy<ObjectProperty<float>> _dataPartialDamageRadius;
        private readonly Lazy<ObjectProperty<float>> _dataPartialDamageAmount;
        public DeathDamageSapper(): base(1633969217)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
        }

        public DeathDamageSapper(int newId): base(1633969217, newId)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
        }

        public DeathDamageSapper(string newRawcode): base(1633969217, newRawcode)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
        }

        public DeathDamageSapper(ObjectDatabase db): base(1633969217, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
        }

        public DeathDamageSapper(int newId, ObjectDatabase db): base(1633969217, newId, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
        }

        public DeathDamageSapper(string newRawcode, ObjectDatabase db): base(1633969217, newRawcode, db)
        {
            _dataFullDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageRadius, SetDataFullDamageRadius));
            _dataFullDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataFullDamageAmount, SetDataFullDamageAmount));
            _dataPartialDamageRadius = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageRadius, SetDataPartialDamageRadius));
            _dataPartialDamageAmount = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataPartialDamageAmount, SetDataPartialDamageAmount));
        }

        public ObjectProperty<float> DataFullDamageRadius => _dataFullDamageRadius.Value;
        public ObjectProperty<float> DataFullDamageAmount => _dataFullDamageAmount.Value;
        public ObjectProperty<float> DataPartialDamageRadius => _dataPartialDamageRadius.Value;
        public ObjectProperty<float> DataPartialDamageAmount => _dataPartialDamageAmount.Value;
        private float GetDataFullDamageRadius(int level)
        {
            return _modifications[828466244, level].ValueAsFloat;
        }

        private void SetDataFullDamageRadius(int level, float value)
        {
            _modifications[828466244, level] = new LevelObjectDataModification{Id = 828466244, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private float GetDataFullDamageAmount(int level)
        {
            return _modifications[845243460, level].ValueAsFloat;
        }

        private void SetDataFullDamageAmount(int level, float value)
        {
            _modifications[845243460, level] = new LevelObjectDataModification{Id = 845243460, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private float GetDataPartialDamageRadius(int level)
        {
            return _modifications[862020676, level].ValueAsFloat;
        }

        private void SetDataPartialDamageRadius(int level, float value)
        {
            _modifications[862020676, level] = new LevelObjectDataModification{Id = 862020676, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 3};
        }

        private float GetDataPartialDamageAmount(int level)
        {
            return _modifications[878797892, level].ValueAsFloat;
        }

        private void SetDataPartialDamageAmount(int level, float value)
        {
            _modifications[878797892, level] = new LevelObjectDataModification{Id = 878797892, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 4};
        }
    }
}